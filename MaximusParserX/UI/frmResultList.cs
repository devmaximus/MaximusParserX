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
    public partial class frmResultList : DockContent
    {
        public frmResultList()
        {
            InitializeComponent();
        }

        public UIManager UIManager { get; set; }

        public void Init()
        {
            myResultList1.UIManager = this.UIManager;
            myResultList1.Init();
        }
 
        private void frmResultList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                base.Hide();
            }
        }

        public void AddResult(Result result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateManager.DelegateAddResult(AddResult), result);
            }
            else
            {
                this.myResultList1.AddResult(result);
            }
        }
    }
}
