using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTail
{
    public class EncodingInfoItem
    {
        private EncodingInfo m_encoding;

        public EncodingInfoItem(EncodingInfo encoding)
        {
            m_encoding = encoding;
        }

        public override string ToString()
        {
            return m_encoding.DisplayName;
        }

        public Encoding GetEncoding()
        {
            return m_encoding.GetEncoding();
        }
    }
}
