using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_npc_text : DumpObjectBase
    {
        public const string TableName = "locales_npc_text";
		public System.UInt32? entry;
		public System.String text0_0_loc1;
		public System.String text0_0_loc2;
		public System.String text0_0_loc3;
		public System.String text0_0_loc4;
		public System.String text0_0_loc5;
		public System.String text0_0_loc6;
		public System.String text0_0_loc7;
		public System.String text0_0_loc8;
		public System.String text0_1_loc1;
		public System.String text0_1_loc2;
		public System.String text0_1_loc3;
		public System.String text0_1_loc4;
		public System.String text0_1_loc5;
		public System.String text0_1_loc6;
		public System.String text0_1_loc7;
		public System.String text0_1_loc8;
		public System.String text1_0_loc1;
		public System.String text1_0_loc2;
		public System.String text1_0_loc3;
		public System.String text1_0_loc4;
		public System.String text1_0_loc5;
		public System.String text1_0_loc6;
		public System.String text1_0_loc7;
		public System.String text1_0_loc8;
		public System.String text1_1_loc1;
		public System.String text1_1_loc2;
		public System.String text1_1_loc3;
		public System.String text1_1_loc4;
		public System.String text1_1_loc5;
		public System.String text1_1_loc6;
		public System.String text1_1_loc7;
		public System.String text1_1_loc8;
		public System.String text2_0_loc1;
		public System.String text2_0_loc2;
		public System.String text2_0_loc3;
		public System.String text2_0_loc4;
		public System.String text2_0_loc5;
		public System.String text2_0_loc6;
		public System.String text2_0_loc7;
		public System.String text2_0_loc8;
		public System.String text2_1_loc1;
		public System.String text2_1_loc2;
		public System.String text2_1_loc3;
		public System.String text2_1_loc4;
		public System.String text2_1_loc5;
		public System.String text2_1_loc6;
		public System.String text2_1_loc7;
		public System.String text2_1_loc8;
		public System.String text3_0_loc1;
		public System.String text3_0_loc2;
		public System.String text3_0_loc3;
		public System.String text3_0_loc4;
		public System.String text3_0_loc5;
		public System.String text3_0_loc6;
		public System.String text3_0_loc7;
		public System.String text3_0_loc8;
		public System.String text3_1_loc1;
		public System.String text3_1_loc2;
		public System.String text3_1_loc3;
		public System.String text3_1_loc4;
		public System.String text3_1_loc5;
		public System.String text3_1_loc6;
		public System.String text3_1_loc7;
		public System.String text3_1_loc8;
		public System.String text4_0_loc1;
		public System.String text4_0_loc2;
		public System.String text4_0_loc3;
		public System.String text4_0_loc4;
		public System.String text4_0_loc5;
		public System.String text4_0_loc6;
		public System.String text4_0_loc7;
		public System.String text4_0_loc8;
		public System.String text4_1_loc1;
		public System.String text4_1_loc2;
		public System.String text4_1_loc3;
		public System.String text4_1_loc4;
		public System.String text4_1_loc5;
		public System.String text4_1_loc6;
		public System.String text4_1_loc7;
		public System.String text4_1_loc8;
		public System.String text5_0_loc1;
		public System.String text5_0_loc2;
		public System.String text5_0_loc3;
		public System.String text5_0_loc4;
		public System.String text5_0_loc5;
		public System.String text5_0_loc6;
		public System.String text5_0_loc7;
		public System.String text5_0_loc8;
		public System.String text5_1_loc1;
		public System.String text5_1_loc2;
		public System.String text5_1_loc3;
		public System.String text5_1_loc4;
		public System.String text5_1_loc5;
		public System.String text5_1_loc6;
		public System.String text5_1_loc7;
		public System.String text5_1_loc8;
		public System.String text6_0_loc1;
		public System.String text6_0_loc2;
		public System.String text6_0_loc3;
		public System.String text6_0_loc4;
		public System.String text6_0_loc5;
		public System.String text6_0_loc6;
		public System.String text6_0_loc7;
		public System.String text6_0_loc8;
		public System.String text6_1_loc1;
		public System.String text6_1_loc2;
		public System.String text6_1_loc3;
		public System.String text6_1_loc4;
		public System.String text6_1_loc5;
		public System.String text6_1_loc6;
		public System.String text6_1_loc7;
		public System.String text6_1_loc8;
		public System.String text7_0_loc1;
		public System.String text7_0_loc2;
		public System.String text7_0_loc3;
		public System.String text7_0_loc4;
		public System.String text7_0_loc5;
		public System.String text7_0_loc6;
		public System.String text7_0_loc7;
		public System.String text7_0_loc8;
		public System.String text7_1_loc1;
		public System.String text7_1_loc2;
		public System.String text7_1_loc3;
		public System.String text7_1_loc4;
		public System.String text7_1_loc5;
		public System.String text7_1_loc6;
		public System.String text7_1_loc7;
		public System.String text7_1_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `text0_0_loc1`, `text0_0_loc2`, `text0_0_loc3`, `text0_0_loc4`, `text0_0_loc5`, `text0_0_loc6`, `text0_0_loc7`, `text0_0_loc8`, `text0_1_loc1`, `text0_1_loc2`, `text0_1_loc3`, `text0_1_loc4`, `text0_1_loc5`, `text0_1_loc6`, `text0_1_loc7`, `text0_1_loc8`, `text1_0_loc1`, `text1_0_loc2`, `text1_0_loc3`, `text1_0_loc4`, `text1_0_loc5`, `text1_0_loc6`, `text1_0_loc7`, `text1_0_loc8`, `text1_1_loc1`, `text1_1_loc2`, `text1_1_loc3`, `text1_1_loc4`, `text1_1_loc5`, `text1_1_loc6`, `text1_1_loc7`, `text1_1_loc8`, `text2_0_loc1`, `text2_0_loc2`, `text2_0_loc3`, `text2_0_loc4`, `text2_0_loc5`, `text2_0_loc6`, `text2_0_loc7`, `text2_0_loc8`, `text2_1_loc1`, `text2_1_loc2`, `text2_1_loc3`, `text2_1_loc4`, `text2_1_loc5`, `text2_1_loc6`, `text2_1_loc7`, `text2_1_loc8`, `text3_0_loc1`, `text3_0_loc2`, `text3_0_loc3`, `text3_0_loc4`, `text3_0_loc5`, `text3_0_loc6`, `text3_0_loc7`, `text3_0_loc8`, `text3_1_loc1`, `text3_1_loc2`, `text3_1_loc3`, `text3_1_loc4`, `text3_1_loc5`, `text3_1_loc6`, `text3_1_loc7`, `text3_1_loc8`, `text4_0_loc1`, `text4_0_loc2`, `text4_0_loc3`, `text4_0_loc4`, `text4_0_loc5`, `text4_0_loc6`, `text4_0_loc7`, `text4_0_loc8`, `text4_1_loc1`, `text4_1_loc2`, `text4_1_loc3`, `text4_1_loc4`, `text4_1_loc5`, `text4_1_loc6`, `text4_1_loc7`, `text4_1_loc8`, `text5_0_loc1`, `text5_0_loc2`, `text5_0_loc3`, `text5_0_loc4`, `text5_0_loc5`, `text5_0_loc6`, `text5_0_loc7`, `text5_0_loc8`, `text5_1_loc1`, `text5_1_loc2`, `text5_1_loc3`, `text5_1_loc4`, `text5_1_loc5`, `text5_1_loc6`, `text5_1_loc7`, `text5_1_loc8`, `text6_0_loc1`, `text6_0_loc2`, `text6_0_loc3`, `text6_0_loc4`, `text6_0_loc5`, `text6_0_loc6`, `text6_0_loc7`, `text6_0_loc8`, `text6_1_loc1`, `text6_1_loc2`, `text6_1_loc3`, `text6_1_loc4`, `text6_1_loc5`, `text6_1_loc6`, `text6_1_loc7`, `text6_1_loc8`, `text7_0_loc1`, `text7_0_loc2`, `text7_0_loc3`, `text7_0_loc4`, `text7_0_loc5`, `text7_0_loc6`, `text7_0_loc7`, `text7_0_loc8`, `text7_1_loc1`, `text7_1_loc2`, `text7_1_loc3`, `text7_1_loc4`, `text7_1_loc5`, `text7_1_loc6`, `text7_1_loc7`, `text7_1_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}', '{79}', '{80}', '{81}', '{82}', '{83}', '{84}', '{85}', '{86}', '{87}', '{88}', '{89}', '{90}', '{91}', '{92}', '{93}', '{94}', '{95}', '{96}', '{97}', '{98}', '{99}', '{100}', '{101}', '{102}', '{103}', '{104}', '{105}', '{106}', '{107}', '{108}', '{109}', '{110}', '{111}', '{112}', '{113}', '{114}', '{115}', '{116}', '{117}', '{118}', '{119}', '{120}', '{121}', '{122}', '{123}', '{124}', '{125}', '{126}', '{127}', '{128}');", entry.GetValueOrDefault(), text0_0_loc1.ToSQL(), text0_0_loc2.ToSQL(), text0_0_loc3.ToSQL(), text0_0_loc4.ToSQL(), text0_0_loc5.ToSQL(), text0_0_loc6.ToSQL(), text0_0_loc7.ToSQL(), text0_0_loc8.ToSQL(), text0_1_loc1.ToSQL(), text0_1_loc2.ToSQL(), text0_1_loc3.ToSQL(), text0_1_loc4.ToSQL(), text0_1_loc5.ToSQL(), text0_1_loc6.ToSQL(), text0_1_loc7.ToSQL(), text0_1_loc8.ToSQL(), text1_0_loc1.ToSQL(), text1_0_loc2.ToSQL(), text1_0_loc3.ToSQL(), text1_0_loc4.ToSQL(), text1_0_loc5.ToSQL(), text1_0_loc6.ToSQL(), text1_0_loc7.ToSQL(), text1_0_loc8.ToSQL(), text1_1_loc1.ToSQL(), text1_1_loc2.ToSQL(), text1_1_loc3.ToSQL(), text1_1_loc4.ToSQL(), text1_1_loc5.ToSQL(), text1_1_loc6.ToSQL(), text1_1_loc7.ToSQL(), text1_1_loc8.ToSQL(), text2_0_loc1.ToSQL(), text2_0_loc2.ToSQL(), text2_0_loc3.ToSQL(), text2_0_loc4.ToSQL(), text2_0_loc5.ToSQL(), text2_0_loc6.ToSQL(), text2_0_loc7.ToSQL(), text2_0_loc8.ToSQL(), text2_1_loc1.ToSQL(), text2_1_loc2.ToSQL(), text2_1_loc3.ToSQL(), text2_1_loc4.ToSQL(), text2_1_loc5.ToSQL(), text2_1_loc6.ToSQL(), text2_1_loc7.ToSQL(), text2_1_loc8.ToSQL(), text3_0_loc1.ToSQL(), text3_0_loc2.ToSQL(), text3_0_loc3.ToSQL(), text3_0_loc4.ToSQL(), text3_0_loc5.ToSQL(), text3_0_loc6.ToSQL(), text3_0_loc7.ToSQL(), text3_0_loc8.ToSQL(), text3_1_loc1.ToSQL(), text3_1_loc2.ToSQL(), text3_1_loc3.ToSQL(), text3_1_loc4.ToSQL(), text3_1_loc5.ToSQL(), text3_1_loc6.ToSQL(), text3_1_loc7.ToSQL(), text3_1_loc8.ToSQL(), text4_0_loc1.ToSQL(), text4_0_loc2.ToSQL(), text4_0_loc3.ToSQL(), text4_0_loc4.ToSQL(), text4_0_loc5.ToSQL(), text4_0_loc6.ToSQL(), text4_0_loc7.ToSQL(), text4_0_loc8.ToSQL(), text4_1_loc1.ToSQL(), text4_1_loc2.ToSQL(), text4_1_loc3.ToSQL(), text4_1_loc4.ToSQL(), text4_1_loc5.ToSQL(), text4_1_loc6.ToSQL(), text4_1_loc7.ToSQL(), text4_1_loc8.ToSQL(), text5_0_loc1.ToSQL(), text5_0_loc2.ToSQL(), text5_0_loc3.ToSQL(), text5_0_loc4.ToSQL(), text5_0_loc5.ToSQL(), text5_0_loc6.ToSQL(), text5_0_loc7.ToSQL(), text5_0_loc8.ToSQL(), text5_1_loc1.ToSQL(), text5_1_loc2.ToSQL(), text5_1_loc3.ToSQL(), text5_1_loc4.ToSQL(), text5_1_loc5.ToSQL(), text5_1_loc6.ToSQL(), text5_1_loc7.ToSQL(), text5_1_loc8.ToSQL(), text6_0_loc1.ToSQL(), text6_0_loc2.ToSQL(), text6_0_loc3.ToSQL(), text6_0_loc4.ToSQL(), text6_0_loc5.ToSQL(), text6_0_loc6.ToSQL(), text6_0_loc7.ToSQL(), text6_0_loc8.ToSQL(), text6_1_loc1.ToSQL(), text6_1_loc2.ToSQL(), text6_1_loc3.ToSQL(), text6_1_loc4.ToSQL(), text6_1_loc5.ToSQL(), text6_1_loc6.ToSQL(), text6_1_loc7.ToSQL(), text6_1_loc8.ToSQL(), text7_0_loc1.ToSQL(), text7_0_loc2.ToSQL(), text7_0_loc3.ToSQL(), text7_0_loc4.ToSQL(), text7_0_loc5.ToSQL(), text7_0_loc6.ToSQL(), text7_0_loc7.ToSQL(), text7_0_loc8.ToSQL(), text7_1_loc1.ToSQL(), text7_1_loc2.ToSQL(), text7_1_loc3.ToSQL(), text7_1_loc4.ToSQL(), text7_1_loc5.ToSQL(), text7_1_loc6.ToSQL(), text7_1_loc7.ToSQL(), text7_1_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(text0_0_loc1 != null)
			{
				sb.AppendLine("`text0_0_loc1`='" + text0_0_loc1.ToSQL() + "'");
			}
			if(text0_0_loc2 != null)
			{
				sb.AppendLine("`text0_0_loc2`='" + text0_0_loc2.ToSQL() + "'");
			}
			if(text0_0_loc3 != null)
			{
				sb.AppendLine("`text0_0_loc3`='" + text0_0_loc3.ToSQL() + "'");
			}
			if(text0_0_loc4 != null)
			{
				sb.AppendLine("`text0_0_loc4`='" + text0_0_loc4.ToSQL() + "'");
			}
			if(text0_0_loc5 != null)
			{
				sb.AppendLine("`text0_0_loc5`='" + text0_0_loc5.ToSQL() + "'");
			}
			if(text0_0_loc6 != null)
			{
				sb.AppendLine("`text0_0_loc6`='" + text0_0_loc6.ToSQL() + "'");
			}
			if(text0_0_loc7 != null)
			{
				sb.AppendLine("`text0_0_loc7`='" + text0_0_loc7.ToSQL() + "'");
			}
			if(text0_0_loc8 != null)
			{
				sb.AppendLine("`text0_0_loc8`='" + text0_0_loc8.ToSQL() + "'");
			}
			if(text0_1_loc1 != null)
			{
				sb.AppendLine("`text0_1_loc1`='" + text0_1_loc1.ToSQL() + "'");
			}
			if(text0_1_loc2 != null)
			{
				sb.AppendLine("`text0_1_loc2`='" + text0_1_loc2.ToSQL() + "'");
			}
			if(text0_1_loc3 != null)
			{
				sb.AppendLine("`text0_1_loc3`='" + text0_1_loc3.ToSQL() + "'");
			}
			if(text0_1_loc4 != null)
			{
				sb.AppendLine("`text0_1_loc4`='" + text0_1_loc4.ToSQL() + "'");
			}
			if(text0_1_loc5 != null)
			{
				sb.AppendLine("`text0_1_loc5`='" + text0_1_loc5.ToSQL() + "'");
			}
			if(text0_1_loc6 != null)
			{
				sb.AppendLine("`text0_1_loc6`='" + text0_1_loc6.ToSQL() + "'");
			}
			if(text0_1_loc7 != null)
			{
				sb.AppendLine("`text0_1_loc7`='" + text0_1_loc7.ToSQL() + "'");
			}
			if(text0_1_loc8 != null)
			{
				sb.AppendLine("`text0_1_loc8`='" + text0_1_loc8.ToSQL() + "'");
			}
			if(text1_0_loc1 != null)
			{
				sb.AppendLine("`text1_0_loc1`='" + text1_0_loc1.ToSQL() + "'");
			}
			if(text1_0_loc2 != null)
			{
				sb.AppendLine("`text1_0_loc2`='" + text1_0_loc2.ToSQL() + "'");
			}
			if(text1_0_loc3 != null)
			{
				sb.AppendLine("`text1_0_loc3`='" + text1_0_loc3.ToSQL() + "'");
			}
			if(text1_0_loc4 != null)
			{
				sb.AppendLine("`text1_0_loc4`='" + text1_0_loc4.ToSQL() + "'");
			}
			if(text1_0_loc5 != null)
			{
				sb.AppendLine("`text1_0_loc5`='" + text1_0_loc5.ToSQL() + "'");
			}
			if(text1_0_loc6 != null)
			{
				sb.AppendLine("`text1_0_loc6`='" + text1_0_loc6.ToSQL() + "'");
			}
			if(text1_0_loc7 != null)
			{
				sb.AppendLine("`text1_0_loc7`='" + text1_0_loc7.ToSQL() + "'");
			}
			if(text1_0_loc8 != null)
			{
				sb.AppendLine("`text1_0_loc8`='" + text1_0_loc8.ToSQL() + "'");
			}
			if(text1_1_loc1 != null)
			{
				sb.AppendLine("`text1_1_loc1`='" + text1_1_loc1.ToSQL() + "'");
			}
			if(text1_1_loc2 != null)
			{
				sb.AppendLine("`text1_1_loc2`='" + text1_1_loc2.ToSQL() + "'");
			}
			if(text1_1_loc3 != null)
			{
				sb.AppendLine("`text1_1_loc3`='" + text1_1_loc3.ToSQL() + "'");
			}
			if(text1_1_loc4 != null)
			{
				sb.AppendLine("`text1_1_loc4`='" + text1_1_loc4.ToSQL() + "'");
			}
			if(text1_1_loc5 != null)
			{
				sb.AppendLine("`text1_1_loc5`='" + text1_1_loc5.ToSQL() + "'");
			}
			if(text1_1_loc6 != null)
			{
				sb.AppendLine("`text1_1_loc6`='" + text1_1_loc6.ToSQL() + "'");
			}
			if(text1_1_loc7 != null)
			{
				sb.AppendLine("`text1_1_loc7`='" + text1_1_loc7.ToSQL() + "'");
			}
			if(text1_1_loc8 != null)
			{
				sb.AppendLine("`text1_1_loc8`='" + text1_1_loc8.ToSQL() + "'");
			}
			if(text2_0_loc1 != null)
			{
				sb.AppendLine("`text2_0_loc1`='" + text2_0_loc1.ToSQL() + "'");
			}
			if(text2_0_loc2 != null)
			{
				sb.AppendLine("`text2_0_loc2`='" + text2_0_loc2.ToSQL() + "'");
			}
			if(text2_0_loc3 != null)
			{
				sb.AppendLine("`text2_0_loc3`='" + text2_0_loc3.ToSQL() + "'");
			}
			if(text2_0_loc4 != null)
			{
				sb.AppendLine("`text2_0_loc4`='" + text2_0_loc4.ToSQL() + "'");
			}
			if(text2_0_loc5 != null)
			{
				sb.AppendLine("`text2_0_loc5`='" + text2_0_loc5.ToSQL() + "'");
			}
			if(text2_0_loc6 != null)
			{
				sb.AppendLine("`text2_0_loc6`='" + text2_0_loc6.ToSQL() + "'");
			}
			if(text2_0_loc7 != null)
			{
				sb.AppendLine("`text2_0_loc7`='" + text2_0_loc7.ToSQL() + "'");
			}
			if(text2_0_loc8 != null)
			{
				sb.AppendLine("`text2_0_loc8`='" + text2_0_loc8.ToSQL() + "'");
			}
			if(text2_1_loc1 != null)
			{
				sb.AppendLine("`text2_1_loc1`='" + text2_1_loc1.ToSQL() + "'");
			}
			if(text2_1_loc2 != null)
			{
				sb.AppendLine("`text2_1_loc2`='" + text2_1_loc2.ToSQL() + "'");
			}
			if(text2_1_loc3 != null)
			{
				sb.AppendLine("`text2_1_loc3`='" + text2_1_loc3.ToSQL() + "'");
			}
			if(text2_1_loc4 != null)
			{
				sb.AppendLine("`text2_1_loc4`='" + text2_1_loc4.ToSQL() + "'");
			}
			if(text2_1_loc5 != null)
			{
				sb.AppendLine("`text2_1_loc5`='" + text2_1_loc5.ToSQL() + "'");
			}
			if(text2_1_loc6 != null)
			{
				sb.AppendLine("`text2_1_loc6`='" + text2_1_loc6.ToSQL() + "'");
			}
			if(text2_1_loc7 != null)
			{
				sb.AppendLine("`text2_1_loc7`='" + text2_1_loc7.ToSQL() + "'");
			}
			if(text2_1_loc8 != null)
			{
				sb.AppendLine("`text2_1_loc8`='" + text2_1_loc8.ToSQL() + "'");
			}
			if(text3_0_loc1 != null)
			{
				sb.AppendLine("`text3_0_loc1`='" + text3_0_loc1.ToSQL() + "'");
			}
			if(text3_0_loc2 != null)
			{
				sb.AppendLine("`text3_0_loc2`='" + text3_0_loc2.ToSQL() + "'");
			}
			if(text3_0_loc3 != null)
			{
				sb.AppendLine("`text3_0_loc3`='" + text3_0_loc3.ToSQL() + "'");
			}
			if(text3_0_loc4 != null)
			{
				sb.AppendLine("`text3_0_loc4`='" + text3_0_loc4.ToSQL() + "'");
			}
			if(text3_0_loc5 != null)
			{
				sb.AppendLine("`text3_0_loc5`='" + text3_0_loc5.ToSQL() + "'");
			}
			if(text3_0_loc6 != null)
			{
				sb.AppendLine("`text3_0_loc6`='" + text3_0_loc6.ToSQL() + "'");
			}
			if(text3_0_loc7 != null)
			{
				sb.AppendLine("`text3_0_loc7`='" + text3_0_loc7.ToSQL() + "'");
			}
			if(text3_0_loc8 != null)
			{
				sb.AppendLine("`text3_0_loc8`='" + text3_0_loc8.ToSQL() + "'");
			}
			if(text3_1_loc1 != null)
			{
				sb.AppendLine("`text3_1_loc1`='" + text3_1_loc1.ToSQL() + "'");
			}
			if(text3_1_loc2 != null)
			{
				sb.AppendLine("`text3_1_loc2`='" + text3_1_loc2.ToSQL() + "'");
			}
			if(text3_1_loc3 != null)
			{
				sb.AppendLine("`text3_1_loc3`='" + text3_1_loc3.ToSQL() + "'");
			}
			if(text3_1_loc4 != null)
			{
				sb.AppendLine("`text3_1_loc4`='" + text3_1_loc4.ToSQL() + "'");
			}
			if(text3_1_loc5 != null)
			{
				sb.AppendLine("`text3_1_loc5`='" + text3_1_loc5.ToSQL() + "'");
			}
			if(text3_1_loc6 != null)
			{
				sb.AppendLine("`text3_1_loc6`='" + text3_1_loc6.ToSQL() + "'");
			}
			if(text3_1_loc7 != null)
			{
				sb.AppendLine("`text3_1_loc7`='" + text3_1_loc7.ToSQL() + "'");
			}
			if(text3_1_loc8 != null)
			{
				sb.AppendLine("`text3_1_loc8`='" + text3_1_loc8.ToSQL() + "'");
			}
			if(text4_0_loc1 != null)
			{
				sb.AppendLine("`text4_0_loc1`='" + text4_0_loc1.ToSQL() + "'");
			}
			if(text4_0_loc2 != null)
			{
				sb.AppendLine("`text4_0_loc2`='" + text4_0_loc2.ToSQL() + "'");
			}
			if(text4_0_loc3 != null)
			{
				sb.AppendLine("`text4_0_loc3`='" + text4_0_loc3.ToSQL() + "'");
			}
			if(text4_0_loc4 != null)
			{
				sb.AppendLine("`text4_0_loc4`='" + text4_0_loc4.ToSQL() + "'");
			}
			if(text4_0_loc5 != null)
			{
				sb.AppendLine("`text4_0_loc5`='" + text4_0_loc5.ToSQL() + "'");
			}
			if(text4_0_loc6 != null)
			{
				sb.AppendLine("`text4_0_loc6`='" + text4_0_loc6.ToSQL() + "'");
			}
			if(text4_0_loc7 != null)
			{
				sb.AppendLine("`text4_0_loc7`='" + text4_0_loc7.ToSQL() + "'");
			}
			if(text4_0_loc8 != null)
			{
				sb.AppendLine("`text4_0_loc8`='" + text4_0_loc8.ToSQL() + "'");
			}
			if(text4_1_loc1 != null)
			{
				sb.AppendLine("`text4_1_loc1`='" + text4_1_loc1.ToSQL() + "'");
			}
			if(text4_1_loc2 != null)
			{
				sb.AppendLine("`text4_1_loc2`='" + text4_1_loc2.ToSQL() + "'");
			}
			if(text4_1_loc3 != null)
			{
				sb.AppendLine("`text4_1_loc3`='" + text4_1_loc3.ToSQL() + "'");
			}
			if(text4_1_loc4 != null)
			{
				sb.AppendLine("`text4_1_loc4`='" + text4_1_loc4.ToSQL() + "'");
			}
			if(text4_1_loc5 != null)
			{
				sb.AppendLine("`text4_1_loc5`='" + text4_1_loc5.ToSQL() + "'");
			}
			if(text4_1_loc6 != null)
			{
				sb.AppendLine("`text4_1_loc6`='" + text4_1_loc6.ToSQL() + "'");
			}
			if(text4_1_loc7 != null)
			{
				sb.AppendLine("`text4_1_loc7`='" + text4_1_loc7.ToSQL() + "'");
			}
			if(text4_1_loc8 != null)
			{
				sb.AppendLine("`text4_1_loc8`='" + text4_1_loc8.ToSQL() + "'");
			}
			if(text5_0_loc1 != null)
			{
				sb.AppendLine("`text5_0_loc1`='" + text5_0_loc1.ToSQL() + "'");
			}
			if(text5_0_loc2 != null)
			{
				sb.AppendLine("`text5_0_loc2`='" + text5_0_loc2.ToSQL() + "'");
			}
			if(text5_0_loc3 != null)
			{
				sb.AppendLine("`text5_0_loc3`='" + text5_0_loc3.ToSQL() + "'");
			}
			if(text5_0_loc4 != null)
			{
				sb.AppendLine("`text5_0_loc4`='" + text5_0_loc4.ToSQL() + "'");
			}
			if(text5_0_loc5 != null)
			{
				sb.AppendLine("`text5_0_loc5`='" + text5_0_loc5.ToSQL() + "'");
			}
			if(text5_0_loc6 != null)
			{
				sb.AppendLine("`text5_0_loc6`='" + text5_0_loc6.ToSQL() + "'");
			}
			if(text5_0_loc7 != null)
			{
				sb.AppendLine("`text5_0_loc7`='" + text5_0_loc7.ToSQL() + "'");
			}
			if(text5_0_loc8 != null)
			{
				sb.AppendLine("`text5_0_loc8`='" + text5_0_loc8.ToSQL() + "'");
			}
			if(text5_1_loc1 != null)
			{
				sb.AppendLine("`text5_1_loc1`='" + text5_1_loc1.ToSQL() + "'");
			}
			if(text5_1_loc2 != null)
			{
				sb.AppendLine("`text5_1_loc2`='" + text5_1_loc2.ToSQL() + "'");
			}
			if(text5_1_loc3 != null)
			{
				sb.AppendLine("`text5_1_loc3`='" + text5_1_loc3.ToSQL() + "'");
			}
			if(text5_1_loc4 != null)
			{
				sb.AppendLine("`text5_1_loc4`='" + text5_1_loc4.ToSQL() + "'");
			}
			if(text5_1_loc5 != null)
			{
				sb.AppendLine("`text5_1_loc5`='" + text5_1_loc5.ToSQL() + "'");
			}
			if(text5_1_loc6 != null)
			{
				sb.AppendLine("`text5_1_loc6`='" + text5_1_loc6.ToSQL() + "'");
			}
			if(text5_1_loc7 != null)
			{
				sb.AppendLine("`text5_1_loc7`='" + text5_1_loc7.ToSQL() + "'");
			}
			if(text5_1_loc8 != null)
			{
				sb.AppendLine("`text5_1_loc8`='" + text5_1_loc8.ToSQL() + "'");
			}
			if(text6_0_loc1 != null)
			{
				sb.AppendLine("`text6_0_loc1`='" + text6_0_loc1.ToSQL() + "'");
			}
			if(text6_0_loc2 != null)
			{
				sb.AppendLine("`text6_0_loc2`='" + text6_0_loc2.ToSQL() + "'");
			}
			if(text6_0_loc3 != null)
			{
				sb.AppendLine("`text6_0_loc3`='" + text6_0_loc3.ToSQL() + "'");
			}
			if(text6_0_loc4 != null)
			{
				sb.AppendLine("`text6_0_loc4`='" + text6_0_loc4.ToSQL() + "'");
			}
			if(text6_0_loc5 != null)
			{
				sb.AppendLine("`text6_0_loc5`='" + text6_0_loc5.ToSQL() + "'");
			}
			if(text6_0_loc6 != null)
			{
				sb.AppendLine("`text6_0_loc6`='" + text6_0_loc6.ToSQL() + "'");
			}
			if(text6_0_loc7 != null)
			{
				sb.AppendLine("`text6_0_loc7`='" + text6_0_loc7.ToSQL() + "'");
			}
			if(text6_0_loc8 != null)
			{
				sb.AppendLine("`text6_0_loc8`='" + text6_0_loc8.ToSQL() + "'");
			}
			if(text6_1_loc1 != null)
			{
				sb.AppendLine("`text6_1_loc1`='" + text6_1_loc1.ToSQL() + "'");
			}
			if(text6_1_loc2 != null)
			{
				sb.AppendLine("`text6_1_loc2`='" + text6_1_loc2.ToSQL() + "'");
			}
			if(text6_1_loc3 != null)
			{
				sb.AppendLine("`text6_1_loc3`='" + text6_1_loc3.ToSQL() + "'");
			}
			if(text6_1_loc4 != null)
			{
				sb.AppendLine("`text6_1_loc4`='" + text6_1_loc4.ToSQL() + "'");
			}
			if(text6_1_loc5 != null)
			{
				sb.AppendLine("`text6_1_loc5`='" + text6_1_loc5.ToSQL() + "'");
			}
			if(text6_1_loc6 != null)
			{
				sb.AppendLine("`text6_1_loc6`='" + text6_1_loc6.ToSQL() + "'");
			}
			if(text6_1_loc7 != null)
			{
				sb.AppendLine("`text6_1_loc7`='" + text6_1_loc7.ToSQL() + "'");
			}
			if(text6_1_loc8 != null)
			{
				sb.AppendLine("`text6_1_loc8`='" + text6_1_loc8.ToSQL() + "'");
			}
			if(text7_0_loc1 != null)
			{
				sb.AppendLine("`text7_0_loc1`='" + text7_0_loc1.ToSQL() + "'");
			}
			if(text7_0_loc2 != null)
			{
				sb.AppendLine("`text7_0_loc2`='" + text7_0_loc2.ToSQL() + "'");
			}
			if(text7_0_loc3 != null)
			{
				sb.AppendLine("`text7_0_loc3`='" + text7_0_loc3.ToSQL() + "'");
			}
			if(text7_0_loc4 != null)
			{
				sb.AppendLine("`text7_0_loc4`='" + text7_0_loc4.ToSQL() + "'");
			}
			if(text7_0_loc5 != null)
			{
				sb.AppendLine("`text7_0_loc5`='" + text7_0_loc5.ToSQL() + "'");
			}
			if(text7_0_loc6 != null)
			{
				sb.AppendLine("`text7_0_loc6`='" + text7_0_loc6.ToSQL() + "'");
			}
			if(text7_0_loc7 != null)
			{
				sb.AppendLine("`text7_0_loc7`='" + text7_0_loc7.ToSQL() + "'");
			}
			if(text7_0_loc8 != null)
			{
				sb.AppendLine("`text7_0_loc8`='" + text7_0_loc8.ToSQL() + "'");
			}
			if(text7_1_loc1 != null)
			{
				sb.AppendLine("`text7_1_loc1`='" + text7_1_loc1.ToSQL() + "'");
			}
			if(text7_1_loc2 != null)
			{
				sb.AppendLine("`text7_1_loc2`='" + text7_1_loc2.ToSQL() + "'");
			}
			if(text7_1_loc3 != null)
			{
				sb.AppendLine("`text7_1_loc3`='" + text7_1_loc3.ToSQL() + "'");
			}
			if(text7_1_loc4 != null)
			{
				sb.AppendLine("`text7_1_loc4`='" + text7_1_loc4.ToSQL() + "'");
			}
			if(text7_1_loc5 != null)
			{
				sb.AppendLine("`text7_1_loc5`='" + text7_1_loc5.ToSQL() + "'");
			}
			if(text7_1_loc6 != null)
			{
				sb.AppendLine("`text7_1_loc6`='" + text7_1_loc6.ToSQL() + "'");
			}
			if(text7_1_loc7 != null)
			{
				sb.AppendLine("`text7_1_loc7`='" + text7_1_loc7.ToSQL() + "'");
			}
			if(text7_1_loc8 != null)
			{
				sb.AppendLine("`text7_1_loc8`='" + text7_1_loc8.ToSQL() + "'");
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

		public locales_npc_text() : base(TableName) 
        {
        }
	}
}
