using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class spell_proc_event : DumpObjectBase
    {
        public const string TableName = "spell_proc_event";
		public System.UInt32? entry;
		public System.Byte? schoolmask;
		public System.UInt16? spellfamilyname;
		public System.UInt32? spellfamilymaska0;
		public System.UInt32? spellfamilymaska1;
		public System.UInt32? spellfamilymaska2;
		public System.UInt32? spellfamilymaskb0;
		public System.UInt32? spellfamilymaskb1;
		public System.UInt32? spellfamilymaskb2;
		public System.UInt32? spellfamilymaskc0;
		public System.UInt32? spellfamilymaskc1;
		public System.UInt32? spellfamilymaskc2;
		public System.UInt32? procflags;
		public System.UInt32? procex;
		public System.Single? ppmrate;
		public System.Single? customchance;
		public System.UInt32? cooldown;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `schoolmask`, `spellfamilyname`, `spellfamilymaska0`, `spellfamilymaska1`, `spellfamilymaska2`, `spellfamilymaskb0`, `spellfamilymaskb1`, `spellfamilymaskb2`, `spellfamilymaskc0`, `spellfamilymaskc1`, `spellfamilymaskc2`, `procflags`, `procex`, `ppmrate`, `customchance`, `cooldown`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}');", entry.GetValueOrDefault(), schoolmask.GetValueOrDefault(), spellfamilyname.GetValueOrDefault(), spellfamilymaska0.GetValueOrDefault(), spellfamilymaska1.GetValueOrDefault(), spellfamilymaska2.GetValueOrDefault(), spellfamilymaskb0.GetValueOrDefault(), spellfamilymaskb1.GetValueOrDefault(), spellfamilymaskb2.GetValueOrDefault(), spellfamilymaskc0.GetValueOrDefault(), spellfamilymaskc1.GetValueOrDefault(), spellfamilymaskc2.GetValueOrDefault(), procflags.GetValueOrDefault(), procex.GetValueOrDefault(), ((Decimal)ppmrate.GetValueOrDefault()), ((Decimal)customchance.GetValueOrDefault()), cooldown.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(schoolmask != null)
			{
				sb.AppendLine("`schoolmask`='" + schoolmask.Value.ToString() + "'");
			}
			if(spellfamilyname != null)
			{
				sb.AppendLine("`spellfamilyname`='" + spellfamilyname.Value.ToString() + "'");
			}
			if(spellfamilymaska0 != null)
			{
				sb.AppendLine("`spellfamilymaska0`='" + spellfamilymaska0.Value.ToString() + "'");
			}
			if(spellfamilymaska1 != null)
			{
				sb.AppendLine("`spellfamilymaska1`='" + spellfamilymaska1.Value.ToString() + "'");
			}
			if(spellfamilymaska2 != null)
			{
				sb.AppendLine("`spellfamilymaska2`='" + spellfamilymaska2.Value.ToString() + "'");
			}
			if(spellfamilymaskb0 != null)
			{
				sb.AppendLine("`spellfamilymaskb0`='" + spellfamilymaskb0.Value.ToString() + "'");
			}
			if(spellfamilymaskb1 != null)
			{
				sb.AppendLine("`spellfamilymaskb1`='" + spellfamilymaskb1.Value.ToString() + "'");
			}
			if(spellfamilymaskb2 != null)
			{
				sb.AppendLine("`spellfamilymaskb2`='" + spellfamilymaskb2.Value.ToString() + "'");
			}
			if(spellfamilymaskc0 != null)
			{
				sb.AppendLine("`spellfamilymaskc0`='" + spellfamilymaskc0.Value.ToString() + "'");
			}
			if(spellfamilymaskc1 != null)
			{
				sb.AppendLine("`spellfamilymaskc1`='" + spellfamilymaskc1.Value.ToString() + "'");
			}
			if(spellfamilymaskc2 != null)
			{
				sb.AppendLine("`spellfamilymaskc2`='" + spellfamilymaskc2.Value.ToString() + "'");
			}
			if(procflags != null)
			{
				sb.AppendLine("`procflags`='" + procflags.Value.ToString() + "'");
			}
			if(procex != null)
			{
				sb.AppendLine("`procex`='" + procex.Value.ToString() + "'");
			}
			if(ppmrate != null)
			{
				sb.AppendLine("`ppmrate`='" + ((Decimal)ppmrate.Value).ToString() + "'");
			}
			if(customchance != null)
			{
				sb.AppendLine("`customchance`='" + ((Decimal)customchance.Value).ToString() + "'");
			}
			if(cooldown != null)
			{
				sb.AppendLine("`cooldown`='" + cooldown.Value.ToString() + "'");
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

		public spell_proc_event() : base(TableName) 
        {
        }
	}
}
