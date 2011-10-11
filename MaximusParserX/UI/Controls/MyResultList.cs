using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaximusParserX.Frame;

namespace MaximusParserX.UI.Controls
{
    public partial class MyResultList : UserControl
    {
        public MyResultList()
        {
            InitializeComponent();
        }

        public UIManager UIManager { get; set; }

        public void Init()
        {
            //cboSeverityLevel.SelectedText = UIManager.EventManager.AddResultSeverityLevel.ToString();
        }

        public void AddResult(Result result)
        {
            if (result.Message.HasValue())
            {
                AddItemToListView(result);

                foreach (var tSubResult in result.SubResultList)
                {
                    if (tSubResult.Message.HasValue())
                    {
                        AddResult(tSubResult);
                    }
                }
            }
        }

        public void AddItemToListView(Result result)
        {
            var tlvItem = this.lvResults.Items.Add(DateTime.Now.ToString());

            tlvItem.SubItems.Add(result.Severity.ToString());
            tlvItem.SubItems.Add(result.Message);

            if (result.Severity < ResultSeverityType.Warning)
            {
                tlvItem.BackColor = Color.White;
            }
            else if (result.Severity == ResultSeverityType.Warning)
            {
                tlvItem.BackColor = Color.LightYellow;
                tlvItem.ForeColor = Color.Brown;
            }
            else if (result.Severity >= ResultSeverityType.Error)
            {
                tlvItem.BackColor = Color.Red;
                tlvItem.ForeColor = Color.White;
            }

            tlvItem.EnsureVisible();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lvResults.Items.Clear();
        }

        private void cboSeverityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!cboSeverityLevel.Text.IsEmpty())
            //    UIManager.EventManager.AddResultSeverityLevel = cboSeverityLevel.Text.ToEnum<ResultSeverityType>();
        }

        private void cboSeverityLevel_Click(object sender, EventArgs e)
        {
            //if (!cboSeverityLevel.Text.IsEmpty())
            //    UIManager.EventManager.AddResultSeverityLevel = cboSeverityLevel.Text.ToEnum<ResultSeverityType>();
        }
    }

}

