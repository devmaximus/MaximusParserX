using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_model_race : DumpObjectBase
    {
        public const string TableName = "creature_model_race";
		public System.UInt32? modelid;
		public System.UInt32? racemask;
		public System.UInt32? creature_entry;
		public System.UInt32? modelid_racial;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`modelid`, `racemask`, `creature_entry`, `modelid_racial`) VALUES ('{0}', '{1}', '{2}', '{3}');", modelid.GetValueOrDefault(), racemask.GetValueOrDefault(), creature_entry.GetValueOrDefault(), modelid_racial.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(racemask != null)
			{
				sb.AppendLine("`racemask`='" + racemask.Value.ToString() + "'");
			}
			if(creature_entry != null)
			{
				sb.AppendLine("`creature_entry`='" + creature_entry.Value.ToString() + "'");
			}
			if(modelid_racial != null)
			{
				sb.AppendLine("`modelid_racial`='" + modelid_racial.Value.ToString() + "'");
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

		public creature_model_race() : base(TableName) 
        {
        }
	}
}
