using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_movement : DumpObjectBase
    {
        public const string TableName = "creature_movement";
		public System.UInt32? id;
		public System.UInt32? point;
		public System.Single? position_x;
		public System.Single? position_y;
		public System.Single? position_z;
		public System.UInt32? waittime;
		public System.UInt32? script_id;
		public System.Int32? textid1;
		public System.Int32? textid2;
		public System.Int32? textid3;
		public System.Int32? textid4;
		public System.Int32? textid5;
		public System.UInt32? emote;
		public System.UInt32? spell;
		public System.Int32? wpguid;
		public System.Single? orientation;
		public System.Int32? model1;
		public System.Int32? model2;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `point`, `position_x`, `position_y`, `position_z`, `waittime`, `script_id`, `textid1`, `textid2`, `textid3`, `textid4`, `textid5`, `emote`, `spell`, `wpguid`, `orientation`, `model1`, `model2`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');", id.GetValueOrDefault(), point.GetValueOrDefault(), ((Decimal)position_x.GetValueOrDefault()), ((Decimal)position_y.GetValueOrDefault()), ((Decimal)position_z.GetValueOrDefault()), waittime.GetValueOrDefault(), script_id.GetValueOrDefault(), textid1.GetValueOrDefault(), textid2.GetValueOrDefault(), textid3.GetValueOrDefault(), textid4.GetValueOrDefault(), textid5.GetValueOrDefault(), emote.GetValueOrDefault(), spell.GetValueOrDefault(), wpguid.GetValueOrDefault(), ((Decimal)orientation.GetValueOrDefault()), model1.GetValueOrDefault(), model2.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(point != null)
			{
				sb.AppendLine("`point`='" + point.Value.ToString() + "'");
			}
			if(position_x != null)
			{
				sb.AppendLine("`position_x`='" + ((Decimal)position_x.Value).ToString() + "'");
			}
			if(position_y != null)
			{
				sb.AppendLine("`position_y`='" + ((Decimal)position_y.Value).ToString() + "'");
			}
			if(position_z != null)
			{
				sb.AppendLine("`position_z`='" + ((Decimal)position_z.Value).ToString() + "'");
			}
			if(waittime != null)
			{
				sb.AppendLine("`waittime`='" + waittime.Value.ToString() + "'");
			}
			if(script_id != null)
			{
				sb.AppendLine("`script_id`='" + script_id.Value.ToString() + "'");
			}
			if(textid1 != null)
			{
				sb.AppendLine("`textid1`='" + textid1.Value.ToString() + "'");
			}
			if(textid2 != null)
			{
				sb.AppendLine("`textid2`='" + textid2.Value.ToString() + "'");
			}
			if(textid3 != null)
			{
				sb.AppendLine("`textid3`='" + textid3.Value.ToString() + "'");
			}
			if(textid4 != null)
			{
				sb.AppendLine("`textid4`='" + textid4.Value.ToString() + "'");
			}
			if(textid5 != null)
			{
				sb.AppendLine("`textid5`='" + textid5.Value.ToString() + "'");
			}
			if(emote != null)
			{
				sb.AppendLine("`emote`='" + emote.Value.ToString() + "'");
			}
			if(spell != null)
			{
				sb.AppendLine("`spell`='" + spell.Value.ToString() + "'");
			}
			if(wpguid != null)
			{
				sb.AppendLine("`wpguid`='" + wpguid.Value.ToString() + "'");
			}
			if(orientation != null)
			{
				sb.AppendLine("`orientation`='" + ((Decimal)orientation.Value).ToString() + "'");
			}
			if(model1 != null)
			{
				sb.AppendLine("`model1`='" + model1.Value.ToString() + "'");
			}
			if(model2 != null)
			{
				sb.AppendLine("`model2`='" + model2.Value.ToString() + "'");
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

		public creature_movement() : base(TableName) 
        {
        }
	}
}
