using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_threat : DumpObjectBase
    {
        public const string TableName = "spell_threat";
		public System.UInt32? entry;
		public System.Int16? threat;
		public System.Single? multiplier;
		public System.Single? ap_bonus;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `threat`, `multiplier`, `ap_bonus`) VALUES ('{0}', '{1}', '{2}', '{3}');", entry.GetValueOrDefault(), threat.GetValueOrDefault(), ((Decimal)multiplier.GetValueOrDefault()), ((Decimal)ap_bonus.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(threat != null)
			{
				sb.AppendLine("`threat`='" + threat.Value.ToString() + "'");
			}
			if(multiplier != null)
			{
				sb.AppendLine("`multiplier`='" + ((Decimal)multiplier.Value).ToString() + "'");
			}
			if(ap_bonus != null)
			{
				sb.AppendLine("`ap_bonus`='" + ((Decimal)ap_bonus.Value).ToString() + "'");
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

		public spell_threat() : base(TableName) 
        {
        }
	}
}
