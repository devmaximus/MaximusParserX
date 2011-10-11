using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class quest_poi_points : CustomDumpObjectBase
    {
        public const string TableName = "quest_poi_points";
		public System.UInt32? questid;
		public System.SByte? poiid;
		public System.Int32? x;
		public System.Int32? y;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`questid`, `poiid`, `x`, `y`{4}) VALUES ('{0}', '{1}', '{2}', '{3}'{5});", questid.GetValueOrDefault(), poiid.GetValueOrDefault(), x.GetValueOrDefault(), y.GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(poiid != null)
			{
				sb.AppendLine("`poiid`='" + poiid.Value.ToString() + "'");
			}
			if(x != null)
			{
				sb.AppendLine("`x`='" + x.Value.ToString() + "'");
			}
			if(y != null)
			{
				sb.AppendLine("`y`='" + y.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `questid`='" + questid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `questid`='" + questid.Value.ToString() + "';");
        }

		public quest_poi_points() : base(TableName) 
        {
        }
	}
}
