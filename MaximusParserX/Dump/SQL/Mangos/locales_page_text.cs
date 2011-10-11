using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_page_text : DumpObjectBase
    {
        public const string TableName = "locales_page_text";
		public System.UInt32? entry;
		public System.String text_loc1;
		public System.String text_loc2;
		public System.String text_loc3;
		public System.String text_loc4;
		public System.String text_loc5;
		public System.String text_loc6;
		public System.String text_loc7;
		public System.String text_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `text_loc1`, `text_loc2`, `text_loc3`, `text_loc4`, `text_loc5`, `text_loc6`, `text_loc7`, `text_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", entry.GetValueOrDefault(), text_loc1.ToSQL(), text_loc2.ToSQL(), text_loc3.ToSQL(), text_loc4.ToSQL(), text_loc5.ToSQL(), text_loc6.ToSQL(), text_loc7.ToSQL(), text_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(text_loc1 != null)
			{
				sb.AppendLine("`text_loc1`='" + text_loc1.ToSQL() + "'");
			}
			if(text_loc2 != null)
			{
				sb.AppendLine("`text_loc2`='" + text_loc2.ToSQL() + "'");
			}
			if(text_loc3 != null)
			{
				sb.AppendLine("`text_loc3`='" + text_loc3.ToSQL() + "'");
			}
			if(text_loc4 != null)
			{
				sb.AppendLine("`text_loc4`='" + text_loc4.ToSQL() + "'");
			}
			if(text_loc5 != null)
			{
				sb.AppendLine("`text_loc5`='" + text_loc5.ToSQL() + "'");
			}
			if(text_loc6 != null)
			{
				sb.AppendLine("`text_loc6`='" + text_loc6.ToSQL() + "'");
			}
			if(text_loc7 != null)
			{
				sb.AppendLine("`text_loc7`='" + text_loc7.ToSQL() + "'");
			}
			if(text_loc8 != null)
			{
				sb.AppendLine("`text_loc8`='" + text_loc8.ToSQL() + "'");
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

		public locales_page_text() : base(TableName) 
        {
        }
	}
}
