using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaximusParserX.UI
{
    public partial class frmSniffDirectory : Form
    {
        public frmSniffDirectory()
        {
            InitializeComponent();
        }

        private Local.SniffDirectory sniffDirectory = null;
        private Local.Settings settings = null;

        public Local.SniffDirectory View(Local.Settings settings, Local.SniffDirectory sniffDirectory)
        {
            this.sniffDirectory = sniffDirectory.Clone();
            this.settings = settings;

            UpdateViewer();

            var result = this.ShowDialog();

            if (result == DialogResult.OK)
                return this.sniffDirectory;
            else
                return null;
        }

        public void UpdateViewer()
        {
            this.txtDirectory.Text = this.sniffDirectory.Directory;
            this.chkRecursive.Checked = this.sniffDirectory.Recursive;
            this.chkInclude.Checked = this.sniffDirectory.Include;

            lstFiles.Items.Clear();

            if (this.sniffDirectory.DirectoryExists())
            {
                foreach (var file in this.sniffDirectory.GetFiles())
                {
                    lstFiles.Items.Add(file.Name);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.sniffDirectory.DirectoryExists())
                this.folderBrowserDialog1.SelectedPath = this.sniffDirectory.Directory;
            else
                this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtDirectory.Text = this.folderBrowserDialog1.SelectedPath.ToLower();
            }
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            this.sniffDirectory.Directory = txtDirectory.Text;

            if (!this.sniffDirectory.Directory.IsEmpty())
                txtDirectory.BackColor = Color.White;
            else
                txtDirectory.BackColor = this.sniffDirectory.DirectoryExists() ? Color.White : Color.LightSalmon;

            UpdateViewer();
        }

        private void chkRecursive_Click(object sender, EventArgs e)
        {
            this.sniffDirectory.Recursive = chkRecursive.Checked;

            UpdateViewer();
        }

        private void chkInclude_Click(object sender, EventArgs e)
        {
            this.sniffDirectory.Include = chkInclude.Checked;

            UpdateViewer();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var exists = settings.SniffDirectoryList.Exists(t => t.DataObjectGUID != this.sniffDirectory.DataObjectGUID && t.Directory.StringValueOrEmpty().ToLower() == this.sniffDirectory.Directory.StringValueOrEmpty().ToLower());

            if (exists)
            {
                MessageBox.Show(string.Format("Sniff Directory with Path '{0}' already exists", this.sniffDirectory.Directory));
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateViewer();
        }

        private void txtSearchPattern_TextChanged(object sender, EventArgs e)
        {
            this.sniffDirectory.SearchPattern = txtSearchPattern.Text;

            UpdateViewer();
        }
    }
}
