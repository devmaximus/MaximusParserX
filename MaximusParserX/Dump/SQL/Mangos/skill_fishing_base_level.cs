using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class skill_fishing_base_level : DumpObjectBase
    {
        public const string TableName = "skill_fishing_base_level";
		public System.UInt32? entry;
		public System.Int16? skill;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `skill`) VALUES ('{0}', '{1}');", entry.GetValueOrDefault(), skill.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(skill != null)
			{
				sb.AppendLine("`skill`='" + skill.Value.ToString() + "'");
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

		public skill_fishing_base_level() : base(TableName) 
        {
        }
	}
}
