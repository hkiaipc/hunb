using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }


    public class DBFactory 
    {
        private DBFactory()
        {
        }

        static public HunBeiDBDataContext Create()
        {
            return new HunBeiDBDataContext();
        }
    }

}
