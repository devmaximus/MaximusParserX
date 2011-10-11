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
    public partial class frmSniffList : DockContent
    {
        public frmSniffList()
        {
            InitializeComponent();
        }

        private delegate ListViewItem DelegateInternalAddOrUpdateItem(string key, string name, string typename, string createddatetime, string filesize, string packettotalcount, string clientbuildname, string filename);
        private delegate void DelegateLoadListViewItems(IList<ListViewItem> items);

        public UIManager UIManager { get; set; }
        private readonly object LockAddOrUpdateItem = new object();
        private readonly object LockInitialize = new object();
        private System.Threading.Thread thread;
        private bool stopthread = false;

        public void UpdateViewer()
        {
            if (UIManager == null || UIManager.Settings == null) return;
            lock (LockInitialize)
            {
                if (thread != null && thread.IsAlive)
                {
                    stopthread = true;
                    while (thread.IsAlive)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    stopthread = false;
                }
                lstView.Items.Clear();
                thread = new System.Threading.Thread(new System.Threading.ThreadStart(UpdateViewerInternal));
                thread.Start();
            }
        }

        private void UpdateViewerInternal()
        {
            var sniffDirectoryList = UIManager.Settings.SniffDirectoryList.Where(t => t.Include == true).ToList();
          
            foreach (var sniffDirectory in sniffDirectoryList)
            {
                if (stopthread) return;

                UIManager.DelegateManager.AddInfo("Loading Sniffs from Directory {0}.", sniffDirectory.Directory);

                var items = new List<ListViewItem>();

                foreach (var fileInfo in sniffDirectory.GetFiles())
                {
                    if (stopthread) return;

                    var sniffCache = this.UIManager.Settings.SniffCacheList.Where(t => t.FileName.ToLower() == fileInfo.FullName.ToLower()).FirstOrDefault();

                    if (sniffCache == null)
                    {
                        var reader = MaximusParserX.Reading.Readers.ReaderLoader.GetReaderForFile(UIManager.DelegateManager, fileInfo.FullName);

                        if (reader != null)
                        {
                            sniffCache = new Local.SniffCache();
                            sniffCache.PacketTotalCount = reader.PacketTotalCount.ToString();
                            sniffCache.ClientBuildName = reader.ClientBuildName;
                            sniffCache.FileName = reader.FileName.ToLower();
                            sniffCache.FileSize = reader.FileSize;
                            sniffCache.Name = reader.Name;
                            sniffCache.TypeName = reader.TypeName;
                            sniffCache.CreatedDateTime = reader.CreatedDateTime.ToString("MM/dd/yyyy");
                            this.UIManager.Settings.SniffCacheList.Add(sniffCache);

                            reader.Close();
                        }
                        else
                        {
                            UIManager.DelegateManager.AddError("Failed to Load File: {0}", fileInfo.Name);
                        }
                    }

                    if (sniffCache != null) items.Add(InternalAddOrUpdateItem(Guid.NewGuid().ToString(), sniffCache.Name, sniffCache.TypeName, sniffCache.CreatedDateTime, sniffCache.FileSize, sniffCache.PacketTotalCount, sniffCache.ClientBuildName, sniffCache.FileName));
                }

                LoadListViewItems(items);

                UIManager.DelegateManager.AddInfo("Completed Loading Sniffs from Directory {0}.", sniffDirectory.Directory);
            }

            
        }

        public void LoadListViewItems(IList<ListViewItem> items)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateLoadListViewItems(LoadListViewItems), items);
            }
            else
            {
                lstView.BeginUpdate();
                lstView.Items.AddRange(items.ToArray());
                lstView.EndUpdate();
            }
        }

        public ListViewItem InternalAddOrUpdateItem(string key, string name, string typename, string createddatetime, string filesize, string packettotalcount, string clientbuildname, string filename)
        {

            var listviewitem = new ListViewItem(name);
            listviewitem.SubItems.Add(typename);
            listviewitem.SubItems.Add(createddatetime);
            listviewitem.SubItems.Add(filesize);
            listviewitem.SubItems.Add(packettotalcount);
            listviewitem.SubItems.Add(clientbuildname);

            listviewitem.Tag = filename;

            return listviewitem;

        }

        public void AddOrUpdateItem(MaximusParserX.Reading.Readers.ReaderBase readerbase)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateManager.DelegateAddOrUpdateItem<MaximusParserX.Reading.Readers.ReaderBase>(AddOrUpdateItem), readerbase);
            }
            else
            {
                var key = readerbase.ReaderGUID.ToString();

                ListViewItem listviewitem = null;

                if (!lstView.Items.ContainsKey(key))
                {
                    listviewitem = lstView.Items.Add(key, readerbase.Name, 0);
                    listviewitem.SubItems.Add(readerbase.TypeName);
                    listviewitem.SubItems.Add(readerbase.CreatedDateTime.ToString("MM/dd/yyyy"));
                    listviewitem.SubItems.Add(readerbase.FileSize);
                    listviewitem.SubItems.Add(readerbase.PacketTotalCount.ToString());
                    listviewitem.SubItems.Add(readerbase.ClientBuildName);
                }
                else
                {
                    listviewitem = lstView.Items[key];
                    listviewitem.SubItems[0].Text = readerbase.Name;
                    listviewitem.SubItems[1].Text = readerbase.TypeName;
                    listviewitem.SubItems[2].Text = readerbase.CreatedDateTime.ToString("MM/dd/yyyy");
                    listviewitem.SubItems[3].Text = readerbase.FileSize;
                    listviewitem.SubItems[4].Text = readerbase.PacketTotalCount.ToString();
                    listviewitem.SubItems[5].Text = readerbase.ClientBuildName;
                }

                listviewitem.Tag = readerbase.FileName;

                readerbase.Close();
            }
        }

        private void frmSniffList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                base.Hide();
            }
        }

        private void lstView_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedSniff();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenSelectedSniff();
        }

        public void OpenSelectedSniff()
        {

        }

        private void mnuDump_Click(object sender, EventArgs e)
        {

        }
    }
}
