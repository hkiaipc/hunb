using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using Xdgk.Communi;
using System.Net;
using System.Diagnostics;
//using NUnit.UiKit;

namespace CommuniServer
{
    public partial class frmStationItem : NUnit.UiKit.SettingsDialogBase 
    {

        /// <summary>
        /// 
        /// </summary>
        private frmStationItem()
        {
            InitializeComponent();
            FillDiscriminateMode();
            BindGroup();
        }


        /// <summary>
        /// 
        /// </summary>
        private void BindGroup()
        {
            DataTable tbl = YeHeCommuniServerApp.Default.CSDBI.GetGroupDataTable();
            this.cmbGroup .DisplayMember= "GroupName";
            this.cmbGroup .ValueMember = "GroupID";
            this.cmbGroup.DataSource = tbl;
        }

        private StationCollection _stations;

        /// <summary>
        /// 获取新添加或正在编辑的站点
        /// </summary>
        public Station Station
        {
            get { return _station; }
        } private Station _station;

        /// <summary>
        /// 
        /// </summary>
        public frmStationItem(StationCollection stations) 
        {
            this.InitializeComponent();
            this.FillDiscriminateMode();

            BindGroup();
            ShowSocketSettingUI();

            _stations = stations; 
            // set init value
            //
            this.cmbDiscriminateMode.SelectedValue = DiscriminateMode.ByIPAddress;
            this._adeState = ADEState.Add;
            this.rbSocket.Checked = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public frmStationItem(StationCollection stations, Station station) 
        {
            this.InitializeComponent();
            this.FillDiscriminateMode();

            BindGroup();
            this._stations = stations;
            this._station = station;

            this.ADEState = ADEState.Edit;

            this.txtStationName.Text = this._station.Name;
            this.GroupID = GetGroupID(this._station.ID);
            this.txtRemark.Text = this._station.Description;

            if (this._station.CommuniType is SocketCommuniType)
            {
                this.rbSocket.Checked = true;
                this.rbSerialPort.Checked = false;
                this.ShowSocketSettingUI();

                SocketCommuniType socketct = this._station.CommuniType as SocketCommuniType;

                if (socketct.DiscriminateMode == DiscriminateMode.ByIPAddress)
                {
                    this.txtStationIP.Text = socketct.IPAddress.ToString();
                }
                this.numLocalPort.Value = socketct.LocalPort;
                this.numRemotePort.Value = socketct.RemotePort;
                this.cmbDiscriminateMode.SelectedValue = socketct.DiscriminateMode;
            }

            if (this._station.CommuniType is SerialCommuniType)
            {
                this.rbSocket.Checked = false;
                this.rbSerialPort.Checked = true;
                this.ShowSerialPortSettingUI();

                SerialCommuniType serialct = this._station.CommuniType as SerialCommuniType;
                this.ucSerialPortSetting1.SerialCommuniType = serialct;
            }
        }

        private int GetGroupID(int p)
        {
            return YeHeCommuniServerApp.Default.CSDBI.GetGroupIDByStationID(p);
        }

        /// <summary>
        /// 
        /// </summary>
        public ADEState ADEState
        {
            get { return _adeState; }
            protected set { _adeState = value; }
        } private ADEState _adeState;

        /// <summary>
        /// 
        /// </summary>
        private void FillDiscriminateMode()
        {
            this.cmbDiscriminateMode.DataSource = StationDiscriminateMode.Items;
            this.cmbDiscriminateMode.DisplayMember = "Text";
            this.cmbDiscriminateMode.ValueMember = "DiscriminateMode";    
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckIPAddress()
        {
            IPAddress ip;
            bool b = IPAddress.TryParse(this.txtStationIP.Text, out ip);
            if (!b)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.InvalidIPAddress);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketCT"></param>
        //private void EditStation(SocketCommuniType socketCT)
        private void EditStation(CommuniType ct)
        {
            string oldName = _station.Name;
            // edit
            _station.Name = this.txtStationName.Text.Trim();
            _station.CommuniType = ct;
            _station.Description = this.txtRemark.Text;

            GetCSDBI().EditStation(oldName, _station);
            YeHeCommuniServerApp.Default.CSDBI.UpdateStationGroup(
                _station.ID, this.GroupID);
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketCT"></param>
        //private void AddStation(SocketCommuniType socketCT)
        private void AddStation(CommuniType ct)
        {
            // add
            string name = this.txtStationName.Text.Trim();
            string desc = this.txtRemark.Text.Trim();
            Station dbstation = new Station(name, ct);
            //dbstation.Ordinal = (int)this.numOrdinal.Value;
            dbstation.Description = this.txtRemark.Text;
            //dbstation.Street = this.txtStreet.Text.Trim();
            //dbstation.Create();

            _station = dbstation;


            //_station = new CZGRStation(name, 
                //socketCT, dbstation);

            //_stations.Add(_station);

            GetCSDBI().AddStation(dbstation);

            Debug.Assert(dbstation.ID > 0);
            YeHeCommuniServerApp.Default.CSDBI.UpdateStationGroup(dbstation.ID,
                this.GroupID);

            // TODO: add station to hardwaremanager
            //
        }

        private int GroupID
        {
            get
            {
                if (this.cmbGroup.Items.Count > 0 && this.cmbGroup.SelectedIndex >= 0)
                {
                    return (int)this.cmbGroup.SelectedValue;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.cmbGroup.SelectedValue = value;
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CSDBI GetCSDBI()
        {
            return YeHeCommuniServerApp.Default.CSDBI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        private bool CreateCommuniType(out CommuniType ct)
        {
            ct = null;
            bool b = false;
            if (rbSerialPort.Checked)
            {
                SerialCommuniType serialCT;
                b = CreateSerialCommuniType(out serialCT);
                ct = serialCT;
            }

            else if (rbSocket.Checked)
            {
                SocketCommuniType socketct;
                b = CreateSocketCommuniType(out socketct);
                ct = socketct;
            }
            else
            {
                throw new NotImplementedException("unknown communi type");
            }
            return b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialct"></param>
        /// <returns></returns>
        private bool CreateSerialCommuniType(out SerialCommuniType serialct)
        {
            serialct = null;
            if (ucSerialPortSetting1.VerifyPortName())
            {
                serialct = ucSerialPortSetting1.SerialCommuniType;
                return true;
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("无效的串口名称.");
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CreateSocketCommuniType( out SocketCommuniType socketct)
        {
            DiscriminateMode dm = (DiscriminateMode)this.cmbDiscriminateMode.SelectedValue;
            socketct = null;
            switch (dm)
            {
                case DiscriminateMode.ByIPAddress :
                    bool b = CheckIPAddress();
                    if (!b)
                        return false;
                    IPAddress ip = GetIPAddress();
                    socketct = new SocketCommuniType(ip);
                    break;

                case DiscriminateMode.ByLocalPort:
                    int lp = GetLocalPort();
                    socketct = new SocketCommuniType(dm, lp);
                    break; 

                case DiscriminateMode.ByRemotePort:
                    int rp = GetRemotePort();
                    socketct = new SocketCommuniType(dm, rp);
                    break;

                default:
                    throw new NotImplementedException("DiscriminateMode: " + dm);
            }

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IPAddress GetIPAddress()
        {
            return IPAddress.Parse(this.txtStationIP.Text);
        }


        /// <summary>
        /// 
        /// </summary>
        private int GetLocalPort()
        {
            return (int)this.numLocalPort.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetRemotePort()
        {
            return (int)this.numRemotePort.Value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckName()
        {
            string name = this.txtStationName.Text.Trim();
            if (name.Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.StationNameCanNotEmpty);
                return false;
            }

            bool b = _stations.ExistName(name, _station);
            if (b)
            {
                string msg = string.Format(strings.ExistStationName, this.txtStationName.Text);
                NUnit.UiKit.UserMessage.DisplayFailure(msg);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStationItem_Load(object sender, EventArgs e)
        {
            //rbSocket.Checked = true;
            //ShowSocketSettingUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dm"></param>
        private void VisiblePanel(DiscriminateMode dm)
        {
            panelByIPAddress.Visible = dm == DiscriminateMode.ByIPAddress;
            panelByLocalPort.Visible = dm == DiscriminateMode.ByLocalPort;
            panelBylRemotePort.Visible = dm == DiscriminateMode.ByRemotePort;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDiscriminateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.cmbDiscriminateMode.SelectedItem;
            StationDiscriminateMode.Item item = obj as StationDiscriminateMode.Item;
            DiscriminateMode dm = item.DiscriminateMode;
            VisiblePanel(dm);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private bool CheckName()
        //{
        //    string name = this.txtStationName.Text.Trim();
        //    if (name.Length == 0)
        //    {
        //        NUnit.UiKit.UserMessage.DisplayFailure(strings.StationNameCanNotEmpty);
        //        return false;
        //    }

        //    bool b = _stations.ExistName(name, _station);
        //    if (b)
        //    {
        //        string msg = string.Format(strings.ExistStationName, this.txtStationName.Text);
        //        NUnit.UiKit.UserMessage.DisplayFailure(msg);
        //        return false;
        //    }

        //    return true;
        //}

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!CheckName())
                return;
            //SocketCommuniType socketCT;
            //bool b = CreateSocketCommuniType(out socketCT);
            CommuniType ct;
            bool b = CreateCommuniType(out ct);

            if (!b)
                return;

            if (_station == null)
            {
                AddStation(ct);
            }
            else
            {
                EditStation(ct);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSerialPort_CheckedChanged(object sender, EventArgs e)
        {
            ShowSerialPortSettingUI();
        }

        private void ShowSerialPortSettingUI()
        {
            this.ucSerialPortSetting1.Visible = true;
            this.panel1.Visible = false;
        }

        private void rbSocket_CheckedChanged(object sender, EventArgs e)
        {
            ShowSocketSettingUI();
        }

        private void ShowSocketSettingUI()
        {
            this.ucSerialPortSetting1.Visible = false;
            this.panel1.Visible = true;
        }
    }


}
