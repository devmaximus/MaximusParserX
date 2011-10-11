using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class player_xp_for_level : DumpObjectBase
    {
        public const string TableName = "player_xp_for_level";
		public System.UInt32? lvl;
		public System.UInt32? xp_for_next_level;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`lvl`, `xp_for_next_level`) VALUES ('{0}', '{1}');", lvl.GetValueOrDefault(), xp_for_next_level.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(xp_for_next_level != null)
			{
				sb.AppendLine("`xp_for_next_level`='" + xp_for_next_level.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `lvl`='" + lvl.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `lvl`='" + lvl.Value.ToString() + "';");
        }

		public player_xp_for_level() : base(TableName) 
        {
        }
	}
}
