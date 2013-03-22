using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DTLib
{
    /// <summary>
    /// 
    /// </summary>
    public class ServerLogger
    {
        /// <summary>
        /// 
        /// </summary>
        static public RichTextBox TextBox
        {
            get { return _textBox; }
            set { _textBox = value; }
        } static private RichTextBox _textBox;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        static public void Log(string s)
        {
            if (ServerLogger.TextBox != null)
            {
                ServerLogger.TextBox.AppendText(s);
            }
        }
    }
}
