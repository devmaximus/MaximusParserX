using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_chain : DumpObjectBase
    {
        public const string TableName = "spell_chain";
		public System.Int32? spell_id;
		public System.Int32? prev_spell;
		public System.Int32? first_spell;
		public System.SByte? rank;
		public System.Int32? req_spell;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`spell_id`, `prev_spell`, `first_spell`, `rank`, `req_spell`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", spell_id.GetValueOrDefault(), prev_spell.GetValueOrDefault(), first_spell.GetValueOrDefault(), rank.GetValueOrDefault(), req_spell.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(prev_spell != null)
			{
				sb.AppendLine("`prev_spell`='" + prev_spell.Value.ToString() + "'");
			}
			if(first_spell != null)
			{
				sb.AppendLine("`first_spell`='" + first_spell.Value.ToString() + "'");
			}
			if(rank != null)
			{
				sb.AppendLine("`rank`='" + rank.Value.ToString() + "'");
			}
			if(req_spell != null)
			{
				sb.AppendLine("`req_spell`='" + req_spell.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `spell_id`='" + spell_id.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `spell_id`='" + spell_id.Value.ToString() + "';");
        }

		public spell_chain() : base(TableName) 
        {
        }
	}
}
