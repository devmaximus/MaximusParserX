using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MaximusParserX.UI.Controls
{
    public class MyTextBox : TextBox
    {
        private IContainer components;

        public MyTextBox()
        {
            this.components = null;
            this.InitializeComponent();
        }

        public MyTextBox(IContainer container)
        {
            this.components = null;
            container.Add(this);
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();

            base.Enter += new EventHandler(this.MyTextBox_Enter);
            base.ResumeLayout(false);
        }

        private void MyTextBox_Enter(object sender, EventArgs e)
        {
            base.SelectAll();
        }

    }
}

