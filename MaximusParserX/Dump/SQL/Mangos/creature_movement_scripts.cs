using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_movement_scripts : DumpObjectBase
    {
        public const string TableName = "creature_movement_scripts";
		public System.UInt32? id;
		public System.UInt32? delay;
		public System.UInt32? command;
		public System.UInt32? datalong;
		public System.UInt32? datalong2;
		public System.UInt32? datalong3;
		public System.UInt32? datalong4;
		public System.Byte? data_flags;
		public System.Int32? dataint;
		public System.Int32? dataint2;
		public System.Int32? dataint3;
		public System.Int32? dataint4;
		public System.Single? x;
		public System.Single? y;
		public System.Single? z;
		public System.Single? o;
		public System.String comments;

		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `delay`, `command`, `datalong`, `datalong2`, `datalong3`, `datalong4`, `data_flags`, `dataint`, `dataint2`, `dataint3`, `dataint4`, `x`, `y`, `z`, `o`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');", id.GetValueOrDefault(), delay.GetValueOrDefault(), command.GetValueOrDefault(), datalong.GetValueOrDefault(), datalong2.GetValueOrDefault(), datalong3.GetValueOrDefault(), datalong4.GetValueOrDefault(), data_flags.GetValueOrDefault(), dataint.GetValueOrDefault(), dataint2.GetValueOrDefault(), dataint3.GetValueOrDefault(), dataint4.GetValueOrDefault(), ((Decimal)x.GetValueOrDefault()), ((Decimal)y.GetValueOrDefault()), ((Decimal)z.GetValueOrDefault()), ((Decimal)o.GetValueOrDefault()), comments.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(delay != null)
			{
				sb.AppendLine("`delay`='" + delay.Value.ToString() + "'");
			}
			if(command != null)
			{
				sb.AppendLine("`command`='" + command.Value.ToString() + "'");
			}
			if(datalong != null)
			{
				sb.AppendLine("`datalong`='" + datalong.Value.ToString() + "'");
			}
			if(datalong2 != null)
			{
				sb.AppendLine("`datalong2`='" + datalong2.Value.ToString() + "'");
			}
			if(datalong3 != null)
			{
				sb.AppendLine("`datalong3`='" + datalong3.Value.ToString() + "'");
			}
			if(datalong4 != null)
			{
				sb.AppendLine("`datalong4`='" + datalong4.Value.ToString() + "'");
			}
			if(data_flags != null)
			{
				sb.AppendLine("`data_flags`='" + data_flags.Value.ToString() + "'");
			}
			if(dataint != null)
			{
				sb.AppendLine("`dataint`='" + dataint.Value.ToString() + "'");
			}
			if(dataint2 != null)
			{
				sb.AppendLine("`dataint2`='" + dataint2.Value.ToString() + "'");
			}
			if(dataint3 != null)
			{
				sb.AppendLine("`dataint3`='" + dataint3.Value.ToString() + "'");
			}
			if(dataint4 != null)
			{
				sb.AppendLine("`dataint4`='" + dataint4.Value.ToString() + "'");
			}
			if(x != null)
			{
				sb.AppendLine("`x`='" + ((Decimal)x.Value).ToString() + "'");
			}
			if(y != null)
			{
				sb.AppendLine("`y`='" + ((Decimal)y.Value).ToString() + "'");
			}
			if(z != null)
			{
				sb.AppendLine("`z`='" + ((Decimal)z.Value).ToString() + "'");
			}
			if(o != null)
			{
				sb.AppendLine("`o`='" + ((Decimal)o.Value).ToString() + "'");
			}
			if(comments != null)
			{
				sb.AppendLine("`comments`='" + comments.ToSQL() + "'");
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

		public creature_movement_scripts() : base(TableName) 
        {
        }
	}
}
