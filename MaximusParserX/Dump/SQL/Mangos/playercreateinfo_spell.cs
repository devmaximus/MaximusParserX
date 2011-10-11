using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class playercreateinfo_spell : DumpObjectBase
    {
        public const string TableName = "playercreateinfo_spell";
		public System.Byte? race;
		public System.Byte? class_;
		public System.UInt32? spell;
		public System.String note;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`race`, `class`, `spell`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}');", race.GetValueOrDefault(), class_.GetValueOrDefault(), spell.GetValueOrDefault(), note.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(class_ != null)
			{
				sb.AppendLine("`class`='" + class_.Value.ToString() + "'");
			}
			if(spell != null)
			{
				sb.AppendLine("`spell`='" + spell.Value.ToString() + "'");
			}
			if(note != null)
			{
				sb.AppendLine("`note`='" + note.ToSQL() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `race`='" + race.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `race`='" + race.Value.ToString() + "';");
        }

		public playercreateinfo_spell() : base(TableName) 
        {
        }
	}
}
