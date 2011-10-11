using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class reputation_reward_rate : DumpObjectBase
    {
        public const string TableName = "reputation_reward_rate";
		public System.UInt32? faction;
		public System.Single? quest_rate;
		public System.Single? creature_rate;
		public System.Single? spell_rate;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`faction`, `quest_rate`, `creature_rate`, `spell_rate`) VALUES ('{0}', '{1}', '{2}', '{3}');", faction.GetValueOrDefault(), ((Decimal)quest_rate.GetValueOrDefault()), ((Decimal)creature_rate.GetValueOrDefault()), ((Decimal)spell_rate.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(quest_rate != null)
			{
				sb.AppendLine("`quest_rate`='" + ((Decimal)quest_rate.Value).ToString() + "'");
			}
			if(creature_rate != null)
			{
				sb.AppendLine("`creature_rate`='" + ((Decimal)creature_rate.Value).ToString() + "'");
			}
			if(spell_rate != null)
			{
				sb.AppendLine("`spell_rate`='" + ((Decimal)spell_rate.Value).ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `faction`='" + faction.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `faction`='" + faction.Value.ToString() + "';");
        }

		public reputation_reward_rate() : base(TableName) 
        {
        }
	}
}
