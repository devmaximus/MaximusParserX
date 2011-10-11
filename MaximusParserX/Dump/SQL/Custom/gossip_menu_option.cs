using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class gossip_menu_option : CustomDumpObjectBase
    {
        public const string TableName = "gossip_menu_option";
        public System.UInt32? menu_id;
        public System.UInt32? id;
        public System.UInt32? option_icon;
        public System.String option_text;
        public System.Byte? option_id;
        public System.UInt32? npc_option_npcflag;
        public System.Int32? action_menu_id;
        public System.UInt32? action_poi_id;
        public System.UInt32? action_script_id;
        public System.Byte? box_coded;
        public System.UInt32? box_money;
        public System.String box_text;
        public System.Byte? cond_1;
        public System.UInt32? cond_1_val_1;
        public System.UInt32? cond_1_val_2;
        public System.Byte? cond_2;
        public System.UInt32? cond_2_val_1;
        public System.UInt32? cond_2_val_2;
        public System.Byte? cond_3;
        public System.UInt32? cond_3_val_1;
        public System.UInt32? cond_3_val_2;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`menu_id`, `id`, `option_icon`, `option_text`, `option_id`, `npc_option_npcflag`, `action_menu_id`, `action_poi_id`, `action_script_id`, `box_coded`, `box_money`, `box_text`, `cond_1`, `cond_1_val_1`, `cond_1_val_2`, `cond_2`, `cond_2_val_1`, `cond_2_val_2`, `cond_3`, `cond_3_val_1`, `cond_3_val_2`{21}) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}'{22});", menu_id.GetValueOrDefault(), id.GetValueOrDefault(), option_icon.GetValueOrDefault(), option_text.ToSQL(), option_id.GetValueOrDefault(), npc_option_npcflag.GetValueOrDefault(), action_menu_id.GetValueOrDefault(), action_poi_id.GetValueOrDefault(), action_script_id.GetValueOrDefault(), box_coded.GetValueOrDefault(), box_money.GetValueOrDefault(), box_text.ToSQL(), cond_1.GetValueOrDefault(), cond_1_val_1.GetValueOrDefault(), cond_1_val_2.GetValueOrDefault(), cond_2.GetValueOrDefault(), cond_2_val_1.GetValueOrDefault(), cond_2_val_2.GetValueOrDefault(), cond_3.GetValueOrDefault(), cond_3_val_1.GetValueOrDefault(), cond_3_val_2.GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

        public override string GetUpdateCommand()
        {
            var sb = new StringBuilder();
            sb.Append("UPDATE `" + TableName + "` SET ");

            if (option_icon != null)
            {
                sb.AppendLine("`option_icon`='" + option_icon.Value.ToString() + "'");
            }
            if (option_text != null)
            {
                sb.AppendLine("`option_text`='" + option_text.ToSQL() + "'");
            }
            if (option_id != null)
            {
                sb.AppendLine("`option_id`='" + option_id.Value.ToString() + "'");
            }
            if (npc_option_npcflag != null)
            {
                sb.AppendLine("`npc_option_npcflag`='" + npc_option_npcflag.Value.ToString() + "'");
            }
            if (action_menu_id != null)
            {
                sb.AppendLine("`action_menu_id`='" + action_menu_id.Value.ToString() + "'");
            }
            if (action_poi_id != null)
            {
                sb.AppendLine("`action_poi_id`='" + action_poi_id.Value.ToString() + "'");
            }
            if (action_script_id != null)
            {
                sb.AppendLine("`action_script_id`='" + action_script_id.Value.ToString() + "'");
            }
            if (box_coded != null)
            {
                sb.AppendLine("`box_coded`='" + box_coded.Value.ToString() + "'");
            }
            if (box_money != null)
            {
                sb.AppendLine("`box_money`='" + box_money.Value.ToString() + "'");
            }
            if (box_text != null)
            {
                sb.AppendLine("`box_text`='" + box_text.ToSQL() + "'");
            }
            if (cond_1 != null)
            {
                sb.AppendLine("`cond_1`='" + cond_1.Value.ToString() + "'");
            }
            if (cond_1_val_1 != null)
            {
                sb.AppendLine("`cond_1_val_1`='" + cond_1_val_1.Value.ToString() + "'");
            }
            if (cond_1_val_2 != null)
            {
                sb.AppendLine("`cond_1_val_2`='" + cond_1_val_2.Value.ToString() + "'");
            }
            if (cond_2 != null)
            {
                sb.AppendLine("`cond_2`='" + cond_2.Value.ToString() + "'");
            }
            if (cond_2_val_1 != null)
            {
                sb.AppendLine("`cond_2_val_1`='" + cond_2_val_1.Value.ToString() + "'");
            }
            if (cond_2_val_2 != null)
            {
                sb.AppendLine("`cond_2_val_2`='" + cond_2_val_2.Value.ToString() + "'");
            }
            if (cond_3 != null)
            {
                sb.AppendLine("`cond_3`='" + cond_3.Value.ToString() + "'");
            }
            if (cond_3_val_1 != null)
            {
                sb.AppendLine("`cond_3_val_1`='" + cond_3_val_1.Value.ToString() + "'");
            }
            if (cond_3_val_2 != null)
            {
                sb.AppendLine("`cond_3_val_2`='" + cond_3_val_2.Value.ToString() + "'");
            }
            sb = sb.Replace("\r\n", ", ");
            sb.Append(" WHERE `menu_id`='" + menu_id.Value.ToString() + "' AND `id`='" + id.Value.ToString() + "';");
            sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
        }

        public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `menu_id`='" + menu_id.Value.ToString() + "';");
        }

		public gossip_menu_option() : base(TableName) 
        {
        }
	}
}
