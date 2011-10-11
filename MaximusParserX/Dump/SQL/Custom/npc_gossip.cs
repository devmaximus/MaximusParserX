using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class npc_gossip : CustomDumpObjectBase
    {
        public const string TableName = "npc_gossip";
		public System.UInt32? npc_guid;
		public System.UInt32? textid;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`npc_guid`, `textid`{2}) VALUES ('{0}', '{1}'{3});", npc_guid.GetValueOrDefault(), textid.GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(textid != null)
			{
				sb.AppendLine("`textid`='" + textid.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `npc_guid`='" + npc_guid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `npc_guid`='" + npc_guid.Value.ToString() + "';");
        }

		public npc_gossip() : base(TableName) 
        {
        }
	}
}
