using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class game_event : DumpObjectBase
    {
        public const string TableName = "game_event";
		public System.UInt32? entry;
		public System.DateTime? start_time;
		public System.DateTime? end_time;
		public System.UInt64? occurence;
		public System.UInt64? length;
		public System.UInt32? holiday;
		public System.String description;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `start_time`, `end_time`, `occurence`, `length`, `holiday`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", entry.GetValueOrDefault(), start_time.GetValueOrDefault(), end_time.GetValueOrDefault(), occurence.GetValueOrDefault(), length.GetValueOrDefault(), holiday.GetValueOrDefault(), description.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(start_time != null)
			{
				sb.AppendLine("`start_time`='" + start_time.Value.ToString() + "'");
			}
			if(end_time != null)
			{
				sb.AppendLine("`end_time`='" + end_time.Value.ToString() + "'");
			}
			if(occurence != null)
			{
				sb.AppendLine("`occurence`='" + occurence.Value.ToString() + "'");
			}
			if(length != null)
			{
				sb.AppendLine("`length`='" + length.Value.ToString() + "'");
			}
			if(holiday != null)
			{
				sb.AppendLine("`holiday`='" + holiday.Value.ToString() + "'");
			}
			if(description != null)
			{
				sb.AppendLine("`description`='" + description.ToSQL() + "'");
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

		public game_event() : base(TableName) 
        {
        }
	}
}
