using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class pool_pool : DumpObjectBase
    {
        public const string TableName = "pool_pool";
		public System.UInt32? pool_id;
		public System.UInt32? mother_pool;
		public System.Single? chance;
		public System.String description;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`pool_id`, `mother_pool`, `chance`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');", pool_id.GetValueOrDefault(), mother_pool.GetValueOrDefault(), ((Decimal)chance.GetValueOrDefault()), description.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(mother_pool != null)
			{
				sb.AppendLine("`mother_pool`='" + mother_pool.Value.ToString() + "'");
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
				sb.Append(" WHERE `pool_id`='" + pool_id.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `pool_id`='" + pool_id.Value.ToString() + "';");
        }

		public pool_pool() : base(TableName) 
        {
        }
	}
}
