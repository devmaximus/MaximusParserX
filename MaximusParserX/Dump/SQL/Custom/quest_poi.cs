using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class quest_poi : CustomDumpObjectBase
    {
        public const string TableName = "quest_poi";
		public System.UInt32? questid;
		public System.SByte? poiid;
		public System.Int32? objindex;
		public System.UInt32? mapid;
		public System.UInt32? mapareaid;
		public System.Byte? floorid;
		public System.UInt32? unk3;
		public System.UInt32? unk4;

        public IDictionary<string, quest_poi_points> quest_poi_points { get; set; }

		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`questid`, `poiid`, `objindex`, `mapid`, `mapareaid`, `floorid`, `unk3`, `unk4`{8}) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'{9});", questid.GetValueOrDefault(), poiid.GetValueOrDefault(), objindex.GetValueOrDefault(), mapid.GetValueOrDefault(), mapareaid.GetValueOrDefault(), floorid.GetValueOrDefault(), unk3.GetValueOrDefault(), unk4.GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(poiid != null)
			{
				sb.AppendLine("`poiid`='" + poiid.Value.ToString() + "'");
			}
			if(objindex != null)
			{
				sb.AppendLine("`objindex`='" + objindex.Value.ToString() + "'");
			}
			if(mapid != null)
			{
				sb.AppendLine("`mapid`='" + mapid.Value.ToString() + "'");
			}
			if(mapareaid != null)
			{
				sb.AppendLine("`mapareaid`='" + mapareaid.Value.ToString() + "'");
			}
			if(floorid != null)
			{
				sb.AppendLine("`floorid`='" + floorid.Value.ToString() + "'");
			}
			if(unk3 != null)
			{
				sb.AppendLine("`unk3`='" + unk3.Value.ToString() + "'");
			}
			if(unk4 != null)
			{
				sb.AppendLine("`unk4`='" + unk4.Value.ToString() + "'");
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

		public quest_poi() : base(TableName) 
        {
        }
	}
}
