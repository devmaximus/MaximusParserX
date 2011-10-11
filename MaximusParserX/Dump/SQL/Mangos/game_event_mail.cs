using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class game_event_mail : DumpObjectBase
    {
        public const string TableName = "game_event_mail";
		public System.Int16? event_;
		public System.UInt32? racemask;
		public System.UInt32? quest;
		public System.UInt32? mailtemplateid;
		public System.UInt32? senderentry;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`event`, `racemask`, `quest`, `mailtemplateid`, `senderentry`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", event_.GetValueOrDefault(), racemask.GetValueOrDefault(), quest.GetValueOrDefault(), mailtemplateid.GetValueOrDefault(), senderentry.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(racemask != null)
			{
				sb.AppendLine("`racemask`='" + racemask.Value.ToString() + "'");
			}
			if(quest != null)
			{
				sb.AppendLine("`quest`='" + quest.Value.ToString() + "'");
			}
			if(mailtemplateid != null)
			{
				sb.AppendLine("`mailtemplateid`='" + mailtemplateid.Value.ToString() + "'");
			}
			if(senderentry != null)
			{
				sb.AppendLine("`senderentry`='" + senderentry.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `event`='" + event_.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `event`='" + event_.Value.ToString() + "';");
        }

		public game_event_mail() : base(TableName) 
        {
        }
	}
}
