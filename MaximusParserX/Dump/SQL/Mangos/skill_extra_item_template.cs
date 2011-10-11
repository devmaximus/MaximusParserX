using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class skill_extra_item_template : DumpObjectBase
    {
        public const string TableName = "skill_extra_item_template";
		public System.UInt32? spellid;
		public System.UInt32? requiredspecialization;
		public System.Single? additionalcreatechance;
		public System.Byte? additionalmaxnum;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`spellid`, `requiredspecialization`, `additionalcreatechance`, `additionalmaxnum`) VALUES ('{0}', '{1}', '{2}', '{3}');", spellid.GetValueOrDefault(), requiredspecialization.GetValueOrDefault(), ((Decimal)additionalcreatechance.GetValueOrDefault()), additionalmaxnum.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(requiredspecialization != null)
			{
				sb.AppendLine("`requiredspecialization`='" + requiredspecialization.Value.ToString() + "'");
			}
			if(additionalcreatechance != null)
			{
				sb.AppendLine("`additionalcreatechance`='" + ((Decimal)additionalcreatechance.Value).ToString() + "'");
			}
			if(additionalmaxnum != null)
			{
				sb.AppendLine("`additionalmaxnum`='" + additionalmaxnum.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `spellid`='" + spellid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `spellid`='" + spellid.Value.ToString() + "';");
        }

		public skill_extra_item_template() : base(TableName) 
        {
        }
	}
}
