using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_model_info : DumpObjectBase
    {
        public const string TableName = "creature_model_info";
		public System.UInt32? modelid;
		public System.Single? bounding_radius;
		public System.Single? combat_reach;
		public System.Byte? gender;
		public System.UInt32? modelid_other_gender;
		public System.UInt32? modelid_alternative;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`modelid`, `bounding_radius`, `combat_reach`, `gender`, `modelid_other_gender`, `modelid_alternative`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", modelid.GetValueOrDefault(), ((Decimal)bounding_radius.GetValueOrDefault()), ((Decimal)combat_reach.GetValueOrDefault()), gender.GetValueOrDefault(), modelid_other_gender.GetValueOrDefault(), modelid_alternative.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(bounding_radius != null)
			{
				sb.AppendLine("`bounding_radius`='" + ((Decimal)bounding_radius.Value).ToString() + "'");
			}
			if(combat_reach != null)
			{
				sb.AppendLine("`combat_reach`='" + ((Decimal)combat_reach.Value).ToString() + "'");
			}
			if(gender != null)
			{
				sb.AppendLine("`gender`='" + gender.Value.ToString() + "'");
			}
			if(modelid_other_gender != null)
			{
				sb.AppendLine("`modelid_other_gender`='" + modelid_other_gender.Value.ToString() + "'");
			}
			if(modelid_alternative != null)
			{
				sb.AppendLine("`modelid_alternative`='" + modelid_alternative.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `modelid`='" + modelid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `modelid`='" + modelid.Value.ToString() + "';");
        }

		public creature_model_info() : base(TableName) 
        {
        }
	}
}
