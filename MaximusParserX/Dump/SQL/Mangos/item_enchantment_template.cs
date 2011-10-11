using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class item_enchantment_template : DumpObjectBase
    {
        public const string TableName = "item_enchantment_template";
		public System.UInt32? entry;
		public System.UInt32? ench;
		public System.Single? chance;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `ench`, `chance`) VALUES ('{0}', '{1}', '{2}');", entry.GetValueOrDefault(), ench.GetValueOrDefault(), ((Decimal)chance.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(ench != null)
			{
				sb.AppendLine("`ench`='" + ench.Value.ToString() + "'");
			}
			if(chance != null)
			{
				sb.AppendLine("`chance`='" + ((Decimal)chance.Value).ToString() + "'");
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

		public item_enchantment_template() : base(TableName) 
        {
        }
	}
}
