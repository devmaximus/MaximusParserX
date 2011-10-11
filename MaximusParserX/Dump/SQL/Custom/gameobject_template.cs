using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class gameobject_template : CustomDumpObjectBase
    {
        public const string TableName = "gameobject_template";
		public System.UInt32? entry;
		public System.Byte? type;
		public System.UInt32? displayid;
		public System.String name;
		public System.String iconname;
		public System.String castbarcaption;
		public System.String unk1;
		public System.UInt16? faction;
		public System.UInt32? flags;
		public System.Single? size;
		public System.UInt32? questitem1;
		public System.UInt32? questitem2;
		public System.UInt32? questitem3;
		public System.UInt32? questitem4;
		public System.UInt32? questitem5;
		public System.UInt32? questitem6;
		public System.UInt32? data0;
		public System.UInt32? data1;
		public System.UInt32? data2;
		public System.UInt32? data3;
		public System.UInt32? data4;
		public System.UInt32? data5;
		public System.UInt32? data6;
		public System.UInt32? data7;
		public System.UInt32? data8;
		public System.UInt32? data9;
		public System.UInt32? data10;
		public System.UInt32? data11;
		public System.UInt32? data12;
		public System.UInt32? data13;
		public System.UInt32? data14;
		public System.UInt32? data15;
		public System.UInt32? data16;
		public System.UInt32? data17;
		public System.UInt32? data18;
		public System.UInt32? data19;
		public System.UInt32? data20;
		public System.UInt32? data21;
		public System.UInt32? data22;
		public System.UInt32? data23;
		public System.UInt32? mingold;
		public System.UInt32? maxgold;
		public System.String scriptname;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `type`, `displayid`, `name`, `iconname`, `castbarcaption`, `unk1`, `faction`, `flags`, `size`, `questitem1`, `questitem2`, `questitem3`, `questitem4`, `questitem5`, `questitem6`, `data0`, `data1`, `data2`, `data3`, `data4`, `data5`, `data6`, `data7`, `data8`, `data9`, `data10`, `data11`, `data12`, `data13`, `data14`, `data15`, `data16`, `data17`, `data18`, `data19`, `data20`, `data21`, `data22`, `data23`, `mingold`, `maxgold`, `scriptname`{43}) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}'{44});", entry.GetValueOrDefault(), type.GetValueOrDefault(), displayid.GetValueOrDefault(), name.ToSQL(), iconname.ToSQL(), castbarcaption.ToSQL(), unk1.ToSQL(), faction.GetValueOrDefault(), flags.GetValueOrDefault(), ((Decimal)size.GetValueOrDefault()), questitem1.GetValueOrDefault(), questitem2.GetValueOrDefault(), questitem3.GetValueOrDefault(), questitem4.GetValueOrDefault(), questitem5.GetValueOrDefault(), questitem6.GetValueOrDefault(), data0.GetValueOrDefault(), data1.GetValueOrDefault(), data2.GetValueOrDefault(), data3.GetValueOrDefault(), data4.GetValueOrDefault(), data5.GetValueOrDefault(), data6.GetValueOrDefault(), data7.GetValueOrDefault(), data8.GetValueOrDefault(), data9.GetValueOrDefault(), data10.GetValueOrDefault(), data11.GetValueOrDefault(), data12.GetValueOrDefault(), data13.GetValueOrDefault(), data14.GetValueOrDefault(), data15.GetValueOrDefault(), data16.GetValueOrDefault(), data17.GetValueOrDefault(), data18.GetValueOrDefault(), data19.GetValueOrDefault(), data20.GetValueOrDefault(), data21.GetValueOrDefault(), data22.GetValueOrDefault(), data23.GetValueOrDefault(), mingold.GetValueOrDefault(), maxgold.GetValueOrDefault(), scriptname.ToSQL(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(type != null)
			{
				sb.AppendLine("`type`='" + type.Value.ToString() + "'");
			}
			if(displayid != null)
			{
				sb.AppendLine("`displayid`='" + displayid.Value.ToString() + "'");
			}
			if(name != null)
			{
				sb.AppendLine("`name`='" + name.ToSQL() + "'");
			}
			if(iconname != null)
			{
				sb.AppendLine("`iconname`='" + iconname.ToSQL() + "'");
			}
			if(castbarcaption != null)
			{
				sb.AppendLine("`castbarcaption`='" + castbarcaption.ToSQL() + "'");
			}
			if(unk1 != null)
			{
				sb.AppendLine("`unk1`='" + unk1.ToSQL() + "'");
			}
			if(faction != null)
			{
				sb.AppendLine("`faction`='" + faction.Value.ToString() + "'");
			}
			if(flags != null)
			{
				sb.AppendLine("`flags`='" + flags.Value.ToString() + "'");
			}
			if(size != null)
			{
				sb.AppendLine("`size`='" + ((Decimal)size.Value).ToString() + "'");
			}
			if(questitem1 != null)
			{
				sb.AppendLine("`questitem1`='" + questitem1.Value.ToString() + "'");
			}
			if(questitem2 != null)
			{
				sb.AppendLine("`questitem2`='" + questitem2.Value.ToString() + "'");
			}
			if(questitem3 != null)
			{
				sb.AppendLine("`questitem3`='" + questitem3.Value.ToString() + "'");
			}
			if(questitem4 != null)
			{
				sb.AppendLine("`questitem4`='" + questitem4.Value.ToString() + "'");
			}
			if(questitem5 != null)
			{
				sb.AppendLine("`questitem5`='" + questitem5.Value.ToString() + "'");
			}
			if(questitem6 != null)
			{
				sb.AppendLine("`questitem6`='" + questitem6.Value.ToString() + "'");
			}
			if(data0 != null)
			{
				sb.AppendLine("`data0`='" + data0.Value.ToString() + "'");
			}
			if(data1 != null)
			{
				sb.AppendLine("`data1`='" + data1.Value.ToString() + "'");
			}
			if(data2 != null)
			{
				sb.AppendLine("`data2`='" + data2.Value.ToString() + "'");
			}
			if(data3 != null)
			{
				sb.AppendLine("`data3`='" + data3.Value.ToString() + "'");
			}
			if(data4 != null)
			{
				sb.AppendLine("`data4`='" + data4.Value.ToString() + "'");
			}
			if(data5 != null)
			{
				sb.AppendLine("`data5`='" + data5.Value.ToString() + "'");
			}
			if(data6 != null)
			{
				sb.AppendLine("`data6`='" + data6.Value.ToString() + "'");
			}
			if(data7 != null)
			{
				sb.AppendLine("`data7`='" + data7.Value.ToString() + "'");
			}
			if(data8 != null)
			{
				sb.AppendLine("`data8`='" + data8.Value.ToString() + "'");
			}
			if(data9 != null)
			{
				sb.AppendLine("`data9`='" + data9.Value.ToString() + "'");
			}
			if(data10 != null)
			{
				sb.AppendLine("`data10`='" + data10.Value.ToString() + "'");
			}
			if(data11 != null)
			{
				sb.AppendLine("`data11`='" + data11.Value.ToString() + "'");
			}
			if(data12 != null)
			{
				sb.AppendLine("`data12`='" + data12.Value.ToString() + "'");
			}
			if(data13 != null)
			{
				sb.AppendLine("`data13`='" + data13.Value.ToString() + "'");
			}
			if(data14 != null)
			{
				sb.AppendLine("`data14`='" + data14.Value.ToString() + "'");
			}
			if(data15 != null)
			{
				sb.AppendLine("`data15`='" + data15.Value.ToString() + "'");
			}
			if(data16 != null)
			{
				sb.AppendLine("`data16`='" + data16.Value.ToString() + "'");
			}
			if(data17 != null)
			{
				sb.AppendLine("`data17`='" + data17.Value.ToString() + "'");
			}
			if(data18 != null)
			{
				sb.AppendLine("`data18`='" + data18.Value.ToString() + "'");
			}
			if(data19 != null)
			{
				sb.AppendLine("`data19`='" + data19.Value.ToString() + "'");
			}
			if(data20 != null)
			{
				sb.AppendLine("`data20`='" + data20.Value.ToString() + "'");
			}
			if(data21 != null)
			{
				sb.AppendLine("`data21`='" + data21.Value.ToString() + "'");
			}
			if(data22 != null)
			{
				sb.AppendLine("`data22`='" + data22.Value.ToString() + "'");
			}
			if(data23 != null)
			{
				sb.AppendLine("`data23`='" + data23.Value.ToString() + "'");
			}
			if(mingold != null)
			{
				sb.AppendLine("`mingold`='" + mingold.Value.ToString() + "'");
			}
			if(maxgold != null)
			{
				sb.AppendLine("`maxgold`='" + maxgold.Value.ToString() + "'");
			}
			if(scriptname != null)
			{
				sb.AppendLine("`scriptname`='" + scriptname.ToSQL() + "'");
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

		public gameobject_template() : base(TableName) 
        {
        }
	}
}
