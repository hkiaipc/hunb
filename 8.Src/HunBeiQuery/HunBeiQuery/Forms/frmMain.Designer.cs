namespace HunBeiQuery
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.历史数据HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史曲线CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAmountCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbLine = new System.Windows.Forms.ToolStripButton();
            this.tsbCompare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInfo = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(790, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLast,
            this.toolStripMenuItem1,
            this.历史数据HToolStripMenuItem,
            this.历史曲线CToolStripMenuItem,
            this.mnuAmountCompare,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // mnuLast
            // 
            this.mnuLast.Name = "mnuLast";
            this.mnuLast.Size = new System.Drawing.Size(136, 22);
            this.mnuLast.Text = "最新数据(&L)";
            this.mnuLast.Click += new System.EventHandler(this.mnuLast_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // 历史数据HToolStripMenuItem
            // 
            this.历史数据HToolStripMenuItem.Name = "历史数据HToolStripMenuItem";
            this.历史数据HToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.历史数据HToolStripMenuItem.Text = "历史数据(&H)";
            this.历史数据HToolStripMenuItem.Click += new System.EventHandler(this.历史数据HToolStripMenuItem_Click);
            // 
            // 历史曲线CToolStripMenuItem
            // 
            this.历史曲线CToolStripMenuItem.Name = "历史曲线CToolStripMenuItem";
            this.历史曲线CToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.历史曲线CToolStripMenuItem.Text = "历史曲线(&C)";
            this.历史曲线CToolStripMenuItem.Click += new System.EventHandler(this.历史曲线CToolStripMenuItem_Click);
            // 
            // mnuAmountCompare
            // 
            this.mnuAmountCompare.Name = "mnuAmountCompare";
            this.mnuAmountCompare.Size = new System.Drawing.Size(136, 22);
            this.mnuAmountCompare.Text = "水量比较(S)";
            this.mnuAmountCompare.Click += new System.EventHandler(this.mnuAmountCompare_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLast,
            this.tsbHistory,
            this.tsbLine,
            this.tsbCompare,
            this.toolStripSeparator,
            this.tsbInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(790, 51);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbLast
            // 
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(57, 48);
            this.tsbLast.Text = "最新数据";
            this.tsbLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // tsbHistory
            // 
            this.tsbHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbHistory.Image")));
            this.tsbHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHistory.Name = "tsbHistory";
            this.tsbHistory.Size = new System.Drawing.Size(57, 48);
            this.tsbHistory.Text = "历史数据";
            this.tsbHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbHistory.Click += new System.EventHandler(this.tsbHistory_Click);
            // 
            // tsbLine
            // 
            this.tsbLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbLine.Image")));
            this.tsbLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLine.Name = "tsbLine";
            this.tsbLine.Size = new System.Drawing.Size(57, 48);
            this.tsbLine.Text = "历史曲线";
            this.tsbLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLine.Click += new System.EventHandler(this.tsbLine_Click);
            // 
            // tsbCompare
            // 
            this.tsbCompare.Image = ((System.Drawing.Image)(resources.GetObject("tsbCompare.Image")));
            this.tsbCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompare.Name = "tsbCompare";
            this.tsbCompare.Size = new System.Drawing.Size(57, 48);
            this.tsbCompare.Text = "水量比较";
            this.tsbCompare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCompare.Click += new System.EventHandler(this.tsbCompare_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 51);
            // 
            // tsbInfo
            // 
            this.tsbInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbInfo.Image")));
            this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInfo.Name = "tsbInfo";
            this.tsbInfo.Size = new System.Drawing.Size(36, 48);
            this.tsbInfo.Text = "关于";
            this.tsbInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInfo.Click += new System.EventHandler(this.tsbInfo_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(790, 372);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLast;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 历史数据HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史曲线CToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAmountCompare;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.ToolStripButton tsbLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbInfo;
        private System.Windows.Forms.ToolStripButton tsbCompare;
    }
}

