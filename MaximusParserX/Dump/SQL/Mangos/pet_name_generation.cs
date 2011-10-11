using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class pet_name_generation : DumpObjectBase
    {
        public const string TableName = "pet_name_generation";
		public System.UInt32? id;
		public System.String word;
		public System.UInt32? entry;
		public System.SByte? half;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `word`, `entry`, `half`) VALUES ('{0}', '{1}', '{2}', '{3}');", id.GetValueOrDefault(), word.ToSQL(), entry.GetValueOrDefault(), half.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(word != null)
			{
				sb.AppendLine("`word`='" + word.ToSQL() + "'");
			}
			if(entry != null)
			{
				sb.AppendLine("`entry`='" + entry.Value.ToString() + "'");
			}
			if(half != null)
			{
				sb.AppendLine("`half`='" + half.Value.ToString() + "'");
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

		public pet_name_generation() : base(TableName) 
        {
        }
	}
}
