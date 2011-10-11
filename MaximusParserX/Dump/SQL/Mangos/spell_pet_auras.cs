using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_pet_auras : DumpObjectBase
    {
        public const string TableName = "spell_pet_auras";
		public System.UInt32? spell;
		public System.Byte? effectid;
		public System.UInt32? pet;
		public System.UInt32? aura;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`spell`, `effectid`, `pet`, `aura`) VALUES ('{0}', '{1}', '{2}', '{3}');", spell.GetValueOrDefault(), effectid.GetValueOrDefault(), pet.GetValueOrDefault(), aura.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(effectid != null)
			{
				sb.AppendLine("`effectid`='" + effectid.Value.ToString() + "'");
			}
			if(pet != null)
			{
				sb.AppendLine("`pet`='" + pet.Value.ToString() + "'");
			}
			if(aura != null)
			{
				sb.AppendLine("`aura`='" + aura.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `spell`='" + spell.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `spell`='" + spell.Value.ToString() + "';");
        }

		public spell_pet_auras() : base(TableName) 
        {
        }
	}
}
