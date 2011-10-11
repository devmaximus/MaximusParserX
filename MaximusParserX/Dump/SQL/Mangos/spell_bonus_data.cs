using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_bonus_data : DumpObjectBase
    {
        public const string TableName = "spell_bonus_data";
		public System.UInt32? entry;
		public System.Single? direct_bonus;
		public System.Single? dot_bonus;
		public System.Single? ap_bonus;
		public System.Single? ap_dot_bonus;
		public System.String comments;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `direct_bonus`, `dot_bonus`, `ap_bonus`, `ap_dot_bonus`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", entry.GetValueOrDefault(), ((Decimal)direct_bonus.GetValueOrDefault()), ((Decimal)dot_bonus.GetValueOrDefault()), ((Decimal)ap_bonus.GetValueOrDefault()), ((Decimal)ap_dot_bonus.GetValueOrDefault()), comments.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(direct_bonus != null)
			{
				sb.AppendLine("`direct_bonus`='" + ((Decimal)direct_bonus.Value).ToString() + "'");
			}
			if(dot_bonus != null)
			{
				sb.AppendLine("`dot_bonus`='" + ((Decimal)dot_bonus.Value).ToString() + "'");
			}
			if(ap_bonus != null)
			{
				sb.AppendLine("`ap_bonus`='" + ((Decimal)ap_bonus.Value).ToString() + "'");
			}
			if(ap_dot_bonus != null)
			{
				sb.AppendLine("`ap_dot_bonus`='" + ((Decimal)ap_dot_bonus.Value).ToString() + "'");
			}
			if(comments != null)
			{
				sb.AppendLine("`comments`='" + comments.ToSQL() + "'");
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

		public spell_bonus_data() : base(TableName) 
        {
        }
	}
}
