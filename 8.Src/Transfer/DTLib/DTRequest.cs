using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xdgk.Common;
//using System.Windows.Forms;
using DTCommon ;

namespace DTLib
{

    /// <summary>
    /// 
    /// </summary>
    public class DTRequest : MarshalByRefObject
    {
        /*
        #region StationNames
        /// <summary>
        /// 
        /// </summary>
        public string[] StationNames
        {
            get
            {
                return _stationNames;
            }
            set
            {
                _stationNames = value;
            }
        } private string[] _stationNames;
        #endregion //StationNames

        #region LastDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastDateTime
        {
            get
            {
                return _lastDateTime;
            }
            set
            {
                _lastDateTime = value;
            }
        } private DateTime _lastDateTime;
        #endregion //LastDateTime

        #region Remark
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                if (_remark == null)
                {
                    _remark = string.Empty;
                }
                return _remark;
            }
            set
            {
                _remark = value;
            }
        } private string _remark;
        #endregion //Remark

        DBIBase DBI
        {
            get
            {
                if (_dbi == null)
                {
                    _dbi = new DBIBase(ServerInfo.ConnectionString);
                }
                return _dbi;
            }
        } private DBIBase _dbi;

        /// <summary>
        /// 
        /// </summary>
        public string Execute()
        {
            Console.WriteLine("exe");
            ServerLogger.Log("Execute()" + Environment.NewLine);

            FileStream fs = File.Open("1", FileMode.Open);
            int b = fs.ReadByte();
            fs.Close();
            //return b.ToString();
            DataTable tbl = DBI.ExecuteDataTable("select * from jobs");

            string s = null;
            foreach (DataRow row in tbl.Rows)
            {
                foreach (object c in row.ItemArray)
                {
                    s += (c.ToString() + " : " + "");
                }
                s += (Environment.NewLine);
            }
            return s;

            //return DateTime.Now.ToString();
        }
         */

        static public event RequestEventHandler RequestEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsReady()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="requestName"></param>
        /// <param name="state"></param>
        public RequestResult Request(string clientID, RequestNameEnum requestName,
            object state)
        {
            if (RequestEvent != null)
            {
                RequestEventArgs e = new RequestEventArgs();
                e.ClientID = clientID;
                e.RequestNameEnum = requestName;
                e.State = state;

                RequestEvent(this, e);

                return e.RequestResult;
            }
            return null;
        }
    }
}
