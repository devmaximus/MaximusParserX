using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class gameobject_battleground : DumpObjectBase
    {
        public const string TableName = "gameobject_battleground";
		public System.UInt32? guid;
		public System.Byte? event1;
		public System.Byte? event2;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`guid`, `event1`, `event2`) VALUES ('{0}', '{1}', '{2}');", guid.GetValueOrDefault(), event1.GetValueOrDefault(), event2.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(event1 != null)
			{
				sb.AppendLine("`event1`='" + event1.Value.ToString() + "'");
			}
			if(event2 != null)
			{
				sb.AppendLine("`event2`='" + event2.Value.ToString() + "'");
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

		public gameobject_battleground() : base(TableName) 
        {
        }
	}
}
