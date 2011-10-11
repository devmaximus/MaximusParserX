using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using MaximusParserX.UI.Controls;
using MaximusParserX.Frame;
using System.Threading.Tasks;

namespace MaximusParserX.UI
{
    public partial class frmSniffDirectoryList : DockContent
    {
        public UIManager UIManager { get; set; }
        private bool skipupdate = false;
        public frmSniffDirectoryList()
        {
            InitializeComponent();
        }

        public void UpdateViewer()
        {
            skipupdate = true;

            foreach (var sniffDirectory in UIManager.Settings.SniffDirectoryList)
            {
                AddOrUpdateItem(sniffDirectory);
            }

            skipupdate = false;
        }

        public Local.SniffDirectory SelectedItem
        {
            get
            {
                if (this.lstView.SelectedItems.Count == 0) return null;
                return (Local.SniffDirectory)this.lstView.SelectedItems[0].Tag;
            }
        }

        public void AddOrUpdateItem(Local.SniffDirectory sniffDirectory)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateManager.DelegateAddOrUpdateItem<Local.SniffDirectory>(AddOrUpdateItem), sniffDirectory);
            }
            else
            {

                lstView.BeginUpdate();
                var key = sniffDirectory.Directory;

                ListViewItem listviewitem = null;

                if (!lstView.Items.ContainsKey(key))
                {
                    listviewitem = lstView.Items.Add(key, sniffDirectory.Directory, 0);
                    listviewitem.SubItems.Add(sniffDirectory.SearchPattern);
                    listviewitem.SubItems.Add(sniffDirectory.Recursive.BoolValueYesNo());
                    listviewitem.SubItems.Add(sniffDirectory.GetFiles().Count.ToString());
                }
                else
                {
                    listviewitem = lstView.Items[key];
                    listviewitem.SubItems[0].Text = sniffDirectory.Directory;
                    listviewitem.SubItems[1].Text = sniffDirectory.SearchPattern;
                    listviewitem.SubItems[2].Text = sniffDirectory.Recursive.BoolValueYesNo();
                    listviewitem.SubItems[3].Text = sniffDirectory.GetFiles().Count.ToString();

                }

                listviewitem.Checked = sniffDirectory.Include;
                listviewitem.Tag = (Guid?)sniffDirectory.DataObjectGUID;

                if (sniffDirectory.Include)
                {
                    listviewitem.BackColor = !sniffDirectory.DirectoryExists() ? Color.Salmon : Color.LightGreen;
                    listviewitem.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    listviewitem.BackColor = Color.White;
                    listviewitem.ForeColor = Color.LightGray;
                }
                lstView.EndUpdate();

            }
        }

        private void frmSniffSourceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                base.Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var t = new frmSniffDirectory();
            var newsniffDirectory = new Local.SniffDirectory(true);

            newsniffDirectory = t.View(UIManager.Settings, newsniffDirectory);

            if (newsniffDirectory != null)
            {
                UIManager.Settings.SniffDirectoryList.RemoveAll(j => j.DataObjectGUID == newsniffDirectory.DataObjectGUID);
                UIManager.Settings.SniffDirectoryList.Add(newsniffDirectory);
            }
            UIManager.SniffDirectoryListPanel.UpdateViewer();
            UIManager.SniffListPanel.UpdateViewer();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove selected?", "removing", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

                UIManager.Settings.SniffDirectoryList.RemoveAll(t => this.lstView.SelectedItems.Cast<ListViewItem>().Select(j => (j.Tag as Guid?).Value).Contains(t.DataObjectGUID));

                foreach (ListViewItem item in this.lstView.SelectedItems)
                {
                    item.Remove();
                }

                UIManager.SniffListPanel.UpdateViewer();
            }
        }

        private void lstView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var guid = (e.Item.Tag as Guid?);
            if (guid == null || skipupdate) return;

            var t = UIManager.Settings.SniffDirectoryList.Where(j => j.DataObjectGUID == guid.Value).First();
            t.Include = e.Item.Checked;


            if (t.Include)
            {
                e.Item.BackColor = !t.DirectoryExists() ? Color.Salmon : Color.LightGreen;
                e.Item.ForeColor = SystemColors.ControlText;
            }
            else
            {
                e.Item.BackColor = Color.White;
                e.Item.ForeColor = Color.LightGray;
            }

            UIManager.SniffListPanel.UpdateViewer();
        }

        private void btnAddSpecial_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var directoryInfo = new System.IO.DirectoryInfo(this.folderBrowserDialog1.SelectedPath);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var newsniffDirectory = new Local.SniffDirectory(true) { Directory = directory.FullName.ToLower(), Include = true, Recursive = false, SearchPattern = "*.sqlite" };

                    UIManager.Settings.SniffDirectoryList.RemoveAll(j => j.Directory == newsniffDirectory.Directory);
                    UIManager.Settings.SniffDirectoryList.Add(newsniffDirectory);

                }

                UIManager.SniffDirectoryListPanel.UpdateViewer();
                UIManager.SniffListPanel.UpdateViewer();

            }
        }
    }
}
