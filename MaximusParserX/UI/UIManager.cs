
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace MaximusParserX.UI
{
    public class UIManager
    {
        public DelegateManager DelegateManager { get; private set; }
        public DockPanel DockPanel { get; private set; }
        public frmResultList ResultListPanel { get; private set; }
        public frmSniffList SniffListPanel = new frmSniffList();
        public Local.Settings Settings { get; private set; }
        public frmSniffDirectoryList SniffDirectoryListPanel = new frmSniffDirectoryList();
        public frmDump DumpPanel = new frmDump();

        public UIManager(DockPanel dockPanel, DelegateManager delegateManager)
        {
            this.DockPanel = dockPanel;
            this.DelegateManager = delegateManager;
        }

        public void InitSettings(Local.Settings settings)
        {
            this.Settings = settings;
            this.SniffDirectoryListPanel.UpdateViewer();
            this.SniffListPanel.UpdateViewer();
            
        }

        public System.Windows.Forms.Form ParentForm
        {
            get { return (System.Windows.Forms.Form)this.DockPanel.Parent; }
        }

        public string ShowHideResultListPanel()
        {
            if (this.ResultListPanel.Visible)
            {
                this.ResultListPanel.Hide();
            }
            else
            {
                this.ResultListPanel.Show();
            }

            return this.ResultListPanel.Visible ? "Hide Results Pane" : "Show Results Pane";
        }

        public void InitUI()
        {
            this.InitSniffListPanel();
            this.InitSniffDirectoryListPanel();
            this.InitResultListPanel();
            this.SniffListPanel.DockTo(this.SniffDirectoryListPanel.Pane, System.Windows.Forms.DockStyle.Fill, -1);
            InitDumpPanel();
        }

        public void InitResultListPanel()
        {
            if (this.ResultListPanel == null)
            {
                this.ResultListPanel = new frmResultList();
                this.ResultListPanel.MdiParent = this.ParentForm;
                this.ResultListPanel.Show(this.DockPanel);
                this.ResultListPanel.DockState = DockState.DockBottom;
                this.ResultListPanel.VisibleState = DockState.DockBottom;
                this.ResultListPanel.UIManager = this;
                this.ResultListPanel.Init();
                this.DelegateManager.AddResult += new DelegateManager.DelegateAddResult(this.ResultListPanel.AddResult);
            }
        }

        public void InitSniffListPanel()
        {
            this.SniffListPanel.MdiParent = this.ParentForm;
            this.SniffListPanel.Show(this.DockPanel);
            this.SniffListPanel.UIManager = this;
            this.SniffListPanel.DockState = DockState.DockLeft;
            this.SniffListPanel.VisibleState = DockState.DockLeft;
        }


        public void InitDumpPanel()
        {
            this.DumpPanel.MdiParent = this.ParentForm;
            this.DumpPanel.Show(this.DockPanel);
            this.DumpPanel.UIManager = this;
            this.DumpPanel.DockState = DockState.Document;
            this.DumpPanel.VisibleState = DockState.Document;
        }

        public string ShowHideSniffListPanel()
        {
            if (this.SniffListPanel.Visible)
            {
                this.SniffListPanel.Hide();
            }
            else
            {
                this.SniffListPanel.Show();
            }

            return SniffListPanelText;
        }

        public string SniffListPanelText { get { return this.SniffListPanel.Visible ? "Hide Sniffs Pane" : "Show Sniffs Pane"; } }

        public void InitSniffDirectoryListPanel()
        {
            this.SniffDirectoryListPanel.MdiParent = this.ParentForm;
            this.SniffDirectoryListPanel.Show(this.DockPanel);
            this.SniffDirectoryListPanel.UIManager = this;
            this.SniffDirectoryListPanel.DockState = DockState.DockLeft;
            this.SniffDirectoryListPanel.VisibleState = DockState.DockLeft;
        }

        public string ShowHideSniffDirectoryListPanel()
        {
            if (this.SniffDirectoryListPanel.Visible)
            {
                this.SniffDirectoryListPanel.Hide();
            }
            else
            {
                this.SniffDirectoryListPanel.Show();
            }

            return SniffDirectoryListPanelText;
        }

        public string SniffDirectoryListPanelText { get { return this.SniffDirectoryListPanel.Visible ? "Hide Sniff Directories Pane" : "Show Sniff Directories Pane"; } }

        ~UIManager()
        {
            this.SniffListPanel.Close();
            this.SniffListPanel.Dispose();
            this.SniffListPanel = null;

            this.DelegateManager.AddResult -= new DelegateManager.DelegateAddResult(this.ResultListPanel.AddResult);
            this.ResultListPanel.Close();
            this.ResultListPanel.Dispose();
            this.ResultListPanel = null;

            this.DockPanel.Dispose();
            this.DockPanel = null;
            this.DelegateManager = null;
        }
    }
}
