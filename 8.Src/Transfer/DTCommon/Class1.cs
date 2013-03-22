using System;
using System.Collections.Generic;
using System.Text;

namespace DTCommon
{
    /// <summary>
    /// 
    /// </summary>
    public enum RequestNameEnum
    {
        GetStationList,
        GetWLData,
        GetGroupList,
        GetDeviceList,
        GetDeviceID,
        GetDeviceLastDataDateTime,
        SetWLData
    }

    /// <summary>
    /// 
    /// </summary>
    public enum RequestResultEnum
    {
        OK,
        Error,
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void RequestEventHandler(object sender, RequestEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public class RequestEventArgs : EventArgs
    {
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

        #region RequestNameEnum
        /// <summary>
        /// 
        /// </summary>
        public RequestNameEnum RequestNameEnum
        {
            get
            {
                return _requestNameEnum;
            }
            set
            {
                _requestNameEnum = value;
            }
        } private RequestNameEnum _requestNameEnum;
        #endregion //RequestNameEnum

        #region State
        /// <summary>
        /// 
        /// </summary>
        public object State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        } private object _state;
        #endregion //State


        /// <summary>
        /// 
        /// </summary>
        public RequestResult RequestResult
        {
            get { return _requestResult; }
            set { _requestResult = value; }
        } private RequestResult _requestResult;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RequestResult
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestResultEnum ResultEnum
        {
            get { return _resultEnum; }
            set { _resultEnum = value; }
        } private RequestResultEnum _resultEnum;


        #region Result
        /// <summary>
        /// 
        /// </summary>
        public object Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        } private object _result;
        #endregion //Result

    }
}
