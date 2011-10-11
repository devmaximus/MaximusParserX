using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MaximusParserX.UI.Controls
{
 
    public class MyTreeView : TreeView
    {
        private IContainer components;

        public MyTreeView()
        {
            this.components = null;
            this.InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-XP systems
            if (!NativeInterop.IsWinXP)
                SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint))
            {
                Message m = new Message();
                m.HWnd = Handle;
                m.Msg = NativeInterop.WM_PRINTCLIENT;
                m.WParam = e.Graphics.GetHdc();
                m.LParam = (IntPtr)NativeInterop.PRF_CLIENT;
                DefWndProc(ref m);
                e.Graphics.ReleaseHdc(m.WParam);
            }
            base.OnPaint(e);
        }

        public MyTreeView(IContainer container)
        {
            this.components = null;
            container.Add(this);
            this.InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-XP systems
            if (!NativeInterop.IsWinXP)
                SetStyle(ControlStyles.UserPaint, true);
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
            this.components = new Container();
            base.SuspendLayout();
            base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            base.FullRowSelect = true;
            base.Location = new Point(0, 0);
            base.Name = "TreeView";
            base.Size = new Size(0x1ac, 0x84);
            base.TabIndex = 0;
            base.Name = "MyTreeView";
            base.Size = new Size(0x1ac, 0x84);
            base.ResumeLayout(false);
        }
    }
}
