using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class game_event_creature_data : DumpObjectBase
    {
        public const string TableName = "game_event_creature_data";
		public System.UInt32? guid;
		public System.UInt32? entry_id;
		public System.UInt32? modelid;
		public System.UInt32? equipment_id;
		public System.UInt32? spell_start;
		public System.UInt32? spell_end;
		public System.UInt16? event_;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`guid`, `entry_id`, `modelid`, `equipment_id`, `spell_start`, `spell_end`, `event`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", guid.GetValueOrDefault(), entry_id.GetValueOrDefault(), modelid.GetValueOrDefault(), equipment_id.GetValueOrDefault(), spell_start.GetValueOrDefault(), spell_end.GetValueOrDefault(), event_.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(entry_id != null)
			{
				sb.AppendLine("`entry_id`='" + entry_id.Value.ToString() + "'");
			}
			if(modelid != null)
			{
				sb.AppendLine("`modelid`='" + modelid.Value.ToString() + "'");
			}
			if(equipment_id != null)
			{
				sb.AppendLine("`equipment_id`='" + equipment_id.Value.ToString() + "'");
			}
			if(spell_start != null)
			{
				sb.AppendLine("`spell_start`='" + spell_start.Value.ToString() + "'");
			}
			if(spell_end != null)
			{
				sb.AppendLine("`spell_end`='" + spell_end.Value.ToString() + "'");
			}
			if(event_ != null)
			{
				sb.AppendLine("`event`='" + event_.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `guid`='" + guid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `guid`='" + guid.Value.ToString() + "';");
        }

		public game_event_creature_data() : base(TableName) 
        {
        }
	}
}
