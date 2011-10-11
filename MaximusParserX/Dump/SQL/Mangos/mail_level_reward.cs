using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class mail_level_reward : DumpObjectBase
    {
        public const string TableName = "mail_level_reward";
		public System.UInt32? level;
		public System.UInt32? racemask;
		public System.UInt32? mailtemplateid;
		public System.UInt32? senderentry;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`level`, `racemask`, `mailtemplateid`, `senderentry`) VALUES ('{0}', '{1}', '{2}', '{3}');", level.GetValueOrDefault(), racemask.GetValueOrDefault(), mailtemplateid.GetValueOrDefault(), senderentry.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(racemask != null)
			{
				sb.AppendLine("`racemask`='" + racemask.Value.ToString() + "'");
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
				sb.Append(" WHERE `level`='" + level.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `level`='" + level.Value.ToString() + "';");
        }

		public mail_level_reward() : base(TableName) 
        {
        }
	}
}
