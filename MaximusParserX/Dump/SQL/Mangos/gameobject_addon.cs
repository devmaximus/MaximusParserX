using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class gameobject_addon : DumpObjectBase
    {
        public const string TableName = "gameobject_addon";
		public System.UInt32? guid;
		public System.Single? path_rotation0;
		public System.Single? path_rotation1;
		public System.Single? path_rotation2;
		public System.Single? path_rotation3;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`guid`, `path_rotation0`, `path_rotation1`, `path_rotation2`, `path_rotation3`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", guid.GetValueOrDefault(), ((Decimal)path_rotation0.GetValueOrDefault()), ((Decimal)path_rotation1.GetValueOrDefault()), ((Decimal)path_rotation2.GetValueOrDefault()), ((Decimal)path_rotation3.GetValueOrDefault()));
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(path_rotation0 != null)
			{
				sb.AppendLine("`path_rotation0`='" + ((Decimal)path_rotation0.Value).ToString() + "'");
			}
			if(path_rotation1 != null)
			{
				sb.AppendLine("`path_rotation1`='" + ((Decimal)path_rotation1.Value).ToString() + "'");
			}
			if(path_rotation2 != null)
			{
				sb.AppendLine("`path_rotation2`='" + ((Decimal)path_rotation2.Value).ToString() + "'");
			}
			if(path_rotation3 != null)
			{
				sb.AppendLine("`path_rotation3`='" + ((Decimal)path_rotation3.Value).ToString() + "'");
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

		public gameobject_addon() : base(TableName) 
        {
        }
	}
}
