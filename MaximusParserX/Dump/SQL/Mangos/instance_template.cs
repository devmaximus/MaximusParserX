using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class instance_template : DumpObjectBase
    {
        public const string TableName = "instance_template";
		public System.UInt16? map;
		public System.UInt16? parent;
		public System.Byte? levelmin;
		public System.Byte? levelmax;
		public System.String scriptname;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`map`, `parent`, `levelmin`, `levelmax`, `scriptname`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", map.GetValueOrDefault(), parent.GetValueOrDefault(), levelmin.GetValueOrDefault(), levelmax.GetValueOrDefault(), scriptname.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(parent != null)
			{
				sb.AppendLine("`parent`='" + parent.Value.ToString() + "'");
			}
			if(levelmin != null)
			{
				sb.AppendLine("`levelmin`='" + levelmin.Value.ToString() + "'");
			}
			if(levelmax != null)
			{
				sb.AppendLine("`levelmax`='" + levelmax.Value.ToString() + "'");
			}
			if(scriptname != null)
			{
				sb.AppendLine("`scriptname`='" + scriptname.ToSQL() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `map`='" + map.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `map`='" + map.Value.ToString() + "';");
        }

		public instance_template() : base(TableName) 
        {
        }
	}
}
