using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_target_position : DumpObjectBase
    {
        public const string TableName = "spell_target_position";
		public System.UInt32? id;
		public System.UInt16? target_map;
		public System.Single? target_position_x;
		public System.Single? target_position_y;
		public System.Single? target_position_z;
		public System.Single? target_orientation;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `target_map`, `target_position_x`, `target_position_y`, `target_position_z`, `target_orientation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", id.GetValueOrDefault(), target_map.GetValueOrDefault(), ((Decimal)target_position_x.GetValueOrDefault()), ((Decimal)target_position_y.GetValueOrDefault()), ((Decimal)target_position_z.GetValueOrDefault()), ((Decimal)target_orientation.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(target_map != null)
			{
				sb.AppendLine("`target_map`='" + target_map.Value.ToString() + "'");
			}
			if(target_position_x != null)
			{
				sb.AppendLine("`target_position_x`='" + ((Decimal)target_position_x.Value).ToString() + "'");
			}
			if(target_position_y != null)
			{
				sb.AppendLine("`target_position_y`='" + ((Decimal)target_position_y.Value).ToString() + "'");
			}
			if(target_position_z != null)
			{
				sb.AppendLine("`target_position_z`='" + ((Decimal)target_position_z.Value).ToString() + "'");
			}
			if(target_orientation != null)
			{
				sb.AppendLine("`target_orientation`='" + ((Decimal)target_orientation.Value).ToString() + "'");
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

		public spell_target_position() : base(TableName) 
        {
        }
	}
}
