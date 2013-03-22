using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTLib;

namespace DTC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //ServerLogger.TextBox = this.richTextBox1;
        }

        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Client c = new Client();
            //c._textBox = this.richTextBox1;
            //c.A();
            this.Client.Execute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            string url = System.Configuration.ConfigurationSettings.AppSettings["url"];

            this.Text = this.AppTitle;
            this.timer1.Interval = this.Interval;

            // TODO:
            //
            string st = string.Format("服务器地址:{0}, 数据传输间隔: {1}秒",
                url,
                Convert.ToInt32(this.Interval / 1000)
                );
            this.toolStripStatusLabel1.Text = st;
        }

        /// <summary>
        /// 
        /// </summary>
        private int Interval
        {
            get
            {
                string s = System.Configuration.ConfigurationSettings.AppSettings ["interval"];
                int r;
                bool b = int.TryParse(s, out r);
                if (b)
                {
                    if (r < 10 * 1000)
                    {
                        r = 10 * 1000;
                    }
                }
                return r;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Client Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new Client();
                    _client._textBox = this.richTextBox1;
                }
                return _client;
            }

        } private Client _client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Client.CheckAndExecute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult dr =  NUnit.UiKit.UserMessage.Ask("确定要退出吗?");
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private string AppTitle
        {
            get
            {
                string t = System.Configuration.ConfigurationSettings.AppSettings["Title"];
                return t;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Format("{0}\r\n\r\n版本: {1}", AppTitle,
                Application.ProductVersion);

            MessageBox.Show(this, s, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
