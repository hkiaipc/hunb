using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HunBeiQuery.UC;

namespace HunBeiQuery
{
    public partial class frmLast : Form
    {
        public frmLast()
        {
            InitializeComponent();
            //this.panel1.Dock = DockStyle.Fill;
            //this.panel1.AutoScroll = true;
        }

        HunBeiDBDataContext db = DBFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        private void FillGroupName()
        {
            var q = (from p in db.vMeasureSluiceDataLast
                     select new { Text = p.GroupName }).Distinct();

            this.cmbGroup.DisplayMember = "Text";
            this.cmbGroup.DataSource = q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLast_Load(object sender, EventArgs e)
        {
            this.FillGroupName();
            this.Query();
            //this.Query("DefaultGroup");
            //var q = from p in db.vMeasureSluiceDataLast 
            //            select p;

            //List<vMeasureSluiceDataLast> list = q.ToList();
            ////foreach (vMeasureSluiceDataLast item in q)
            ////for (int i = 0; i < list.Count-1 ; i++)
            //{
            //    //vMeasureSluiceDataLast item = list[i];
            //    this.ucSluice1.vMeasureSluiceDataLast = list[0];
            //    this.ucSluice2.vMeasureSluiceDataLast = list[1];
            //}
            this.timer1.Interval = 5 * 60 * 1000;
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSluice1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///
        /// </summary>
        private void Query(string groupName)
        {
            var q = from p in db.vMeasureSluiceDataLast
                    where p.GroupName == groupName
                    //orderby p.StationID
                    select p;

            List<vMeasureSluiceDataLast> list = q.ToList();
            if (list.Count > 0)
            {
                if (!IsLastBuildGroup(list))
                {
                    // build ucs
                    //
                    BuildUCs(list);

                }
                UpdateDatas(list);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private void BuildUCs(List<vMeasureSluiceDataLast> list)
        {
            this.panel1.Controls.Clear();
            int n = 0;
            foreach (vMeasureSluiceDataLast item in list)
            {
                UC.UCSluice ucsluice = new HunBeiQuery.UC.UCSluice();
                ucsluice.Tag = item.StationName;
                Add(ucsluice, n);
                n++;
            }

            this._lastBuildGroup = list[0].GroupName;

            this.panel2.AutoScrollPosition = new Point(0, 0);

            this.panel1.Width = list.Count * ZM_WIDTH;
            this.panel1.Height = ZM_HEIGHT;

            //this.panel1.Location = new Point(0, 0);
            this.panel1.Top = 0;
            //this.panel1.Left = (this.panel2.Width - this.panel1.Width) / 2;
            int left = (this.panel2.Width - this.panel1.Width) / 2;
            if (left < 0)
            {
                left = 0;
            }
            Console.WriteLine(this.panel1.Left);

            this.panel1.Location = new Point(left, 0);

        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateDatas(List<vMeasureSluiceDataLast> list)
        {
            foreach (vMeasureSluiceDataLast item in list)
            {
                UC.UCSluice ucsluice = FindUCSluice(item.StationName);
                if (ucsluice != null)
                {
                    ucsluice.vMeasureSluiceDataLast = item;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private HunBeiQuery.UC.UCSluice FindUCSluice(string stationName)
        {
            UC.UCSluice uc = null;
            foreach ( Control ctrl in  panel1.Controls )
            {
                if (ctrl is UC.UCSluice)
                {
                    UCSluice temp = ctrl as UCSluice;   
                    string tempName = temp.Tag.ToString ().Trim ();
                    if (string.Compare(stationName, tempName, true) == 0)
                    {
                        uc = temp;
                        break;
                    }
                }

            }
            return uc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="n"></param>
        private void Add(UC.UCSluice uc, int n)
        {
            Point loc = GetLocate(n);
            Size size = GetSize();
            uc.Location = loc;
            uc.Size = size;
            this.panel1.Controls.Add(uc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Size GetSize()
        {
            return new Size(ZM_WIDTH , ZM_HEIGHT );
        }

        private const int ZM_WIDTH = 314;
        //private const int ZM_WIDTH = 340;
        private const int ZM_HEIGHT = 563;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Point GetLocate(int n)
        {
            int ucWidth = ZM_WIDTH;
            return new Point(n * ucWidth, 0);
            //return new Point(0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool IsLastBuildGroup(List<vMeasureSluiceDataLast> list)
        {
            return list[0].GroupName == _lastBuildGroup;
        }
        
        /// <summary>
        /// 
        /// </summary>
        private string _lastBuildGroup;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            string g = this.cmbGroup.Text;
            this.Query(g);
            this.SetTitle(g);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        void SetTitle(string groupName)
        {
            string s = string.Format ("{0} 最新数据", groupName );
            this.label2.Text = s;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Query();
        }
    }
}
