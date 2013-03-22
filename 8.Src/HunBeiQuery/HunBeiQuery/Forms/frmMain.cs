using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HunBeiQuery.Forms;

namespace HunBeiQuery
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LoadMainBG()
        {
            string s = ".\\Resource\\mainbg.jpg";
            Image img = null;
            try
            {
                img = Image.FromFile(s);
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = img;
            }
            //catch (Exception ex )
            catch
            {
                // ignore exception 
                //
            }
        }


        private void mnuLast_Click(object sender, EventArgs e)
        {
            frmLast f = GetLastForm();

            f.Show();
            f.Activate();
        }

        private frmLast GetLastForm()
        {
            // todo: temp curve
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmLast)
                {
                    return (frmLast)f;
                }
            }

            //frmGRDataQR nf = new frmGRDataQR();
            frmLast nf = new frmLast();
            nf.WindowState = FormWindowState.Maximized;
            nf.MdiParent = this;
            return nf;
        }

        private frmMeasureDitchData GetMeasureDitchDataFrom()
        {
            // todo: temp curve
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmMeasureDitchData)
                {
                    return (frmMeasureDitchData)f;
                }
            }

            //frmGRDataQR nf = new frmGRDataQR();
            frmMeasureDitchData nf = new frmMeasureDitchData();
            nf.WindowState = FormWindowState.Maximized;
            nf.MdiParent = this;
            return nf;
        }

        private frmCurve GetCurveForm()
        {
            // todo: temp curve
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmCurve)
                {
                    return (frmCurve)f;
                }
            }

            //frmGRDataQR nf = new frmGRDataQR();
            frmCurve nf = new frmCurve();
            nf.WindowState = FormWindowState.Maximized;
            nf.MdiParent = this;
            return nf;
        }
        private void 历史数据HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMeasureDitchData f = GetMeasureDitchDataFrom();
            f.Show();
            f.Activate();
        }

        private void 历史曲线CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurve f = GetCurveForm();
            f.Show();
            f.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ddd(Type t)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == t)
                {
                    f.Show();
                    f.Activate();
                    return;
                }
            }

            object obj =  t.Assembly.CreateInstance(t.FullName);
            Form nf = (Form)obj;
            nf.MdiParent = this;
            nf.Show();
            nf.Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = AppConfig.Default.Title;
            LoadMainBG();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Format(
                "{0}\r\n\r\n版本 {1}",
                AppConfig.Default.Title,
                ProductVersion );
            MessageBox.Show(this, s, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
