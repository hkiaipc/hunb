using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HunBeiQuery
{
    public partial class UCConditionDT : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler QueryEvent;

        /// <summary>
        /// 
        /// </summary>
        public UCConditionDT()
        {
            InitializeComponent();
        }


        public DateTime Begin
        {
            get
            {
                return new DateTime(this.dtpBeginDate.Value.Year, 1, 1);
            }
        }

        public DateTime End
        {
            get
            {
                return new DateTime(this.dtpEndDate.Value.Date.Year, 1, 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.QueryEvent != null)
            {
                QueryEvent(this, EventArgs.Empty);
            }
        }
    }
}
