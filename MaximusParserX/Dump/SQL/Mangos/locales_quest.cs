using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class locales_quest : DumpObjectBase
    {
        public const string TableName = "locales_quest";
		public System.UInt32? entry;
		public System.String title_loc1;
		public System.String title_loc2;
		public System.String title_loc3;
		public System.String title_loc4;
		public System.String title_loc5;
		public System.String title_loc6;
		public System.String title_loc7;
		public System.String title_loc8;
		public System.String details_loc1;
		public System.String details_loc2;
		public System.String details_loc3;
		public System.String details_loc4;
		public System.String details_loc5;
		public System.String details_loc6;
		public System.String details_loc7;
		public System.String details_loc8;
		public System.String objectives_loc1;
		public System.String objectives_loc2;
		public System.String objectives_loc3;
		public System.String objectives_loc4;
		public System.String objectives_loc5;
		public System.String objectives_loc6;
		public System.String objectives_loc7;
		public System.String objectives_loc8;
		public System.String offerrewardtext_loc1;
		public System.String offerrewardtext_loc2;
		public System.String offerrewardtext_loc3;
		public System.String offerrewardtext_loc4;
		public System.String offerrewardtext_loc5;
		public System.String offerrewardtext_loc6;
		public System.String offerrewardtext_loc7;
		public System.String offerrewardtext_loc8;
		public System.String requestitemstext_loc1;
		public System.String requestitemstext_loc2;
		public System.String requestitemstext_loc3;
		public System.String requestitemstext_loc4;
		public System.String requestitemstext_loc5;
		public System.String requestitemstext_loc6;
		public System.String requestitemstext_loc7;
		public System.String requestitemstext_loc8;
		public System.String endtext_loc1;
		public System.String endtext_loc2;
		public System.String endtext_loc3;
		public System.String endtext_loc4;
		public System.String endtext_loc5;
		public System.String endtext_loc6;
		public System.String endtext_loc7;
		public System.String endtext_loc8;
		public System.String completedtext_loc1;
		public System.String completedtext_loc2;
		public System.String completedtext_loc3;
		public System.String completedtext_loc4;
		public System.String completedtext_loc5;
		public System.String completedtext_loc6;
		public System.String completedtext_loc7;
		public System.String completedtext_loc8;
		public System.String objectivetext1_loc1;
		public System.String objectivetext1_loc2;
		public System.String objectivetext1_loc3;
		public System.String objectivetext1_loc4;
		public System.String objectivetext1_loc5;
		public System.String objectivetext1_loc6;
		public System.String objectivetext1_loc7;
		public System.String objectivetext1_loc8;
		public System.String objectivetext2_loc1;
		public System.String objectivetext2_loc2;
		public System.String objectivetext2_loc3;
		public System.String objectivetext2_loc4;
		public System.String objectivetext2_loc5;
		public System.String objectivetext2_loc6;
		public System.String objectivetext2_loc7;
		public System.String objectivetext2_loc8;
		public System.String objectivetext3_loc1;
		public System.String objectivetext3_loc2;
		public System.String objectivetext3_loc3;
		public System.String objectivetext3_loc4;
		public System.String objectivetext3_loc5;
		public System.String objectivetext3_loc6;
		public System.String objectivetext3_loc7;
		public System.String objectivetext3_loc8;
		public System.String objectivetext4_loc1;
		public System.String objectivetext4_loc2;
		public System.String objectivetext4_loc3;
		public System.String objectivetext4_loc4;
		public System.String objectivetext4_loc5;
		public System.String objectivetext4_loc6;
		public System.String objectivetext4_loc7;
		public System.String objectivetext4_loc8;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `title_loc1`, `title_loc2`, `title_loc3`, `title_loc4`, `title_loc5`, `title_loc6`, `title_loc7`, `title_loc8`, `details_loc1`, `details_loc2`, `details_loc3`, `details_loc4`, `details_loc5`, `details_loc6`, `details_loc7`, `details_loc8`, `objectives_loc1`, `objectives_loc2`, `objectives_loc3`, `objectives_loc4`, `objectives_loc5`, `objectives_loc6`, `objectives_loc7`, `objectives_loc8`, `offerrewardtext_loc1`, `offerrewardtext_loc2`, `offerrewardtext_loc3`, `offerrewardtext_loc4`, `offerrewardtext_loc5`, `offerrewardtext_loc6`, `offerrewardtext_loc7`, `offerrewardtext_loc8`, `requestitemstext_loc1`, `requestitemstext_loc2`, `requestitemstext_loc3`, `requestitemstext_loc4`, `requestitemstext_loc5`, `requestitemstext_loc6`, `requestitemstext_loc7`, `requestitemstext_loc8`, `endtext_loc1`, `endtext_loc2`, `endtext_loc3`, `endtext_loc4`, `endtext_loc5`, `endtext_loc6`, `endtext_loc7`, `endtext_loc8`, `completedtext_loc1`, `completedtext_loc2`, `completedtext_loc3`, `completedtext_loc4`, `completedtext_loc5`, `completedtext_loc6`, `completedtext_loc7`, `completedtext_loc8`, `objectivetext1_loc1`, `objectivetext1_loc2`, `objectivetext1_loc3`, `objectivetext1_loc4`, `objectivetext1_loc5`, `objectivetext1_loc6`, `objectivetext1_loc7`, `objectivetext1_loc8`, `objectivetext2_loc1`, `objectivetext2_loc2`, `objectivetext2_loc3`, `objectivetext2_loc4`, `objectivetext2_loc5`, `objectivetext2_loc6`, `objectivetext2_loc7`, `objectivetext2_loc8`, `objectivetext3_loc1`, `objectivetext3_loc2`, `objectivetext3_loc3`, `objectivetext3_loc4`, `objectivetext3_loc5`, `objectivetext3_loc6`, `objectivetext3_loc7`, `objectivetext3_loc8`, `objectivetext4_loc1`, `objectivetext4_loc2`, `objectivetext4_loc3`, `objectivetext4_loc4`, `objectivetext4_loc5`, `objectivetext4_loc6`, `objectivetext4_loc7`, `objectivetext4_loc8`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}', '{79}', '{80}', '{81}', '{82}', '{83}', '{84}', '{85}', '{86}', '{87}', '{88}');", entry.GetValueOrDefault(), title_loc1.ToSQL(), title_loc2.ToSQL(), title_loc3.ToSQL(), title_loc4.ToSQL(), title_loc5.ToSQL(), title_loc6.ToSQL(), title_loc7.ToSQL(), title_loc8.ToSQL(), details_loc1.ToSQL(), details_loc2.ToSQL(), details_loc3.ToSQL(), details_loc4.ToSQL(), details_loc5.ToSQL(), details_loc6.ToSQL(), details_loc7.ToSQL(), details_loc8.ToSQL(), objectives_loc1.ToSQL(), objectives_loc2.ToSQL(), objectives_loc3.ToSQL(), objectives_loc4.ToSQL(), objectives_loc5.ToSQL(), objectives_loc6.ToSQL(), objectives_loc7.ToSQL(), objectives_loc8.ToSQL(), offerrewardtext_loc1.ToSQL(), offerrewardtext_loc2.ToSQL(), offerrewardtext_loc3.ToSQL(), offerrewardtext_loc4.ToSQL(), offerrewardtext_loc5.ToSQL(), offerrewardtext_loc6.ToSQL(), offerrewardtext_loc7.ToSQL(), offerrewardtext_loc8.ToSQL(), requestitemstext_loc1.ToSQL(), requestitemstext_loc2.ToSQL(), requestitemstext_loc3.ToSQL(), requestitemstext_loc4.ToSQL(), requestitemstext_loc5.ToSQL(), requestitemstext_loc6.ToSQL(), requestitemstext_loc7.ToSQL(), requestitemstext_loc8.ToSQL(), endtext_loc1.ToSQL(), endtext_loc2.ToSQL(), endtext_loc3.ToSQL(), endtext_loc4.ToSQL(), endtext_loc5.ToSQL(), endtext_loc6.ToSQL(), endtext_loc7.ToSQL(), endtext_loc8.ToSQL(), completedtext_loc1.ToSQL(), completedtext_loc2.ToSQL(), completedtext_loc3.ToSQL(), completedtext_loc4.ToSQL(), completedtext_loc5.ToSQL(), completedtext_loc6.ToSQL(), completedtext_loc7.ToSQL(), completedtext_loc8.ToSQL(), objectivetext1_loc1.ToSQL(), objectivetext1_loc2.ToSQL(), objectivetext1_loc3.ToSQL(), objectivetext1_loc4.ToSQL(), objectivetext1_loc5.ToSQL(), objectivetext1_loc6.ToSQL(), objectivetext1_loc7.ToSQL(), objectivetext1_loc8.ToSQL(), objectivetext2_loc1.ToSQL(), objectivetext2_loc2.ToSQL(), objectivetext2_loc3.ToSQL(), objectivetext2_loc4.ToSQL(), objectivetext2_loc5.ToSQL(), objectivetext2_loc6.ToSQL(), objectivetext2_loc7.ToSQL(), objectivetext2_loc8.ToSQL(), objectivetext3_loc1.ToSQL(), objectivetext3_loc2.ToSQL(), objectivetext3_loc3.ToSQL(), objectivetext3_loc4.ToSQL(), objectivetext3_loc5.ToSQL(), objectivetext3_loc6.ToSQL(), objectivetext3_loc7.ToSQL(), objectivetext3_loc8.ToSQL(), objectivetext4_loc1.ToSQL(), objectivetext4_loc2.ToSQL(), objectivetext4_loc3.ToSQL(), objectivetext4_loc4.ToSQL(), objectivetext4_loc5.ToSQL(), objectivetext4_loc6.ToSQL(), objectivetext4_loc7.ToSQL(), objectivetext4_loc8.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(title_loc1 != null)
			{
				sb.AppendLine("`title_loc1`='" + title_loc1.ToSQL() + "'");
			}
			if(title_loc2 != null)
			{
				sb.AppendLine("`title_loc2`='" + title_loc2.ToSQL() + "'");
			}
			if(title_loc3 != null)
			{
				sb.AppendLine("`title_loc3`='" + title_loc3.ToSQL() + "'");
			}
			if(title_loc4 != null)
			{
				sb.AppendLine("`title_loc4`='" + title_loc4.ToSQL() + "'");
			}
			if(title_loc5 != null)
			{
				sb.AppendLine("`title_loc5`='" + title_loc5.ToSQL() + "'");
			}
			if(title_loc6 != null)
			{
				sb.AppendLine("`title_loc6`='" + title_loc6.ToSQL() + "'");
			}
			if(title_loc7 != null)
			{
				sb.AppendLine("`title_loc7`='" + title_loc7.ToSQL() + "'");
			}
			if(title_loc8 != null)
			{
				sb.AppendLine("`title_loc8`='" + title_loc8.ToSQL() + "'");
			}
			if(details_loc1 != null)
			{
				sb.AppendLine("`details_loc1`='" + details_loc1.ToSQL() + "'");
			}
			if(details_loc2 != null)
			{
				sb.AppendLine("`details_loc2`='" + details_loc2.ToSQL() + "'");
			}
			if(details_loc3 != null)
			{
				sb.AppendLine("`details_loc3`='" + details_loc3.ToSQL() + "'");
			}
			if(details_loc4 != null)
			{
				sb.AppendLine("`details_loc4`='" + details_loc4.ToSQL() + "'");
			}
			if(details_loc5 != null)
			{
				sb.AppendLine("`details_loc5`='" + details_loc5.ToSQL() + "'");
			}
			if(details_loc6 != null)
			{
				sb.AppendLine("`details_loc6`='" + details_loc6.ToSQL() + "'");
			}
			if(details_loc7 != null)
			{
				sb.AppendLine("`details_loc7`='" + details_loc7.ToSQL() + "'");
			}
			if(details_loc8 != null)
			{
				sb.AppendLine("`details_loc8`='" + details_loc8.ToSQL() + "'");
			}
			if(objectives_loc1 != null)
			{
				sb.AppendLine("`objectives_loc1`='" + objectives_loc1.ToSQL() + "'");
			}
			if(objectives_loc2 != null)
			{
				sb.AppendLine("`objectives_loc2`='" + objectives_loc2.ToSQL() + "'");
			}
			if(objectives_loc3 != null)
			{
				sb.AppendLine("`objectives_loc3`='" + objectives_loc3.ToSQL() + "'");
			}
			if(objectives_loc4 != null)
			{
				sb.AppendLine("`objectives_loc4`='" + objectives_loc4.ToSQL() + "'");
			}
			if(objectives_loc5 != null)
			{
				sb.AppendLine("`objectives_loc5`='" + objectives_loc5.ToSQL() + "'");
			}
			if(objectives_loc6 != null)
			{
				sb.AppendLine("`objectives_loc6`='" + objectives_loc6.ToSQL() + "'");
			}
			if(objectives_loc7 != null)
			{
				sb.AppendLine("`objectives_loc7`='" + objectives_loc7.ToSQL() + "'");
			}
			if(objectives_loc8 != null)
			{
				sb.AppendLine("`objectives_loc8`='" + objectives_loc8.ToSQL() + "'");
			}
			if(offerrewardtext_loc1 != null)
			{
				sb.AppendLine("`offerrewardtext_loc1`='" + offerrewardtext_loc1.ToSQL() + "'");
			}
			if(offerrewardtext_loc2 != null)
			{
				sb.AppendLine("`offerrewardtext_loc2`='" + offerrewardtext_loc2.ToSQL() + "'");
			}
			if(offerrewardtext_loc3 != null)
			{
				sb.AppendLine("`offerrewardtext_loc3`='" + offerrewardtext_loc3.ToSQL() + "'");
			}
			if(offerrewardtext_loc4 != null)
			{
				sb.AppendLine("`offerrewardtext_loc4`='" + offerrewardtext_loc4.ToSQL() + "'");
			}
			if(offerrewardtext_loc5 != null)
			{
				sb.AppendLine("`offerrewardtext_loc5`='" + offerrewardtext_loc5.ToSQL() + "'");
			}
			if(offerrewardtext_loc6 != null)
			{
				sb.AppendLine("`offerrewardtext_loc6`='" + offerrewardtext_loc6.ToSQL() + "'");
			}
			if(offerrewardtext_loc7 != null)
			{
				sb.AppendLine("`offerrewardtext_loc7`='" + offerrewardtext_loc7.ToSQL() + "'");
			}
			if(offerrewardtext_loc8 != null)
			{
				sb.AppendLine("`offerrewardtext_loc8`='" + offerrewardtext_loc8.ToSQL() + "'");
			}
			if(requestitemstext_loc1 != null)
			{
				sb.AppendLine("`requestitemstext_loc1`='" + requestitemstext_loc1.ToSQL() + "'");
			}
			if(requestitemstext_loc2 != null)
			{
				sb.AppendLine("`requestitemstext_loc2`='" + requestitemstext_loc2.ToSQL() + "'");
			}
			if(requestitemstext_loc3 != null)
			{
				sb.AppendLine("`requestitemstext_loc3`='" + requestitemstext_loc3.ToSQL() + "'");
			}
			if(requestitemstext_loc4 != null)
			{
				sb.AppendLine("`requestitemstext_loc4`='" + requestitemstext_loc4.ToSQL() + "'");
			}
			if(requestitemstext_loc5 != null)
			{
				sb.AppendLine("`requestitemstext_loc5`='" + requestitemstext_loc5.ToSQL() + "'");
			}
			if(requestitemstext_loc6 != null)
			{
				sb.AppendLine("`requestitemstext_loc6`='" + requestitemstext_loc6.ToSQL() + "'");
			}
			if(requestitemstext_loc7 != null)
			{
				sb.AppendLine("`requestitemstext_loc7`='" + requestitemstext_loc7.ToSQL() + "'");
			}
			if(requestitemstext_loc8 != null)
			{
				sb.AppendLine("`requestitemstext_loc8`='" + requestitemstext_loc8.ToSQL() + "'");
			}
			if(endtext_loc1 != null)
			{
				sb.AppendLine("`endtext_loc1`='" + endtext_loc1.ToSQL() + "'");
			}
			if(endtext_loc2 != null)
			{
				sb.AppendLine("`endtext_loc2`='" + endtext_loc2.ToSQL() + "'");
			}
			if(endtext_loc3 != null)
			{
				sb.AppendLine("`endtext_loc3`='" + endtext_loc3.ToSQL() + "'");
			}
			if(endtext_loc4 != null)
			{
				sb.AppendLine("`endtext_loc4`='" + endtext_loc4.ToSQL() + "'");
			}
			if(endtext_loc5 != null)
			{
				sb.AppendLine("`endtext_loc5`='" + endtext_loc5.ToSQL() + "'");
			}
			if(endtext_loc6 != null)
			{
				sb.AppendLine("`endtext_loc6`='" + endtext_loc6.ToSQL() + "'");
			}
			if(endtext_loc7 != null)
			{
				sb.AppendLine("`endtext_loc7`='" + endtext_loc7.ToSQL() + "'");
			}
			if(endtext_loc8 != null)
			{
				sb.AppendLine("`endtext_loc8`='" + endtext_loc8.ToSQL() + "'");
			}
			if(completedtext_loc1 != null)
			{
				sb.AppendLine("`completedtext_loc1`='" + completedtext_loc1.ToSQL() + "'");
			}
			if(completedtext_loc2 != null)
			{
				sb.AppendLine("`completedtext_loc2`='" + completedtext_loc2.ToSQL() + "'");
			}
			if(completedtext_loc3 != null)
			{
				sb.AppendLine("`completedtext_loc3`='" + completedtext_loc3.ToSQL() + "'");
			}
			if(completedtext_loc4 != null)
			{
				sb.AppendLine("`completedtext_loc4`='" + completedtext_loc4.ToSQL() + "'");
			}
			if(completedtext_loc5 != null)
			{
				sb.AppendLine("`completedtext_loc5`='" + completedtext_loc5.ToSQL() + "'");
			}
			if(completedtext_loc6 != null)
			{
				sb.AppendLine("`completedtext_loc6`='" + completedtext_loc6.ToSQL() + "'");
			}
			if(completedtext_loc7 != null)
			{
				sb.AppendLine("`completedtext_loc7`='" + completedtext_loc7.ToSQL() + "'");
			}
			if(completedtext_loc8 != null)
			{
				sb.AppendLine("`completedtext_loc8`='" + completedtext_loc8.ToSQL() + "'");
			}
			if(objectivetext1_loc1 != null)
			{
				sb.AppendLine("`objectivetext1_loc1`='" + objectivetext1_loc1.ToSQL() + "'");
			}
			if(objectivetext1_loc2 != null)
			{
				sb.AppendLine("`objectivetext1_loc2`='" + objectivetext1_loc2.ToSQL() + "'");
			}
			if(objectivetext1_loc3 != null)
			{
				sb.AppendLine("`objectivetext1_loc3`='" + objectivetext1_loc3.ToSQL() + "'");
			}
			if(objectivetext1_loc4 != null)
			{
				sb.AppendLine("`objectivetext1_loc4`='" + objectivetext1_loc4.ToSQL() + "'");
			}
			if(objectivetext1_loc5 != null)
			{
				sb.AppendLine("`objectivetext1_loc5`='" + objectivetext1_loc5.ToSQL() + "'");
			}
			if(objectivetext1_loc6 != null)
			{
				sb.AppendLine("`objectivetext1_loc6`='" + objectivetext1_loc6.ToSQL() + "'");
			}
			if(objectivetext1_loc7 != null)
			{
				sb.AppendLine("`objectivetext1_loc7`='" + objectivetext1_loc7.ToSQL() + "'");
			}
			if(objectivetext1_loc8 != null)
			{
				sb.AppendLine("`objectivetext1_loc8`='" + objectivetext1_loc8.ToSQL() + "'");
			}
			if(objectivetext2_loc1 != null)
			{
				sb.AppendLine("`objectivetext2_loc1`='" + objectivetext2_loc1.ToSQL() + "'");
			}
			if(objectivetext2_loc2 != null)
			{
				sb.AppendLine("`objectivetext2_loc2`='" + objectivetext2_loc2.ToSQL() + "'");
			}
			if(objectivetext2_loc3 != null)
			{
				sb.AppendLine("`objectivetext2_loc3`='" + objectivetext2_loc3.ToSQL() + "'");
			}
			if(objectivetext2_loc4 != null)
			{
				sb.AppendLine("`objectivetext2_loc4`='" + objectivetext2_loc4.ToSQL() + "'");
			}
			if(objectivetext2_loc5 != null)
			{
				sb.AppendLine("`objectivetext2_loc5`='" + objectivetext2_loc5.ToSQL() + "'");
			}
			if(objectivetext2_loc6 != null)
			{
				sb.AppendLine("`objectivetext2_loc6`='" + objectivetext2_loc6.ToSQL() + "'");
			}
			if(objectivetext2_loc7 != null)
			{
				sb.AppendLine("`objectivetext2_loc7`='" + objectivetext2_loc7.ToSQL() + "'");
			}
			if(objectivetext2_loc8 != null)
			{
				sb.AppendLine("`objectivetext2_loc8`='" + objectivetext2_loc8.ToSQL() + "'");
			}
			if(objectivetext3_loc1 != null)
			{
				sb.AppendLine("`objectivetext3_loc1`='" + objectivetext3_loc1.ToSQL() + "'");
			}
			if(objectivetext3_loc2 != null)
			{
				sb.AppendLine("`objectivetext3_loc2`='" + objectivetext3_loc2.ToSQL() + "'");
			}
			if(objectivetext3_loc3 != null)
			{
				sb.AppendLine("`objectivetext3_loc3`='" + objectivetext3_loc3.ToSQL() + "'");
			}
			if(objectivetext3_loc4 != null)
			{
				sb.AppendLine("`objectivetext3_loc4`='" + objectivetext3_loc4.ToSQL() + "'");
			}
			if(objectivetext3_loc5 != null)
			{
				sb.AppendLine("`objectivetext3_loc5`='" + objectivetext3_loc5.ToSQL() + "'");
			}
			if(objectivetext3_loc6 != null)
			{
				sb.AppendLine("`objectivetext3_loc6`='" + objectivetext3_loc6.ToSQL() + "'");
			}
			if(objectivetext3_loc7 != null)
			{
				sb.AppendLine("`objectivetext3_loc7`='" + objectivetext3_loc7.ToSQL() + "'");
			}
			if(objectivetext3_loc8 != null)
			{
				sb.AppendLine("`objectivetext3_loc8`='" + objectivetext3_loc8.ToSQL() + "'");
			}
			if(objectivetext4_loc1 != null)
			{
				sb.AppendLine("`objectivetext4_loc1`='" + objectivetext4_loc1.ToSQL() + "'");
			}
			if(objectivetext4_loc2 != null)
			{
				sb.AppendLine("`objectivetext4_loc2`='" + objectivetext4_loc2.ToSQL() + "'");
			}
			if(objectivetext4_loc3 != null)
			{
				sb.AppendLine("`objectivetext4_loc3`='" + objectivetext4_loc3.ToSQL() + "'");
			}
			if(objectivetext4_loc4 != null)
			{
				sb.AppendLine("`objectivetext4_loc4`='" + objectivetext4_loc4.ToSQL() + "'");
			}
			if(objectivetext4_loc5 != null)
			{
				sb.AppendLine("`objectivetext4_loc5`='" + objectivetext4_loc5.ToSQL() + "'");
			}
			if(objectivetext4_loc6 != null)
			{
				sb.AppendLine("`objectivetext4_loc6`='" + objectivetext4_loc6.ToSQL() + "'");
			}
			if(objectivetext4_loc7 != null)
			{
				sb.AppendLine("`objectivetext4_loc7`='" + objectivetext4_loc7.ToSQL() + "'");
			}
			if(objectivetext4_loc8 != null)
			{
				sb.AppendLine("`objectivetext4_loc8`='" + objectivetext4_loc8.ToSQL() + "'");
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

		public locales_quest() : base(TableName) 
        {
        }
	}
}
