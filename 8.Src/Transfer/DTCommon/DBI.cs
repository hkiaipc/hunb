using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using Xdgk.Common ;

namespace DTCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class DB 
    {
        private DBIBase DBI
        {
            get{
                if(_dbiBase ==null )
                {
                    string connection= System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                    _dbiBase = new DBIBase(connection);
                }
                return _dbiBase;
            }
        } private DBIBase _dbiBase ;


        /// <summary>
        /// 
        /// </summary>
        public DB()
        {
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="clientID"></param>
        ///// <returns></returns>
        //public DataTable GetStationDataTable(string clientID)
        //{
        //    string s = string.Format(
        //        "select * from tbl where ClientID = '{0}'", 
        //        clientID);
        //    return DBI.ExecuteDataTable(s);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="lastDateTime"></param>
        /// <returns></returns>
        public DataTable GetWLDataTable(int deviceID, DateTime lastDateTime)
        {
            // 处理小数秒造成的重复记录的问题
            //
            lastDateTime += TimeSpan.FromSeconds(1d);

            string s = string.Format(
                "select top 30 * from tblMeasureSluiceData where deviceID = '{0}' and DT > '{1}' order by DT ",
                deviceID, lastDateTime);
            Console.WriteLine(s);
            return DBI.ExecuteDataTable(s);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="stationName"></param>
        ///// <param name="lastDateTime"></param>
        ///// <returns></returns>
        //public DataTable GetWLDataTable(string stationName, string deviceName, DateTime lastDateTime)
        //{
        //    string s = string.Format(
        //        "select top 30 * from vDataXD202 where stationName = '{0}' and DeviceName = '{1}' and DT > '{2}' order by DT ",
        //        stationName, deviceName, lastDateTime);
        //    return DBI.ExecuteDataTable(s);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public  DateTime GetDeviceDataLastDateTime(int deviceID)
        {
            DateTime dt = DateTime.Parse ("2000-1-1");
                string s = string.Format(
                "select max(DT) from tblMeasureSluiceData where DeviceID = '{0}'",
                deviceID);

            object obj = DBI.ExecuteScalar (s);
            if (obj != null && obj != DBNull.Value)
            {
                dt = Convert.ToDateTime(obj);
            }

            return dt;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="station"></param>
        ///// <returns></returns>
        //public  DateTime GetStationLastDateTime(string station, string device)
        //{
        //    DateTime dt = DateTime.Parse ("2000-1-1");
        //        string s = string.Format(
        //        "select max(DT) from vDataXD202 where StationName = '{0}' and DeviceName = '{1}'",
        //        station, device);

        //    object obj = DBI.ExecuteScalar (s);
        //    if (obj != null && obj != DBNull.Value)
        //    {
        //        dt = Convert.ToDateTime(obj);
        //    }

//        //    return dt;
//        //}

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="dt"></param>
//        /// <param name="height"></param>
//        public void InsertWL(int localDeviceID, DataRow row)
//        {
//            DateTime dt = Convert.ToDateTime(row["DT"]);
//            float gateHeight = Convert.ToSingle(row["Gateheight"]);
//            float beforeDepth = Convert.ToSingle(row["BeforeDepth"]);
//            float beforeLevel = Convert.ToSingle(row["BeforeLevel"]);
//            float afterDepth = Convert.ToSingle(row["AfterDepth"]);
//            float afterLevel = Convert.ToSingle(row["AfterLevel"]);
//            float flowRate = Convert.ToSingle(row["FlowRate"]);
//            float todayFlow = Convert.ToSingle(row["TodayFlow"]);
//            float monthFlow = Convert.ToSingle(row["MonthFlow"]);
//            float totalFlow = Convert.ToSingle(row["TotalFlow"]);

//            string sql = string.Format(
//"INSERT INTO tblDataXD202(DeviceID, DT, GateHeight, BeforeDepth, BeforeLevel, AfterDepth, AfterLevel, FlowRate, TodayFlow, MonthFlow, TotalFlow) " +
//" VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
//localDeviceID, dt, gateHeight, beforeDepth, beforeLevel, afterDepth, afterLevel,
//flowRate, todayFlow, monthFlow, totalFlow);
//            this.DBI.ExecuteScalar(sql);
//        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetGroupDataTable()
        {
            string sql = "select * from tblGroup where deleted = 0";
            DataTable tbl = this.DBI.ExecuteDataTable(sql);
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public DataTable GetStationDataTable(int groupID)
        {
            string s = string.Format(
                "select * from tblStation where groupID = {0} and deleted = 0",
                groupID);
            return this.DBI.ExecuteDataTable(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public DataTable GetDeviceDataTable(int stationID)
        {
            string s = string.Format(
                "select * from tblDevice where StationID = {0} and deleted = 0",
                stationID);
            return this.DBI.ExecuteDataTable(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g">group name</param>
        /// <param name="s">station name</param>
        /// <param name="d">device name</param>
        /// <returns></returns>
        public int GetDeviceID(string g, string s, string d)
        {
            int groupID = GetGroupID(g);
            int stationID = GetStationID(groupID, s);
            int deviceID = GetDeviceID(stationID, d);
            return deviceID;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationID"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private int GetDeviceID(int stationID, string deviceName)
        {
            string s = string.Format(
                "select deviceid from tbldevice where stationid = {0} and name = '{1}'",
                stationID, deviceName);

            object obj = DBI.ExecuteScalar(s);
            if (obj == null || obj == DBNull.Value)
            {
                CreateDevice(stationID, deviceName);
                return GetDeviceID(stationID, deviceName);
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationID"></param>
        /// <param name="deviceName"></param>
        private void CreateDevice(int stationID, string deviceName)
        {
            string s = string.Format(
                "insert into tblDevice (stationid, name, deleted, address) values ({0}, '{1}', 0, 1)",
                stationID, deviceName);
            DBI.ExecuteScalar(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private int GetStationID(int groupID, string stationName)
        {
            string s = string.Format(
                "select stationid from tblstation where groupid = {0} and name = '{1}'",
                groupID, stationName);

            object obj = this.DBI.ExecuteScalar(s);
            if (obj == null || obj == DBNull.Value)
            {
                CreateStation(groupID, stationName);
                return GetStationID(groupID, stationName);
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        private void CreateStation(int groupID, string stationName)
        {
            string s = string.Format(
                "insert into tblStation(groupID, name, deleted) values({0}, '{1}', 0)",
                groupID, stationName);
            DBI.ExecuteScalar(s);

        }

        /// <summary>
        /// get group id, if not exist create new group
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private int GetGroupID(string g)
        {
            string s = string.Format(
                "select groupid from tblgroup where groupname = '{0}'",
                g);

            object r = this.DBI.ExecuteScalar(s);
            if (r == null || r == DBNull.Value)
            {
                CreateGroup(g);
                return GetGroupID(g);
            }
            else
            {
                return Convert.ToInt32(r);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        private void CreateGroup(string g)
        {
            string s = string.Format(
                "insert into tblGroup(groupName) values('{0}')", g);
            this.DBI.ExecuteScalar(s);
        }

        public void InsertWL2(int deviceID, DataRow row)
        {
            DateTime dt = Convert.ToDateTime(row["DT"]);
            float gateHeight = Convert.ToSingle(row["height"]);
            float beforeWL= Convert.ToSingle(row["BeforeWL"]);
            float behindWL = Convert.ToSingle(row["BehindWL"]);
            float instantFlux = Convert.ToSingle(row["InstantFlux"]);
            float remainedAmount = Convert.ToSingle(row["RemainedAmount"]);
            float usedAmount = Convert.ToSingle(row["UsedAmount"]);

            string sql = string.Format(
"INSERT INTO tblMeasureSluiceData(DeviceID, DT, Height, BeforeWL, BehindWL, InstantFlux, RemainedAmount, UsedAmount) " +
" VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
deviceID, dt, gateHeight, beforeWL, behindWL, instantFlux,
remainedAmount, usedAmount);
            this.DBI.ExecuteScalar(sql);
          
        }
    }
}
