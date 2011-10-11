using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class game_event_quest : DumpObjectBase
    {
        public const string TableName = "game_event_quest";
		public System.UInt32? quest;
		public System.UInt16? event_;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`quest`, `event`) VALUES ('{0}', '{1}');", quest.GetValueOrDefault(), event_.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(event_ != null)
			{
				sb.AppendLine("`event`='" + event_.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `quest`='" + quest.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `quest`='" + quest.Value.ToString() + "';");
        }

		public game_event_quest() : base(TableName) 
        {
        }
	}
}
