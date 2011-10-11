using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class playercreateinfo : DumpObjectBase
    {
        public const string TableName = "playercreateinfo";
		public System.Byte? race;
		public System.Byte? class_;
		public System.UInt16? map;
		public System.UInt32? zone;
		public System.Single? position_x;
		public System.Single? position_y;
		public System.Single? position_z;
		public System.Single? orientation;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`race`, `class`, `map`, `zone`, `position_x`, `position_y`, `position_z`, `orientation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", race.GetValueOrDefault(), class_.GetValueOrDefault(), map.GetValueOrDefault(), zone.GetValueOrDefault(), ((Decimal)position_x.GetValueOrDefault()), ((Decimal)position_y.GetValueOrDefault()), ((Decimal)position_z.GetValueOrDefault()), ((Decimal)orientation.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(class_ != null)
			{
				sb.AppendLine("`class`='" + class_.Value.ToString() + "'");
			}
			if(map != null)
			{
				sb.AppendLine("`map`='" + map.Value.ToString() + "'");
			}
			if(zone != null)
			{
				sb.AppendLine("`zone`='" + zone.Value.ToString() + "'");
			}
			if(position_x != null)
			{
				sb.AppendLine("`position_x`='" + ((Decimal)position_x.Value).ToString() + "'");
			}
			if(position_y != null)
			{
				sb.AppendLine("`position_y`='" + ((Decimal)position_y.Value).ToString() + "'");
			}
			if(position_z != null)
			{
				sb.AppendLine("`position_z`='" + ((Decimal)position_z.Value).ToString() + "'");
			}
			if(orientation != null)
			{
				sb.AppendLine("`orientation`='" + ((Decimal)orientation.Value).ToString() + "'");
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

		public playercreateinfo() : base(TableName) 
        {
        }
	}
}
