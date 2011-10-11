using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class gameobject_involvedrelation : DumpObjectBase
    {
        public const string TableName = "gameobject_involvedrelation";
		public System.UInt32? id;
		public System.UInt32? quest;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `quest`) VALUES ('{0}', '{1}');", id.GetValueOrDefault(), quest.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(quest != null)
			{
				sb.AppendLine("`quest`='" + quest.Value.ToString() + "'");
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

		public gameobject_involvedrelation() : base(TableName) 
        {
        }
	}
}
