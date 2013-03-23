using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HunBeiQuery
{
    public partial class frmMeasureDitchData : Form
    {
        HunBeiDBDataContext _db = new HunBeiDBDataContext();
        

        /// <summary>
        /// 
        /// </summary>
        public frmMeasureDitchData()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            SetColumn();
            ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
            _db.Log = Console.Out;
        }

        void ucCondition1_QueryEvent(object sender, EventArgs e)
        {
            this.btnQuery_Click(null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="dataPropertyName"></param>
        void AddColumn(string headerText, string dataPropertyName)
        {
            DataGridViewColumn c = new DataGridViewTextBoxColumn();
            c.HeaderText = headerText;
            c.DataPropertyName = dataPropertyName;
            this.dataGridView1.Columns.Add(c);
        }

        /// <summary>
        /// 
        /// </summary>
        void SetColumn()
        {
            this.dataGridView1.Columns.Clear();
            AddColumn("分中心", "GroupName");
            AddColumn("站名", "StationName");
            AddColumn("时间", "DT");
            AddColumn ("闸高", "Height");
            AddColumn ("闸前水位", "BeforeWL");
            AddColumn ("闸后水位", "BehindWL");
            AddColumn ("瞬时流量", "InstantFlux");
            AddColumn ("剩余水量", "RemainedAmount");
        }

        /// <summary>
        ///
        /// </summary>
        DateTime Begin
        {
            get
            {
                //return DateTime.Parse("2001-1-1");
                return this.ucCondition1.Begin;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object GetQuery()
        {
            int selectedStationID = ucCondition1 .SelectedStationID ;

            var q = from p in _db.vMeasureSluiceData
                    where p.DT > Begin && p.DT < this.ucCondition1.End
                        && (selectedStationID > 0 ? 
                        p.StationID == selectedStationID : true)
                    select p;

            return q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ucCondition1.SelectedStationID);
            var q = GetQuery();
            this.dataGridView1.DataSource = q;
        }

        private void frmMeasureDitchData_Load(object sender, EventArgs e)
        {
            DGUI.SetUI(this.dataGridView1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
