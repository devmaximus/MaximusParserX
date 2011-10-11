using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class scripted_event_id : DumpObjectBase
    {
        public const string TableName = "scripted_event_id";
		public System.Int32? id;
		public System.String scriptname;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `scriptname`) VALUES ('{0}', '{1}');", id.GetValueOrDefault(), scriptname.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(scriptname != null)
			{
				sb.AppendLine("`scriptname`='" + scriptname.ToSQL() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `id`='" + id.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `id`='" + id.Value.ToString() + "';");
        }

		public scripted_event_id() : base(TableName) 
        {
        }
	}
}
