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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ucCondition1 = new HunBeiQuery.UCCondition();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(236, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(428, 367);
            this.zedGraphControl1.TabIndex = 1;
            // 
            // ucCondition1
            // 
            this.ucCondition1.IsAddAll = true;
            this.ucCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucCondition1.Name = "ucCondition1";
            this.ucCondition1.Size = new System.Drawing.Size(218, 204);
            this.ucCondition1.TabIndex = 0;
            // 
            // frmCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 391);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.ucCondition1);
            this.Name = "frmCurve";
            this.Text = "历史曲线";
            this.Load += new System.EventHandler(this.frmCurve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCCondition ucCondition1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}