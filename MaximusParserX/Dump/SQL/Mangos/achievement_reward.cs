using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class achievement_reward : DumpObjectBase
    {
        public const string TableName = "achievement_reward";
		public System.UInt32? entry;
		public System.SByte? gender;
		public System.UInt32? title_a;
		public System.UInt32? title_h;
		public System.UInt32? item;
		public System.UInt32? sender;
		public System.String subject;
		public System.String text;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `gender`, `title_a`, `title_h`, `item`, `sender`, `subject`, `text`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", entry.GetValueOrDefault(), gender.GetValueOrDefault(), title_a.GetValueOrDefault(), title_h.GetValueOrDefault(), item.GetValueOrDefault(), sender.GetValueOrDefault(), subject.ToSQL(), text.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(gender != null)
			{
				sb.AppendLine("`gender`='" + gender.Value.ToString() + "'");
			}
			if(title_a != null)
			{
				sb.AppendLine("`title_a`='" + title_a.Value.ToString() + "'");
			}
			if(title_h != null)
			{
				sb.AppendLine("`title_h`='" + title_h.Value.ToString() + "'");
			}
			if(item != null)
			{
				sb.AppendLine("`item`='" + item.Value.ToString() + "'");
			}
			if(sender != null)
			{
				sb.AppendLine("`sender`='" + sender.Value.ToString() + "'");
			}
			if(subject != null)
			{
				sb.AppendLine("`subject`='" + subject.ToSQL() + "'");
			}
			if(text != null)
			{
				sb.AppendLine("`text`='" + text.ToSQL() + "'");
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

		public achievement_reward() : base(TableName) 
        {
        }
	}
}
