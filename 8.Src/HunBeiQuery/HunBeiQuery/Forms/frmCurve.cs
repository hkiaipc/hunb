using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace HunBeiQuery.Forms
{
    public partial class frmCurve : Form
    {
        public frmCurve()
        {
            InitializeComponent();
            this.ucCondition1.IsAddAll = false;
            this.zedWL.IsShowPointValues = true;
            this.zedIF.IsShowPointValues = true;
            this.zedSUM.IsShowPointValues = true;

            this.zedWL.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
            this.zedIF.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
            this.zedSUM.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
            this.ucCondition1.QueryEvent += new EventHandler(ucCondition1_QueryEvent);
            GraphPane gp = this.zedWL.MasterPane[0];
            ZedConfig.Default.ConfigWLLineGraphPane(this.zedWL.MasterPane[0],
                "时间", "数据(cm)");
            gp.Chart.Fill = new Fill(Color.LightGoldenrodYellow);


            gp = this.zedIF.MasterPane[0];
            ZedConfig.Default.ConfigWLLineGraphPane(gp,
                "时间", "瞬时流量(m3/s)");
            gp.Chart.Fill = new Fill(Color.LightGoldenrodYellow);

            gp = this.zedSUM.MasterPane[0];
            ZedConfig.Default.ConfigWLLineGraphPane(gp,
                "时间", "剩余水量(m3)");
            gp.Chart.Fill = new Fill(Color.LightGoldenrodYellow);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucCondition1_QueryEvent(object sender, EventArgs e)
        {
            Query();
        }

        #region zedGraphControl1_PointValueEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pane"></param>
        /// <param name="curve"></param>
        /// <param name="iPt"></param>
        /// <returns></returns>
        string zedGraphControl1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
			// Get the PointPair that is under the mouse
			PointPair pt = curve[iPt];
            DateTime dt = XDate.XLDateToDateTime( pt.X);
            string s = string.Format("{0}\r\n{1}\r\n{2}", curve.Label.Text,
                dt, pt.Y.ToString("f2"));
            return s;
        }
        #endregion //zedGraphControl1_PointValueEvent

        //HunBeiDBDataContext _db = new HunBeiDBDataContext();
        HunBeiDBDataContext _db = DBFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            // TODO:
            int selectedStationID = ucCondition1 .SelectedStationID ;

            var q = from p in _db.vMeasureSluiceData
                    where p.DT > this.ucCondition1.Begin  && p.DT < this.ucCondition1.End
                        && (selectedStationID > 0 ? 
                        p.StationID == selectedStationID : true) 
                    select p;

            List<vMeasureSluiceData> list = q.ToList();
            LineHelper[] lines = GetLineHelpers(list);

            GraphPane mypane = this.zedWL.MasterPane[0];
            mypane.CurveList.Clear();
            foreach (LineHelper l in lines)
            {
                LineItem lineItem = mypane.AddCurve(l.Text, l.PointList, l.Color);
                lineItem.Line.Width = l.LineWidth;
                lineItem.Symbol = l.Symbol;
            }

            // title
            //
            mypane.Title.Text = this.GetCurveTitle();
            this.zedWL.AxisChange();
            this.zedWL.Invalidate(true);



            // if
            //
            LineHelper lh = GetIFLineHelper ( list );
            mypane = this.zedIF.MasterPane[0];
            mypane.CurveList.Clear();
            LineItem li = mypane.AddCurve(lh.Text, lh.PointList, lh.Color);
            li.Line.Width = lh.LineWidth;
            li.Symbol = lh.Symbol;
            mypane.Title.Text = GetIFTitle ();
            mypane.AxisChange();
            this.zedIF.Invalidate();

            // remain
            //
            lh = GetRemainedLineHelper(list);
            mypane = this.zedSUM.MasterPane[0];
            mypane.CurveList.Clear();
            li = mypane.AddCurve(lh.Text, lh.PointList, lh.Color);
            li.Line.Width = lh.LineWidth;
            li.Symbol = lh.Symbol;
            mypane.Title.Text = GetRemainedTitle();
            mypane.AxisChange();
            this.zedSUM.Invalidate();


        }

        private string GetIFTitle()
        {
            string s = string.Format("{0} ~ {1} {2} 瞬时流量曲线",
                this.ucCondition1.Begin, 
                this.ucCondition1.End ,
                this.ucCondition1.SelectedStationName);
            return s;
        }

        private string GetRemainedTitle()
        {
            string s = string.Format("{0} ~ {1} {2} 剩余水量曲线",
                this.ucCondition1.Begin, 
                this.ucCondition1.End ,
                this.ucCondition1.SelectedStationName);
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetCurveTitle()
        {
            string s = string.Format("{0} ~ {1} {2} 数据曲线",
                this.ucCondition1.Begin, 
                this.ucCondition1.End ,
                this.ucCondition1.SelectedStationName);
            return s;
        }

        private LineHelper GetIFLineHelper(List<vMeasureSluiceData> list)
        {
            LineHelper r = new LineHelper("瞬时流量", Color.Red, 1, SymbolType.Square);
            foreach ( vMeasureSluiceData item in list )
            {
                DateTime dt = (DateTime)item.DT;
                XDate xdt = XDate.DateTimeToXLDate(dt);
                float instantFlux= (float)item.InstantFlux;

                r.PointList.Add(xdt, instantFlux);
            }
            return r;
        }

        private LineHelper GetRemainedLineHelper(List<vMeasureSluiceData> list)
        {
            LineHelper r = new LineHelper("剩余水量", Color.Red, 1, SymbolType.Square);
            foreach ( vMeasureSluiceData item in list )
            {
                DateTime dt = (DateTime)item.DT;
                XDate xdt = XDate.DateTimeToXLDate(dt);
                float instantFlux = (float)item.RemainedAmount;

                r.PointList.Add(xdt, instantFlux);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private LineHelper[] GetLineHelpers(List<vMeasureSluiceData> list)
        {
            LineHelper beforeLine= new LineHelper("闸前水位", Color.Red , 
                1, SymbolType.Square);

            LineHelper behindLine= new LineHelper("闸后水位", Color.Blue,
                1, SymbolType.Square);
            LineHelper heightLine = new LineHelper("闸高", Color.Green, 1, SymbolType.Square);

            //LineHelper gp2Line = new LineHelper(strings.GP2, ColorHelper.GetLineColor(strings.GP2),
            //    ZedConfigValues.Default.GP2Config.Width, SymbolType.None);
            //LineHelper bp2Line = new LineHelper(strings.BP2, ColorHelper.GetLineColor(strings.BP2),
            //    ZedConfigValues.Default.BP2Config.Width, SymbolType.None);

            LineHelper[] lines = new LineHelper[] {beforeLine ,behindLine ,heightLine };

            //tbl.Compute(
            foreach ( vMeasureSluiceData item in list )
            {
                DateTime dt = (DateTime)item.DT;
                XDate xdt = XDate.DateTimeToXLDate(dt);
                //float beforeWL= (float)Math.Round(item.BeforeWL,2);
                float beforeWL = (float)item.BeforeWL;
                float behindWL= (float)item.BehindWL;
                float height = (float)item.Height;
                //float gp2 = (float)Math.Round(Convert.ToSingle(row["gp2"]), 2);
                //float bp2 = (float)Math.Round(Convert.ToSingle(row["bp2"]), 2);
                //pts.Add(xdt, gt1);

                beforeLine.PointList.Add(xdt, beforeWL);
                behindLine.PointList.Add(xdt, behindWL);
                heightLine.PointList.Add(xdt, height);
                //gp2Line.PointList.Add(xdt, gp2);
                //bp2Line.PointList.Add(xdt, bp2);
            }
            return lines;
        }

        private void frmCurve_Load(object sender, EventArgs e)
        {
            ZedConfig.Default.InitGraphPane(this.zedWL.MasterPane[0], "");
            ZedConfig.Default.InitGraphPane(this.zedIF.MasterPane[0], "");
            ZedConfig.Default.InitGraphPane(this.zedSUM.MasterPane[0], "");

        }

        private void ucCondition1_Load(object sender, EventArgs e)
        {

        }
    }
}
