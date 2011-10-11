using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class playercreateinfo_item : DumpObjectBase
    {
        public const string TableName = "playercreateinfo_item";
		public System.Byte? race;
		public System.Byte? class_;
		public System.UInt32? itemid;
		public System.Byte? amount;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`race`, `class`, `itemid`, `amount`) VALUES ('{0}', '{1}', '{2}', '{3}');", race.GetValueOrDefault(), class_.GetValueOrDefault(), itemid.GetValueOrDefault(), amount.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(class_ != null)
			{
				sb.AppendLine("`class`='" + class_.Value.ToString() + "'");
			}
			if(itemid != null)
			{
				sb.AppendLine("`itemid`='" + itemid.Value.ToString() + "'");
			}
			if(amount != null)
			{
				sb.AppendLine("`amount`='" + amount.Value.ToString() + "'");
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

		public playercreateinfo_item() : base(TableName) 
        {
        }
	}
}
