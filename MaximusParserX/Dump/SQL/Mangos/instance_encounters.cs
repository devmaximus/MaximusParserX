using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class instance_encounters : DumpObjectBase
    {
        public const string TableName = "instance_encounters";
		public System.UInt32? entry;
		public System.Byte? credittype;
		public System.UInt32? creditentry;
		public System.UInt16? lastencounterdungeon;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `credittype`, `creditentry`, `lastencounterdungeon`) VALUES ('{0}', '{1}', '{2}', '{3}');", entry.GetValueOrDefault(), credittype.GetValueOrDefault(), creditentry.GetValueOrDefault(), lastencounterdungeon.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(credittype != null)
			{
				sb.AppendLine("`credittype`='" + credittype.Value.ToString() + "'");
			}
			if(creditentry != null)
			{
				sb.AppendLine("`creditentry`='" + creditentry.Value.ToString() + "'");
			}
			if(lastencounterdungeon != null)
			{
				sb.AppendLine("`lastencounterdungeon`='" + lastencounterdungeon.Value.ToString() + "'");
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

		public instance_encounters() : base(TableName) 
        {
        }
	}
}
