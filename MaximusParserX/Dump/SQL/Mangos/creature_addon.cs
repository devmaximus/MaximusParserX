using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_addon : DumpObjectBase
    {
        public const string TableName = "creature_addon";
		public System.UInt32? guid;
		public System.UInt32? mount;
		public System.UInt32? bytes1;
		public System.Byte? b2_0_sheath;
		public System.Byte? b2_1_pvp_state;
		public System.UInt32? emote;
		public System.UInt32? moveflags;
		public System.String auras;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`guid`, `mount`, `bytes1`, `b2_0_sheath`, `b2_1_pvp_state`, `emote`, `moveflags`, `auras`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", guid.GetValueOrDefault(), mount.GetValueOrDefault(), bytes1.GetValueOrDefault(), b2_0_sheath.GetValueOrDefault(), b2_1_pvp_state.GetValueOrDefault(), emote.GetValueOrDefault(), moveflags.GetValueOrDefault(), auras.ToSQL());
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
				sb.Append(" WHERE `guid`='" + guid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `guid`='" + guid.Value.ToString() + "';");
        }

		public creature_addon() : base(TableName) 
        {
        }
	}
}
