using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class npc_vendor_template : DumpObjectBase
    {
        public const string TableName = "npc_vendor_template";
		public System.UInt32? entry;
		public System.UInt32? item;
		public System.Byte? maxcount;
		public System.UInt32? incrtime;
		public System.UInt32? extendedcost;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `item`, `maxcount`, `incrtime`, `extendedcost`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", entry.GetValueOrDefault(), item.GetValueOrDefault(), maxcount.GetValueOrDefault(), incrtime.GetValueOrDefault(), extendedcost.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(item != null)
			{
				sb.AppendLine("`item`='" + item.Value.ToString() + "'");
			}
			if(maxcount != null)
			{
				sb.AppendLine("`maxcount`='" + maxcount.Value.ToString() + "'");
			}
			if(incrtime != null)
			{
				sb.AppendLine("`incrtime`='" + incrtime.Value.ToString() + "'");
			}
			if(extendedcost != null)
			{
				sb.AppendLine("`extendedcost`='" + extendedcost.Value.ToString() + "'");
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

		public npc_vendor_template() : base(TableName) 
        {
        }
	}
}
