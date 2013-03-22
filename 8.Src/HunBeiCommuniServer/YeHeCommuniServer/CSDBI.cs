using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Xdgk.Communi.Interface;
using Xdgk.Common;
using Xdgk.Communi;

namespace CommuniServer
{

    /// <summary>
    /// 
    /// </summary>
    public class CSDBI : DBIBase
    {
        /// <summary>
        /// 
        /// </summary>
        static public CSDBI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CSDBI(Config.Default.ConnectionString);
                }
                return _instance;
            }
        } static private CSDBI _instance;

        #region CSDBI
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        public CSDBI(string connString) : base(connString )
        {
        }
        #endregion //CSDBI

        //#region Default
        ///// <summary>
        ///// 
        ///// </summary>
        //static public CSDBI Default
        //{
        //    get
        //    {
        //        //if (s_default == null)
        //        //    throw new InvalidOperationException("DBI not init");
        //        return s_default;
        //    }
        //} static private CSDBI s_default;
        //#endregion //Default

        //#region Init
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="connString"></param>
        //static public void Init(string connString)
        //{
        //    if (s_default != null)
        //        throw new InvalidOperationException("DBI already inited");
        //    s_default = new CSDBI(connString);
        //}
        //#endregion //Init

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteStatinDeviceDataView()
        {
            string sql = "SELECT * FROM vStationDevice";
            return this.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteStationDataTable()
        {
            string sql = "select * from tblStation";
            return this.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteDeviceDataTable()
        {
            string sql = "select * from tblDevice";
            return this.ExecuteDataTable(sql);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public object AddStation(Station station)
        {
            string sql = "insert into tblStation(Name, Remark, CommuniTypeContent) values(@n, @r, @c); select @@Identity";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = null;
            p = new SqlParameter("n", station.Name);
            cmd.Parameters.Add(p);

            p = new SqlParameter("r", station.Description);
            cmd.Parameters.Add(p);

            p = new SqlParameter("c", station.CommuniType.ToXml());
            cmd.Parameters.Add(p);
            object obj = this.ExecuteScalar(cmd);
            int id = Convert.ToInt32(obj);
            //station.ID = GetIdentity();
            station.ID = id;
            return obj;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public object DeleteStaion(int stationID)
        {
            string sql = "update tblStation Set Deleted = 1 where StationID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = null;
            p = new SqlParameter("id", stationID);
            cmd.Parameters.Add(p);
            return this.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        public object EditStation(string oldName, Station station)
        {
            string sql = "select stationID from tblStation where Name = @n";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = new SqlParameter("n", oldName);
            cmd.Parameters.Add(p);
            object id = this.ExecuteScalar(cmd);
            int stationId = (int)id;

            return EditStation(stationId, station);
        }

        public void UpdateStationGroup(int stationID, int groupID)
        {
            string sql = string.Format (
                "update tblStation set groupID = {1} where stationid = {0}" ,
                stationID, 
                groupID);
            this.ExecuteScalar(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public object EditStation(int stationID, Station station)
        {
            string sql = "update tblStation Set Name = @n, Remark = @r, CommuniTypeContent = @c Where StationID = @id";

            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = null;

            p = new SqlParameter("n", station.Name);
            cmd.Parameters.Add(p);

            p = new SqlParameter("r", station.Description);
            cmd.Parameters.Add(p);

            p = new SqlParameter("c", station.CommuniType.ToXml());
            cmd.Parameters.Add(p);

            p = new SqlParameter("id", stationID);
            cmd.Parameters.Add(p);
            return this.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public object AddDevice(int StationID, Device device)
        {
            string sql = "insert into tblDevice(StationID, Name, DeviceType, Address, Remark) values(@stationID, @n, @deviceType, @address, @r)";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p =null ;
            p = new SqlParameter("stationID", StationID);
            cmd.Parameters.Add(p);

            p = new SqlParameter("n", device.Name);
            cmd.Parameters.Add(p);

            p = new SqlParameter("deviceType", device.DeviceType);
            cmd.Parameters.Add(p);

            p = new SqlParameter("address", device.Address);
            cmd.Parameters.Add(p);

            p = new SqlParameter("r", device.Remark);
            cmd.Parameters.Add(p);

            object obj = this.ExecuteScalar(cmd);

            device.ID = this.GetIdentity();
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public object EditDevice(Device device)
        {
            string sql = "update tblDevice set Name = @n, DeviceType = @deviceType, Address = @address, Remark = @r where DeviceID = @deviceID";

            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p =null ;
            p = new SqlParameter("deviceID", device.ID);
            cmd.Parameters.Add(p);

            p = new SqlParameter("n", device.Name);
            cmd.Parameters.Add(p);

            p = new SqlParameter("deviceType", device.DeviceType);
            cmd.Parameters.Add(p);

            p = new SqlParameter("address", device.Address);
            cmd.Parameters.Add(p);

            p = new SqlParameter("r", device.Remark);
            cmd.Parameters.Add(p);

            return this.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceID"></param>
        internal object DeleteDevice(int deviceID)
        {
            string sql = "update tblDevice Set Deleted = 1 where DeviceID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter p = null;
            p = new SqlParameter("id", deviceID);
            cmd.Parameters.Add(p);
            return this.ExecuteScalar(cmd);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetGroupDataTable()
        {
            string s = string.Format(
                "select * from tblGroup where deleted = 0");
            return this.ExecuteDataTable(s);
        }

        public void AddGroup(string name)
        {
            string s = string.Format(
                "insert into tblGroup(GroupName) values('{0}')", name );
            this.ExecuteScalar(s);
        }

        public void UpdateGroup(int id, string newName)
        {
            string s = string.Format(
                "update tblGroup set GroupName = '{1}' where groupID = {0}", id, newName );
            this.ExecuteScalar(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGroup(int id)
        {
            string s = string.Format(
                "update tblGroup set deleted = 1 where groupID = {0}", id);
            this.ExecuteScalar(s);
        }

        internal int GetGroupIDByStationID(int p)
        {
            string s = string.Format(
                "select groupID from tblstation where stationID = {0}",
                p);

            return (int)this.ExecuteScalar(s);
        }
    }
}
