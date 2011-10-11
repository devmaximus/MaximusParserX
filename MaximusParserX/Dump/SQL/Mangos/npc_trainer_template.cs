using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class npc_trainer_template : DumpObjectBase
    {
        public const string TableName = "npc_trainer_template";
		public System.UInt32? entry;
		public System.UInt32? spell;
		public System.UInt32? spellcost;
		public System.UInt16? reqskill;
		public System.UInt16? reqskillvalue;
		public System.Byte? reqlevel;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `spell`, `spellcost`, `reqskill`, `reqskillvalue`, `reqlevel`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", entry.GetValueOrDefault(), spell.GetValueOrDefault(), spellcost.GetValueOrDefault(), reqskill.GetValueOrDefault(), reqskillvalue.GetValueOrDefault(), reqlevel.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(spell != null)
			{
				sb.AppendLine("`spell`='" + spell.Value.ToString() + "'");
			}
			if(spellcost != null)
			{
				sb.AppendLine("`spellcost`='" + spellcost.Value.ToString() + "'");
			}
			if(reqskill != null)
			{
				sb.AppendLine("`reqskill`='" + reqskill.Value.ToString() + "'");
			}
			if(reqskillvalue != null)
			{
				sb.AppendLine("`reqskillvalue`='" + reqskillvalue.Value.ToString() + "'");
			}
			if(reqlevel != null)
			{
				sb.AppendLine("`reqlevel`='" + reqlevel.Value.ToString() + "'");
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

		public npc_trainer_template() : base(TableName) 
        {
        }
	}
}
