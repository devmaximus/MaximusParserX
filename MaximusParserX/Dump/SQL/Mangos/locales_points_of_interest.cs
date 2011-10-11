using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_points_of_interest : DumpObjectBase
    {
        public const string TableName = "locales_points_of_interest";
		public System.UInt32? entry;
		public System.String icon_name_loc1;
		public System.String icon_name_loc2;
		public System.String icon_name_loc3;
		public System.String icon_name_loc4;
		public System.String icon_name_loc5;
		public System.String icon_name_loc6;
		public System.String icon_name_loc7;
		public System.String icon_name_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `icon_name_loc1`, `icon_name_loc2`, `icon_name_loc3`, `icon_name_loc4`, `icon_name_loc5`, `icon_name_loc6`, `icon_name_loc7`, `icon_name_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", entry.GetValueOrDefault(), icon_name_loc1.ToSQL(), icon_name_loc2.ToSQL(), icon_name_loc3.ToSQL(), icon_name_loc4.ToSQL(), icon_name_loc5.ToSQL(), icon_name_loc6.ToSQL(), icon_name_loc7.ToSQL(), icon_name_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(icon_name_loc1 != null)
			{
				sb.AppendLine("`icon_name_loc1`='" + icon_name_loc1.ToSQL() + "'");
			}
			if(icon_name_loc2 != null)
			{
				sb.AppendLine("`icon_name_loc2`='" + icon_name_loc2.ToSQL() + "'");
			}
			if(icon_name_loc3 != null)
			{
				sb.AppendLine("`icon_name_loc3`='" + icon_name_loc3.ToSQL() + "'");
			}
			if(icon_name_loc4 != null)
			{
				sb.AppendLine("`icon_name_loc4`='" + icon_name_loc4.ToSQL() + "'");
			}
			if(icon_name_loc5 != null)
			{
				sb.AppendLine("`icon_name_loc5`='" + icon_name_loc5.ToSQL() + "'");
			}
			if(icon_name_loc6 != null)
			{
				sb.AppendLine("`icon_name_loc6`='" + icon_name_loc6.ToSQL() + "'");
			}
			if(icon_name_loc7 != null)
			{
				sb.AppendLine("`icon_name_loc7`='" + icon_name_loc7.ToSQL() + "'");
			}
			if(icon_name_loc8 != null)
			{
				sb.AppendLine("`icon_name_loc8`='" + icon_name_loc8.ToSQL() + "'");
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

		public locales_points_of_interest() : base(TableName) 
        {
        }
	}
}
