using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_onkill_reputation : DumpObjectBase
    {
        public const string TableName = "creature_onkill_reputation";
		public System.UInt32? creature_id;
		public System.Int16? rewonkillrepfaction1;
		public System.Int16? rewonkillrepfaction2;
		public System.SByte? maxstanding1;
		public System.SByte? isteamaward1;
		public System.Int32? rewonkillrepvalue1;
		public System.SByte? maxstanding2;
		public System.SByte? isteamaward2;
		public System.Int32? rewonkillrepvalue2;
		public System.Byte? teamdependent;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`creature_id`, `rewonkillrepfaction1`, `rewonkillrepfaction2`, `maxstanding1`, `isteamaward1`, `rewonkillrepvalue1`, `maxstanding2`, `isteamaward2`, `rewonkillrepvalue2`, `teamdependent`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');", creature_id.GetValueOrDefault(), rewonkillrepfaction1.GetValueOrDefault(), rewonkillrepfaction2.GetValueOrDefault(), maxstanding1.GetValueOrDefault(), isteamaward1.GetValueOrDefault(), rewonkillrepvalue1.GetValueOrDefault(), maxstanding2.GetValueOrDefault(), isteamaward2.GetValueOrDefault(), rewonkillrepvalue2.GetValueOrDefault(), teamdependent.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(rewonkillrepfaction1 != null)
			{
				sb.AppendLine("`rewonkillrepfaction1`='" + rewonkillrepfaction1.Value.ToString() + "'");
			}
			if(rewonkillrepfaction2 != null)
			{
				sb.AppendLine("`rewonkillrepfaction2`='" + rewonkillrepfaction2.Value.ToString() + "'");
			}
			if(maxstanding1 != null)
			{
				sb.AppendLine("`maxstanding1`='" + maxstanding1.Value.ToString() + "'");
			}
			if(isteamaward1 != null)
			{
				sb.AppendLine("`isteamaward1`='" + isteamaward1.Value.ToString() + "'");
			}
			if(rewonkillrepvalue1 != null)
			{
				sb.AppendLine("`rewonkillrepvalue1`='" + rewonkillrepvalue1.Value.ToString() + "'");
			}
			if(maxstanding2 != null)
			{
				sb.AppendLine("`maxstanding2`='" + maxstanding2.Value.ToString() + "'");
			}
			if(isteamaward2 != null)
			{
				sb.AppendLine("`isteamaward2`='" + isteamaward2.Value.ToString() + "'");
			}
			if(rewonkillrepvalue2 != null)
			{
				sb.AppendLine("`rewonkillrepvalue2`='" + rewonkillrepvalue2.Value.ToString() + "'");
			}
			if(teamdependent != null)
			{
				sb.AppendLine("`teamdependent`='" + teamdependent.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `creature_id`='" + creature_id.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `creature_id`='" + creature_id.Value.ToString() + "';");
        }

		public creature_onkill_reputation() : base(TableName) 
        {
        }
	}
}
