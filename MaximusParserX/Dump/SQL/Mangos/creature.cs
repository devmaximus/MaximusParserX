using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature : DumpObjectBase
    {
        public const string TableName = "creature";
		public System.UInt32? guid;
		public System.UInt32? id;
		public System.UInt16? map;
		public System.Byte? spawnmask;
		public System.UInt16? phasemask;
		public System.UInt32? modelid;
		public System.Int32? equipment_id;
		public System.Single? position_x;
		public System.Single? position_y;
		public System.Single? position_z;
		public System.Single? orientation;
		public System.UInt32? spawntimesecs;
		public System.Single? spawndist;
		public System.UInt32? currentwaypoint;
		public System.UInt32? curhealth;
		public System.UInt32? curmana;
		public System.Byte? deathstate;
		public System.Byte? movementtype;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`guid`, `id`, `map`, `spawnmask`, `phasemask`, `modelid`, `equipment_id`, `position_x`, `position_y`, `position_z`, `orientation`, `spawntimesecs`, `spawndist`, `currentwaypoint`, `curhealth`, `curmana`, `deathstate`, `movementtype`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');", guid.GetValueOrDefault(), id.GetValueOrDefault(), map.GetValueOrDefault(), spawnmask.GetValueOrDefault(), phasemask.GetValueOrDefault(), modelid.GetValueOrDefault(), equipment_id.GetValueOrDefault(), ((Decimal)position_x.GetValueOrDefault()), ((Decimal)position_y.GetValueOrDefault()), ((Decimal)position_z.GetValueOrDefault()), ((Decimal)orientation.GetValueOrDefault()), spawntimesecs.GetValueOrDefault(), ((Decimal)spawndist.GetValueOrDefault()), currentwaypoint.GetValueOrDefault(), curhealth.GetValueOrDefault(), curmana.GetValueOrDefault(), deathstate.GetValueOrDefault(), movementtype.GetValueOrDefault());
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
			if(modelid != null)
			{
				sb.AppendLine("`modelid`='" + modelid.Value.ToString() + "'");
			}
			if(equipment_id != null)
			{
				sb.AppendLine("`equipment_id`='" + equipment_id.Value.ToString() + "'");
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
			if(spawntimesecs != null)
			{
				sb.AppendLine("`spawntimesecs`='" + spawntimesecs.Value.ToString() + "'");
			}
			if(spawndist != null)
			{
				sb.AppendLine("`spawndist`='" + ((Decimal)spawndist.Value).ToString() + "'");
			}
			if(currentwaypoint != null)
			{
				sb.AppendLine("`currentwaypoint`='" + currentwaypoint.Value.ToString() + "'");
			}
			if(curhealth != null)
			{
				sb.AppendLine("`curhealth`='" + curhealth.Value.ToString() + "'");
			}
			if(curmana != null)
			{
				sb.AppendLine("`curmana`='" + curmana.Value.ToString() + "'");
			}
			if(deathstate != null)
			{
				sb.AppendLine("`deathstate`='" + deathstate.Value.ToString() + "'");
			}
			if(movementtype != null)
			{
				sb.AppendLine("`movementtype`='" + movementtype.Value.ToString() + "'");
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

		public creature() : base(TableName) 
        {
        }
	}
}
