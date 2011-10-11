using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class quest_template : DumpObjectBase
    {
        public const string TableName = "quest_template";
		public System.UInt32? entry;
		public System.Byte? method;
		public System.Int16? zoneorsort;
		public System.Byte? minlevel;
		public System.Int16? questlevel;
		public System.UInt16? type;
		public System.UInt16? requiredclasses;
		public System.UInt16? requiredraces;
		public System.UInt16? requiredskill;
		public System.UInt16? requiredskillvalue;
		public System.UInt16? repobjectivefaction;
		public System.Int32? repobjectivevalue;
		public System.UInt16? requiredminrepfaction;
		public System.Int32? requiredminrepvalue;
		public System.UInt16? requiredmaxrepfaction;
		public System.Int32? requiredmaxrepvalue;
		public System.Byte? suggestedplayers;
		public System.UInt32? limittime;
		public System.UInt32? questflags;
		public System.Byte? specialflags;
		public System.Byte? chartitleid;
		public System.Byte? playersslain;
		public System.Byte? bonustalents;
		public System.Int32? prevquestid;
		public System.Int32? nextquestid;
		public System.Int32? exclusivegroup;
		public System.UInt32? nextquestinchain;
		public System.Byte? rewxpid;
		public System.UInt32? srcitemid;
		public System.Byte? srcitemcount;
		public System.UInt32? srcspell;
		public System.String title;
		public System.String details;
		public System.String objectives;
		public System.String offerrewardtext;
		public System.String requestitemstext;
		public System.String endtext;
		public System.String completedtext;
		public System.String objectivetext1;
		public System.String objectivetext2;
		public System.String objectivetext3;
		public System.String objectivetext4;
		public System.UInt32? reqitemid1;
		public System.UInt32? reqitemid2;
		public System.UInt32? reqitemid3;
		public System.UInt32? reqitemid4;
		public System.UInt32? reqitemid5;
		public System.UInt32? reqitemid6;
		public System.UInt16? reqitemcount1;
		public System.UInt16? reqitemcount2;
		public System.UInt16? reqitemcount3;
		public System.UInt16? reqitemcount4;
		public System.UInt16? reqitemcount5;
		public System.UInt16? reqitemcount6;
		public System.UInt32? reqsourceid1;
		public System.UInt32? reqsourceid2;
		public System.UInt32? reqsourceid3;
		public System.UInt32? reqsourceid4;
		public System.UInt16? reqsourcecount1;
		public System.UInt16? reqsourcecount2;
		public System.UInt16? reqsourcecount3;
		public System.UInt16? reqsourcecount4;
		public System.Int32? reqcreatureorgoid1;
		public System.Int32? reqcreatureorgoid2;
		public System.Int32? reqcreatureorgoid3;
		public System.Int32? reqcreatureorgoid4;
		public System.UInt16? reqcreatureorgocount1;
		public System.UInt16? reqcreatureorgocount2;
		public System.UInt16? reqcreatureorgocount3;
		public System.UInt16? reqcreatureorgocount4;
		public System.UInt32? reqspellcast1;
		public System.UInt32? reqspellcast2;
		public System.UInt32? reqspellcast3;
		public System.UInt32? reqspellcast4;
		public System.UInt32? rewchoiceitemid1;
		public System.UInt32? rewchoiceitemid2;
		public System.UInt32? rewchoiceitemid3;
		public System.UInt32? rewchoiceitemid4;
		public System.UInt32? rewchoiceitemid5;
		public System.UInt32? rewchoiceitemid6;
		public System.UInt16? rewchoiceitemcount1;
		public System.UInt16? rewchoiceitemcount2;
		public System.UInt16? rewchoiceitemcount3;
		public System.UInt16? rewchoiceitemcount4;
		public System.UInt16? rewchoiceitemcount5;
		public System.UInt16? rewchoiceitemcount6;
		public System.UInt32? rewitemid1;
		public System.UInt32? rewitemid2;
		public System.UInt32? rewitemid3;
		public System.UInt32? rewitemid4;
		public System.UInt16? rewitemcount1;
		public System.UInt16? rewitemcount2;
		public System.UInt16? rewitemcount3;
		public System.UInt16? rewitemcount4;
		public System.UInt16? rewrepfaction1;
		public System.UInt16? rewrepfaction2;
		public System.UInt16? rewrepfaction3;
		public System.UInt16? rewrepfaction4;
		public System.UInt16? rewrepfaction5;
		public System.SByte? rewrepvalueid1;
		public System.SByte? rewrepvalueid2;
		public System.SByte? rewrepvalueid3;
		public System.SByte? rewrepvalueid4;
		public System.SByte? rewrepvalueid5;
		public System.Int32? rewrepvalue1;
		public System.Int32? rewrepvalue2;
		public System.Int32? rewrepvalue3;
		public System.Int32? rewrepvalue4;
		public System.Int32? rewrepvalue5;
		public System.UInt32? rewhonoraddition;
		public System.Single? rewhonormultiplier;
		public System.Int32? reworreqmoney;
		public System.UInt32? rewmoneymaxlevel;
		public System.UInt32? rewspell;
		public System.UInt32? rewspellcast;
		public System.UInt32? rewmailtemplateid;
		public System.UInt32? rewmaildelaysecs;
		public System.UInt16? pointmapid;
		public System.Single? pointx;
		public System.Single? pointy;
		public System.UInt32? pointopt;
		public System.UInt16? detailsemote1;
		public System.UInt16? detailsemote2;
		public System.UInt16? detailsemote3;
		public System.UInt16? detailsemote4;
		public System.UInt32? detailsemotedelay1;
		public System.UInt32? detailsemotedelay2;
		public System.UInt32? detailsemotedelay3;
		public System.UInt32? detailsemotedelay4;
		public System.UInt16? incompleteemote;
		public System.UInt16? completeemote;
		public System.UInt16? offerrewardemote1;
		public System.UInt16? offerrewardemote2;
		public System.UInt16? offerrewardemote3;
		public System.UInt16? offerrewardemote4;
		public System.UInt32? offerrewardemotedelay1;
		public System.UInt32? offerrewardemotedelay2;
		public System.UInt32? offerrewardemotedelay3;
		public System.UInt32? offerrewardemotedelay4;
		public System.UInt32? startscript;
		public System.UInt32? completescript;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `method`, `zoneorsort`, `minlevel`, `questlevel`, `type`, `requiredclasses`, `requiredraces`, `requiredskill`, `requiredskillvalue`, `repobjectivefaction`, `repobjectivevalue`, `requiredminrepfaction`, `requiredminrepvalue`, `requiredmaxrepfaction`, `requiredmaxrepvalue`, `suggestedplayers`, `limittime`, `questflags`, `specialflags`, `chartitleid`, `playersslain`, `bonustalents`, `prevquestid`, `nextquestid`, `exclusivegroup`, `nextquestinchain`, `rewxpid`, `srcitemid`, `srcitemcount`, `srcspell`, `title`, `details`, `objectives`, `offerrewardtext`, `requestitemstext`, `endtext`, `completedtext`, `objectivetext1`, `objectivetext2`, `objectivetext3`, `objectivetext4`, `reqitemid1`, `reqitemid2`, `reqitemid3`, `reqitemid4`, `reqitemid5`, `reqitemid6`, `reqitemcount1`, `reqitemcount2`, `reqitemcount3`, `reqitemcount4`, `reqitemcount5`, `reqitemcount6`, `reqsourceid1`, `reqsourceid2`, `reqsourceid3`, `reqsourceid4`, `reqsourcecount1`, `reqsourcecount2`, `reqsourcecount3`, `reqsourcecount4`, `reqcreatureorgoid1`, `reqcreatureorgoid2`, `reqcreatureorgoid3`, `reqcreatureorgoid4`, `reqcreatureorgocount1`, `reqcreatureorgocount2`, `reqcreatureorgocount3`, `reqcreatureorgocount4`, `reqspellcast1`, `reqspellcast2`, `reqspellcast3`, `reqspellcast4`, `rewchoiceitemid1`, `rewchoiceitemid2`, `rewchoiceitemid3`, `rewchoiceitemid4`, `rewchoiceitemid5`, `rewchoiceitemid6`, `rewchoiceitemcount1`, `rewchoiceitemcount2`, `rewchoiceitemcount3`, `rewchoiceitemcount4`, `rewchoiceitemcount5`, `rewchoiceitemcount6`, `rewitemid1`, `rewitemid2`, `rewitemid3`, `rewitemid4`, `rewitemcount1`, `rewitemcount2`, `rewitemcount3`, `rewitemcount4`, `rewrepfaction1`, `rewrepfaction2`, `rewrepfaction3`, `rewrepfaction4`, `rewrepfaction5`, `rewrepvalueid1`, `rewrepvalueid2`, `rewrepvalueid3`, `rewrepvalueid4`, `rewrepvalueid5`, `rewrepvalue1`, `rewrepvalue2`, `rewrepvalue3`, `rewrepvalue4`, `rewrepvalue5`, `rewhonoraddition`, `rewhonormultiplier`, `reworreqmoney`, `rewmoneymaxlevel`, `rewspell`, `rewspellcast`, `rewmailtemplateid`, `rewmaildelaysecs`, `pointmapid`, `pointx`, `pointy`, `pointopt`, `detailsemote1`, `detailsemote2`, `detailsemote3`, `detailsemote4`, `detailsemotedelay1`, `detailsemotedelay2`, `detailsemotedelay3`, `detailsemotedelay4`, `incompleteemote`, `completeemote`, `offerrewardemote1`, `offerrewardemote2`, `offerrewardemote3`, `offerrewardemote4`, `offerrewardemotedelay1`, `offerrewardemotedelay2`, `offerrewardemotedelay3`, `offerrewardemotedelay4`, `startscript`, `completescript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}', '{79}', '{80}', '{81}', '{82}', '{83}', '{84}', '{85}', '{86}', '{87}', '{88}', '{89}', '{90}', '{91}', '{92}', '{93}', '{94}', '{95}', '{96}', '{97}', '{98}', '{99}', '{100}', '{101}', '{102}', '{103}', '{104}', '{105}', '{106}', '{107}', '{108}', '{109}', '{110}', '{111}', '{112}', '{113}', '{114}', '{115}', '{116}', '{117}', '{118}', '{119}', '{120}', '{121}', '{122}', '{123}', '{124}', '{125}', '{126}', '{127}', '{128}', '{129}', '{130}', '{131}', '{132}', '{133}', '{134}', '{135}', '{136}', '{137}', '{138}', '{139}', '{140}');", entry.GetValueOrDefault(), method.GetValueOrDefault(), zoneorsort.GetValueOrDefault(), minlevel.GetValueOrDefault(), questlevel.GetValueOrDefault(), type.GetValueOrDefault(), requiredclasses.GetValueOrDefault(), requiredraces.GetValueOrDefault(), requiredskill.GetValueOrDefault(), requiredskillvalue.GetValueOrDefault(), repobjectivefaction.GetValueOrDefault(), repobjectivevalue.GetValueOrDefault(), requiredminrepfaction.GetValueOrDefault(), requiredminrepvalue.GetValueOrDefault(), requiredmaxrepfaction.GetValueOrDefault(), requiredmaxrepvalue.GetValueOrDefault(), suggestedplayers.GetValueOrDefault(), limittime.GetValueOrDefault(), questflags.GetValueOrDefault(), specialflags.GetValueOrDefault(), chartitleid.GetValueOrDefault(), playersslain.GetValueOrDefault(), bonustalents.GetValueOrDefault(), prevquestid.GetValueOrDefault(), nextquestid.GetValueOrDefault(), exclusivegroup.GetValueOrDefault(), nextquestinchain.GetValueOrDefault(), rewxpid.GetValueOrDefault(), srcitemid.GetValueOrDefault(), srcitemcount.GetValueOrDefault(), srcspell.GetValueOrDefault(), title.ToSQL(), details.ToSQL(), objectives.ToSQL(), offerrewardtext.ToSQL(), requestitemstext.ToSQL(), endtext.ToSQL(), completedtext.ToSQL(), objectivetext1.ToSQL(), objectivetext2.ToSQL(), objectivetext3.ToSQL(), objectivetext4.ToSQL(), reqitemid1.GetValueOrDefault(), reqitemid2.GetValueOrDefault(), reqitemid3.GetValueOrDefault(), reqitemid4.GetValueOrDefault(), reqitemid5.GetValueOrDefault(), reqitemid6.GetValueOrDefault(), reqitemcount1.GetValueOrDefault(), reqitemcount2.GetValueOrDefault(), reqitemcount3.GetValueOrDefault(), reqitemcount4.GetValueOrDefault(), reqitemcount5.GetValueOrDefault(), reqitemcount6.GetValueOrDefault(), reqsourceid1.GetValueOrDefault(), reqsourceid2.GetValueOrDefault(), reqsourceid3.GetValueOrDefault(), reqsourceid4.GetValueOrDefault(), reqsourcecount1.GetValueOrDefault(), reqsourcecount2.GetValueOrDefault(), reqsourcecount3.GetValueOrDefault(), reqsourcecount4.GetValueOrDefault(), reqcreatureorgoid1.GetValueOrDefault(), reqcreatureorgoid2.GetValueOrDefault(), reqcreatureorgoid3.GetValueOrDefault(), reqcreatureorgoid4.GetValueOrDefault(), reqcreatureorgocount1.GetValueOrDefault(), reqcreatureorgocount2.GetValueOrDefault(), reqcreatureorgocount3.GetValueOrDefault(), reqcreatureorgocount4.GetValueOrDefault(), reqspellcast1.GetValueOrDefault(), reqspellcast2.GetValueOrDefault(), reqspellcast3.GetValueOrDefault(), reqspellcast4.GetValueOrDefault(), rewchoiceitemid1.GetValueOrDefault(), rewchoiceitemid2.GetValueOrDefault(), rewchoiceitemid3.GetValueOrDefault(), rewchoiceitemid4.GetValueOrDefault(), rewchoiceitemid5.GetValueOrDefault(), rewchoiceitemid6.GetValueOrDefault(), rewchoiceitemcount1.GetValueOrDefault(), rewchoiceitemcount2.GetValueOrDefault(), rewchoiceitemcount3.GetValueOrDefault(), rewchoiceitemcount4.GetValueOrDefault(), rewchoiceitemcount5.GetValueOrDefault(), rewchoiceitemcount6.GetValueOrDefault(), rewitemid1.GetValueOrDefault(), rewitemid2.GetValueOrDefault(), rewitemid3.GetValueOrDefault(), rewitemid4.GetValueOrDefault(), rewitemcount1.GetValueOrDefault(), rewitemcount2.GetValueOrDefault(), rewitemcount3.GetValueOrDefault(), rewitemcount4.GetValueOrDefault(), rewrepfaction1.GetValueOrDefault(), rewrepfaction2.GetValueOrDefault(), rewrepfaction3.GetValueOrDefault(), rewrepfaction4.GetValueOrDefault(), rewrepfaction5.GetValueOrDefault(), rewrepvalueid1.GetValueOrDefault(), rewrepvalueid2.GetValueOrDefault(), rewrepvalueid3.GetValueOrDefault(), rewrepvalueid4.GetValueOrDefault(), rewrepvalueid5.GetValueOrDefault(), rewrepvalue1.GetValueOrDefault(), rewrepvalue2.GetValueOrDefault(), rewrepvalue3.GetValueOrDefault(), rewrepvalue4.GetValueOrDefault(), rewrepvalue5.GetValueOrDefault(), rewhonoraddition.GetValueOrDefault(), ((Decimal)rewhonormultiplier.GetValueOrDefault()), reworreqmoney.GetValueOrDefault(), rewmoneymaxlevel.GetValueOrDefault(), rewspell.GetValueOrDefault(), rewspellcast.GetValueOrDefault(), rewmailtemplateid.GetValueOrDefault(), rewmaildelaysecs.GetValueOrDefault(), pointmapid.GetValueOrDefault(), ((Decimal)pointx.GetValueOrDefault()), ((Decimal)pointy.GetValueOrDefault()), pointopt.GetValueOrDefault(), detailsemote1.GetValueOrDefault(), detailsemote2.GetValueOrDefault(), detailsemote3.GetValueOrDefault(), detailsemote4.GetValueOrDefault(), detailsemotedelay1.GetValueOrDefault(), detailsemotedelay2.GetValueOrDefault(), detailsemotedelay3.GetValueOrDefault(), detailsemotedelay4.GetValueOrDefault(), incompleteemote.GetValueOrDefault(), completeemote.GetValueOrDefault(), offerrewardemote1.GetValueOrDefault(), offerrewardemote2.GetValueOrDefault(), offerrewardemote3.GetValueOrDefault(), offerrewardemote4.GetValueOrDefault(), offerrewardemotedelay1.GetValueOrDefault(), offerrewardemotedelay2.GetValueOrDefault(), offerrewardemotedelay3.GetValueOrDefault(), offerrewardemotedelay4.GetValueOrDefault(), startscript.GetValueOrDefault(), completescript.GetValueOrDefault());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(method != null)
			{
				sb.AppendLine("`method`='" + method.Value.ToString() + "'");
			}
			if(zoneorsort != null)
			{
				sb.AppendLine("`zoneorsort`='" + zoneorsort.Value.ToString() + "'");
			}
			if(minlevel != null)
			{
				sb.AppendLine("`minlevel`='" + minlevel.Value.ToString() + "'");
			}
			if(questlevel != null)
			{
				sb.AppendLine("`questlevel`='" + questlevel.Value.ToString() + "'");
			}
			if(type != null)
			{
				sb.AppendLine("`type`='" + type.Value.ToString() + "'");
			}
			if(requiredclasses != null)
			{
				sb.AppendLine("`requiredclasses`='" + requiredclasses.Value.ToString() + "'");
			}
			if(requiredraces != null)
			{
				sb.AppendLine("`requiredraces`='" + requiredraces.Value.ToString() + "'");
			}
			if(requiredskill != null)
			{
				sb.AppendLine("`requiredskill`='" + requiredskill.Value.ToString() + "'");
			}
			if(requiredskillvalue != null)
			{
				sb.AppendLine("`requiredskillvalue`='" + requiredskillvalue.Value.ToString() + "'");
			}
			if(repobjectivefaction != null)
			{
				sb.AppendLine("`repobjectivefaction`='" + repobjectivefaction.Value.ToString() + "'");
			}
			if(repobjectivevalue != null)
			{
				sb.AppendLine("`repobjectivevalue`='" + repobjectivevalue.Value.ToString() + "'");
			}
			if(requiredminrepfaction != null)
			{
				sb.AppendLine("`requiredminrepfaction`='" + requiredminrepfaction.Value.ToString() + "'");
			}
			if(requiredminrepvalue != null)
			{
				sb.AppendLine("`requiredminrepvalue`='" + requiredminrepvalue.Value.ToString() + "'");
			}
			if(requiredmaxrepfaction != null)
			{
				sb.AppendLine("`requiredmaxrepfaction`='" + requiredmaxrepfaction.Value.ToString() + "'");
			}
			if(requiredmaxrepvalue != null)
			{
				sb.AppendLine("`requiredmaxrepvalue`='" + requiredmaxrepvalue.Value.ToString() + "'");
			}
			if(suggestedplayers != null)
			{
				sb.AppendLine("`suggestedplayers`='" + suggestedplayers.Value.ToString() + "'");
			}
			if(limittime != null)
			{
				sb.AppendLine("`limittime`='" + limittime.Value.ToString() + "'");
			}
			if(questflags != null)
			{
				sb.AppendLine("`questflags`='" + questflags.Value.ToString() + "'");
			}
			if(specialflags != null)
			{
				sb.AppendLine("`specialflags`='" + specialflags.Value.ToString() + "'");
			}
			if(chartitleid != null)
			{
				sb.AppendLine("`chartitleid`='" + chartitleid.Value.ToString() + "'");
			}
			if(playersslain != null)
			{
				sb.AppendLine("`playersslain`='" + playersslain.Value.ToString() + "'");
			}
			if(bonustalents != null)
			{
				sb.AppendLine("`bonustalents`='" + bonustalents.Value.ToString() + "'");
			}
			if(prevquestid != null)
			{
				sb.AppendLine("`prevquestid`='" + prevquestid.Value.ToString() + "'");
			}
			if(nextquestid != null)
			{
				sb.AppendLine("`nextquestid`='" + nextquestid.Value.ToString() + "'");
			}
			if(exclusivegroup != null)
			{
				sb.AppendLine("`exclusivegroup`='" + exclusivegroup.Value.ToString() + "'");
			}
			if(nextquestinchain != null)
			{
				sb.AppendLine("`nextquestinchain`='" + nextquestinchain.Value.ToString() + "'");
			}
			if(rewxpid != null)
			{
				sb.AppendLine("`rewxpid`='" + rewxpid.Value.ToString() + "'");
			}
			if(srcitemid != null)
			{
				sb.AppendLine("`srcitemid`='" + srcitemid.Value.ToString() + "'");
			}
			if(srcitemcount != null)
			{
				sb.AppendLine("`srcitemcount`='" + srcitemcount.Value.ToString() + "'");
			}
			if(srcspell != null)
			{
				sb.AppendLine("`srcspell`='" + srcspell.Value.ToString() + "'");
			}
			if(title != null)
			{
				sb.AppendLine("`title`='" + title.ToSQL() + "'");
			}
			if(details != null)
			{
				sb.AppendLine("`details`='" + details.ToSQL() + "'");
			}
			if(objectives != null)
			{
				sb.AppendLine("`objectives`='" + objectives.ToSQL() + "'");
			}
			if(offerrewardtext != null)
			{
				sb.AppendLine("`offerrewardtext`='" + offerrewardtext.ToSQL() + "'");
			}
			if(requestitemstext != null)
			{
				sb.AppendLine("`requestitemstext`='" + requestitemstext.ToSQL() + "'");
			}
			if(endtext != null)
			{
				sb.AppendLine("`endtext`='" + endtext.ToSQL() + "'");
			}
			if(completedtext != null)
			{
				sb.AppendLine("`completedtext`='" + completedtext.ToSQL() + "'");
			}
			if(objectivetext1 != null)
			{
				sb.AppendLine("`objectivetext1`='" + objectivetext1.ToSQL() + "'");
			}
			if(objectivetext2 != null)
			{
				sb.AppendLine("`objectivetext2`='" + objectivetext2.ToSQL() + "'");
			}
			if(objectivetext3 != null)
			{
				sb.AppendLine("`objectivetext3`='" + objectivetext3.ToSQL() + "'");
			}
			if(objectivetext4 != null)
			{
				sb.AppendLine("`objectivetext4`='" + objectivetext4.ToSQL() + "'");
			}
			if(reqitemid1 != null)
			{
				sb.AppendLine("`reqitemid1`='" + reqitemid1.Value.ToString() + "'");
			}
			if(reqitemid2 != null)
			{
				sb.AppendLine("`reqitemid2`='" + reqitemid2.Value.ToString() + "'");
			}
			if(reqitemid3 != null)
			{
				sb.AppendLine("`reqitemid3`='" + reqitemid3.Value.ToString() + "'");
			}
			if(reqitemid4 != null)
			{
				sb.AppendLine("`reqitemid4`='" + reqitemid4.Value.ToString() + "'");
			}
			if(reqitemid5 != null)
			{
				sb.AppendLine("`reqitemid5`='" + reqitemid5.Value.ToString() + "'");
			}
			if(reqitemid6 != null)
			{
				sb.AppendLine("`reqitemid6`='" + reqitemid6.Value.ToString() + "'");
			}
			if(reqitemcount1 != null)
			{
				sb.AppendLine("`reqitemcount1`='" + reqitemcount1.Value.ToString() + "'");
			}
			if(reqitemcount2 != null)
			{
				sb.AppendLine("`reqitemcount2`='" + reqitemcount2.Value.ToString() + "'");
			}
			if(reqitemcount3 != null)
			{
				sb.AppendLine("`reqitemcount3`='" + reqitemcount3.Value.ToString() + "'");
			}
			if(reqitemcount4 != null)
			{
				sb.AppendLine("`reqitemcount4`='" + reqitemcount4.Value.ToString() + "'");
			}
			if(reqitemcount5 != null)
			{
				sb.AppendLine("`reqitemcount5`='" + reqitemcount5.Value.ToString() + "'");
			}
			if(reqitemcount6 != null)
			{
				sb.AppendLine("`reqitemcount6`='" + reqitemcount6.Value.ToString() + "'");
			}
			if(reqsourceid1 != null)
			{
				sb.AppendLine("`reqsourceid1`='" + reqsourceid1.Value.ToString() + "'");
			}
			if(reqsourceid2 != null)
			{
				sb.AppendLine("`reqsourceid2`='" + reqsourceid2.Value.ToString() + "'");
			}
			if(reqsourceid3 != null)
			{
				sb.AppendLine("`reqsourceid3`='" + reqsourceid3.Value.ToString() + "'");
			}
			if(reqsourceid4 != null)
			{
				sb.AppendLine("`reqsourceid4`='" + reqsourceid4.Value.ToString() + "'");
			}
			if(reqsourcecount1 != null)
			{
				sb.AppendLine("`reqsourcecount1`='" + reqsourcecount1.Value.ToString() + "'");
			}
			if(reqsourcecount2 != null)
			{
				sb.AppendLine("`reqsourcecount2`='" + reqsourcecount2.Value.ToString() + "'");
			}
			if(reqsourcecount3 != null)
			{
				sb.AppendLine("`reqsourcecount3`='" + reqsourcecount3.Value.ToString() + "'");
			}
			if(reqsourcecount4 != null)
			{
				sb.AppendLine("`reqsourcecount4`='" + reqsourcecount4.Value.ToString() + "'");
			}
			if(reqcreatureorgoid1 != null)
			{
				sb.AppendLine("`reqcreatureorgoid1`='" + reqcreatureorgoid1.Value.ToString() + "'");
			}
			if(reqcreatureorgoid2 != null)
			{
				sb.AppendLine("`reqcreatureorgoid2`='" + reqcreatureorgoid2.Value.ToString() + "'");
			}
			if(reqcreatureorgoid3 != null)
			{
				sb.AppendLine("`reqcreatureorgoid3`='" + reqcreatureorgoid3.Value.ToString() + "'");
			}
			if(reqcreatureorgoid4 != null)
			{
				sb.AppendLine("`reqcreatureorgoid4`='" + reqcreatureorgoid4.Value.ToString() + "'");
			}
			if(reqcreatureorgocount1 != null)
			{
				sb.AppendLine("`reqcreatureorgocount1`='" + reqcreatureorgocount1.Value.ToString() + "'");
			}
			if(reqcreatureorgocount2 != null)
			{
				sb.AppendLine("`reqcreatureorgocount2`='" + reqcreatureorgocount2.Value.ToString() + "'");
			}
			if(reqcreatureorgocount3 != null)
			{
				sb.AppendLine("`reqcreatureorgocount3`='" + reqcreatureorgocount3.Value.ToString() + "'");
			}
			if(reqcreatureorgocount4 != null)
			{
				sb.AppendLine("`reqcreatureorgocount4`='" + reqcreatureorgocount4.Value.ToString() + "'");
			}
			if(reqspellcast1 != null)
			{
				sb.AppendLine("`reqspellcast1`='" + reqspellcast1.Value.ToString() + "'");
			}
			if(reqspellcast2 != null)
			{
				sb.AppendLine("`reqspellcast2`='" + reqspellcast2.Value.ToString() + "'");
			}
			if(reqspellcast3 != null)
			{
				sb.AppendLine("`reqspellcast3`='" + reqspellcast3.Value.ToString() + "'");
			}
			if(reqspellcast4 != null)
			{
				sb.AppendLine("`reqspellcast4`='" + reqspellcast4.Value.ToString() + "'");
			}
			if(rewchoiceitemid1 != null)
			{
				sb.AppendLine("`rewchoiceitemid1`='" + rewchoiceitemid1.Value.ToString() + "'");
			}
			if(rewchoiceitemid2 != null)
			{
				sb.AppendLine("`rewchoiceitemid2`='" + rewchoiceitemid2.Value.ToString() + "'");
			}
			if(rewchoiceitemid3 != null)
			{
				sb.AppendLine("`rewchoiceitemid3`='" + rewchoiceitemid3.Value.ToString() + "'");
			}
			if(rewchoiceitemid4 != null)
			{
				sb.AppendLine("`rewchoiceitemid4`='" + rewchoiceitemid4.Value.ToString() + "'");
			}
			if(rewchoiceitemid5 != null)
			{
				sb.AppendLine("`rewchoiceitemid5`='" + rewchoiceitemid5.Value.ToString() + "'");
			}
			if(rewchoiceitemid6 != null)
			{
				sb.AppendLine("`rewchoiceitemid6`='" + rewchoiceitemid6.Value.ToString() + "'");
			}
			if(rewchoiceitemcount1 != null)
			{
				sb.AppendLine("`rewchoiceitemcount1`='" + rewchoiceitemcount1.Value.ToString() + "'");
			}
			if(rewchoiceitemcount2 != null)
			{
				sb.AppendLine("`rewchoiceitemcount2`='" + rewchoiceitemcount2.Value.ToString() + "'");
			}
			if(rewchoiceitemcount3 != null)
			{
				sb.AppendLine("`rewchoiceitemcount3`='" + rewchoiceitemcount3.Value.ToString() + "'");
			}
			if(rewchoiceitemcount4 != null)
			{
				sb.AppendLine("`rewchoiceitemcount4`='" + rewchoiceitemcount4.Value.ToString() + "'");
			}
			if(rewchoiceitemcount5 != null)
			{
				sb.AppendLine("`rewchoiceitemcount5`='" + rewchoiceitemcount5.Value.ToString() + "'");
			}
			if(rewchoiceitemcount6 != null)
			{
				sb.AppendLine("`rewchoiceitemcount6`='" + rewchoiceitemcount6.Value.ToString() + "'");
			}
			if(rewitemid1 != null)
			{
				sb.AppendLine("`rewitemid1`='" + rewitemid1.Value.ToString() + "'");
			}
			if(rewitemid2 != null)
			{
				sb.AppendLine("`rewitemid2`='" + rewitemid2.Value.ToString() + "'");
			}
			if(rewitemid3 != null)
			{
				sb.AppendLine("`rewitemid3`='" + rewitemid3.Value.ToString() + "'");
			}
			if(rewitemid4 != null)
			{
				sb.AppendLine("`rewitemid4`='" + rewitemid4.Value.ToString() + "'");
			}
			if(rewitemcount1 != null)
			{
				sb.AppendLine("`rewitemcount1`='" + rewitemcount1.Value.ToString() + "'");
			}
			if(rewitemcount2 != null)
			{
				sb.AppendLine("`rewitemcount2`='" + rewitemcount2.Value.ToString() + "'");
			}
			if(rewitemcount3 != null)
			{
				sb.AppendLine("`rewitemcount3`='" + rewitemcount3.Value.ToString() + "'");
			}
			if(rewitemcount4 != null)
			{
				sb.AppendLine("`rewitemcount4`='" + rewitemcount4.Value.ToString() + "'");
			}
			if(rewrepfaction1 != null)
			{
				sb.AppendLine("`rewrepfaction1`='" + rewrepfaction1.Value.ToString() + "'");
			}
			if(rewrepfaction2 != null)
			{
				sb.AppendLine("`rewrepfaction2`='" + rewrepfaction2.Value.ToString() + "'");
			}
			if(rewrepfaction3 != null)
			{
				sb.AppendLine("`rewrepfaction3`='" + rewrepfaction3.Value.ToString() + "'");
			}
			if(rewrepfaction4 != null)
			{
				sb.AppendLine("`rewrepfaction4`='" + rewrepfaction4.Value.ToString() + "'");
			}
			if(rewrepfaction5 != null)
			{
				sb.AppendLine("`rewrepfaction5`='" + rewrepfaction5.Value.ToString() + "'");
			}
			if(rewrepvalueid1 != null)
			{
				sb.AppendLine("`rewrepvalueid1`='" + rewrepvalueid1.Value.ToString() + "'");
			}
			if(rewrepvalueid2 != null)
			{
				sb.AppendLine("`rewrepvalueid2`='" + rewrepvalueid2.Value.ToString() + "'");
			}
			if(rewrepvalueid3 != null)
			{
				sb.AppendLine("`rewrepvalueid3`='" + rewrepvalueid3.Value.ToString() + "'");
			}
			if(rewrepvalueid4 != null)
			{
				sb.AppendLine("`rewrepvalueid4`='" + rewrepvalueid4.Value.ToString() + "'");
			}
			if(rewrepvalueid5 != null)
			{
				sb.AppendLine("`rewrepvalueid5`='" + rewrepvalueid5.Value.ToString() + "'");
			}
			if(rewrepvalue1 != null)
			{
				sb.AppendLine("`rewrepvalue1`='" + rewrepvalue1.Value.ToString() + "'");
			}
			if(rewrepvalue2 != null)
			{
				sb.AppendLine("`rewrepvalue2`='" + rewrepvalue2.Value.ToString() + "'");
			}
			if(rewrepvalue3 != null)
			{
				sb.AppendLine("`rewrepvalue3`='" + rewrepvalue3.Value.ToString() + "'");
			}
			if(rewrepvalue4 != null)
			{
				sb.AppendLine("`rewrepvalue4`='" + rewrepvalue4.Value.ToString() + "'");
			}
			if(rewrepvalue5 != null)
			{
				sb.AppendLine("`rewrepvalue5`='" + rewrepvalue5.Value.ToString() + "'");
			}
			if(rewhonoraddition != null)
			{
				sb.AppendLine("`rewhonoraddition`='" + rewhonoraddition.Value.ToString() + "'");
			}
			if(rewhonormultiplier != null)
			{
				sb.AppendLine("`rewhonormultiplier`='" + ((Decimal)rewhonormultiplier.Value).ToString() + "'");
			}
			if(reworreqmoney != null)
			{
				sb.AppendLine("`reworreqmoney`='" + reworreqmoney.Value.ToString() + "'");
			}
			if(rewmoneymaxlevel != null)
			{
				sb.AppendLine("`rewmoneymaxlevel`='" + rewmoneymaxlevel.Value.ToString() + "'");
			}
			if(rewspell != null)
			{
				sb.AppendLine("`rewspell`='" + rewspell.Value.ToString() + "'");
			}
			if(rewspellcast != null)
			{
				sb.AppendLine("`rewspellcast`='" + rewspellcast.Value.ToString() + "'");
			}
			if(rewmailtemplateid != null)
			{
				sb.AppendLine("`rewmailtemplateid`='" + rewmailtemplateid.Value.ToString() + "'");
			}
			if(rewmaildelaysecs != null)
			{
				sb.AppendLine("`rewmaildelaysecs`='" + rewmaildelaysecs.Value.ToString() + "'");
			}
			if(pointmapid != null)
			{
				sb.AppendLine("`pointmapid`='" + pointmapid.Value.ToString() + "'");
			}
			if(pointx != null)
			{
				sb.AppendLine("`pointx`='" + ((Decimal)pointx.Value).ToString() + "'");
			}
			if(pointy != null)
			{
				sb.AppendLine("`pointy`='" + ((Decimal)pointy.Value).ToString() + "'");
			}
			if(pointopt != null)
			{
				sb.AppendLine("`pointopt`='" + pointopt.Value.ToString() + "'");
			}
			if(detailsemote1 != null)
			{
				sb.AppendLine("`detailsemote1`='" + detailsemote1.Value.ToString() + "'");
			}
			if(detailsemote2 != null)
			{
				sb.AppendLine("`detailsemote2`='" + detailsemote2.Value.ToString() + "'");
			}
			if(detailsemote3 != null)
			{
				sb.AppendLine("`detailsemote3`='" + detailsemote3.Value.ToString() + "'");
			}
			if(detailsemote4 != null)
			{
				sb.AppendLine("`detailsemote4`='" + detailsemote4.Value.ToString() + "'");
			}
			if(detailsemotedelay1 != null)
			{
				sb.AppendLine("`detailsemotedelay1`='" + detailsemotedelay1.Value.ToString() + "'");
			}
			if(detailsemotedelay2 != null)
			{
				sb.AppendLine("`detailsemotedelay2`='" + detailsemotedelay2.Value.ToString() + "'");
			}
			if(detailsemotedelay3 != null)
			{
				sb.AppendLine("`detailsemotedelay3`='" + detailsemotedelay3.Value.ToString() + "'");
			}
			if(detailsemotedelay4 != null)
			{
				sb.AppendLine("`detailsemotedelay4`='" + detailsemotedelay4.Value.ToString() + "'");
			}
			if(incompleteemote != null)
			{
				sb.AppendLine("`incompleteemote`='" + incompleteemote.Value.ToString() + "'");
			}
			if(completeemote != null)
			{
				sb.AppendLine("`completeemote`='" + completeemote.Value.ToString() + "'");
			}
			if(offerrewardemote1 != null)
			{
				sb.AppendLine("`offerrewardemote1`='" + offerrewardemote1.Value.ToString() + "'");
			}
			if(offerrewardemote2 != null)
			{
				sb.AppendLine("`offerrewardemote2`='" + offerrewardemote2.Value.ToString() + "'");
			}
			if(offerrewardemote3 != null)
			{
				sb.AppendLine("`offerrewardemote3`='" + offerrewardemote3.Value.ToString() + "'");
			}
			if(offerrewardemote4 != null)
			{
				sb.AppendLine("`offerrewardemote4`='" + offerrewardemote4.Value.ToString() + "'");
			}
			if(offerrewardemotedelay1 != null)
			{
				sb.AppendLine("`offerrewardemotedelay1`='" + offerrewardemotedelay1.Value.ToString() + "'");
			}
			if(offerrewardemotedelay2 != null)
			{
				sb.AppendLine("`offerrewardemotedelay2`='" + offerrewardemotedelay2.Value.ToString() + "'");
			}
			if(offerrewardemotedelay3 != null)
			{
				sb.AppendLine("`offerrewardemotedelay3`='" + offerrewardemotedelay3.Value.ToString() + "'");
			}
			if(offerrewardemotedelay4 != null)
			{
				sb.AppendLine("`offerrewardemotedelay4`='" + offerrewardemotedelay4.Value.ToString() + "'");
			}
			if(startscript != null)
			{
				sb.AppendLine("`startscript`='" + startscript.Value.ToString() + "'");
			}
			if(completescript != null)
			{
				sb.AppendLine("`completescript`='" + completescript.Value.ToString() + "'");
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

		public quest_template() : base(TableName) 
        {
        }
	}
}
