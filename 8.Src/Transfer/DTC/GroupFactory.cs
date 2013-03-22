using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using DTLib;
using DTCommon;

namespace DTC
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupFactory
    {
        /// <summary>
        /// 
        /// </summary>
        //static private DTRequest _request;
        static private Client _client;

        /// <summary>
        /// 
        /// </summary>
        //static public GroupCollection CreateLocalGroupCollection(DB db, DTRequest dtRequest)
        static public GroupCollection CreateLocalGroupCollection(DB db, Client client)
        {
            _client = client;
            //_request = dtRequest;

            GroupCollection gs = new GroupCollection();
            DataTable tbl = db.GetGroupDataTable();
            foreach ( DataRow row in tbl.Rows){
                Group g = new Group();
                g.ID = Convert.ToInt32(row["GroupID"]);
                g.Name = row["GroupName"].ToString().Trim();
                CreateStationCollection(db, g);
                gs.Add(g);
            }

            return gs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="gs"></param>
        private static void CreateStationCollection(DB db, Group g)
        {
            DataTable tbl = db.GetStationDataTable(g.ID);
            foreach ( DataRow row in tbl.Rows )
            {
                Station s = new Station(g);
                s.ID = Convert.ToInt32 (row["StationID"]);
                s.Name = row["name"].ToString().Trim();

                CreateDeviceCollection(db, s);
                g.StationCollection.Add(s);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="s"></param>
        private static void CreateDeviceCollection(DB db, Station s)
        {
            
            DataTable tbl = db.GetDeviceDataTable ( s.ID );
            foreach (DataRow row in tbl.Rows)
            {
                Device d = new Device(s);
                d.ID = Convert.ToInt32(row["DeviceID"]);
                d.Name = row["name"].ToString().Trim();
                s.DeviceCollection.Add(d);

                //if (_request.IsReady())
                if (_client.IsRequestReady())
                {
                    object state = new object[] { 
                        d.Station.Group.Name ,
                        d.Station.Name , 
                        d.Name };
                    //RequestResult r =  _request.Request("", RequestNameEnum.GetDeviceID, state);
                    RequestResult r = _client.ExecuteRequestDeviceID(state);
                    if (r.ResultEnum == RequestResultEnum.OK)
                    {
                        int remoteDeviceID = (int)r.Result;
                        d.RemoteID = remoteDeviceID;
                    }
                }
            }
        }
    }
}
