using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class player_classlevelstats : DumpObjectBase
    {
        public const string TableName = "player_classlevelstats";
		public System.Byte? class_;
		public System.Byte? level;
		public System.UInt16? basehp;
		public System.UInt16? basemana;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`class`, `level`, `basehp`, `basemana`) VALUES ('{0}', '{1}', '{2}', '{3}');", class_.GetValueOrDefault(), level.GetValueOrDefault(), basehp.GetValueOrDefault(), basemana.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(level != null)
			{
				sb.AppendLine("`level`='" + level.Value.ToString() + "'");
			}
			if(basehp != null)
			{
				sb.AppendLine("`basehp`='" + basehp.Value.ToString() + "'");
			}
			if(basemana != null)
			{
				sb.AppendLine("`basemana`='" + basemana.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `class`='" + class_.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `class`='" + class_.Value.ToString() + "';");
        }

		public player_classlevelstats() : base(TableName) 
        {
        }
	}
}
