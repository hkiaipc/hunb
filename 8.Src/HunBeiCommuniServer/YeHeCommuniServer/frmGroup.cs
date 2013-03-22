using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommuniServer
{
    public partial class frmGroup : NUnit.UiKit.SettingsDialogBase 
    {
        public frmGroup()
        {
            InitializeComponent();
            BindGroup();
        }

        private void frmGroup_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void BindGroup()
        {
            DataTable tbl = YeHeCommuniServerApp.Default.CSDBI.GetGroupDataTable();
            this.listBox1.DisplayMember = "GroupName";
            this.listBox1.ValueMember = "GroupID";
            this.listBox1.DataSource = tbl;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGroupItem f = new frmGroupItem();
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string n = f.GroupName;
                YeHeCommuniServerApp.Default.CSDBI.AddGroup(n);
                BindGroup();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int id = (int)this.listBox1.SelectedValue;
                string oldname = this.listBox1.Text;

                frmGroupItem f = new frmGroupItem();
                f.GroupName = oldname;
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string n = f.GroupName;
                    YeHeCommuniServerApp.Default.CSDBI.UpdateGroup(id, n);

                    BindGroup();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int id = (int)this.listBox1.SelectedValue;
                string s = "确定要删除吗?";
                DialogResult dr =  NUnit.UiKit.UserMessage.Ask(s);
                if (dr == DialogResult.Yes)
                {
                    YeHeCommuniServerApp.Default.CSDBI.DeleteGroup(id);
                    BindGroup();
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
