using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Xdgk.Common;

namespace HunBeiQuery
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());

            new App().Run();
        }
    }

    public class App : AppBase
    {
        public override Form MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new frmMain();
                }
                return _mainForm;
            }
        } private frmMain _mainForm;
    }
}
