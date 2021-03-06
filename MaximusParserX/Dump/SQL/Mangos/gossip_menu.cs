using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class gossip_menu : DumpObjectBase
    {
        public const string TableName = "gossip_menu";
		public System.UInt16? entry;
		public System.UInt32? text_id;
		public System.Byte? cond_1;
		public System.UInt32? cond_1_val_1;
		public System.UInt32? cond_1_val_2;
		public System.Byte? cond_2;
		public System.UInt32? cond_2_val_1;
		public System.UInt32? cond_2_val_2;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `text_id`, `cond_1`, `cond_1_val_1`, `cond_1_val_2`, `cond_2`, `cond_2_val_1`, `cond_2_val_2`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", entry.GetValueOrDefault(), text_id.GetValueOrDefault(), cond_1.GetValueOrDefault(), cond_1_val_1.GetValueOrDefault(), cond_1_val_2.GetValueOrDefault(), cond_2.GetValueOrDefault(), cond_2_val_1.GetValueOrDefault(), cond_2_val_2.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(text_id != null)
			{
				sb.AppendLine("`text_id`='" + text_id.Value.ToString() + "'");
			}
			if(cond_1 != null)
			{
				sb.AppendLine("`cond_1`='" + cond_1.Value.ToString() + "'");
			}
			if(cond_1_val_1 != null)
			{
				sb.AppendLine("`cond_1_val_1`='" + cond_1_val_1.Value.ToString() + "'");
			}
			if(cond_1_val_2 != null)
			{
				sb.AppendLine("`cond_1_val_2`='" + cond_1_val_2.Value.ToString() + "'");
			}
			if(cond_2 != null)
			{
				sb.AppendLine("`cond_2`='" + cond_2.Value.ToString() + "'");
			}
			if(cond_2_val_1 != null)
			{
				sb.AppendLine("`cond_2_val_1`='" + cond_2_val_1.Value.ToString() + "'");
			}
			if(cond_2_val_2 != null)
			{
				sb.AppendLine("`cond_2_val_2`='" + cond_2_val_2.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `entry`='" + entry.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `entry`='" + entry.Value.ToString() + "';");
        }

		public gossip_menu() : base(TableName) 
        {
        }
	}
}
