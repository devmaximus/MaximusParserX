using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_ai_texts : DumpObjectBase
    {
        public const string TableName = "creature_ai_texts";
		public System.Int32? entry;
		public System.String content_default;
		public System.String content_loc1;
		public System.String content_loc2;
		public System.String content_loc3;
		public System.String content_loc4;
		public System.String content_loc5;
		public System.String content_loc6;
		public System.String content_loc7;
		public System.String content_loc8;
		public System.UInt32? sound;
		public System.Byte? type;
		public System.Byte? language;
		public System.UInt16? emote;
		public System.String comment;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `content_default`, `content_loc1`, `content_loc2`, `content_loc3`, `content_loc4`, `content_loc5`, `content_loc6`, `content_loc7`, `content_loc8`, `sound`, `type`, `language`, `emote`, `comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}');", entry.GetValueOrDefault(), content_default.ToSQL(), content_loc1.ToSQL(), content_loc2.ToSQL(), content_loc3.ToSQL(), content_loc4.ToSQL(), content_loc5.ToSQL(), content_loc6.ToSQL(), content_loc7.ToSQL(), content_loc8.ToSQL(), sound.GetValueOrDefault(), type.GetValueOrDefault(), language.GetValueOrDefault(), emote.GetValueOrDefault(), comment.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(content_default != null)
			{
				sb.AppendLine("`content_default`='" + content_default.ToSQL() + "'");
			}
			if(content_loc1 != null)
			{
				sb.AppendLine("`content_loc1`='" + content_loc1.ToSQL() + "'");
			}
			if(content_loc2 != null)
			{
				sb.AppendLine("`content_loc2`='" + content_loc2.ToSQL() + "'");
			}
			if(content_loc3 != null)
			{
				sb.AppendLine("`content_loc3`='" + content_loc3.ToSQL() + "'");
			}
			if(content_loc4 != null)
			{
				sb.AppendLine("`content_loc4`='" + content_loc4.ToSQL() + "'");
			}
			if(content_loc5 != null)
			{
				sb.AppendLine("`content_loc5`='" + content_loc5.ToSQL() + "'");
			}
			if(content_loc6 != null)
			{
				sb.AppendLine("`content_loc6`='" + content_loc6.ToSQL() + "'");
			}
			if(content_loc7 != null)
			{
				sb.AppendLine("`content_loc7`='" + content_loc7.ToSQL() + "'");
			}
			if(content_loc8 != null)
			{
				sb.AppendLine("`content_loc8`='" + content_loc8.ToSQL() + "'");
			}
			if(sound != null)
			{
				sb.AppendLine("`sound`='" + sound.Value.ToString() + "'");
			}
			if(type != null)
			{
				sb.AppendLine("`type`='" + type.Value.ToString() + "'");
			}
			if(language != null)
			{
				sb.AppendLine("`language`='" + language.Value.ToString() + "'");
			}
			if(emote != null)
			{
				sb.AppendLine("`emote`='" + emote.Value.ToString() + "'");
			}
			if(comment != null)
			{
				sb.AppendLine("`comment`='" + comment.ToSQL() + "'");
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

		public creature_ai_texts() : base(TableName) 
        {
        }
	}
}
