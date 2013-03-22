using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
namespace DTC
{
    /// <summary>
    /// 
    /// </summary>
    public class Group
    {
        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        } private int _iD;
        #endregion //ID

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name


        #region StationCollection
        /// <summary>
        /// 
        /// </summary>
        public StationCollection StationCollection
        {
            get
            {
                if (_stationCollection == null)
                {
                    _stationCollection = new StationCollection();
                }
                return _stationCollection;
            }
            set
            {
                _stationCollection = value;
            }
        } private StationCollection _stationCollection;
        #endregion //StationCollection

    }
    public class GroupCollection : Collection<Group>
    {
    }


    public class Station
    {
        public Station(Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }

            this.Group = group;
        }
        #region Group
        /// <summary>
        /// 
        /// </summary>
        public Group Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        } private Group _group;
        #endregion //Group

        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        } private int _iD;
        #endregion //ID

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name
        #region DeviceCollection
        /// <summary>
        /// 
        /// </summary>
        public DeviceCollection DeviceCollection
        {
            get
            {
                if (_deviceCollection == null)
                {
                    _deviceCollection = new DeviceCollection();
                }
                return _deviceCollection;
            }
            set
            {
                _deviceCollection = value;
            }
        } private DeviceCollection _deviceCollection;
        #endregion //DeviceCollection

    }
    public class StationCollection : Collection<Station>
    {
    }



    /// <summary>
    /// 
    /// </summary>
    public class Device
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public Device(Station station)
        {
            if (station == null)
            {
                throw new ArgumentNullException("station");
            }
            this.Station = station;
        }

        #region Station
        /// <summary>
        /// 
        /// </summary>
        public Station Station
        {
            get
            {
                return _station;
            }
            set
            {
                _station = value;
            }
        } private Station _station;
        #endregion //Station

        #region RemoteID
        /// <summary>
        /// 
        /// </summary>
        public int RemoteID
        {
            get
            {
                return _remoteID;
            }
            set
            {
                _remoteID = value;
            }
        } private int _remoteID;
        #endregion //RemoteID

        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        } private int _iD;
        #endregion //ID

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

        /// <summary>
        /// is get remote device id ? 
        /// if not try get.
        /// </summary>
        /// <returns></returns>
        public bool CheckRemoteID()
        {
            if (this._remoteID > 0)
            {
                return true;
            }
            else
            {
                Client c =  ClientFactory.GetClient();
                c.ExecuteRequestDeviceID(this);
                return this._remoteID > 0;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeviceCollection : Collection<Device>
    {
    }
}
