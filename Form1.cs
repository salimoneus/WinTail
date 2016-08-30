using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WinTail
{
    public partial class Form1 : Form
    {
        private Graphics m_graphics = null;
        private bool m_bInit = false;
        private bool m_bRun = false;
        private bool m_bAutoScroll = false;
        private bool m_bOnTop = false;
        private bool m_bAutoFit = false;
        private Thread m_thread = null;
        private AutoResetEvent m_finishedEvent = new AutoResetEvent(true);
        private string m_fileName = String.Empty;
        private const string AutoEncodingString = "Auto-detect Encoding";

        public Form1()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            comboBoxEncoding.Items.Add(AutoEncodingString);
            List<EncodingInfo> infoList = Encoding.GetEncodings().ToList();
            infoList.Sort(delegate(EncodingInfo i1, EncodingInfo i2) { return i1.DisplayName.CompareTo(i2.DisplayName); });
            infoList.ForEach(item => comboBoxEncoding.Items.Add(new EncodingInfoItem(item)));
            comboBoxEncoding.SelectedItem = AutoEncodingString;
            ToggleAutoScroll();
            m_bInit = true;
        }

        private void ToggleAutoScroll()
        {
            m_bAutoScroll = !m_bAutoScroll;
            buttonAutoScroll.BackColor = m_bAutoScroll ? Color.LightGreen : SystemColors.Control;
        }

        private void ToggleOnTop()
        {
            m_bOnTop = !m_bOnTop;
            TopMost = m_bOnTop;
            buttonOnTop.BackColor = m_bOnTop ? Color.LightGreen : SystemColors.Control;
        }

        private void ToggleAutoFit()
        {
            m_bAutoFit = !m_bAutoFit;
            buttonAutoFit.BackColor = m_bAutoFit ? Color.LightGreen : SystemColors.Control;
        }

        private void ToggleButtonStop()
        {
            if (m_bRun == true)
            {
                ShutdownThread();
            }
            else if (m_fileName != String.Empty)
            {
                ReStart();
            }
        }

        private void SetTitle(string file)
        {
            Text = "WinTail - " + file;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files != null && files.Length > 0)
            {
                m_fileName = files[0];

            }
            else
            {
                m_fileName = String.Empty;
            }

            ReStart();
        }

        private void ReStart()
        {
            ShutdownThread();

            listBox1.Items.Clear();

            SetTitle(System.IO.Path.GetFileName(m_fileName));

            if (m_thread == null)
            {
                m_thread = new Thread(new ThreadStart(StartWatcher));
                m_thread.Start();
            }

            buttonStop.Text = "Stop";
            buttonStop.BackColor = Color.LightGreen;
        }

        private void AddLine(string line)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                listBox1.Items.Add(line);

                if (m_graphics == null)
                {
                    m_graphics = listBox1.CreateGraphics();
                }

                if (m_bAutoFit)
                {
                    SizeF mySize = m_graphics.MeasureString(line, listBox1.Font);
                    if (this.Width < mySize.Width)
                    {
                        this.Width = Convert.ToInt32(mySize.Width);
                    }
                }

                if (m_bAutoScroll)
                {
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            });
        }

        public void StartWatcher()
        {
            m_bRun = true;
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher(".");
            fsw.Filter = m_fileName;
            fsw.Changed += (s, e) => wh.Set();

            try
            {
                var fs = new FileStream(m_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                fs.Seek(0, SeekOrigin.End);
                Encoding encoding = null;

                this.Invoke((MethodInvoker)delegate()
                {
                    if (comboBoxEncoding.SelectedItem.ToString() == AutoEncodingString)
                    {
                        encoding = TextFileEncodingDetector.DetectTextFileEncoding2(m_fileName);
                    }
                    else
                    {
                        EncodingInfoItem infoItem = comboBoxEncoding.SelectedItem as EncodingInfoItem;
                        if (infoItem != null)
                        {
                            encoding = infoItem.GetEncoding();
                        }
                    }
                });

                if (encoding == null)
                {
                    AddLine("Unable to determine file encoding, please select an encoding and retry.");
                }
                else
                {
                    using (var sr = new StreamReader(fs, encoding))
                    {
                        var s = "";
                        while (m_bRun == true)
                        {
                            s = sr.ReadLine();
                            if (s != null)
                            {
                                AddLine(s);
                            }
                            else
                            {
                                wh.WaitOne(100);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AddLine(e.Message);
            }

            wh.Close();
            m_finishedEvent.Set();
        }

        private void ShutdownThread()
        {
            if (m_bRun == true)
            {
                m_bRun = false;
                if (!m_finishedEvent.WaitOne(10000))
                {
                    m_thread.Abort();
                }
                m_thread = null;
            }

            buttonStop.Text = "Start";
            buttonStop.BackColor = SystemColors.Control;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutdownThread();
        }

        private void comboBoxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bInit)
            {
                ReStart();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonAutoScroll_Click(object sender, EventArgs e)
        {
            ToggleAutoScroll();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            ToggleButtonStop();
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == (Keys.C | Keys.Control)) && (listBox1.SelectedIndex != -1))
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
                e.Handled = true;
            }
        }

        private void buttonOnTop_Click(object sender, EventArgs e)
        {
            ToggleOnTop();
        }

        private void buttonAutoFit_Click(object sender, EventArgs e)
        {
            ToggleAutoFit();
        }
    }
}
