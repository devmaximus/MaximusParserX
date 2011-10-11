using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_elixir : DumpObjectBase
    {
        public const string TableName = "spell_elixir";
		public System.UInt32? entry;
		public System.Byte? mask;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `mask`) VALUES ('{0}', '{1}');", entry.GetValueOrDefault(), mask.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(mask != null)
			{
				sb.AppendLine("`mask`='" + mask.Value.ToString() + "'");
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

		public spell_elixir() : base(TableName) 
        {
        }
	}
}
