using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class player_levelstats : DumpObjectBase
    {
        public const string TableName = "player_levelstats";
		public System.Byte? race;
		public System.Byte? class_;
		public System.Byte? level;
		public System.Byte? str;
		public System.Byte? agi;
		public System.Byte? sta;
		public System.Byte? inte;
		public System.Byte? spi;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`race`, `class`, `level`, `str`, `agi`, `sta`, `inte`, `spi`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", race.GetValueOrDefault(), class_.GetValueOrDefault(), level.GetValueOrDefault(), str.GetValueOrDefault(), agi.GetValueOrDefault(), sta.GetValueOrDefault(), inte.GetValueOrDefault(), spi.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(class_ != null)
			{
				sb.AppendLine("`class`='" + class_.Value.ToString() + "'");
			}
			if(level != null)
			{
				sb.AppendLine("`level`='" + level.Value.ToString() + "'");
			}
			if(str != null)
			{
				sb.AppendLine("`str`='" + str.Value.ToString() + "'");
			}
			if(agi != null)
			{
				sb.AppendLine("`agi`='" + agi.Value.ToString() + "'");
			}
			if(sta != null)
			{
				sb.AppendLine("`sta`='" + sta.Value.ToString() + "'");
			}
			if(inte != null)
			{
				sb.AppendLine("`inte`='" + inte.Value.ToString() + "'");
			}
			if(spi != null)
			{
				sb.AppendLine("`spi`='" + spi.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `race`='" + race.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `race`='" + race.Value.ToString() + "';");
        }

		public player_levelstats() : base(TableName) 
        {
        }
	}
}
