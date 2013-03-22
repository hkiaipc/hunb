using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms ;
using ZedGraph;

namespace HunBeiQuery
{
    /// <summary>
    /// 
    /// </summary>
    public class DGUI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        static public void SetUI(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            //dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Blue;
        }
    }

    public class LineHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public LineHelper( string text, Color color )
            : this( text, color, 1, SymbolType.None )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsY2Axis
        {
            get { return _isY2Axis; }
            set { _isY2Axis = value; }
        } private bool _isY2Axis;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="symbol"></param>
        public LineHelper(string text, Color color, int width, SymbolType symbol)
        {
            this.Text = text;
            this.Color = color;
            this.LineWidth = width;
            this.SymbolType = symbol;
        }

        /// <summary>
        /// 
        /// </summary>
        public int LineWidth
        {
            get { return _lineWidth; }
            set 
            {
                if (_lineWidth < 1)
                    throw new ArgumentOutOfRangeException("LineWidth", value, "must >=1");
                _lineWidth = value; 
            }
        } private int _lineWidth = 1;


        /// <summary>
        /// 
        /// </summary>
        public SymbolType SymbolType
        {
            get { return _symbolType; }
            set { _symbolType = value; }
        } private SymbolType _symbolType = SymbolType.None;


        /// <summary>
        /// 
        /// </summary>
        public Symbol Symbol
        {
            get { Symbol s= new Symbol(this.SymbolType, this.Color);
            s.Fill = new Fill(Color.White);
            return s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        } private string _text;


        /// <summary>
        /// 
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        } private Color _color;

        /// <summary>
        /// 
        /// </summary>
        public PointPairList PointList
        {
            get
            {
                if (_pointList == null)
                    _pointList = new PointPairList();
                return _pointList; 
            }
        } private PointPairList _pointList;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ZedConfig
    {

        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public ZedConfig Default
        {
            get { return s_default; }
        } static private ZedConfig s_default = new ZedConfig();
        #endregion //Default

        #region InitGraphPane
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        public void InitGraphPane(GraphPane gp, string title)
        {
            int fontsize = 14;
            gp.Legend.FontSpec.Size = fontsize;
            gp.XAxis.Title.FontSpec.Size = fontsize;
            //gp.XAxis.MajorGrid.IsVisible = true;

            gp.YAxis.Title.FontSpec.Size = fontsize;
            gp.YAxis.MajorGrid.IsVisible = true;

            gp.Title.FontSpec.Size = fontsize + 4;
            // zi ti suo fang 
            //
            gp.IsFontsScaled = false;


            //gp.Title.Text = "压力曲线";
            gp.Title.Text = title;
        }
        #endregion //InitGraphPane

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="xtitle"></param>
        /// <param name="ytitle"></param>
        public void ConfigWLLineGraphPane(GraphPane gp, string xTitle, string ytitle)
        {
            gp.XAxis.Title.Text = xTitle;
            gp.YAxis.Title.Text = ytitle;
            gp.XAxis.Type = AxisType.Date;
            gp.XAxis.Scale.Format = "d";

            gp.YAxis.Scale.Min = 0;
        }
        //#region ConfigTempLineGraphPane
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="gp"></param>
        //public void ConfigTempLineGraphPane(GraphPane gp, string xTitle, string yTitle)
        //{
        //    gp.XAxis.Title.Text = "时间"
        //    gp.XAxis.Title.Text = xTitle;
        //    gp.XAxis.Type = AxisType.Date;
        //    gp.XAxis.Scale.Format = "d";


        //    ////gp.YAxis.Title.Text = strings.Temperature;
        //    YAxisConfig tempconfig = ZedConfigValues.Default.TemperatureCurveConfig;
        //    gp.YAxis.Title.Text = yTitle;
        //    gp.YAxis.Scale.Min = tempconfig.Min;
        //    gp.YAxis.Scale.Max = tempconfig.Max;
        //    gp.YAxis.Scale.MajorStep = tempconfig.MajorStep;
        //    gp.YAxis.Scale.MinorStep = tempconfig.MinorStep;
        //    gp.YAxis.MajorGrid.IsVisible = tempconfig.MajorGridVisible;
        //    gp.YAxis.MinorGrid.IsVisible = tempconfig.MinorGridVisible;
        //    //gp.YAxis.Scale.MinorStep = 25;
        //    gp.YAxis.Scale.Format = "G";


        //    //gp.AddY2Axis("Flux");
        //    //gp.Y2Axis.Scale.Min = 0;
        //    //gp.Y2Axis.Scale.Max = 30;
        //    //gp.Y2Axis.IsVisible = true;
        //    //gp.Y2Axis.Title.IsVisible = true;
        //}
        //#endregion //ConfigTempLineGraphPane

        //#region ConfigPressLineGraphPane
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="gp"></param>
        //public void ConfigPressLineGraphPane(GraphPane gp, string xTitle, string yTitle)
        //{
        //    gp.XAxis.Title.Text = xTitle;
        //    gp.XAxis.Type = AxisType.Date;
        //    gp.XAxis.Scale.Format = "d";

        //    YAxisConfig yaxisConfig = ZedConfigValues.Default.PressCurveConfig;
        //    gp.YAxis.Title.Text = yTitle;
        //    gp.YAxis.Scale.Min = yaxisConfig.Min;
        //    gp.YAxis.Scale.Max = yaxisConfig.Max;
        //    gp.YAxis.Scale.MajorStep = yaxisConfig.MajorStep;
        //    //gp.YAxis.Scale.Format = "f2";
        //}
        //#endregion //ConfigPressLineGraphPane

        #region XAxisScaleFormat
        /// <summary>
        /// 
        /// </summary>
        public string XAxisScaleFormat
        {
            get { return _xaxisScaleFormat; }
            set { _xaxisScaleFormat = value; }
        } private string _xaxisScaleFormat = "yyyy-MM-dd";
        #endregion //XAxisScaleFormat
    }
}
