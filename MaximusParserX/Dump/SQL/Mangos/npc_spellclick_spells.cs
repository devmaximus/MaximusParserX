using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class npc_spellclick_spells : DumpObjectBase
    {
        public const string TableName = "npc_spellclick_spells";
		public System.UInt32? npc_entry;
		public System.UInt32? spell_id;
		public System.UInt32? quest_start;
		public System.Byte? quest_start_active;
		public System.UInt32? quest_end;
		public System.Byte? cast_flags;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`npc_entry`, `spell_id`, `quest_start`, `quest_start_active`, `quest_end`, `cast_flags`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", npc_entry.GetValueOrDefault(), spell_id.GetValueOrDefault(), quest_start.GetValueOrDefault(), quest_start_active.GetValueOrDefault(), quest_end.GetValueOrDefault(), cast_flags.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(spell_id != null)
			{
				sb.AppendLine("`spell_id`='" + spell_id.Value.ToString() + "'");
			}
			if(quest_start != null)
			{
				sb.AppendLine("`quest_start`='" + quest_start.Value.ToString() + "'");
			}
			if(quest_start_active != null)
			{
				sb.AppendLine("`quest_start_active`='" + quest_start_active.Value.ToString() + "'");
			}
			if(quest_end != null)
			{
				sb.AppendLine("`quest_end`='" + quest_end.Value.ToString() + "'");
			}
			if(cast_flags != null)
			{
				sb.AppendLine("`cast_flags`='" + cast_flags.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `npc_entry`='" + npc_entry.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `npc_entry`='" + npc_entry.Value.ToString() + "';");
        }

		public npc_spellclick_spells() : base(TableName) 
        {
        }
	}
}
