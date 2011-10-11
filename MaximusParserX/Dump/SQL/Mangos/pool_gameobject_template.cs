using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class pool_gameobject_template : DumpObjectBase
    {
        public const string TableName = "pool_gameobject_template";
		public System.UInt32? id;
		public System.UInt32? pool_entry;
		public System.Single? chance;
		public System.String description;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `pool_entry`, `chance`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');", id.GetValueOrDefault(), pool_entry.GetValueOrDefault(), ((Decimal)chance.GetValueOrDefault()), description.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(pool_entry != null)
			{
				sb.AppendLine("`pool_entry`='" + pool_entry.Value.ToString() + "'");
			}
			if(chance != null)
			{
				sb.AppendLine("`chance`='" + ((Decimal)chance.Value).ToString() + "'");
			}
			if(description != null)
			{
				sb.AppendLine("`description`='" + description.ToSQL() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `id`='" + id.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `id`='" + id.Value.ToString() + "';");
        }

		public pool_gameobject_template() : base(TableName) 
        {
        }
	}
}
