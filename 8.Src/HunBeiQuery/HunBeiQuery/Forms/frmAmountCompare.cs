using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace HunBeiQuery
{
    public partial class frmAmountCompare : Form
    {
        public frmAmountCompare()
        {
            InitializeComponent();
            this.ucConditionDT1.QueryEvent += new EventHandler(ucConditionDT1_QueryEvent);
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucConditionDT1_QueryEvent(object sender, EventArgs e)
        {
            using (new CP.Windows.Forms.WaitCursor())
            {
                Query();
            }
        }

        private void Query()
        {
            DateTime b = ucConditionDT1.Begin;
            DateTime e = ucConditionDT1.End;
            GroupAmountList gas = CreateGroupAmountList(b, e);
            int c = gas.Count;
            Draw(gas);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Draw(GroupAmountList gas)
        {

            ColorPicker cp = new ColorPicker();
            GraphPane gp = this.zedGraphControl1.GraphPane;
            gp.CurveList.Clear();
            gp.Title.Text = "水量对比";
            gp.XAxis.Title.Text = "年份";
            gp.YAxis.Title.Text = "水量(m3)";

            //gp.AddBar("lable", null, null, Color.Red);
            gp.XAxis.Type = AxisType.Text;

            foreach (GroupAmount ga in gas)
            {
                List<double> values = new List<double>();
                foreach (YearAmount ya in ga.YearAmountList)
                {
                    values.Add(ya.GetSum());
                }
                gp.AddBar(ga.GroupName, null, values.ToArray(), cp.GetColor());
            }
            gp.XAxis.Scale.TextLabels = GetXAxisTextLabels(gas);

            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gas"></param>
        /// <returns></returns>
        private string[] GetXAxisTextLabels(GroupAmountList gas)
        {
            List<string> list = new List<string>();
            GroupAmount ga  =gas[0];
            foreach (YearAmount ya in ga.YearAmountList)
            {
                list.Add(ya.Year.ToString() + "年");
            }
            return list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b">begin year</param>
        /// <param name="e">end year(include end)</param>
        /// <returns></returns>
        private GroupAmountList CreateGroupAmountList(DateTime b, DateTime e)
        {
            List<int> yearList = new List<int>();

            for (int i = b.Year; i <= e.Year; i++)
            {
                yearList.Add(i);
            }

            HunBeiDBDataContext db = DBFactory.Create();

            GroupAmountList gas = new GroupAmountList();

            // 1. get groups
            //
            // 2. get group's stations
            // 
            // 3. calc station amount
            //
            // 4. result 
            //
            var groups = from q in db.tblGroup
                         select q;

            foreach (tblGroup gp in groups)
            {
                GroupAmount ga = new GroupAmount(gp.GroupName);
                gas.Add(ga);

                foreach (int year in yearList)
                {
                    YearAmount ya = new YearAmount(year);
                    ga.YearAmountList.Add(ya);

                    b = new DateTime(year, 1, 1);
                    e = new DateTime(year + 1, 1, 1);

                    foreach (tblStation st in gp.tblStation)
                    {
                        if (st.tblDevice.Count > 0)
                        {
                            tblDevice device = st.tblDevice[0];
                            var measureSluiceDatas = from q in db.tblMeasureSluiceData
                                                     where q.DeviceID == device.DeviceID &&
                                                     q.DT >= b && q.DT < e
                                                     select q;

                            if (measureSluiceDatas.Count() > 0)
                            {
                                DateTime dtMin = (DateTime)measureSluiceDatas.Min(c => c.DT);
                                DateTime dtMax = (DateTime)measureSluiceDatas.Max(c => c.DT);

                                float first = (float)measureSluiceDatas.Single(c => c.DT == dtMin).RemainedAmount;
                                float last = (float)measureSluiceDatas.Single(c => c.DT == dtMax).RemainedAmount;

                                double used = Math.Abs(last - first);
                                //ga.StationAmountList.Add(new StationAmount(st.Name, used));
                                ya.StationAmountList.Add(new StationAmount(st.Name, used));
                            }
                        }
                    }
                }
            }

            return gas;

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GroupAmount
    {
        public GroupAmount(string groupName)
        {
            this._groupName = groupName;
        }

        #region GroupName
        /// <summary>
        /// 
        /// </summary>
        public string GroupName
        {
            get
            {
                if (_groupName == null)
                {
                    _groupName = string.Empty;
                }
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        } private string _groupName;
        #endregion //GroupName

        #region YearAmountList
        /// <summary>
        /// 
        /// </summary>
        public YearAmountList YearAmountList
        {
            get
            {
                if (_yearAmountList == null)
                {
                    _yearAmountList = new YearAmountList();
                }
                return _yearAmountList;
            }
            set
            {
                _yearAmountList = value;
            }
        } private YearAmountList _yearAmountList;
        #endregion //YearAmountList

    }

    public class YearAmount
    {
        public YearAmount(int year)
        {
            this._year = year;
        }

        #region Year
        /// <summary>
        /// 
        /// </summary>
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        } private int _year;
        #endregion //Year

        #region StationAmountList
        /// <summary>
        /// 
        /// </summary>
        public StationAmountCollection StationAmountList
        {
            get
            {
                if (_stationAmountList == null)
                {
                    _stationAmountList = new StationAmountCollection();
                }
                return _stationAmountList;
            }
            set
            {
                _stationAmountList = value;
            }
        } private StationAmountCollection _stationAmountList;
        #endregion //StationAmountList

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetSum()
        {
            if (StationAmountList.Count == 0)
            {
                return 0d;
            }
            else
            {
                double sum = StationAmountList.Sum(c => c.UsedAmount);
                return sum;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class YearAmountList : List<YearAmount>
    {
    }

    public class GroupAmountList : List<GroupAmount>
    {

    }

    public class StationAmountCollection : List<StationAmount>
    {

    }
    public class StationAmount
    {
        public StationAmount(string stationName, double usedAmount)
        {
            this._stationName = stationName;
            this._usedAmount = usedAmount;
        }

        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
            get
            {
                if (_stationName == null)
                {
                    _stationName = string.Empty;
                }
                return _stationName;
            }
            set
            {
                _stationName = value;
            }
        } private string _stationName;
        #endregion //StationName

        #region UsedAmount
        /// <summary>
        /// 
        /// </summary>
        public double UsedAmount
        {
            get
            {
                return _usedAmount;
            }
            set
            {
                _usedAmount = value;
            }
        } private double _usedAmount;
        #endregion //UsedAmount

    }

    public class ColorPicker
    {

        int _idx = 0;
        public Color GetColor ()
        {
            if (_idx >= colors.Length)
            {
                _idx = 0;
            }
            return colors[_idx++];
        }

        Color[] colors = new Color[] {
Color.Red,
Color.Green, 
Color.Blue,
Color.Yellow ,
Color.Black ,
Color.Beige ,
Color.Brown ,
Color.Chocolate ,
Color.Cyan ,
Color.DarkCyan ,
        };
    }
}
