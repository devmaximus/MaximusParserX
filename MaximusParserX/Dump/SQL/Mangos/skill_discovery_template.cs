using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class skill_discovery_template : DumpObjectBase
    {
        public const string TableName = "skill_discovery_template";
		public System.UInt32? spellid;
		public System.UInt32? reqspell;
		public System.UInt16? reqskillvalue;
		public System.Single? chance;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`spellid`, `reqspell`, `reqskillvalue`, `chance`) VALUES ('{0}', '{1}', '{2}', '{3}');", spellid.GetValueOrDefault(), reqspell.GetValueOrDefault(), reqskillvalue.GetValueOrDefault(), ((Decimal)chance.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(reqspell != null)
			{
				sb.AppendLine("`reqspell`='" + reqspell.Value.ToString() + "'");
			}
			if(reqskillvalue != null)
			{
				sb.AppendLine("`reqskillvalue`='" + reqskillvalue.Value.ToString() + "'");
			}
			if(chance != null)
			{
				sb.AppendLine("`chance`='" + ((Decimal)chance.Value).ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `spellid`='" + spellid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `spellid`='" + spellid.Value.ToString() + "';");
        }

		public skill_discovery_template() : base(TableName) 
        {
        }
	}
}
