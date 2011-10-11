using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class page_text : DumpObjectBase
    {
        public const string TableName = "page_text";
		public System.UInt32? entry;
		public System.String text;
		public System.UInt32? next_page;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `text`, `next_page`) VALUES ('{0}', '{1}', '{2}');", entry.GetValueOrDefault(), text.ToSQL(), next_page.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(text != null)
			{
				sb.AppendLine("`text`='" + text.ToSQL() + "'");
			}
			if(next_page != null)
			{
				sb.AppendLine("`next_page`='" + next_page.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `entry`='" + entry.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `entry`='" + entry.Value.ToString() + "';");
        }

		public page_text() : base(TableName) 
        {
        }
	}
}
