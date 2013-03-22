namespace HunBeiQuery
{
    partial class UCCondition
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStationName = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate.Location = new System.Drawing.Point(80, 3);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(130, 21);
            this.dtpBeginDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始时间:";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBeginTime.Location = new System.Drawing.Point(80, 30);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.ShowUpDown = true;
            this.dtpBeginTime.Size = new System.Drawing.Size(130, 21);
            this.dtpBeginTime.TabIndex = 2;
            this.dtpBeginTime.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(80, 85);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(130, 21);
            this.dtpEndTime.TabIndex = 5;
            this.dtpEndTime.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束时间:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(80, 58);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 21);
            this.dtpEndDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "站名:";
            // 
            // cmbStationName
            // 
            this.cmbStationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStationName.FormattingEnabled = true;
            this.cmbStationName.Location = new System.Drawing.Point(80, 132);
            this.cmbStationName.Name = "cmbStationName";
            this.cmbStationName.Size = new System.Drawing.Size(130, 20);
            this.cmbStationName.TabIndex = 7;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(135, 169);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // UCCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.cmbStationName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpBeginTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpBeginDate);
            this.Name = "UCCondition";
            this.Size = new System.Drawing.Size(218, 204);
            this.Load += new System.EventHandler(this.UCCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStationName;
        private System.Windows.Forms.Button btnQuery;
    }
}
