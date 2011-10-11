using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_learn_spell : DumpObjectBase
    {
        public const string TableName = "spell_learn_spell";
		public System.UInt16? entry;
		public System.UInt16? spellid;
		public System.Byte? active;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `spellid`, `active`) VALUES ('{0}', '{1}', '{2}');", entry.GetValueOrDefault(), spellid.GetValueOrDefault(), active.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(spellid != null)
			{
				sb.AppendLine("`spellid`='" + spellid.Value.ToString() + "'");
			}
			if(active != null)
			{
				sb.AppendLine("`active`='" + active.Value.ToString() + "'");
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

		public spell_learn_spell() : base(TableName) 
        {
        }
	}
}
