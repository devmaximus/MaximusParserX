using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_script_target : DumpObjectBase
    {
        public const string TableName = "spell_script_target";
		public System.UInt32? entry;
		public System.Byte? type;
		public System.UInt32? targetentry;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `type`, `targetentry`) VALUES ('{0}', '{1}', '{2}');", entry.GetValueOrDefault(), type.GetValueOrDefault(), targetentry.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(type != null)
			{
				sb.AppendLine("`type`='" + type.Value.ToString() + "'");
			}
			if(targetentry != null)
			{
				sb.AppendLine("`targetentry`='" + targetentry.Value.ToString() + "'");
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

		public spell_script_target() : base(TableName) 
        {
        }
	}
}
