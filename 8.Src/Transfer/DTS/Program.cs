using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTLib;

namespace DTS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Xdgk.Common.Diagnostics.HasPreInstance())
            {
                NUnit.UiKit.UserMessage.DisplayFailure(
                    "程序已经启动");
                return;
            }
            //ServerInfo.ConnectionString = "Data Source=.;Initial Catalog=pubs;User ID=sa;Pwd=sa";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
