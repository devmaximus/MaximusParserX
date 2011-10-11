using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class playercreateinfo_action : DumpObjectBase
    {
        public const string TableName = "playercreateinfo_action";
		public System.Byte? race;
		public System.Byte? class_;
		public System.UInt16? button;
		public System.UInt32? action;
		public System.UInt16? type;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`race`, `class`, `button`, `action`, `type`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", race.GetValueOrDefault(), class_.GetValueOrDefault(), button.GetValueOrDefault(), action.GetValueOrDefault(), type.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(class_ != null)
			{
				sb.AppendLine("`class`='" + class_.Value.ToString() + "'");
			}
			if(button != null)
			{
				sb.AppendLine("`button`='" + button.Value.ToString() + "'");
			}
			if(action != null)
			{
				sb.AppendLine("`action`='" + action.Value.ToString() + "'");
			}
			if(type != null)
			{
				sb.AppendLine("`type`='" + type.Value.ToString() + "'");
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

		public playercreateinfo_action() : base(TableName) 
        {
        }
	}
}
