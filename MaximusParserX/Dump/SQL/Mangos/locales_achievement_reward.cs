using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_achievement_reward : DumpObjectBase
    {
        public const string TableName = "locales_achievement_reward";
		public System.UInt32? entry;
		public System.SByte? gender;
		public System.String subject_loc1;
		public System.String subject_loc2;
		public System.String subject_loc3;
		public System.String subject_loc4;
		public System.String subject_loc5;
		public System.String subject_loc6;
		public System.String subject_loc7;
		public System.String subject_loc8;
		public System.String text_loc1;
		public System.String text_loc2;
		public System.String text_loc3;
		public System.String text_loc4;
		public System.String text_loc5;
		public System.String text_loc6;
		public System.String text_loc7;
		public System.String text_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `gender`, `subject_loc1`, `subject_loc2`, `subject_loc3`, `subject_loc4`, `subject_loc5`, `subject_loc6`, `subject_loc7`, `subject_loc8`, `text_loc1`, `text_loc2`, `text_loc3`, `text_loc4`, `text_loc5`, `text_loc6`, `text_loc7`, `text_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');", entry.GetValueOrDefault(), gender.GetValueOrDefault(), subject_loc1.ToSQL(), subject_loc2.ToSQL(), subject_loc3.ToSQL(), subject_loc4.ToSQL(), subject_loc5.ToSQL(), subject_loc6.ToSQL(), subject_loc7.ToSQL(), subject_loc8.ToSQL(), text_loc1.ToSQL(), text_loc2.ToSQL(), text_loc3.ToSQL(), text_loc4.ToSQL(), text_loc5.ToSQL(), text_loc6.ToSQL(), text_loc7.ToSQL(), text_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(gender != null)
			{
				sb.AppendLine("`gender`='" + gender.Value.ToString() + "'");
			}
			if(subject_loc1 != null)
			{
				sb.AppendLine("`subject_loc1`='" + subject_loc1.ToSQL() + "'");
			}
			if(subject_loc2 != null)
			{
				sb.AppendLine("`subject_loc2`='" + subject_loc2.ToSQL() + "'");
			}
			if(subject_loc3 != null)
			{
				sb.AppendLine("`subject_loc3`='" + subject_loc3.ToSQL() + "'");
			}
			if(subject_loc4 != null)
			{
				sb.AppendLine("`subject_loc4`='" + subject_loc4.ToSQL() + "'");
			}
			if(subject_loc5 != null)
			{
				sb.AppendLine("`subject_loc5`='" + subject_loc5.ToSQL() + "'");
			}
			if(subject_loc6 != null)
			{
				sb.AppendLine("`subject_loc6`='" + subject_loc6.ToSQL() + "'");
			}
			if(subject_loc7 != null)
			{
				sb.AppendLine("`subject_loc7`='" + subject_loc7.ToSQL() + "'");
			}
			if(subject_loc8 != null)
			{
				sb.AppendLine("`subject_loc8`='" + subject_loc8.ToSQL() + "'");
			}
			if(text_loc1 != null)
			{
				sb.AppendLine("`text_loc1`='" + text_loc1.ToSQL() + "'");
			}
			if(text_loc2 != null)
			{
				sb.AppendLine("`text_loc2`='" + text_loc2.ToSQL() + "'");
			}
			if(text_loc3 != null)
			{
				sb.AppendLine("`text_loc3`='" + text_loc3.ToSQL() + "'");
			}
			if(text_loc4 != null)
			{
				sb.AppendLine("`text_loc4`='" + text_loc4.ToSQL() + "'");
			}
			if(text_loc5 != null)
			{
				sb.AppendLine("`text_loc5`='" + text_loc5.ToSQL() + "'");
			}
			if(text_loc6 != null)
			{
				sb.AppendLine("`text_loc6`='" + text_loc6.ToSQL() + "'");
			}
			if(text_loc7 != null)
			{
				sb.AppendLine("`text_loc7`='" + text_loc7.ToSQL() + "'");
			}
			if(text_loc8 != null)
			{
				sb.AppendLine("`text_loc8`='" + text_loc8.ToSQL() + "'");
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

		public locales_achievement_reward() : base(TableName) 
        {
        }
	}
}
