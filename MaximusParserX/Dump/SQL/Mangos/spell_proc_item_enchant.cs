using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_proc_item_enchant : DumpObjectBase
    {
        public const string TableName = "spell_proc_item_enchant";
		public System.UInt32? entry;
		public System.Single? ppmrate;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `ppmrate`) VALUES ('{0}', '{1}');", entry.GetValueOrDefault(), ((Decimal)ppmrate.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(ppmrate != null)
			{
				sb.AppendLine("`ppmrate`='" + ((Decimal)ppmrate.Value).ToString() + "'");
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

		public spell_proc_item_enchant() : base(TableName) 
        {
        }
	}
}
