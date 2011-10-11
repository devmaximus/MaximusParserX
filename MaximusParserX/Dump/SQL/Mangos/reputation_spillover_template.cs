using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class reputation_spillover_template : DumpObjectBase
    {
        public const string TableName = "reputation_spillover_template";
		public System.UInt16? faction;
		public System.UInt16? faction1;
		public System.Single? rate_1;
		public System.Byte? rank_1;
		public System.UInt16? faction2;
		public System.Single? rate_2;
		public System.Byte? rank_2;
		public System.UInt16? faction3;
		public System.Single? rate_3;
		public System.Byte? rank_3;
		public System.UInt16? faction4;
		public System.Single? rate_4;
		public System.Byte? rank_4;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`faction`, `faction1`, `rate_1`, `rank_1`, `faction2`, `rate_2`, `rank_2`, `faction3`, `rate_3`, `rank_3`, `faction4`, `rate_4`, `rank_4`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');", faction.GetValueOrDefault(), faction1.GetValueOrDefault(), ((Decimal)rate_1.GetValueOrDefault()), rank_1.GetValueOrDefault(), faction2.GetValueOrDefault(), ((Decimal)rate_2.GetValueOrDefault()), rank_2.GetValueOrDefault(), faction3.GetValueOrDefault(), ((Decimal)rate_3.GetValueOrDefault()), rank_3.GetValueOrDefault(), faction4.GetValueOrDefault(), ((Decimal)rate_4.GetValueOrDefault()), rank_4.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(faction1 != null)
			{
				sb.AppendLine("`faction1`='" + faction1.Value.ToString() + "'");
			}
			if(rate_1 != null)
			{
				sb.AppendLine("`rate_1`='" + ((Decimal)rate_1.Value).ToString() + "'");
			}
			if(rank_1 != null)
			{
				sb.AppendLine("`rank_1`='" + rank_1.Value.ToString() + "'");
			}
			if(faction2 != null)
			{
				sb.AppendLine("`faction2`='" + faction2.Value.ToString() + "'");
			}
			if(rate_2 != null)
			{
				sb.AppendLine("`rate_2`='" + ((Decimal)rate_2.Value).ToString() + "'");
			}
			if(rank_2 != null)
			{
				sb.AppendLine("`rank_2`='" + rank_2.Value.ToString() + "'");
			}
			if(faction3 != null)
			{
				sb.AppendLine("`faction3`='" + faction3.Value.ToString() + "'");
			}
			if(rate_3 != null)
			{
				sb.AppendLine("`rate_3`='" + ((Decimal)rate_3.Value).ToString() + "'");
			}
			if(rank_3 != null)
			{
				sb.AppendLine("`rank_3`='" + rank_3.Value.ToString() + "'");
			}
			if(faction4 != null)
			{
				sb.AppendLine("`faction4`='" + faction4.Value.ToString() + "'");
			}
			if(rate_4 != null)
			{
				sb.AppendLine("`rate_4`='" + ((Decimal)rate_4.Value).ToString() + "'");
			}
			if(rank_4 != null)
			{
				sb.AppendLine("`rank_4`='" + rank_4.Value.ToString() + "'");
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

		public reputation_spillover_template() : base(TableName) 
        {
        }
	}
}
