namespace WinTail
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAutoScroll = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonOnTop = new System.Windows.Forms.Button();
            this.buttonAutoFit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "                                                                     <Drag text f" +
                "ile here to begin>"});
            this.listBox1.Location = new System.Drawing.Point(0, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(746, 444);
            this.listBox1.TabIndex = 0;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEncoding.FormattingEnabled = true;
            this.comboBoxEncoding.Location = new System.Drawing.Point(0, 2);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(230, 21);
            this.comboBoxEncoding.TabIndex = 1;
            this.comboBoxEncoding.SelectedIndexChanged += new System.EventHandler(this.comboBoxEncoding_SelectedIndexChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(247, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(53, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAutoScroll
            // 
            this.buttonAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoScroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoScroll.Location = new System.Drawing.Point(665, 2);
            this.buttonAutoScroll.Name = "buttonAutoScroll";
            this.buttonAutoScroll.Size = new System.Drawing.Size(81, 23);
            this.buttonAutoScroll.TabIndex = 3;
            this.buttonAutoScroll.Text = "Auto-Scroll";
            this.buttonAutoScroll.UseVisualStyleBackColor = true;
            this.buttonAutoScroll.Click += new System.EventHandler(this.buttonAutoScroll_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(313, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(53, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonOnTop
            // 
            this.buttonOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOnTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOnTop.Location = new System.Drawing.Point(521, 2);
            this.buttonOnTop.Name = "buttonOnTop";
            this.buttonOnTop.Size = new System.Drawing.Size(66, 23);
            this.buttonOnTop.TabIndex = 5;
            this.buttonOnTop.Text = "TopMost";
            this.buttonOnTop.UseVisualStyleBackColor = true;
            this.buttonOnTop.Click += new System.EventHandler(this.buttonOnTop_Click);
            // 
            // buttonAutoFit
            // 
            this.buttonAutoFit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoFit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoFit.Location = new System.Drawing.Point(593, 2);
            this.buttonAutoFit.Name = "buttonAutoFit";
            this.buttonAutoFit.Size = new System.Drawing.Size(66, 23);
            this.buttonAutoFit.TabIndex = 6;
            this.buttonAutoFit.Text = "Auto-Fit";
            this.buttonAutoFit.UseVisualStyleBackColor = true;
            this.buttonAutoFit.Click += new System.EventHandler(this.buttonAutoFit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 473);
            this.Controls.Add(this.buttonAutoFit);
            this.Controls.Add(this.buttonOnTop);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonAutoScroll);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.comboBoxEncoding);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "WinTail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAutoScroll;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonOnTop;
        private System.Windows.Forms.Button buttonAutoFit;
    }
}

