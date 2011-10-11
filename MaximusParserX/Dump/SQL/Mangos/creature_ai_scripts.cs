using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_ai_scripts : DumpObjectBase
    {
        public const string TableName = "creature_ai_scripts";
		public System.UInt32? id;
		public System.UInt32? creature_id;
		public System.Byte? event_type;
		public System.Int32? event_inverse_phase_mask;
		public System.UInt32? event_chance;
		public System.UInt32? event_flags;
		public System.Int32? event_param1;
		public System.Int32? event_param2;
		public System.Int32? event_param3;
		public System.Int32? event_param4;
		public System.Byte? action1_type;
		public System.Int32? action1_param1;
		public System.Int32? action1_param2;
		public System.Int32? action1_param3;
		public System.Byte? action2_type;
		public System.Int32? action2_param1;
		public System.Int32? action2_param2;
		public System.Int32? action2_param3;
		public System.Byte? action3_type;
		public System.Int32? action3_param1;
		public System.Int32? action3_param2;
		public System.Int32? action3_param3;
		public System.String comment;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `creature_id`, `event_type`, `event_inverse_phase_mask`, `event_chance`, `event_flags`, `event_param1`, `event_param2`, `event_param3`, `event_param4`, `action1_type`, `action1_param1`, `action1_param2`, `action1_param3`, `action2_type`, `action2_param1`, `action2_param2`, `action2_param3`, `action3_type`, `action3_param1`, `action3_param2`, `action3_param3`, `comment`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');", id.GetValueOrDefault(), creature_id.GetValueOrDefault(), event_type.GetValueOrDefault(), event_inverse_phase_mask.GetValueOrDefault(), event_chance.GetValueOrDefault(), event_flags.GetValueOrDefault(), event_param1.GetValueOrDefault(), event_param2.GetValueOrDefault(), event_param3.GetValueOrDefault(), event_param4.GetValueOrDefault(), action1_type.GetValueOrDefault(), action1_param1.GetValueOrDefault(), action1_param2.GetValueOrDefault(), action1_param3.GetValueOrDefault(), action2_type.GetValueOrDefault(), action2_param1.GetValueOrDefault(), action2_param2.GetValueOrDefault(), action2_param3.GetValueOrDefault(), action3_type.GetValueOrDefault(), action3_param1.GetValueOrDefault(), action3_param2.GetValueOrDefault(), action3_param3.GetValueOrDefault(), comment.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(creature_id != null)
			{
				sb.AppendLine("`creature_id`='" + creature_id.Value.ToString() + "'");
			}
			if(event_type != null)
			{
				sb.AppendLine("`event_type`='" + event_type.Value.ToString() + "'");
			}
			if(event_inverse_phase_mask != null)
			{
				sb.AppendLine("`event_inverse_phase_mask`='" + event_inverse_phase_mask.Value.ToString() + "'");
			}
			if(event_chance != null)
			{
				sb.AppendLine("`event_chance`='" + event_chance.Value.ToString() + "'");
			}
			if(event_flags != null)
			{
				sb.AppendLine("`event_flags`='" + event_flags.Value.ToString() + "'");
			}
			if(event_param1 != null)
			{
				sb.AppendLine("`event_param1`='" + event_param1.Value.ToString() + "'");
			}
			if(event_param2 != null)
			{
				sb.AppendLine("`event_param2`='" + event_param2.Value.ToString() + "'");
			}
			if(event_param3 != null)
			{
				sb.AppendLine("`event_param3`='" + event_param3.Value.ToString() + "'");
			}
			if(event_param4 != null)
			{
				sb.AppendLine("`event_param4`='" + event_param4.Value.ToString() + "'");
			}
			if(action1_type != null)
			{
				sb.AppendLine("`action1_type`='" + action1_type.Value.ToString() + "'");
			}
			if(action1_param1 != null)
			{
				sb.AppendLine("`action1_param1`='" + action1_param1.Value.ToString() + "'");
			}
			if(action1_param2 != null)
			{
				sb.AppendLine("`action1_param2`='" + action1_param2.Value.ToString() + "'");
			}
			if(action1_param3 != null)
			{
				sb.AppendLine("`action1_param3`='" + action1_param3.Value.ToString() + "'");
			}
			if(action2_type != null)
			{
				sb.AppendLine("`action2_type`='" + action2_type.Value.ToString() + "'");
			}
			if(action2_param1 != null)
			{
				sb.AppendLine("`action2_param1`='" + action2_param1.Value.ToString() + "'");
			}
			if(action2_param2 != null)
			{
				sb.AppendLine("`action2_param2`='" + action2_param2.Value.ToString() + "'");
			}
			if(action2_param3 != null)
			{
				sb.AppendLine("`action2_param3`='" + action2_param3.Value.ToString() + "'");
			}
			if(action3_type != null)
			{
				sb.AppendLine("`action3_type`='" + action3_type.Value.ToString() + "'");
			}
			if(action3_param1 != null)
			{
				sb.AppendLine("`action3_param1`='" + action3_param1.Value.ToString() + "'");
			}
			if(action3_param2 != null)
			{
				sb.AppendLine("`action3_param2`='" + action3_param2.Value.ToString() + "'");
			}
			if(action3_param3 != null)
			{
				sb.AppendLine("`action3_param3`='" + action3_param3.Value.ToString() + "'");
			}
			if(comment != null)
			{
				sb.AppendLine("`comment`='" + comment.ToSQL() + "'");
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

		public creature_ai_scripts() : base(TableName) 
        {
        }
	}
}
