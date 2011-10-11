using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_creature : DumpObjectBase
    {
        public const string TableName = "locales_creature";
		public System.UInt32? entry;
		public System.String name_loc1;
		public System.String name_loc2;
		public System.String name_loc3;
		public System.String name_loc4;
		public System.String name_loc5;
		public System.String name_loc6;
		public System.String name_loc7;
		public System.String name_loc8;
		public System.String subname_loc1;
		public System.String subname_loc2;
		public System.String subname_loc3;
		public System.String subname_loc4;
		public System.String subname_loc5;
		public System.String subname_loc6;
		public System.String subname_loc7;
		public System.String subname_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `name_loc1`, `name_loc2`, `name_loc3`, `name_loc4`, `name_loc5`, `name_loc6`, `name_loc7`, `name_loc8`, `subname_loc1`, `subname_loc2`, `subname_loc3`, `subname_loc4`, `subname_loc5`, `subname_loc6`, `subname_loc7`, `subname_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');", entry.GetValueOrDefault(), name_loc1.ToSQL(), name_loc2.ToSQL(), name_loc3.ToSQL(), name_loc4.ToSQL(), name_loc5.ToSQL(), name_loc6.ToSQL(), name_loc7.ToSQL(), name_loc8.ToSQL(), subname_loc1.ToSQL(), subname_loc2.ToSQL(), subname_loc3.ToSQL(), subname_loc4.ToSQL(), subname_loc5.ToSQL(), subname_loc6.ToSQL(), subname_loc7.ToSQL(), subname_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(name_loc1 != null)
			{
				sb.AppendLine("`name_loc1`='" + name_loc1.ToSQL() + "'");
			}
			if(name_loc2 != null)
			{
				sb.AppendLine("`name_loc2`='" + name_loc2.ToSQL() + "'");
			}
			if(name_loc3 != null)
			{
				sb.AppendLine("`name_loc3`='" + name_loc3.ToSQL() + "'");
			}
			if(name_loc4 != null)
			{
				sb.AppendLine("`name_loc4`='" + name_loc4.ToSQL() + "'");
			}
			if(name_loc5 != null)
			{
				sb.AppendLine("`name_loc5`='" + name_loc5.ToSQL() + "'");
			}
			if(name_loc6 != null)
			{
				sb.AppendLine("`name_loc6`='" + name_loc6.ToSQL() + "'");
			}
			if(name_loc7 != null)
			{
				sb.AppendLine("`name_loc7`='" + name_loc7.ToSQL() + "'");
			}
			if(name_loc8 != null)
			{
				sb.AppendLine("`name_loc8`='" + name_loc8.ToSQL() + "'");
			}
			if(subname_loc1 != null)
			{
				sb.AppendLine("`subname_loc1`='" + subname_loc1.ToSQL() + "'");
			}
			if(subname_loc2 != null)
			{
				sb.AppendLine("`subname_loc2`='" + subname_loc2.ToSQL() + "'");
			}
			if(subname_loc3 != null)
			{
				sb.AppendLine("`subname_loc3`='" + subname_loc3.ToSQL() + "'");
			}
			if(subname_loc4 != null)
			{
				sb.AppendLine("`subname_loc4`='" + subname_loc4.ToSQL() + "'");
			}
			if(subname_loc5 != null)
			{
				sb.AppendLine("`subname_loc5`='" + subname_loc5.ToSQL() + "'");
			}
			if(subname_loc6 != null)
			{
				sb.AppendLine("`subname_loc6`='" + subname_loc6.ToSQL() + "'");
			}
			if(subname_loc7 != null)
			{
				sb.AppendLine("`subname_loc7`='" + subname_loc7.ToSQL() + "'");
			}
			if(subname_loc8 != null)
			{
				sb.AppendLine("`subname_loc8`='" + subname_loc8.ToSQL() + "'");
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

		public locales_creature() : base(TableName) 
        {
        }
	}
}
