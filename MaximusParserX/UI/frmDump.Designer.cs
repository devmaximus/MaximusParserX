namespace MaximusParserX.UI
{
    partial class frmDump
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDump));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBeginDump = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.dumpHexLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpTextLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunMangosTableCodeGenerator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBeginDump,
            this.toolStripSeparator1,
            this.mnuSettings,
            this.toolStripSeparator2,
            this.btnRunMangosTableCodeGenerator,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1285, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBeginDump
            // 
            this.btnBeginDump.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBeginDump.Image = ((System.Drawing.Image)(resources.GetObject("btnBeginDump.Image")));
            this.btnBeginDump.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBeginDump.Name = "btnBeginDump";
            this.btnBeginDump.Size = new System.Drawing.Size(77, 22);
            this.btnBeginDump.Text = "Begin Dump";
            this.btnBeginDump.Click += new System.EventHandler(this.btnBeginDump_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuSettings
            // 
            this.mnuSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dumpHexLogToolStripMenuItem,
            this.dumpTextLogToolStripMenuItem,
            this.dumpSQLToolStripMenuItem});
            this.mnuSettings.Image = ((System.Drawing.Image)(resources.GetObject("mnuSettings.Image")));
            this.mnuSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(62, 22);
            this.mnuSettings.Text = "Settings";
            // 
            // dumpHexLogToolStripMenuItem
            // 
            this.dumpHexLogToolStripMenuItem.CheckOnClick = true;
            this.dumpHexLogToolStripMenuItem.Name = "dumpHexLogToolStripMenuItem";
            this.dumpHexLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dumpHexLogToolStripMenuItem.Text = "Dump Hex Log";
            // 
            // dumpTextLogToolStripMenuItem
            // 
            this.dumpTextLogToolStripMenuItem.CheckOnClick = true;
            this.dumpTextLogToolStripMenuItem.Name = "dumpTextLogToolStripMenuItem";
            this.dumpTextLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dumpTextLogToolStripMenuItem.Text = "Dump Text Log";
            // 
            // dumpSQLToolStripMenuItem
            // 
            this.dumpSQLToolStripMenuItem.CheckOnClick = true;
            this.dumpSQLToolStripMenuItem.Name = "dumpSQLToolStripMenuItem";
            this.dumpSQLToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dumpSQLToolStripMenuItem.Text = "Dump SQL";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRunMangosTableCodeGenerator
            // 
            this.btnRunMangosTableCodeGenerator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRunMangosTableCodeGenerator.Image = ((System.Drawing.Image)(resources.GetObject("btnRunMangosTableCodeGenerator.Image")));
            this.btnRunMangosTableCodeGenerator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunMangosTableCodeGenerator.Name = "btnRunMangosTableCodeGenerator";
            this.btnRunMangosTableCodeGenerator.Size = new System.Drawing.Size(184, 22);
            this.btnRunMangosTableCodeGenerator.Text = "RunMangosTableCodeGenerator";
            this.btnRunMangosTableCodeGenerator.Click += new System.EventHandler(this.btnRunMangosTableCodeGenerator_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // frmDump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 464);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDump";
            this.Text = "frmDump";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBeginDump;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton mnuSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dumpHexLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpTextLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnRunMangosTableCodeGenerator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}