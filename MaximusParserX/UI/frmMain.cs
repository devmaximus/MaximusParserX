using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaximusParserX;

namespace MaximusParserX.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private DelegateManager delegateManager;
        private UIManager uiManager;
        private Local.Settings settings;
        private SortedList<Guid, StatusStripProgress> statusStripProgressList;

        public void UpdateProgress(Guid guid, int total, int current, string info)
        {
            if (InvokeRequired)
            {
                this.Invoke(new DelegateManager.DelegateUpdateProgress(UpdateProgress), guid, total, current, info);
            }
            else
            {
                StatusStripProgress statusStripProgress = null;

                if (statusStripProgressList.ContainsKey(guid))
                { statusStripProgress = statusStripProgressList[guid]; }
                else
                {
                    statusStripProgress = new StatusStripProgress()
                    {
                        StatusStripProgressGuid = guid,
                        ToolStripLabel = new ToolStripLabel(info),
                        ToolStripProgressBar = new ToolStripProgressBar()
                    };

                    MainStatusStrip.Items.Add(statusStripProgress.ToolStripLabel);
                    MainStatusStrip.Items.Add(statusStripProgress.ToolStripProgressBar);

                    statusStripProgressList.Add(guid, statusStripProgress);
                }

                if ((current == 0 && total == 0) || current == total)
                {
                    MainStatusStrip.Items.Remove(statusStripProgress.ToolStripLabel);
                    MainStatusStrip.Items.Remove(statusStripProgress.ToolStripProgressBar);
                    statusStripProgress.ToolStripLabel.Dispose();
                    statusStripProgress.ToolStripProgressBar.Dispose();
                    statusStripProgressList.Remove(guid);
                }
                else
                {
                    statusStripProgress.ToolStripProgressBar.Maximum = total;
                    statusStripProgress.ToolStripProgressBar.Value = current % total;
                    statusStripProgress.ToolStripLabel.Text = info;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.statusStripProgressList = new SortedList<Guid, StatusStripProgress>();
            this.delegateManager = new DelegateManager();
            this.uiManager = new UIManager(MainDockPanel, this.delegateManager);
            this.uiManager.InitUI();
            this.settings = Local.Settings.Load(this.delegateManager);
            this.uiManager.InitSettings(this.settings);

        }

        private void btnShowHideSniffList_Click(object sender, EventArgs e)
        {
            btnShowHideSniffList.Text = this.uiManager.ShowHideSniffListPanel();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        private void btnShowHideSniffDirectoryList_Click(object sender, EventArgs e)
        {
            btnShowHideSniffDirectoryList.Text = this.uiManager.ShowHideSniffDirectoryListPanel();
        }

        private void btnDumpOpcodes_Click(object sender, EventArgs e)
        {
            //Conversions.CustomDumpOpcode.DumpOpcodes();
        }

        private void btnFindOpcodes_Click(object sender, EventArgs e)
        {
           // Conversions.CustomFindOpcode.FindOpcodes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.settings.Save(this.delegateManager);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //var list = System.IO.File.ReadAllText("clientBuildOpcodeList.xml").FromXML<List<MaximusParserX.Conversions.ClientBuildOpcodes>>();

            //foreach (var build in list)
            //{

            //   MaximusParserX.Parsing.Version.Utilities.GetOpcodeName(uint opcode, byte direction, build.ClientBuild)
                

            //        string.Format("MaximusParserX.Parsing.Version.{0}.Definitions.{1}_DEF", clientbuild, opcodename)
            //}
        }

    }
}
