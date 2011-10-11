using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class item_loot_template : DumpObjectBase
    {
        public const string TableName = "item_loot_template";
		public System.UInt32? entry;
		public System.UInt32? item;
		public System.Single? chanceorquestchance;
		public System.Byte? groupid;
		public System.Int32? mincountorref;
		public System.Byte? maxcount;
		public System.Byte? lootcondition;
		public System.UInt32? condition_value1;
		public System.UInt32? condition_value2;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `item`, `chanceorquestchance`, `groupid`, `mincountorref`, `maxcount`, `lootcondition`, `condition_value1`, `condition_value2`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", entry.GetValueOrDefault(), item.GetValueOrDefault(), ((Decimal)chanceorquestchance.GetValueOrDefault()), groupid.GetValueOrDefault(), mincountorref.GetValueOrDefault(), maxcount.GetValueOrDefault(), lootcondition.GetValueOrDefault(), condition_value1.GetValueOrDefault(), condition_value2.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(item != null)
			{
				sb.AppendLine("`item`='" + item.Value.ToString() + "'");
			}
			if(chanceorquestchance != null)
			{
				sb.AppendLine("`chanceorquestchance`='" + ((Decimal)chanceorquestchance.Value).ToString() + "'");
			}
			if(groupid != null)
			{
				sb.AppendLine("`groupid`='" + groupid.Value.ToString() + "'");
			}
			if(mincountorref != null)
			{
				sb.AppendLine("`mincountorref`='" + mincountorref.Value.ToString() + "'");
			}
			if(maxcount != null)
			{
				sb.AppendLine("`maxcount`='" + maxcount.Value.ToString() + "'");
			}
			if(lootcondition != null)
			{
				sb.AppendLine("`lootcondition`='" + lootcondition.Value.ToString() + "'");
			}
			if(condition_value1 != null)
			{
				sb.AppendLine("`condition_value1`='" + condition_value1.Value.ToString() + "'");
			}
			if(condition_value2 != null)
			{
				sb.AppendLine("`condition_value2`='" + condition_value2.Value.ToString() + "'");
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

		public item_loot_template() : base(TableName) 
        {
        }
	}
}
