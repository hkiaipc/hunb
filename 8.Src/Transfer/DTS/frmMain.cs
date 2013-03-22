using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTLib;
using DTCommon;

namespace DTS
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Server Server
        {
            get { return _server; }
        } Server _server = new Server();
        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            //ServerLogger.TextBox = this.richTextBox1;
            DTRequest.RequestEvent += new RequestEventHandler(DTRequest_RequestEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DTRequest_RequestEvent(object sender, RequestEventArgs e)
        {
            RequestResult r = this.Server.ProcessRequest(e.ClientID, e.RequestNameEnum, e.State);
            e.RequestResult = r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuStart_Click(object sender, EventArgs e)
        {
            _server.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "数据传输服务器";
            this.Server.TextBox = this.richTextBox1;
            _server.Start();
            this.toolStripStatusLabel1.Text = "服务已启动, 等待客户请求...";
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

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            string s = string.Format("{0}\r\n\r\n版本: {1}", "数据传输服务端",
                Application.ProductVersion);

            MessageBox.Show(this, s, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
