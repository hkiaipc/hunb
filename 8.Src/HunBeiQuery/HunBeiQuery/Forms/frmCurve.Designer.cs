namespace HunBeiQuery.Forms
{
    partial class frmCurve
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedWL = new ZedGraph.ZedGraphControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpWL = new System.Windows.Forms.TabPage();
            this.tpIF = new System.Windows.Forms.TabPage();
            this.zedIF = new ZedGraph.ZedGraphControl();
            this.tpSUM = new System.Windows.Forms.TabPage();
            this.zedSUM = new ZedGraph.ZedGraphControl();
            this.ucCondition1 = new HunBeiQuery.UCCondition();
            this.tabControl1.SuspendLayout();
            this.tpWL.SuspendLayout();
            this.tpIF.SuspendLayout();
            this.tpSUM.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedWL
            // 
            this.zedWL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedWL.Location = new System.Drawing.Point(3, 3);
            this.zedWL.Name = "zedWL";
            this.zedWL.ScrollGrace = 0;
            this.zedWL.ScrollMaxX = 0;
            this.zedWL.ScrollMaxY = 0;
            this.zedWL.ScrollMaxY2 = 0;
            this.zedWL.ScrollMinX = 0;
            this.zedWL.ScrollMinY = 0;
            this.zedWL.ScrollMinY2 = 0;
            this.zedWL.Size = new System.Drawing.Size(415, 271);
            this.zedWL.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpWL);
            this.tabControl1.Controls.Add(this.tpIF);
            this.tabControl1.Controls.Add(this.tpSUM);
            this.tabControl1.Location = new System.Drawing.Point(236, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(427, 300);
            this.tabControl1.TabIndex = 2;
            // 
            // tpWL
            // 
            this.tpWL.Controls.Add(this.zedWL);
            this.tpWL.Location = new System.Drawing.Point(4, 21);
            this.tpWL.Name = "tpWL";
            this.tpWL.Padding = new System.Windows.Forms.Padding(3);
            this.tpWL.Size = new System.Drawing.Size(419, 275);
            this.tpWL.TabIndex = 0;
            this.tpWL.Text = "水位";
            this.tpWL.UseVisualStyleBackColor = true;
            // 
            // tpIF
            // 
            this.tpIF.Controls.Add(this.zedIF);
            this.tpIF.Location = new System.Drawing.Point(4, 21);
            this.tpIF.Name = "tpIF";
            this.tpIF.Padding = new System.Windows.Forms.Padding(3);
            this.tpIF.Size = new System.Drawing.Size(419, 275);
            this.tpIF.TabIndex = 1;
            this.tpIF.Text = "瞬时";
            this.tpIF.UseVisualStyleBackColor = true;
            // 
            // zedIF
            // 
            this.zedIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedIF.Location = new System.Drawing.Point(3, 3);
            this.zedIF.Name = "zedIF";
            this.zedIF.ScrollGrace = 0;
            this.zedIF.ScrollMaxX = 0;
            this.zedIF.ScrollMaxY = 0;
            this.zedIF.ScrollMaxY2 = 0;
            this.zedIF.ScrollMinX = 0;
            this.zedIF.ScrollMinY = 0;
            this.zedIF.ScrollMinY2 = 0;
            this.zedIF.Size = new System.Drawing.Size(415, 271);
            this.zedIF.TabIndex = 2;
            // 
            // tpSUM
            // 
            this.tpSUM.Controls.Add(this.zedSUM);
            this.tpSUM.Location = new System.Drawing.Point(4, 21);
            this.tpSUM.Name = "tpSUM";
            this.tpSUM.Padding = new System.Windows.Forms.Padding(3);
            this.tpSUM.Size = new System.Drawing.Size(419, 275);
            this.tpSUM.TabIndex = 2;
            this.tpSUM.Text = "剩余";
            this.tpSUM.UseVisualStyleBackColor = true;
            // 
            // zedSUM
            // 
            this.zedSUM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedSUM.Location = new System.Drawing.Point(3, 3);
            this.zedSUM.Name = "zedSUM";
            this.zedSUM.ScrollGrace = 0;
            this.zedSUM.ScrollMaxX = 0;
            this.zedSUM.ScrollMaxY = 0;
            this.zedSUM.ScrollMaxY2 = 0;
            this.zedSUM.ScrollMinX = 0;
            this.zedSUM.ScrollMinY = 0;
            this.zedSUM.ScrollMinY2 = 0;
            this.zedSUM.Size = new System.Drawing.Size(415, 271);
            this.zedSUM.TabIndex = 2;
            // 
            // ucCondition1
            // 
            this.ucCondition1.IsAddAll = true;
            this.ucCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucCondition1.Name = "ucCondition1";
            this.ucCondition1.Size = new System.Drawing.Size(218, 204);
            this.ucCondition1.TabIndex = 0;
            this.ucCondition1.Load += new System.EventHandler(this.ucCondition1_Load);
            // 
            // frmCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 324);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ucCondition1);
            this.Name = "frmCurve";
            this.Text = "历史曲线";
            this.Load += new System.EventHandler(this.frmCurve_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpWL.ResumeLayout(false);
            this.tpIF.ResumeLayout(false);
            this.tpSUM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCCondition ucCondition1;
        private ZedGraph.ZedGraphControl zedWL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpWL;
        private System.Windows.Forms.TabPage tpIF;
        private System.Windows.Forms.TabPage tpSUM;
        private ZedGraph.ZedGraphControl zedIF;
        private ZedGraph.ZedGraphControl zedSUM;
    }
}