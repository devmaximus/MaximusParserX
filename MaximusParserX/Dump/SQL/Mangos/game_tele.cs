using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class game_tele : DumpObjectBase
    {
        public const string TableName = "game_tele";
		public System.UInt32? id;
		public System.Single? position_x;
		public System.Single? position_y;
		public System.Single? position_z;
		public System.Single? orientation;
		public System.UInt16? map;
		public System.String name;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `position_x`, `position_y`, `position_z`, `orientation`, `map`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", id.GetValueOrDefault(), ((Decimal)position_x.GetValueOrDefault()), ((Decimal)position_y.GetValueOrDefault()), ((Decimal)position_z.GetValueOrDefault()), ((Decimal)orientation.GetValueOrDefault()), map.GetValueOrDefault(), name.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(position_x != null)
			{
				sb.AppendLine("`position_x`='" + ((Decimal)position_x.Value).ToString() + "'");
			}
			if(position_y != null)
			{
				sb.AppendLine("`position_y`='" + ((Decimal)position_y.Value).ToString() + "'");
			}
			if(position_z != null)
			{
				sb.AppendLine("`position_z`='" + ((Decimal)position_z.Value).ToString() + "'");
			}
			if(orientation != null)
			{
				sb.AppendLine("`orientation`='" + ((Decimal)orientation.Value).ToString() + "'");
			}
			if(map != null)
			{
				sb.AppendLine("`map`='" + map.Value.ToString() + "'");
			}
			if(name != null)
			{
				sb.AppendLine("`name`='" + name.ToSQL() + "'");
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

		public game_tele() : base(TableName) 
        {
        }
	}
}
