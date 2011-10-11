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
    public partial class frmBrowseDirectory : Form
    {
        public frmBrowseDirectory()
        {
            InitializeComponent();
        }

        private string Directory = null;

        public string View(string directory)
        {
            this.Directory = directory;

            var result = this.ShowDialog();

            if (result == DialogResult.OK)
                return this.Directory;
            else
                return null;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(this.txtDirectory.Text))
                this.folderBrowserDialog1.SelectedPath = this.txtDirectory.Text;
            else
                this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtDirectory.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            this.Directory = txtDirectory.Text;
        }

    }
}
