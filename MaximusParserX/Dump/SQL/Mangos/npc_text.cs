using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class npc_text : DumpObjectBase
    {
        public const string TableName = "npc_text";
		public System.UInt32? id;
		public System.String text0_0;
		public System.String text0_1;
		public System.Byte? lang0;
		public System.Single? prob0;
		public System.UInt16? em0_0;
		public System.UInt16? em0_1;
		public System.UInt16? em0_2;
		public System.UInt16? em0_3;
		public System.UInt16? em0_4;
		public System.UInt16? em0_5;
		public System.String text1_0;
		public System.String text1_1;
		public System.Byte? lang1;
		public System.Single? prob1;
		public System.UInt16? em1_0;
		public System.UInt16? em1_1;
		public System.UInt16? em1_2;
		public System.UInt16? em1_3;
		public System.UInt16? em1_4;
		public System.UInt16? em1_5;
		public System.String text2_0;
		public System.String text2_1;
		public System.Byte? lang2;
		public System.Single? prob2;
		public System.UInt16? em2_0;
		public System.UInt16? em2_1;
		public System.UInt16? em2_2;
		public System.UInt16? em2_3;
		public System.UInt16? em2_4;
		public System.UInt16? em2_5;
		public System.String text3_0;
		public System.String text3_1;
		public System.Byte? lang3;
		public System.Single? prob3;
		public System.UInt16? em3_0;
		public System.UInt16? em3_1;
		public System.UInt16? em3_2;
		public System.UInt16? em3_3;
		public System.UInt16? em3_4;
		public System.UInt16? em3_5;
		public System.String text4_0;
		public System.String text4_1;
		public System.Byte? lang4;
		public System.Single? prob4;
		public System.UInt16? em4_0;
		public System.UInt16? em4_1;
		public System.UInt16? em4_2;
		public System.UInt16? em4_3;
		public System.UInt16? em4_4;
		public System.UInt16? em4_5;
		public System.String text5_0;
		public System.String text5_1;
		public System.Byte? lang5;
		public System.Single? prob5;
		public System.UInt16? em5_0;
		public System.UInt16? em5_1;
		public System.UInt16? em5_2;
		public System.UInt16? em5_3;
		public System.UInt16? em5_4;
		public System.UInt16? em5_5;
		public System.String text6_0;
		public System.String text6_1;
		public System.Byte? lang6;
		public System.Single? prob6;
		public System.UInt16? em6_0;
		public System.UInt16? em6_1;
		public System.UInt16? em6_2;
		public System.UInt16? em6_3;
		public System.UInt16? em6_4;
		public System.UInt16? em6_5;
		public System.String text7_0;
		public System.String text7_1;
		public System.Byte? lang7;
		public System.Single? prob7;
		public System.UInt16? em7_0;
		public System.UInt16? em7_1;
		public System.UInt16? em7_2;
		public System.UInt16? em7_3;
		public System.UInt16? em7_4;
		public System.UInt16? em7_5;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`id`, `text0_0`, `text0_1`, `lang0`, `prob0`, `em0_0`, `em0_1`, `em0_2`, `em0_3`, `em0_4`, `em0_5`, `text1_0`, `text1_1`, `lang1`, `prob1`, `em1_0`, `em1_1`, `em1_2`, `em1_3`, `em1_4`, `em1_5`, `text2_0`, `text2_1`, `lang2`, `prob2`, `em2_0`, `em2_1`, `em2_2`, `em2_3`, `em2_4`, `em2_5`, `text3_0`, `text3_1`, `lang3`, `prob3`, `em3_0`, `em3_1`, `em3_2`, `em3_3`, `em3_4`, `em3_5`, `text4_0`, `text4_1`, `lang4`, `prob4`, `em4_0`, `em4_1`, `em4_2`, `em4_3`, `em4_4`, `em4_5`, `text5_0`, `text5_1`, `lang5`, `prob5`, `em5_0`, `em5_1`, `em5_2`, `em5_3`, `em5_4`, `em5_5`, `text6_0`, `text6_1`, `lang6`, `prob6`, `em6_0`, `em6_1`, `em6_2`, `em6_3`, `em6_4`, `em6_5`, `text7_0`, `text7_1`, `lang7`, `prob7`, `em7_0`, `em7_1`, `em7_2`, `em7_3`, `em7_4`, `em7_5`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}', '{79}', '{80}');", id.GetValueOrDefault(), text0_0.ToSQL(), text0_1.ToSQL(), lang0.GetValueOrDefault(), ((Decimal)prob0.GetValueOrDefault()), em0_0.GetValueOrDefault(), em0_1.GetValueOrDefault(), em0_2.GetValueOrDefault(), em0_3.GetValueOrDefault(), em0_4.GetValueOrDefault(), em0_5.GetValueOrDefault(), text1_0.ToSQL(), text1_1.ToSQL(), lang1.GetValueOrDefault(), ((Decimal)prob1.GetValueOrDefault()), em1_0.GetValueOrDefault(), em1_1.GetValueOrDefault(), em1_2.GetValueOrDefault(), em1_3.GetValueOrDefault(), em1_4.GetValueOrDefault(), em1_5.GetValueOrDefault(), text2_0.ToSQL(), text2_1.ToSQL(), lang2.GetValueOrDefault(), ((Decimal)prob2.GetValueOrDefault()), em2_0.GetValueOrDefault(), em2_1.GetValueOrDefault(), em2_2.GetValueOrDefault(), em2_3.GetValueOrDefault(), em2_4.GetValueOrDefault(), em2_5.GetValueOrDefault(), text3_0.ToSQL(), text3_1.ToSQL(), lang3.GetValueOrDefault(), ((Decimal)prob3.GetValueOrDefault()), em3_0.GetValueOrDefault(), em3_1.GetValueOrDefault(), em3_2.GetValueOrDefault(), em3_3.GetValueOrDefault(), em3_4.GetValueOrDefault(), em3_5.GetValueOrDefault(), text4_0.ToSQL(), text4_1.ToSQL(), lang4.GetValueOrDefault(), ((Decimal)prob4.GetValueOrDefault()), em4_0.GetValueOrDefault(), em4_1.GetValueOrDefault(), em4_2.GetValueOrDefault(), em4_3.GetValueOrDefault(), em4_4.GetValueOrDefault(), em4_5.GetValueOrDefault(), text5_0.ToSQL(), text5_1.ToSQL(), lang5.GetValueOrDefault(), ((Decimal)prob5.GetValueOrDefault()), em5_0.GetValueOrDefault(), em5_1.GetValueOrDefault(), em5_2.GetValueOrDefault(), em5_3.GetValueOrDefault(), em5_4.GetValueOrDefault(), em5_5.GetValueOrDefault(), text6_0.ToSQL(), text6_1.ToSQL(), lang6.GetValueOrDefault(), ((Decimal)prob6.GetValueOrDefault()), em6_0.GetValueOrDefault(), em6_1.GetValueOrDefault(), em6_2.GetValueOrDefault(), em6_3.GetValueOrDefault(), em6_4.GetValueOrDefault(), em6_5.GetValueOrDefault(), text7_0.ToSQL(), text7_1.ToSQL(), lang7.GetValueOrDefault(), ((Decimal)prob7.GetValueOrDefault()), em7_0.GetValueOrDefault(), em7_1.GetValueOrDefault(), em7_2.GetValueOrDefault(), em7_3.GetValueOrDefault(), em7_4.GetValueOrDefault(), em7_5.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(text0_0 != null)
			{
				sb.AppendLine("`text0_0`='" + text0_0.ToSQL() + "'");
			}
			if(text0_1 != null)
			{
				sb.AppendLine("`text0_1`='" + text0_1.ToSQL() + "'");
			}
			if(lang0 != null)
			{
				sb.AppendLine("`lang0`='" + lang0.Value.ToString() + "'");
			}
			if(prob0 != null)
			{
				sb.AppendLine("`prob0`='" + ((Decimal)prob0.Value).ToString() + "'");
			}
			if(em0_0 != null)
			{
				sb.AppendLine("`em0_0`='" + em0_0.Value.ToString() + "'");
			}
			if(em0_1 != null)
			{
				sb.AppendLine("`em0_1`='" + em0_1.Value.ToString() + "'");
			}
			if(em0_2 != null)
			{
				sb.AppendLine("`em0_2`='" + em0_2.Value.ToString() + "'");
			}
			if(em0_3 != null)
			{
				sb.AppendLine("`em0_3`='" + em0_3.Value.ToString() + "'");
			}
			if(em0_4 != null)
			{
				sb.AppendLine("`em0_4`='" + em0_4.Value.ToString() + "'");
			}
			if(em0_5 != null)
			{
				sb.AppendLine("`em0_5`='" + em0_5.Value.ToString() + "'");
			}
			if(text1_0 != null)
			{
				sb.AppendLine("`text1_0`='" + text1_0.ToSQL() + "'");
			}
			if(text1_1 != null)
			{
				sb.AppendLine("`text1_1`='" + text1_1.ToSQL() + "'");
			}
			if(lang1 != null)
			{
				sb.AppendLine("`lang1`='" + lang1.Value.ToString() + "'");
			}
			if(prob1 != null)
			{
				sb.AppendLine("`prob1`='" + ((Decimal)prob1.Value).ToString() + "'");
			}
			if(em1_0 != null)
			{
				sb.AppendLine("`em1_0`='" + em1_0.Value.ToString() + "'");
			}
			if(em1_1 != null)
			{
				sb.AppendLine("`em1_1`='" + em1_1.Value.ToString() + "'");
			}
			if(em1_2 != null)
			{
				sb.AppendLine("`em1_2`='" + em1_2.Value.ToString() + "'");
			}
			if(em1_3 != null)
			{
				sb.AppendLine("`em1_3`='" + em1_3.Value.ToString() + "'");
			}
			if(em1_4 != null)
			{
				sb.AppendLine("`em1_4`='" + em1_4.Value.ToString() + "'");
			}
			if(em1_5 != null)
			{
				sb.AppendLine("`em1_5`='" + em1_5.Value.ToString() + "'");
			}
			if(text2_0 != null)
			{
				sb.AppendLine("`text2_0`='" + text2_0.ToSQL() + "'");
			}
			if(text2_1 != null)
			{
				sb.AppendLine("`text2_1`='" + text2_1.ToSQL() + "'");
			}
			if(lang2 != null)
			{
				sb.AppendLine("`lang2`='" + lang2.Value.ToString() + "'");
			}
			if(prob2 != null)
			{
				sb.AppendLine("`prob2`='" + ((Decimal)prob2.Value).ToString() + "'");
			}
			if(em2_0 != null)
			{
				sb.AppendLine("`em2_0`='" + em2_0.Value.ToString() + "'");
			}
			if(em2_1 != null)
			{
				sb.AppendLine("`em2_1`='" + em2_1.Value.ToString() + "'");
			}
			if(em2_2 != null)
			{
				sb.AppendLine("`em2_2`='" + em2_2.Value.ToString() + "'");
			}
			if(em2_3 != null)
			{
				sb.AppendLine("`em2_3`='" + em2_3.Value.ToString() + "'");
			}
			if(em2_4 != null)
			{
				sb.AppendLine("`em2_4`='" + em2_4.Value.ToString() + "'");
			}
			if(em2_5 != null)
			{
				sb.AppendLine("`em2_5`='" + em2_5.Value.ToString() + "'");
			}
			if(text3_0 != null)
			{
				sb.AppendLine("`text3_0`='" + text3_0.ToSQL() + "'");
			}
			if(text3_1 != null)
			{
				sb.AppendLine("`text3_1`='" + text3_1.ToSQL() + "'");
			}
			if(lang3 != null)
			{
				sb.AppendLine("`lang3`='" + lang3.Value.ToString() + "'");
			}
			if(prob3 != null)
			{
				sb.AppendLine("`prob3`='" + ((Decimal)prob3.Value).ToString() + "'");
			}
			if(em3_0 != null)
			{
				sb.AppendLine("`em3_0`='" + em3_0.Value.ToString() + "'");
			}
			if(em3_1 != null)
			{
				sb.AppendLine("`em3_1`='" + em3_1.Value.ToString() + "'");
			}
			if(em3_2 != null)
			{
				sb.AppendLine("`em3_2`='" + em3_2.Value.ToString() + "'");
			}
			if(em3_3 != null)
			{
				sb.AppendLine("`em3_3`='" + em3_3.Value.ToString() + "'");
			}
			if(em3_4 != null)
			{
				sb.AppendLine("`em3_4`='" + em3_4.Value.ToString() + "'");
			}
			if(em3_5 != null)
			{
				sb.AppendLine("`em3_5`='" + em3_5.Value.ToString() + "'");
			}
			if(text4_0 != null)
			{
				sb.AppendLine("`text4_0`='" + text4_0.ToSQL() + "'");
			}
			if(text4_1 != null)
			{
				sb.AppendLine("`text4_1`='" + text4_1.ToSQL() + "'");
			}
			if(lang4 != null)
			{
				sb.AppendLine("`lang4`='" + lang4.Value.ToString() + "'");
			}
			if(prob4 != null)
			{
				sb.AppendLine("`prob4`='" + ((Decimal)prob4.Value).ToString() + "'");
			}
			if(em4_0 != null)
			{
				sb.AppendLine("`em4_0`='" + em4_0.Value.ToString() + "'");
			}
			if(em4_1 != null)
			{
				sb.AppendLine("`em4_1`='" + em4_1.Value.ToString() + "'");
			}
			if(em4_2 != null)
			{
				sb.AppendLine("`em4_2`='" + em4_2.Value.ToString() + "'");
			}
			if(em4_3 != null)
			{
				sb.AppendLine("`em4_3`='" + em4_3.Value.ToString() + "'");
			}
			if(em4_4 != null)
			{
				sb.AppendLine("`em4_4`='" + em4_4.Value.ToString() + "'");
			}
			if(em4_5 != null)
			{
				sb.AppendLine("`em4_5`='" + em4_5.Value.ToString() + "'");
			}
			if(text5_0 != null)
			{
				sb.AppendLine("`text5_0`='" + text5_0.ToSQL() + "'");
			}
			if(text5_1 != null)
			{
				sb.AppendLine("`text5_1`='" + text5_1.ToSQL() + "'");
			}
			if(lang5 != null)
			{
				sb.AppendLine("`lang5`='" + lang5.Value.ToString() + "'");
			}
			if(prob5 != null)
			{
				sb.AppendLine("`prob5`='" + ((Decimal)prob5.Value).ToString() + "'");
			}
			if(em5_0 != null)
			{
				sb.AppendLine("`em5_0`='" + em5_0.Value.ToString() + "'");
			}
			if(em5_1 != null)
			{
				sb.AppendLine("`em5_1`='" + em5_1.Value.ToString() + "'");
			}
			if(em5_2 != null)
			{
				sb.AppendLine("`em5_2`='" + em5_2.Value.ToString() + "'");
			}
			if(em5_3 != null)
			{
				sb.AppendLine("`em5_3`='" + em5_3.Value.ToString() + "'");
			}
			if(em5_4 != null)
			{
				sb.AppendLine("`em5_4`='" + em5_4.Value.ToString() + "'");
			}
			if(em5_5 != null)
			{
				sb.AppendLine("`em5_5`='" + em5_5.Value.ToString() + "'");
			}
			if(text6_0 != null)
			{
				sb.AppendLine("`text6_0`='" + text6_0.ToSQL() + "'");
			}
			if(text6_1 != null)
			{
				sb.AppendLine("`text6_1`='" + text6_1.ToSQL() + "'");
			}
			if(lang6 != null)
			{
				sb.AppendLine("`lang6`='" + lang6.Value.ToString() + "'");
			}
			if(prob6 != null)
			{
				sb.AppendLine("`prob6`='" + ((Decimal)prob6.Value).ToString() + "'");
			}
			if(em6_0 != null)
			{
				sb.AppendLine("`em6_0`='" + em6_0.Value.ToString() + "'");
			}
			if(em6_1 != null)
			{
				sb.AppendLine("`em6_1`='" + em6_1.Value.ToString() + "'");
			}
			if(em6_2 != null)
			{
				sb.AppendLine("`em6_2`='" + em6_2.Value.ToString() + "'");
			}
			if(em6_3 != null)
			{
				sb.AppendLine("`em6_3`='" + em6_3.Value.ToString() + "'");
			}
			if(em6_4 != null)
			{
				sb.AppendLine("`em6_4`='" + em6_4.Value.ToString() + "'");
			}
			if(em6_5 != null)
			{
				sb.AppendLine("`em6_5`='" + em6_5.Value.ToString() + "'");
			}
			if(text7_0 != null)
			{
				sb.AppendLine("`text7_0`='" + text7_0.ToSQL() + "'");
			}
			if(text7_1 != null)
			{
				sb.AppendLine("`text7_1`='" + text7_1.ToSQL() + "'");
			}
			if(lang7 != null)
			{
				sb.AppendLine("`lang7`='" + lang7.Value.ToString() + "'");
			}
			if(prob7 != null)
			{
				sb.AppendLine("`prob7`='" + ((Decimal)prob7.Value).ToString() + "'");
			}
			if(em7_0 != null)
			{
				sb.AppendLine("`em7_0`='" + em7_0.Value.ToString() + "'");
			}
			if(em7_1 != null)
			{
				sb.AppendLine("`em7_1`='" + em7_1.Value.ToString() + "'");
			}
			if(em7_2 != null)
			{
				sb.AppendLine("`em7_2`='" + em7_2.Value.ToString() + "'");
			}
			if(em7_3 != null)
			{
				sb.AppendLine("`em7_3`='" + em7_3.Value.ToString() + "'");
			}
			if(em7_4 != null)
			{
				sb.AppendLine("`em7_4`='" + em7_4.Value.ToString() + "'");
			}
			if(em7_5 != null)
			{
				sb.AppendLine("`em7_5`='" + em7_5.Value.ToString() + "'");
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

		public npc_text() : base(TableName) 
        {
        }
	}
}
