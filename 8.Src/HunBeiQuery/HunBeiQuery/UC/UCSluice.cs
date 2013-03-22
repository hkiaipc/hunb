using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HunBeiQuery.UC
{
    public partial class UCSluice : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public UCSluice()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public vMeasureSluiceDataLast  vMeasureSluiceDataLast
        {
            get { return _vMeasureSluiceDataLast; }
            set 
            { 
                _vMeasureSluiceDataLast = value;
                UpdateSluice();
            }
        } private vMeasureSluiceDataLast _vMeasureSluiceDataLast;

        /// <summary>
        /// 
        /// </summary>
        private void UpdateSluice()
        {
            if (_vMeasureSluiceDataLast != null)
            {
                //string s = GetDataString(_vMeasureSluiceDataLast);
                //this.richTextBox1.Text = s;
                lblHeight.Text = _vMeasureSluiceDataLast.Height.ToString() + " cm";
                lblHeight2.Text = _vMeasureSluiceDataLast.Height.ToString() + " cm";
                lblName.Text = _vMeasureSluiceDataLast.StationName;
                lblBforeWL.Text = _vMeasureSluiceDataLast.BeforeWL.ToString() + " cm";
                lblBehindWL.Text = _vMeasureSluiceDataLast.BehindWL.ToString() + " cm";
                lblDT.Text = _vMeasureSluiceDataLast.DT.ToString();
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSluice_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetDataString(vMeasureSluiceDataLast data)
        {
            return string.Format(
                "{0}\r\n闸前水位: {1} cm\r\n闸后水位: {2} cm\r\n时间: {3}\r\n",
                data.StationName,
                data.BeforeWL,
                data.BehindWL,
                //data.InstantFlux,
                data.DT);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
