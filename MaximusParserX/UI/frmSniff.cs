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


namespace MaximusParserX.UI
{
    public partial class frmSniff : DockContent
    {
        public frmSniff()
        {
            InitializeComponent();
        }

        public UIManager UIManager { get; set; }

        private void btnBeginParsing_Click(object sender, EventArgs e)
        {

        }

    }
}
