using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommuniServer
{
    public partial class frmGroupItem : NUnit.UiKit.SettingsDialogBase
    {
        public frmGroupItem()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (GroupName.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #region GroupName
        /// <summary>
        /// 
        /// </summary>
        public string GroupName
        {
            get
            {
                return this.textBox1.Text.Trim();
            }
            set
            {
                this.textBox1.Text = value.Trim();
            }
        }
        #endregion //GroupName

    }
}
