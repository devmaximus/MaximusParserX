using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class exploration_basexp : DumpObjectBase
    {
        public const string TableName = "exploration_basexp";
		public System.SByte? level;
		public System.Int32? basexp;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`level`, `basexp`) VALUES ('{0}', '{1}');", level.GetValueOrDefault(), basexp.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(basexp != null)
			{
				sb.AppendLine("`basexp`='" + basexp.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `level`='" + level.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `level`='" + level.Value.ToString() + "';");
        }

		public exploration_basexp() : base(TableName) 
        {
        }
	}
}
