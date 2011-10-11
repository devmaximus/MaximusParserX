using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class creature_equip_template : CustomDumpObjectBase
    {
        public const string TableName = "creature_equip_template";
		public System.UInt32? entry;
		public System.UInt32? equipentry1;
		public System.UInt32? equipentry2;
		public System.UInt32? equipentry3;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `equipentry1`, `equipentry2`, `equipentry3`{4}) VALUES ('{0}', '{1}', '{2}', '{3}'{5});", entry.GetValueOrDefault(), equipentry1.GetValueOrDefault(), equipentry2.GetValueOrDefault(), equipentry3.GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(equipentry1 != null)
			{
				sb.AppendLine("`equipentry1`='" + equipentry1.Value.ToString() + "'");
			}
			if(equipentry2 != null)
			{
				sb.AppendLine("`equipentry2`='" + equipentry2.Value.ToString() + "'");
			}
			if(equipentry3 != null)
			{
				sb.AppendLine("`equipentry3`='" + equipentry3.Value.ToString() + "'");
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

		public creature_equip_template() : base(TableName) 
        {
        }
	}
}
