using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DTCommon;
using System.Runtime.Remoting;
using Xdgk.Common;
using System.Diagnostics;
//using 

namespace DTC
{
    /// <summary>
    /// 
    /// </summary>
    public class Client
    {

        #region Client
        public Client()
        {
            //object o = this.GroupCollection;
        }
        #endregion //Client

        #region Members
        /// <summary>
        /// 
        /// </summary>
        static private TimeSpan DefaultExecuteTimeSpan =  new TimeSpan(0, 30, 0);

        private T _t = new T(DefaultExecuteTimeSpan);
        public RichTextBox _textBox;
        #endregion //Members

        #region DB
        /// <summary>
        /// 
        /// </summary>
        private DB DB
        {
            get 
            {
                if (_db == null)
                {
                    _db = new DB();
                }
                return _db;
            }
        } private DB _db;
        #endregion //DB

        #region Log
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void Log(string s)
        {
            s = DateTime.Now.ToString() + " " + s + Environment.NewLine;
            if (_textBox != null)
            {
                if (_textBox.Text.Length > 100 * 100)
                {
                    _textBox.Clear();
                }
                _textBox.AppendText(s);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void Log(Exception ex)
        {
            string s = ex.Message;
            Log(s);
        }
        #endregion //Log

        #region Request
        /// <summary>
        /// 
        /// </summary>
        private DTLib.DTRequest Request
        {
            get 
            {
                if (_request == null)
                {
                    _request = CreateRequest();
                }
                return _request;
            }
        } private DTLib.DTRequest _request;
        #endregion //Request

        #region CreateRequest
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DTLib.DTRequest CreateRequest()
        {
            DTLib.DTRequest request = null;
            string url = System.Configuration.ConfigurationSettings.AppSettings["url"];
            try
            {
                object obj = Activator.GetObject(typeof(DTLib.DTRequest), url);
                request = obj as DTLib.DTRequest;
            }
            catch (RemotingException remotingEx)
            {
                string exmsg = string.Format(
                    "{0} {1}", DateTime.Now,
                    remotingEx.Message);

                Log(remotingEx.Message);
            }
            return request;
        } 
        #endregion //CreateRequest

        #region CheckAndExecute
        /// <summary>
        /// 
        /// </summary>
        internal void CheckAndExecute()
        {
            if (_t.IsTimeOut())
            {
                try
                {
                    this.Execute();
                }
                catch (RemotingException remotingEx)
                {
                    Log(remotingEx);
                }
                _t.Last = DateTime.Now;
            }
        }
        #endregion //CheckAndExecute

        #region ClientID
        /// <summary>
        /// 
        /// </summary>
        public string ClientID
        {
            get
            {
                if (_clientID == null)
                {
                    _clientID = string.Empty;
                }
                return _clientID;
            }
            set
            {
                _clientID = value;
            }
        } private string _clientID;
        #endregion //ClientID

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            if (IsRequestReady())
            {
                ExecuteRequestWLData();
            }
        }
        #endregion //Execute

        #region IsRequestReady
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsRequestReady()
        {
            try
            {
                return this.Request.IsReady();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
            return false;

        }
        #endregion //IsRequestReady

        #region ExecuteRequestWLData
        /// <summary>
        /// 
        /// </summary>
        private void ExecuteRequestWLData()
        {
            //foreach (string station in this.StationList)
            foreach (Group g in this.GroupCollection)
            {
                foreach (Station s in g.StationCollection)
                {
                    string stationName = s.Name;
                    foreach (Device d in s.DeviceCollection)
                    {
                        string deviceName = d.Name;
                        //ExecuteRequestWLData(stationName, deviceName);
                        ExecuteDeviceDataTrans(d);
                    }
                }
            }
        }
        #endregion //ExecuteRequestWLData

        #region ExecuteDeviceDataTrans
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        private void ExecuteDeviceDataTrans(Device d)
        {
            if (d.CheckRemoteID())
            {
                Debug.Assert(d.RemoteID > 0, "device.RemoteID must > 0");

                while (true)
                {
                    // 1. get remote device last data datetime
                    //
                    RequestResult r = this.Request.Request(this.ClientID,
                        RequestNameEnum.GetDeviceLastDataDateTime, d.RemoteID);
                    if (r.ResultEnum == RequestResultEnum.OK)
                    {
                        DateTime lastDT = (DateTime)r.Result;
                        LogGetLastDataDateTime(d.RemoteID, lastDT);

                        // 2. get later data then last datetime
                        //
                        DataTable tbl = this.DB.GetWLDataTable(d.ID, lastDT);

                        // 3. trans to remote
                        // 
                        object state = new object[] { d.RemoteID, tbl };
                        RequestResult r2 = this.Request.Request(this.ClientID, RequestNameEnum.SetWLData, state);
                        if (r2.ResultEnum != RequestResultEnum.OK)
                        {
                            //Log("SetWLData fail");
                            //Log(r2.ToString());
                            LogSetWLDataFail(d.RemoteID, r2.ResultEnum);
                        }
                        else
                        {
                            int count = tbl.Rows.Count;
                            DateTime b = DateTime.MinValue;
                            DateTime e = DateTime.MinValue;
                            if (count > 0)
                            {
                                b = Convert.ToDateTime(tbl.Rows[0]["DT"]);
                                e = Convert.ToDateTime(tbl.Rows[count - 1]["DT"]);
                            }
                            LogSetLWDataSuccess(d.RemoteID, count, b, e);
                        }

                        // 4. if trans count > 0 continue
                        if (tbl.Rows.Count < 30)
                            break;
                    }
                    else
                    {
                        LogGetLastDataDateTimeError(d.RemoteID);
                    }
                }
            }
        }
        #endregion //ExecuteDeviceDataTrans

        #region LogSetLWDataSuccess
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="count"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        private void LogSetLWDataSuccess(int p, int count, DateTime b, DateTime e)
        {
            string s = string.Empty;
            if (count > 0)
            {
                s = string.Format(
                    "传输设备 '{0}' 数据 '{1}' 条, 从 '{2}' 到 '{3}'", p, count,b,e);
            }
            else
            {
                s = string.Format(
                    "传输设备 '{0}' 数据 '{1}' 条", 
                    p, count);
            }
            Log(s);

        }
        #endregion //LogSetLWDataSuccess

        #region LogSetWLDataFail
        private void LogSetWLDataFail(int p, RequestResultEnum requestResultEnum)
        {
            string s = string.Format(
                "传输设备 '{0}' 数据失败 '{1}'", p, requestResultEnum);
            Log(s);
        }
        #endregion //LogSetWLDataFail

        #region LogGetLastDataDateTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lastDT"></param>
        private void LogGetLastDataDateTime(int p, DateTime lastDT)
        {
            string s = string.Format("获取设备 '{0}' 最后时间 '{1}'",
                p, lastDT);
            Log(s);

        }
        #endregion //LogGetLastDataDateTime

        #region LogGetLastDataDateTimeError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void LogGetLastDataDateTimeError(int p)
        {
            string s = string.Format(
                "获取最后时间失败, 设备ID '{0}'", 
                p);
            Log(s);
        }
        #endregion //LogGetLastDataDateTimeError

        #region ExecuteRequestWLData
        #endregion //ExecuteRequestWLData

        #region LogReceivedInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <param name="device"></param>
        /// <param name="tbl"></param>
        private void LogReceivedInfo(string station, string device, DataTable tbl)
        {
            string s =string.Format("{0} Received data: {1} {2} {3} row\r\n",
                DateTime.Now, station, device, tbl.Rows.Count);
            Log(s);
        }
        #endregion //LogReceivedInfo

        #region GetLocalDeviceID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        private int GetLocalDeviceID(string stationName, string deviceName)
        {
            foreach (Group g in this.GroupCollection)
            {
                foreach ( Station st in g.StationCollection)
                {
                    if (StringHelper.Equal(st.Name, stationName))
                    {
                        foreach (Device d in st.DeviceCollection)
                        {
                            if (StringHelper.Equal(d.Name, deviceName))
                            {
                                return d.ID;
                            }
                        }
                    }
                }
            }
            return 0;
        }
        #endregion //GetLocalDeviceID

        #region RequestWLData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <param name="stationDataLastDateTime"></param>
        /// <returns></returns>
        private RequestResult RequestWLData(string station, string device, DateTime stationDataLastDateTime)
        {
            RequestResult r = null;
            object state = new object[] { station, device, stationDataLastDateTime };
            try
            {
                r = this.Request.Request(this.ClientID, RequestNameEnum.GetWLData, state);
            }
            catch (Exception ex)
            {
                Log(ex);
            }
            return r;
        }
        #endregion //RequestWLData

        #region GroupCollection
        /// <summary>
        /// 
        /// </summary>
        private GroupCollection GroupCollection
        {
            get
            {
                if (_groupCollection == null)
                {
                    //_groupCollection = GroupFactory.CreateLocalGroupCollection(this.DB, this.Request);
                    _groupCollection = GroupFactory.CreateLocalGroupCollection(this.DB, this);
                }
                return _groupCollection;
            }
        } private GroupCollection _groupCollection;
        #endregion //GroupCollection

        #region ExecuteRequestDeviceID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        internal RequestResult ExecuteRequestDeviceID(object state)
        {
            RequestResult r = this.Request.Request(this.ClientID, 
                RequestNameEnum.GetDeviceID, state);
            return r;
        }
        #endregion //ExecuteRequestDeviceID

        #region ExecuteRequestDeviceID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        internal RequestResult ExecuteRequestDeviceID(Device d)
        {
            if (this.IsRequestReady())
            {
                object state = new object[] { 
                        d.Station.Group.Name ,
                        d.Station.Name , 
                        d.Name };
                RequestResult r = this.ExecuteRequestDeviceID(state);
                if (r.ResultEnum == RequestResultEnum.OK)
                {
                    int remoteDeviceID = (int)r.Result;
                    d.RemoteID = remoteDeviceID;
                }
                return r;
            }
            else
            {
                RequestResult r2 = new RequestResult();
                r2.ResultEnum = RequestResultEnum.Error;

                return r2;
            }
        }
        #endregion //ExecuteRequestDeviceID
    }
}
