using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_gossip_menu_option : DumpObjectBase
    {
        public const string TableName = "locales_gossip_menu_option";
		public System.UInt16? menu_id;
		public System.UInt16? id;
		public System.String option_text_loc1;
		public System.String option_text_loc2;
		public System.String option_text_loc3;
		public System.String option_text_loc4;
		public System.String option_text_loc5;
		public System.String option_text_loc6;
		public System.String option_text_loc7;
		public System.String option_text_loc8;
		public System.String box_text_loc1;
		public System.String box_text_loc2;
		public System.String box_text_loc3;
		public System.String box_text_loc4;
		public System.String box_text_loc5;
		public System.String box_text_loc6;
		public System.String box_text_loc7;
		public System.String box_text_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`menu_id`, `id`, `option_text_loc1`, `option_text_loc2`, `option_text_loc3`, `option_text_loc4`, `option_text_loc5`, `option_text_loc6`, `option_text_loc7`, `option_text_loc8`, `box_text_loc1`, `box_text_loc2`, `box_text_loc3`, `box_text_loc4`, `box_text_loc5`, `box_text_loc6`, `box_text_loc7`, `box_text_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');", menu_id.GetValueOrDefault(), id.GetValueOrDefault(), option_text_loc1.ToSQL(), option_text_loc2.ToSQL(), option_text_loc3.ToSQL(), option_text_loc4.ToSQL(), option_text_loc5.ToSQL(), option_text_loc6.ToSQL(), option_text_loc7.ToSQL(), option_text_loc8.ToSQL(), box_text_loc1.ToSQL(), box_text_loc2.ToSQL(), box_text_loc3.ToSQL(), box_text_loc4.ToSQL(), box_text_loc5.ToSQL(), box_text_loc6.ToSQL(), box_text_loc7.ToSQL(), box_text_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(id != null)
			{
				sb.AppendLine("`id`='" + id.Value.ToString() + "'");
			}
			if(option_text_loc1 != null)
			{
				sb.AppendLine("`option_text_loc1`='" + option_text_loc1.ToSQL() + "'");
			}
			if(option_text_loc2 != null)
			{
				sb.AppendLine("`option_text_loc2`='" + option_text_loc2.ToSQL() + "'");
			}
			if(option_text_loc3 != null)
			{
				sb.AppendLine("`option_text_loc3`='" + option_text_loc3.ToSQL() + "'");
			}
			if(option_text_loc4 != null)
			{
				sb.AppendLine("`option_text_loc4`='" + option_text_loc4.ToSQL() + "'");
			}
			if(option_text_loc5 != null)
			{
				sb.AppendLine("`option_text_loc5`='" + option_text_loc5.ToSQL() + "'");
			}
			if(option_text_loc6 != null)
			{
				sb.AppendLine("`option_text_loc6`='" + option_text_loc6.ToSQL() + "'");
			}
			if(option_text_loc7 != null)
			{
				sb.AppendLine("`option_text_loc7`='" + option_text_loc7.ToSQL() + "'");
			}
			if(option_text_loc8 != null)
			{
				sb.AppendLine("`option_text_loc8`='" + option_text_loc8.ToSQL() + "'");
			}
			if(box_text_loc1 != null)
			{
				sb.AppendLine("`box_text_loc1`='" + box_text_loc1.ToSQL() + "'");
			}
			if(box_text_loc2 != null)
			{
				sb.AppendLine("`box_text_loc2`='" + box_text_loc2.ToSQL() + "'");
			}
			if(box_text_loc3 != null)
			{
				sb.AppendLine("`box_text_loc3`='" + box_text_loc3.ToSQL() + "'");
			}
			if(box_text_loc4 != null)
			{
				sb.AppendLine("`box_text_loc4`='" + box_text_loc4.ToSQL() + "'");
			}
			if(box_text_loc5 != null)
			{
				sb.AppendLine("`box_text_loc5`='" + box_text_loc5.ToSQL() + "'");
			}
			if(box_text_loc6 != null)
			{
				sb.AppendLine("`box_text_loc6`='" + box_text_loc6.ToSQL() + "'");
			}
			if(box_text_loc7 != null)
			{
				sb.AppendLine("`box_text_loc7`='" + box_text_loc7.ToSQL() + "'");
			}
			if(box_text_loc8 != null)
			{
				sb.AppendLine("`box_text_loc8`='" + box_text_loc8.ToSQL() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `menu_id`='" + menu_id.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `menu_id`='" + menu_id.Value.ToString() + "';");
        }

		public locales_gossip_menu_option() : base(TableName) 
        {
        }
	}
}
