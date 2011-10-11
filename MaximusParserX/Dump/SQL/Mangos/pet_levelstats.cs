using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class pet_levelstats : DumpObjectBase
    {
        public const string TableName = "pet_levelstats";
		public System.UInt32? creature_entry;
		public System.Byte? level;
		public System.UInt16? hp;
		public System.UInt16? mana;
		public System.UInt32? armor;
		public System.UInt16? str;
		public System.UInt16? agi;
		public System.UInt16? sta;
		public System.UInt16? inte;
		public System.UInt16? spi;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`creature_entry`, `level`, `hp`, `mana`, `armor`, `str`, `agi`, `sta`, `inte`, `spi`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');", creature_entry.GetValueOrDefault(), level.GetValueOrDefault(), hp.GetValueOrDefault(), mana.GetValueOrDefault(), armor.GetValueOrDefault(), str.GetValueOrDefault(), agi.GetValueOrDefault(), sta.GetValueOrDefault(), inte.GetValueOrDefault(), spi.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(level != null)
			{
				sb.AppendLine("`level`='" + level.Value.ToString() + "'");
			}
			if(hp != null)
			{
				sb.AppendLine("`hp`='" + hp.Value.ToString() + "'");
			}
			if(mana != null)
			{
				sb.AppendLine("`mana`='" + mana.Value.ToString() + "'");
			}
			if(armor != null)
			{
				sb.AppendLine("`armor`='" + armor.Value.ToString() + "'");
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
				sb.Append(" WHERE `creature_entry`='" + creature_entry.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `creature_entry`='" + creature_entry.Value.ToString() + "';");
        }

		public pet_levelstats() : base(TableName) 
        {
        }
	}
}
