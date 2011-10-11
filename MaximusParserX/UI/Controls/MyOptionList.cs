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
    public partial class MyOptionList : UserControl
    {
        public MyOptionList()
        {
            InitializeComponent();
        }

        public List<Option> OptionList { get; set; }

        public void Init(List<Option> optionList)
        {
            this.OptionList = optionList;
            UpdateViewer();
        }

        public void UpdateViewer()
        {
            lstView.Items.Clear();

            foreach (var option in this.OptionList)
            {
                var tItem = lstView.Items.Add(option.ValueName.StringValueOrEmpty());
                tItem.Tag = option;
                tItem.SubItems.Add(option.DisplayName.StringValueOrEmpty());
                tItem.SubItems.Add(option.Value.StringValueOrEmpty());
                tItem.SubItems.Add(option.ValueType.StringValueOrEmpty());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
