using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class gameobject : DumpObjectBase
    {
        public const string TableName = "gameobject";
		public System.UInt32? guid;
		public System.UInt32? id;
		public System.UInt16? map;
		public System.Byte? spawnmask;
		public System.UInt16? phasemask;
		public System.Single? position_x;
		public System.Single? position_y;
		public System.Single? position_z;
		public System.Single? orientation;
		public System.Single? rotation0;
		public System.Single? rotation1;
		public System.Single? rotation2;
		public System.Single? rotation3;
		public System.Int32? spawntimesecs;
		public System.Byte? animprogress;
		public System.Byte? state;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`guid`, `id`, `map`, `spawnmask`, `phasemask`, `position_x`, `position_y`, `position_z`, `orientation`, `rotation0`, `rotation1`, `rotation2`, `rotation3`, `spawntimesecs`, `animprogress`, `state`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');", guid.GetValueOrDefault(), id.GetValueOrDefault(), map.GetValueOrDefault(), spawnmask.GetValueOrDefault(), phasemask.GetValueOrDefault(), ((Decimal)position_x.GetValueOrDefault()), ((Decimal)position_y.GetValueOrDefault()), ((Decimal)position_z.GetValueOrDefault()), ((Decimal)orientation.GetValueOrDefault()), ((Decimal)rotation0.GetValueOrDefault()), ((Decimal)rotation1.GetValueOrDefault()), ((Decimal)rotation2.GetValueOrDefault()), ((Decimal)rotation3.GetValueOrDefault()), spawntimesecs.GetValueOrDefault(), animprogress.GetValueOrDefault(), state.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(id != null)
			{
				sb.AppendLine("`id`='" + id.Value.ToString() + "'");
			}
			if(map != null)
			{
				sb.AppendLine("`map`='" + map.Value.ToString() + "'");
			}
			if(spawnmask != null)
			{
				sb.AppendLine("`spawnmask`='" + spawnmask.Value.ToString() + "'");
			}
			if(phasemask != null)
			{
				sb.AppendLine("`phasemask`='" + phasemask.Value.ToString() + "'");
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
			if(orientation != null)
			{
				sb.AppendLine("`orientation`='" + ((Decimal)orientation.Value).ToString() + "'");
			}
			if(rotation0 != null)
			{
				sb.AppendLine("`rotation0`='" + ((Decimal)rotation0.Value).ToString() + "'");
			}
			if(rotation1 != null)
			{
				sb.AppendLine("`rotation1`='" + ((Decimal)rotation1.Value).ToString() + "'");
			}
			if(rotation2 != null)
			{
				sb.AppendLine("`rotation2`='" + ((Decimal)rotation2.Value).ToString() + "'");
			}
			if(rotation3 != null)
			{
				sb.AppendLine("`rotation3`='" + ((Decimal)rotation3.Value).ToString() + "'");
			}
			if(spawntimesecs != null)
			{
				sb.AppendLine("`spawntimesecs`='" + spawntimesecs.Value.ToString() + "'");
			}
			if(animprogress != null)
			{
				sb.AppendLine("`animprogress`='" + animprogress.Value.ToString() + "'");
			}
			if(state != null)
			{
				sb.AppendLine("`state`='" + state.Value.ToString() + "'");
			}
				sb = sb.Replace("\r\n", ", ");
				sb.Append(" WHERE `guid`='" + guid.Value.ToString() + "';");
				sb = sb.Replace(",  WHERE", " WHERE");

            return sb.ToString();
		}

		public override string GetDeleteCommand()
        {
            return string.Format("DELETE FROM `" + TableName + "` WHERE  `guid`='" + guid.Value.ToString() + "';");
        }

		public gameobject() : base(TableName) 
        {
        }
	}
}
