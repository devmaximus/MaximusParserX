using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_area : DumpObjectBase
    {
        public const string TableName = "spell_area";
		public System.UInt32? spell;
		public System.UInt32? area;
		public System.UInt32? quest_start;
		public System.Byte? quest_start_active;
		public System.UInt32? quest_end;
		public System.Int32? aura_spell;
		public System.UInt32? racemask;
		public System.Byte? gender;
		public System.Byte? autocast;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`spell`, `area`, `quest_start`, `quest_start_active`, `quest_end`, `aura_spell`, `racemask`, `gender`, `autocast`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", spell.GetValueOrDefault(), area.GetValueOrDefault(), quest_start.GetValueOrDefault(), quest_start_active.GetValueOrDefault(), quest_end.GetValueOrDefault(), aura_spell.GetValueOrDefault(), racemask.GetValueOrDefault(), gender.GetValueOrDefault(), autocast.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(area != null)
			{
				sb.AppendLine("`area`='" + area.Value.ToString() + "'");
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
			if(aura_spell != null)
			{
				sb.AppendLine("`aura_spell`='" + aura_spell.Value.ToString() + "'");
			}
			if(racemask != null)
			{
				sb.AppendLine("`racemask`='" + racemask.Value.ToString() + "'");
			}
			if(gender != null)
			{
				sb.AppendLine("`gender`='" + gender.Value.ToString() + "'");
			}
			if(autocast != null)
			{
				sb.AppendLine("`autocast`='" + autocast.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `spell`='" + spell.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `spell`='" + spell.Value.ToString() + "';");
        }

		public spell_area() : base(TableName) 
        {
        }
	}
}
