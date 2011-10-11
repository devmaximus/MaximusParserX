using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class creature_template_addon : CustomDumpObjectBase
    {
        public const string TableName = "creature_template_addon";
		public System.UInt32? entry;
		public System.UInt32? mount;
		public System.UInt32? bytes1;
		public System.Byte? b2_0_sheath;
		public System.Byte? b2_1_pvp_state;
		public System.UInt32? emote;
		public System.UInt32? moveflags;
		public System.String auras;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `mount`, `bytes1`, `b2_0_sheath`, `b2_1_pvp_state`, `emote`, `moveflags`, `auras`{8}) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'{9});", entry.GetValueOrDefault(), mount.GetValueOrDefault(), bytes1.GetValueOrDefault(), b2_0_sheath.GetValueOrDefault(), b2_1_pvp_state.GetValueOrDefault(), emote.GetValueOrDefault(), moveflags.GetValueOrDefault(), auras.ToSQL(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(mount != null)
			{
				sb.AppendLine("`mount`='" + mount.Value.ToString() + "'");
			}
			if(bytes1 != null)
			{
				sb.AppendLine("`bytes1`='" + bytes1.Value.ToString() + "'");
			}
			if(b2_0_sheath != null)
			{
				sb.AppendLine("`b2_0_sheath`='" + b2_0_sheath.Value.ToString() + "'");
			}
			if(b2_1_pvp_state != null)
			{
				sb.AppendLine("`b2_1_pvp_state`='" + b2_1_pvp_state.Value.ToString() + "'");
			}
			if(emote != null)
			{
				sb.AppendLine("`emote`='" + emote.Value.ToString() + "'");
			}
			if(moveflags != null)
			{
				sb.AppendLine("`moveflags`='" + moveflags.Value.ToString() + "'");
			}
			if(auras != null)
			{
				sb.AppendLine("`auras`='" + auras.ToSQL() + "'");
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

		public creature_template_addon() : base(TableName) 
        {
        }
	}
}
