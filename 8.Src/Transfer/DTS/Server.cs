using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Diagnostics;
using DTCommon ;

namespace DTS
{
    /// <summary>
    /// 
    /// </summary>
    public class Server
    {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void Log(string s)
        {
            if (this.TextBox != null)
            {
                if (this.TextBox.Text.Length > 100 * 100)
                {
                    this.TextBox.Clear();
                }
                string t = DateTime.Now + " " + s + Environment.NewLine;
                this.TextBox.AppendText(t);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RichTextBox TextBox
        {
            get { return _textBox; }
            set { _textBox = value; }
        } private RichTextBox _textBox;

        /// <summary>
        /// 
        /// </summary>
        public bool IsStarted
        {
            get { return _isStarted; }
        } private bool _isStarted;
            
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            if (!_isStarted)
            {
                string filename = "Config\\Server.xml";
                RemotingConfiguration.Configure(filename, false);
                _isStarted = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="requestNameEnum"></param>
        /// <param name="state"></param>
        public RequestResult ProcessRequest(string clientID, RequestNameEnum requestNameEnum, object state)
        {
            RequestResult r = null;

            switch (requestNameEnum)
            {
                case RequestNameEnum.GetDeviceID :
                    r = ProcessGetDeviceIDRequest(clientID, state);
                    break;

                case RequestNameEnum.GetDeviceLastDataDateTime :
                    r = ProcessGetDeviceLastDataDateTime(clientID, state);
                    break;

                case RequestNameEnum .SetWLData :
                    r = ProcessSetWLData(clientID, state);
                    break;
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private RequestResult ProcessSetWLData(string clientID, object state)
        {
            object[] objs = (object[])state;

            Debug.Assert(objs.Length == 2);


            int deviceID = Convert.ToInt32(objs[0]);
            DataTable tbl = (DataTable)objs[1];

            DateTime first = DateTime.MinValue;
            DateTime last = DateTime.MinValue;
            int count = tbl.Rows.Count;

            if (tbl.Rows.Count > 0)
            {
                first = Convert.ToDateTime(tbl.Rows[0]["DT"]);
                last = Convert.ToDateTime(tbl.Rows[count - 1]["DT"]);
            }

            foreach (DataRow row in tbl.Rows)
            {
                DB.InsertWL2(deviceID, row);
            }

            LogSetWLData(deviceID, count, first, last);

            RequestResult r = new RequestResult();
            r.ResultEnum = RequestResultEnum.OK;
            
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="firstDT"></param>
        /// <param name="lastDT"></param>
        private void LogSetWLData(int deviceID, int count, DateTime firstDT, DateTime lastDT)
        {
            if (count > 0)
            {
                string s = string.Format(
                    "收到设备 '{0}' 数据 '{1}' 条, 从 '{2}' 到 '{3}'",
                    deviceID, count, firstDT, lastDT);
                Log(s);
            }
            else
            {
                string s= string.Format ("收到设备 '{0}' 数据 '{1}' 条",
                    deviceID , count );
                Log(s);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private RequestResult ProcessGetDeviceLastDataDateTime(string clientID, object state)
        {
            int deviceID = Convert.ToInt32(state);
            DateTime dt = this.DB.GetDeviceDataLastDateTime(deviceID);

            RequestResult r = new RequestResult();
            r.ResultEnum = RequestResultEnum.OK;
            r.Result = dt;

            LogGetDeviceLastDataDateTime(deviceID, dt);
            return r;
        }

        private void LogGetDeviceLastDataDateTime(int deviceID, DateTime dt)
        {
            string s = string.Format("获取设备 '{0}' 最后数据时间 '{1}'", deviceID, dt);
            Log(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private RequestResult ProcessGetDeviceIDRequest(string clientID, object state)
        {
            object[] arr = (object[])state;
            Debug.Assert(arr.Length == 3);

            string g = arr[0].ToString();
            string s = arr[1].ToString();
            string d = arr[2].ToString();

            RequestResult r = new RequestResult();
            int deviceID = DB.GetDeviceID(g, s, d);
            if (deviceID > 0)
            {
                r.ResultEnum = RequestResultEnum.OK;
                r.Result = deviceID;
            }
            else
            {
                r.ResultEnum = RequestResultEnum.Error;
            }
            LogGetDeviceIDRequest(g, s, d, deviceID);
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <param name="id"></param>
        private void LogGetDeviceIDRequest(string g, string s, string d, int id)
        {
            string tmp = string.Format("获取 '{0}.{1}.{2}' 设备编号 '{3}'",
                g, s, d, id);
            Log(tmp);
        }
    }
}
