using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.UI.Controls
{
    public static class ListViewBaseExt
    {
 

        public static T SelectedGroupDataObject<T>(this System.Windows.Forms.ListView listview)
        {
            if (listview.SelectedItems.Count > 0)
            {
                var t = ((T)listview.SelectedItems[0].Group.Tag);
                return t;
            }
            return default(T);
        }

        public static T SelectedDataObject<T>(this System.Windows.Forms.ListView listview)
        {
            if (listview.SelectedItems.Count > 0)
            {
                var t = ((T)listview.SelectedItems[0].Tag);
                return t;
            }
            return default(T);
        }

        public static void AutoResizeHeaderSize(this System.Windows.Forms.ColumnHeader columnheader)
        {
            columnheader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public static void AutoResizeColumnContent(this System.Windows.Forms.ColumnHeader columnheader)
        {
            columnheader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public static void AutoResize(this System.Windows.Forms.ColumnHeader columnheader)
        {

            columnheader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);

            if (columnheader.Width == 25)
            {
                columnheader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public static void AutoResize(this System.Windows.Forms.ListView listview)
        {
            if (listview.Items.Count > 0)
            {
                foreach (System.Windows.Forms.ColumnHeader t in listview.Columns)
                {
                    t.AutoResize();
                }
            }
        }
    }
}
