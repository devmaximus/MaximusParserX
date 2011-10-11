using MaximusParserX.UI.Controls;

namespace MaximusParserX.UI
{
    partial class frmResultList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myResultList1 = new MaximusParserX.UI.Controls.MyResultList();
            this.SuspendLayout();
            // 
            // myResultList1
            // 
            this.myResultList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myResultList1.Location = new System.Drawing.Point(0, 0);
            this.myResultList1.Name = "myResultList1";
            this.myResultList1.Size = new System.Drawing.Size(1107, 165);
            this.myResultList1.TabIndex = 0;
            this.myResultList1.UIManager = null;
            // 
            // frmResultList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 165);
            this.Controls.Add(this.myResultList1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "frmResultList";
            this.Text = "Result Log";
            this.ResumeLayout(false);

        }

        #endregion

        private MaximusParserX.UI.Controls.MyResultList myResultList1;
    }
}