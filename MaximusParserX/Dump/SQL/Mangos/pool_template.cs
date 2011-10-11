using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class pool_template : DumpObjectBase
    {
        public const string TableName = "pool_template";
		public System.UInt32? entry;
		public System.UInt32? max_limit;
		public System.String description;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `max_limit`, `description`) VALUES ('{0}', '{1}', '{2}');", entry.GetValueOrDefault(), max_limit.GetValueOrDefault(), description.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(max_limit != null)
			{
				sb.AppendLine("`max_limit`='" + max_limit.Value.ToString() + "'");
			}
			if(description != null)
			{
				sb.AppendLine("`description`='" + description.ToSQL() + "'");
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

		public pool_template() : base(TableName) 
        {
        }
	}
}
