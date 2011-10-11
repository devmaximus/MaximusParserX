using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class points_of_interest : CustomDumpObjectBase
    {
        public const string TableName = "points_of_interest";
		public System.UInt32? entry;
		public System.Single? x;
		public System.Single? y;
		public System.UInt32? icon;
		public System.UInt32? flags;
		public System.UInt32? data;
		public System.String icon_name;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `x`, `y`, `icon`, `flags`, `data`, `icon_name`{7}) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'{8});", entry.GetValueOrDefault(), ((Decimal)x.GetValueOrDefault()), ((Decimal)y.GetValueOrDefault()), icon.GetValueOrDefault(), flags.GetValueOrDefault(), data.GetValueOrDefault(), icon_name.ToSQL(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(x != null)
			{
				sb.AppendLine("`x`='" + ((Decimal)x.Value).ToString() + "'");
			}
			if(y != null)
			{
				sb.AppendLine("`y`='" + ((Decimal)y.Value).ToString() + "'");
			}
			if(icon != null)
			{
				sb.AppendLine("`icon`='" + icon.Value.ToString() + "'");
			}
			if(flags != null)
			{
				sb.AppendLine("`flags`='" + flags.Value.ToString() + "'");
			}
			if(data != null)
			{
				sb.AppendLine("`data`='" + data.Value.ToString() + "'");
			}
			if(icon_name != null)
			{
				sb.AppendLine("`icon_name`='" + icon_name.ToSQL() + "'");
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

		public points_of_interest() : base(TableName) 
        {
        }
	}
}
