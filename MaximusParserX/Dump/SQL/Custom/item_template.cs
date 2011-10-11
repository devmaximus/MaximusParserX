using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
	public class item_template : CustomDumpObjectBase
    {
        public const string TableName = "item_template";
		public System.UInt32? entry;
		public System.Byte? class_;
		public System.Byte? subclass;
		public System.Int32? unk0;
		public System.String name;
		public System.UInt32? displayid;
		public System.Byte? quality;
		public System.UInt32? flags;
		public System.UInt32? flags2;
		public System.Byte? buycount;
		public System.UInt32? buyprice;
		public System.UInt32? sellprice;
		public System.Byte? inventorytype;
		public System.Int32? allowableclass;
		public System.Int32? allowablerace;
		public System.UInt16? itemlevel;
		public System.Byte? requiredlevel;
		public System.UInt16? requiredskill;
		public System.UInt16? requiredskillrank;
		public System.UInt32? requiredspell;
		public System.UInt32? requiredhonorrank;
		public System.UInt32? requiredcityrank;
		public System.UInt16? requiredreputationfaction;
		public System.UInt16? requiredreputationrank;
		public System.Int16? maxcount;
		public System.Int16? stackable;
		public System.Byte? containerslots;
		public System.Byte? statscount;
		public System.Byte? stat_type1;
		public System.Int16? stat_value1;
		public System.Byte? stat_type2;
		public System.Int16? stat_value2;
		public System.Byte? stat_type3;
		public System.Int16? stat_value3;
		public System.Byte? stat_type4;
		public System.Int16? stat_value4;
		public System.Byte? stat_type5;
		public System.Int16? stat_value5;
		public System.Byte? stat_type6;
		public System.Int16? stat_value6;
		public System.Byte? stat_type7;
		public System.Int16? stat_value7;
		public System.Byte? stat_type8;
		public System.Int16? stat_value8;
		public System.Byte? stat_type9;
		public System.Int16? stat_value9;
		public System.Byte? stat_type10;
		public System.Int16? stat_value10;
		public System.Int16? scalingstatdistribution;
		public System.UInt32? scalingstatvalue;
		public System.Single? dmg_min1;
		public System.Single? dmg_max1;
		public System.Byte? dmg_type1;
		public System.Single? dmg_min2;
		public System.Single? dmg_max2;
		public System.Byte? dmg_type2;
		public System.UInt16? armor;
		public System.Byte? holy_res;
		public System.Byte? fire_res;
		public System.Byte? nature_res;
		public System.Byte? frost_res;
		public System.Byte? shadow_res;
		public System.Byte? arcane_res;
		public System.UInt16? delay;
		public System.Byte? ammo_type;
		public System.Single? rangedmodrange;
		public System.UInt32? spellid_1;
		public System.Byte? spelltrigger_1;
		public System.Int16? spellcharges_1;
		public System.Single? spellppmrate_1;
		public System.Int32? spellcooldown_1;
		public System.UInt16? spellcategory_1;
		public System.Int32? spellcategorycooldown_1;
		public System.UInt32? spellid_2;
		public System.Byte? spelltrigger_2;
		public System.Int16? spellcharges_2;
		public System.Single? spellppmrate_2;
		public System.Int32? spellcooldown_2;
		public System.UInt16? spellcategory_2;
		public System.Int32? spellcategorycooldown_2;
		public System.UInt32? spellid_3;
		public System.Byte? spelltrigger_3;
		public System.Int16? spellcharges_3;
		public System.Single? spellppmrate_3;
		public System.Int32? spellcooldown_3;
		public System.UInt16? spellcategory_3;
		public System.Int32? spellcategorycooldown_3;
		public System.UInt32? spellid_4;
		public System.Byte? spelltrigger_4;
		public System.Int16? spellcharges_4;
		public System.Single? spellppmrate_4;
		public System.Int32? spellcooldown_4;
		public System.UInt16? spellcategory_4;
		public System.Int32? spellcategorycooldown_4;
		public System.UInt32? spellid_5;
		public System.Byte? spelltrigger_5;
		public System.Int16? spellcharges_5;
		public System.Single? spellppmrate_5;
		public System.Int32? spellcooldown_5;
		public System.UInt16? spellcategory_5;
		public System.Int32? spellcategorycooldown_5;
		public System.Byte? bonding;
		public System.String description;
		public System.UInt32? pagetext;
		public System.Byte? languageid;
		public System.Byte? pagematerial;
		public System.UInt32? startquest;
		public System.UInt32? lockid;
		public System.SByte? material;
		public System.Byte? sheath;
		public System.UInt32? randomproperty;
		public System.UInt32? randomsuffix;
		public System.UInt32? block;
		public System.UInt32? itemset;
		public System.UInt16? maxdurability;
		public System.UInt32? area;
		public System.Int16? map;
		public System.Int32? bagfamily;
		public System.Int32? totemcategory;
		public System.SByte? socketcolor_1;
		public System.Int32? socketcontent_1;
		public System.SByte? socketcolor_2;
		public System.Int32? socketcontent_2;
		public System.SByte? socketcolor_3;
		public System.Int32? socketcontent_3;
		public System.Int32? socketbonus;
		public System.Int32? gemproperties;
		public System.Int16? requireddisenchantskill;
		public System.Single? armordamagemodifier;
		public System.UInt32? duration;
		public System.Int16? itemlimitcategory;
		public System.UInt32? holidayid;
		public System.String scriptname;
		public System.UInt32? disenchantid;
		public System.Byte? foodtype;
		public System.UInt32? minmoneyloot;
		public System.UInt32? maxmoneyloot;
		public System.Byte? extraflags;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `class`, `subclass`, `unk0`, `name`, `displayid`, `quality`, `flags`, `flags2`, `buycount`, `buyprice`, `sellprice`, `inventorytype`, `allowableclass`, `allowablerace`, `itemlevel`, `requiredlevel`, `requiredskill`, `requiredskillrank`, `requiredspell`, `requiredhonorrank`, `requiredcityrank`, `requiredreputationfaction`, `requiredreputationrank`, `maxcount`, `stackable`, `containerslots`, `statscount`, `stat_type1`, `stat_value1`, `stat_type2`, `stat_value2`, `stat_type3`, `stat_value3`, `stat_type4`, `stat_value4`, `stat_type5`, `stat_value5`, `stat_type6`, `stat_value6`, `stat_type7`, `stat_value7`, `stat_type8`, `stat_value8`, `stat_type9`, `stat_value9`, `stat_type10`, `stat_value10`, `scalingstatdistribution`, `scalingstatvalue`, `dmg_min1`, `dmg_max1`, `dmg_type1`, `dmg_min2`, `dmg_max2`, `dmg_type2`, `armor`, `holy_res`, `fire_res`, `nature_res`, `frost_res`, `shadow_res`, `arcane_res`, `delay`, `ammo_type`, `rangedmodrange`, `spellid_1`, `spelltrigger_1`, `spellcharges_1`, `spellppmrate_1`, `spellcooldown_1`, `spellcategory_1`, `spellcategorycooldown_1`, `spellid_2`, `spelltrigger_2`, `spellcharges_2`, `spellppmrate_2`, `spellcooldown_2`, `spellcategory_2`, `spellcategorycooldown_2`, `spellid_3`, `spelltrigger_3`, `spellcharges_3`, `spellppmrate_3`, `spellcooldown_3`, `spellcategory_3`, `spellcategorycooldown_3`, `spellid_4`, `spelltrigger_4`, `spellcharges_4`, `spellppmrate_4`, `spellcooldown_4`, `spellcategory_4`, `spellcategorycooldown_4`, `spellid_5`, `spelltrigger_5`, `spellcharges_5`, `spellppmrate_5`, `spellcooldown_5`, `spellcategory_5`, `spellcategorycooldown_5`, `bonding`, `description`, `pagetext`, `languageid`, `pagematerial`, `startquest`, `lockid`, `material`, `sheath`, `randomproperty`, `randomsuffix`, `block`, `itemset`, `maxdurability`, `area`, `map`, `bagfamily`, `totemcategory`, `socketcolor_1`, `socketcontent_1`, `socketcolor_2`, `socketcontent_2`, `socketcolor_3`, `socketcontent_3`, `socketbonus`, `gemproperties`, `requireddisenchantskill`, `armordamagemodifier`, `duration`, `itemlimitcategory`, `holidayid`, `scriptname`, `disenchantid`, `foodtype`, `minmoneyloot`, `maxmoneyloot`, `extraflags`{138}) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}', '{79}', '{80}', '{81}', '{82}', '{83}', '{84}', '{85}', '{86}', '{87}', '{88}', '{89}', '{90}', '{91}', '{92}', '{93}', '{94}', '{95}', '{96}', '{97}', '{98}', '{99}', '{100}', '{101}', '{102}', '{103}', '{104}', '{105}', '{106}', '{107}', '{108}', '{109}', '{110}', '{111}', '{112}', '{113}', '{114}', '{115}', '{116}', '{117}', '{118}', '{119}', '{120}', '{121}', '{122}', '{123}', '{124}', '{125}', '{126}', '{127}', '{128}', '{129}', '{130}', '{131}', '{132}', '{133}', '{134}', '{135}', '{136}', '{137}'{139});", entry.GetValueOrDefault(), class_.GetValueOrDefault(), subclass.GetValueOrDefault(), unk0.GetValueOrDefault(), name.ToSQL(), displayid.GetValueOrDefault(), quality.GetValueOrDefault(), flags.GetValueOrDefault(), flags2.GetValueOrDefault(), buycount.GetValueOrDefault(), buyprice.GetValueOrDefault(), sellprice.GetValueOrDefault(), inventorytype.GetValueOrDefault(), allowableclass.GetValueOrDefault(), allowablerace.GetValueOrDefault(), itemlevel.GetValueOrDefault(), requiredlevel.GetValueOrDefault(), requiredskill.GetValueOrDefault(), requiredskillrank.GetValueOrDefault(), requiredspell.GetValueOrDefault(), requiredhonorrank.GetValueOrDefault(), requiredcityrank.GetValueOrDefault(), requiredreputationfaction.GetValueOrDefault(), requiredreputationrank.GetValueOrDefault(), maxcount.GetValueOrDefault(), stackable.GetValueOrDefault(), containerslots.GetValueOrDefault(), statscount.GetValueOrDefault(), stat_type1.GetValueOrDefault(), stat_value1.GetValueOrDefault(), stat_type2.GetValueOrDefault(), stat_value2.GetValueOrDefault(), stat_type3.GetValueOrDefault(), stat_value3.GetValueOrDefault(), stat_type4.GetValueOrDefault(), stat_value4.GetValueOrDefault(), stat_type5.GetValueOrDefault(), stat_value5.GetValueOrDefault(), stat_type6.GetValueOrDefault(), stat_value6.GetValueOrDefault(), stat_type7.GetValueOrDefault(), stat_value7.GetValueOrDefault(), stat_type8.GetValueOrDefault(), stat_value8.GetValueOrDefault(), stat_type9.GetValueOrDefault(), stat_value9.GetValueOrDefault(), stat_type10.GetValueOrDefault(), stat_value10.GetValueOrDefault(), scalingstatdistribution.GetValueOrDefault(), scalingstatvalue.GetValueOrDefault(), ((Decimal)dmg_min1.GetValueOrDefault()), ((Decimal)dmg_max1.GetValueOrDefault()), dmg_type1.GetValueOrDefault(), ((Decimal)dmg_min2.GetValueOrDefault()), ((Decimal)dmg_max2.GetValueOrDefault()), dmg_type2.GetValueOrDefault(), armor.GetValueOrDefault(), holy_res.GetValueOrDefault(), fire_res.GetValueOrDefault(), nature_res.GetValueOrDefault(), frost_res.GetValueOrDefault(), shadow_res.GetValueOrDefault(), arcane_res.GetValueOrDefault(), delay.GetValueOrDefault(), ammo_type.GetValueOrDefault(), ((Decimal)rangedmodrange.GetValueOrDefault()), spellid_1.GetValueOrDefault(), spelltrigger_1.GetValueOrDefault(), spellcharges_1.GetValueOrDefault(), ((Decimal)spellppmrate_1.GetValueOrDefault()), spellcooldown_1.GetValueOrDefault(), spellcategory_1.GetValueOrDefault(), spellcategorycooldown_1.GetValueOrDefault(), spellid_2.GetValueOrDefault(), spelltrigger_2.GetValueOrDefault(), spellcharges_2.GetValueOrDefault(), ((Decimal)spellppmrate_2.GetValueOrDefault()), spellcooldown_2.GetValueOrDefault(), spellcategory_2.GetValueOrDefault(), spellcategorycooldown_2.GetValueOrDefault(), spellid_3.GetValueOrDefault(), spelltrigger_3.GetValueOrDefault(), spellcharges_3.GetValueOrDefault(), ((Decimal)spellppmrate_3.GetValueOrDefault()), spellcooldown_3.GetValueOrDefault(), spellcategory_3.GetValueOrDefault(), spellcategorycooldown_3.GetValueOrDefault(), spellid_4.GetValueOrDefault(), spelltrigger_4.GetValueOrDefault(), spellcharges_4.GetValueOrDefault(), ((Decimal)spellppmrate_4.GetValueOrDefault()), spellcooldown_4.GetValueOrDefault(), spellcategory_4.GetValueOrDefault(), spellcategorycooldown_4.GetValueOrDefault(), spellid_5.GetValueOrDefault(), spelltrigger_5.GetValueOrDefault(), spellcharges_5.GetValueOrDefault(), ((Decimal)spellppmrate_5.GetValueOrDefault()), spellcooldown_5.GetValueOrDefault(), spellcategory_5.GetValueOrDefault(), spellcategorycooldown_5.GetValueOrDefault(), bonding.GetValueOrDefault(), description.ToSQL(), pagetext.GetValueOrDefault(), languageid.GetValueOrDefault(), pagematerial.GetValueOrDefault(), startquest.GetValueOrDefault(), lockid.GetValueOrDefault(), material.GetValueOrDefault(), sheath.GetValueOrDefault(), randomproperty.GetValueOrDefault(), randomsuffix.GetValueOrDefault(), block.GetValueOrDefault(), itemset.GetValueOrDefault(), maxdurability.GetValueOrDefault(), area.GetValueOrDefault(), map.GetValueOrDefault(), bagfamily.GetValueOrDefault(), totemcategory.GetValueOrDefault(), socketcolor_1.GetValueOrDefault(), socketcontent_1.GetValueOrDefault(), socketcolor_2.GetValueOrDefault(), socketcontent_2.GetValueOrDefault(), socketcolor_3.GetValueOrDefault(), socketcontent_3.GetValueOrDefault(), socketbonus.GetValueOrDefault(), gemproperties.GetValueOrDefault(), requireddisenchantskill.GetValueOrDefault(), ((Decimal)armordamagemodifier.GetValueOrDefault()), duration.GetValueOrDefault(), itemlimitcategory.GetValueOrDefault(), holidayid.GetValueOrDefault(), scriptname.ToSQL(), disenchantid.GetValueOrDefault(), foodtype.GetValueOrDefault(), minmoneyloot.GetValueOrDefault(), maxmoneyloot.GetValueOrDefault(), extraflags.GetValueOrDefault(), GetInsertCommandCustomFields(), GetInsertCommandCustomValues());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(class_ != null)
			{
				sb.AppendLine("`class`='" + class_.Value.ToString() + "'");
			}
			if(subclass != null)
			{
				sb.AppendLine("`subclass`='" + subclass.Value.ToString() + "'");
			}
			if(unk0 != null)
			{
				sb.AppendLine("`unk0`='" + unk0.Value.ToString() + "'");
			}
			if(name != null)
			{
				sb.AppendLine("`name`='" + name.ToSQL() + "'");
			}
			if(displayid != null)
			{
				sb.AppendLine("`displayid`='" + displayid.Value.ToString() + "'");
			}
			if(quality != null)
			{
				sb.AppendLine("`quality`='" + quality.Value.ToString() + "'");
			}
			if(flags != null)
			{
				sb.AppendLine("`flags`='" + flags.Value.ToString() + "'");
			}
			if(flags2 != null)
			{
				sb.AppendLine("`flags2`='" + flags2.Value.ToString() + "'");
			}
			if(buycount != null)
			{
				sb.AppendLine("`buycount`='" + buycount.Value.ToString() + "'");
			}
			if(buyprice != null)
			{
				sb.AppendLine("`buyprice`='" + buyprice.Value.ToString() + "'");
			}
			if(sellprice != null)
			{
				sb.AppendLine("`sellprice`='" + sellprice.Value.ToString() + "'");
			}
			if(inventorytype != null)
			{
				sb.AppendLine("`inventorytype`='" + inventorytype.Value.ToString() + "'");
			}
			if(allowableclass != null)
			{
				sb.AppendLine("`allowableclass`='" + allowableclass.Value.ToString() + "'");
			}
			if(allowablerace != null)
			{
				sb.AppendLine("`allowablerace`='" + allowablerace.Value.ToString() + "'");
			}
			if(itemlevel != null)
			{
				sb.AppendLine("`itemlevel`='" + itemlevel.Value.ToString() + "'");
			}
			if(requiredlevel != null)
			{
				sb.AppendLine("`requiredlevel`='" + requiredlevel.Value.ToString() + "'");
			}
			if(requiredskill != null)
			{
				sb.AppendLine("`requiredskill`='" + requiredskill.Value.ToString() + "'");
			}
			if(requiredskillrank != null)
			{
				sb.AppendLine("`requiredskillrank`='" + requiredskillrank.Value.ToString() + "'");
			}
			if(requiredspell != null)
			{
				sb.AppendLine("`requiredspell`='" + requiredspell.Value.ToString() + "'");
			}
			if(requiredhonorrank != null)
			{
				sb.AppendLine("`requiredhonorrank`='" + requiredhonorrank.Value.ToString() + "'");
			}
			if(requiredcityrank != null)
			{
				sb.AppendLine("`requiredcityrank`='" + requiredcityrank.Value.ToString() + "'");
			}
			if(requiredreputationfaction != null)
			{
				sb.AppendLine("`requiredreputationfaction`='" + requiredreputationfaction.Value.ToString() + "'");
			}
			if(requiredreputationrank != null)
			{
				sb.AppendLine("`requiredreputationrank`='" + requiredreputationrank.Value.ToString() + "'");
			}
			if(maxcount != null)
			{
				sb.AppendLine("`maxcount`='" + maxcount.Value.ToString() + "'");
			}
			if(stackable != null)
			{
				sb.AppendLine("`stackable`='" + stackable.Value.ToString() + "'");
			}
			if(containerslots != null)
			{
				sb.AppendLine("`containerslots`='" + containerslots.Value.ToString() + "'");
			}
			if(statscount != null)
			{
				sb.AppendLine("`statscount`='" + statscount.Value.ToString() + "'");
			}
			if(stat_type1 != null)
			{
				sb.AppendLine("`stat_type1`='" + stat_type1.Value.ToString() + "'");
			}
			if(stat_value1 != null)
			{
				sb.AppendLine("`stat_value1`='" + stat_value1.Value.ToString() + "'");
			}
			if(stat_type2 != null)
			{
				sb.AppendLine("`stat_type2`='" + stat_type2.Value.ToString() + "'");
			}
			if(stat_value2 != null)
			{
				sb.AppendLine("`stat_value2`='" + stat_value2.Value.ToString() + "'");
			}
			if(stat_type3 != null)
			{
				sb.AppendLine("`stat_type3`='" + stat_type3.Value.ToString() + "'");
			}
			if(stat_value3 != null)
			{
				sb.AppendLine("`stat_value3`='" + stat_value3.Value.ToString() + "'");
			}
			if(stat_type4 != null)
			{
				sb.AppendLine("`stat_type4`='" + stat_type4.Value.ToString() + "'");
			}
			if(stat_value4 != null)
			{
				sb.AppendLine("`stat_value4`='" + stat_value4.Value.ToString() + "'");
			}
			if(stat_type5 != null)
			{
				sb.AppendLine("`stat_type5`='" + stat_type5.Value.ToString() + "'");
			}
			if(stat_value5 != null)
			{
				sb.AppendLine("`stat_value5`='" + stat_value5.Value.ToString() + "'");
			}
			if(stat_type6 != null)
			{
				sb.AppendLine("`stat_type6`='" + stat_type6.Value.ToString() + "'");
			}
			if(stat_value6 != null)
			{
				sb.AppendLine("`stat_value6`='" + stat_value6.Value.ToString() + "'");
			}
			if(stat_type7 != null)
			{
				sb.AppendLine("`stat_type7`='" + stat_type7.Value.ToString() + "'");
			}
			if(stat_value7 != null)
			{
				sb.AppendLine("`stat_value7`='" + stat_value7.Value.ToString() + "'");
			}
			if(stat_type8 != null)
			{
				sb.AppendLine("`stat_type8`='" + stat_type8.Value.ToString() + "'");
			}
			if(stat_value8 != null)
			{
				sb.AppendLine("`stat_value8`='" + stat_value8.Value.ToString() + "'");
			}
			if(stat_type9 != null)
			{
				sb.AppendLine("`stat_type9`='" + stat_type9.Value.ToString() + "'");
			}
			if(stat_value9 != null)
			{
				sb.AppendLine("`stat_value9`='" + stat_value9.Value.ToString() + "'");
			}
			if(stat_type10 != null)
			{
				sb.AppendLine("`stat_type10`='" + stat_type10.Value.ToString() + "'");
			}
			if(stat_value10 != null)
			{
				sb.AppendLine("`stat_value10`='" + stat_value10.Value.ToString() + "'");
			}
			if(scalingstatdistribution != null)
			{
				sb.AppendLine("`scalingstatdistribution`='" + scalingstatdistribution.Value.ToString() + "'");
			}
			if(scalingstatvalue != null)
			{
				sb.AppendLine("`scalingstatvalue`='" + scalingstatvalue.Value.ToString() + "'");
			}
			if(dmg_min1 != null)
			{
				sb.AppendLine("`dmg_min1`='" + ((Decimal)dmg_min1.Value).ToString() + "'");
			}
			if(dmg_max1 != null)
			{
				sb.AppendLine("`dmg_max1`='" + ((Decimal)dmg_max1.Value).ToString() + "'");
			}
			if(dmg_type1 != null)
			{
				sb.AppendLine("`dmg_type1`='" + dmg_type1.Value.ToString() + "'");
			}
			if(dmg_min2 != null)
			{
				sb.AppendLine("`dmg_min2`='" + ((Decimal)dmg_min2.Value).ToString() + "'");
			}
			if(dmg_max2 != null)
			{
				sb.AppendLine("`dmg_max2`='" + ((Decimal)dmg_max2.Value).ToString() + "'");
			}
			if(dmg_type2 != null)
			{
				sb.AppendLine("`dmg_type2`='" + dmg_type2.Value.ToString() + "'");
			}
			if(armor != null)
			{
				sb.AppendLine("`armor`='" + armor.Value.ToString() + "'");
			}
			if(holy_res != null)
			{
				sb.AppendLine("`holy_res`='" + holy_res.Value.ToString() + "'");
			}
			if(fire_res != null)
			{
				sb.AppendLine("`fire_res`='" + fire_res.Value.ToString() + "'");
			}
			if(nature_res != null)
			{
				sb.AppendLine("`nature_res`='" + nature_res.Value.ToString() + "'");
			}
			if(frost_res != null)
			{
				sb.AppendLine("`frost_res`='" + frost_res.Value.ToString() + "'");
			}
			if(shadow_res != null)
			{
				sb.AppendLine("`shadow_res`='" + shadow_res.Value.ToString() + "'");
			}
			if(arcane_res != null)
			{
				sb.AppendLine("`arcane_res`='" + arcane_res.Value.ToString() + "'");
			}
			if(delay != null)
			{
				sb.AppendLine("`delay`='" + delay.Value.ToString() + "'");
			}
			if(ammo_type != null)
			{
				sb.AppendLine("`ammo_type`='" + ammo_type.Value.ToString() + "'");
			}
			if(rangedmodrange != null)
			{
				sb.AppendLine("`rangedmodrange`='" + ((Decimal)rangedmodrange.Value).ToString() + "'");
			}
			if(spellid_1 != null)
			{
				sb.AppendLine("`spellid_1`='" + spellid_1.Value.ToString() + "'");
			}
			if(spelltrigger_1 != null)
			{
				sb.AppendLine("`spelltrigger_1`='" + spelltrigger_1.Value.ToString() + "'");
			}
			if(spellcharges_1 != null)
			{
				sb.AppendLine("`spellcharges_1`='" + spellcharges_1.Value.ToString() + "'");
			}
			if(spellppmrate_1 != null)
			{
				sb.AppendLine("`spellppmrate_1`='" + ((Decimal)spellppmrate_1.Value).ToString() + "'");
			}
			if(spellcooldown_1 != null)
			{
				sb.AppendLine("`spellcooldown_1`='" + spellcooldown_1.Value.ToString() + "'");
			}
			if(spellcategory_1 != null)
			{
				sb.AppendLine("`spellcategory_1`='" + spellcategory_1.Value.ToString() + "'");
			}
			if(spellcategorycooldown_1 != null)
			{
				sb.AppendLine("`spellcategorycooldown_1`='" + spellcategorycooldown_1.Value.ToString() + "'");
			}
			if(spellid_2 != null)
			{
				sb.AppendLine("`spellid_2`='" + spellid_2.Value.ToString() + "'");
			}
			if(spelltrigger_2 != null)
			{
				sb.AppendLine("`spelltrigger_2`='" + spelltrigger_2.Value.ToString() + "'");
			}
			if(spellcharges_2 != null)
			{
				sb.AppendLine("`spellcharges_2`='" + spellcharges_2.Value.ToString() + "'");
			}
			if(spellppmrate_2 != null)
			{
				sb.AppendLine("`spellppmrate_2`='" + ((Decimal)spellppmrate_2.Value).ToString() + "'");
			}
			if(spellcooldown_2 != null)
			{
				sb.AppendLine("`spellcooldown_2`='" + spellcooldown_2.Value.ToString() + "'");
			}
			if(spellcategory_2 != null)
			{
				sb.AppendLine("`spellcategory_2`='" + spellcategory_2.Value.ToString() + "'");
			}
			if(spellcategorycooldown_2 != null)
			{
				sb.AppendLine("`spellcategorycooldown_2`='" + spellcategorycooldown_2.Value.ToString() + "'");
			}
			if(spellid_3 != null)
			{
				sb.AppendLine("`spellid_3`='" + spellid_3.Value.ToString() + "'");
			}
			if(spelltrigger_3 != null)
			{
				sb.AppendLine("`spelltrigger_3`='" + spelltrigger_3.Value.ToString() + "'");
			}
			if(spellcharges_3 != null)
			{
				sb.AppendLine("`spellcharges_3`='" + spellcharges_3.Value.ToString() + "'");
			}
			if(spellppmrate_3 != null)
			{
				sb.AppendLine("`spellppmrate_3`='" + ((Decimal)spellppmrate_3.Value).ToString() + "'");
			}
			if(spellcooldown_3 != null)
			{
				sb.AppendLine("`spellcooldown_3`='" + spellcooldown_3.Value.ToString() + "'");
			}
			if(spellcategory_3 != null)
			{
				sb.AppendLine("`spellcategory_3`='" + spellcategory_3.Value.ToString() + "'");
			}
			if(spellcategorycooldown_3 != null)
			{
				sb.AppendLine("`spellcategorycooldown_3`='" + spellcategorycooldown_3.Value.ToString() + "'");
			}
			if(spellid_4 != null)
			{
				sb.AppendLine("`spellid_4`='" + spellid_4.Value.ToString() + "'");
			}
			if(spelltrigger_4 != null)
			{
				sb.AppendLine("`spelltrigger_4`='" + spelltrigger_4.Value.ToString() + "'");
			}
			if(spellcharges_4 != null)
			{
				sb.AppendLine("`spellcharges_4`='" + spellcharges_4.Value.ToString() + "'");
			}
			if(spellppmrate_4 != null)
			{
				sb.AppendLine("`spellppmrate_4`='" + ((Decimal)spellppmrate_4.Value).ToString() + "'");
			}
			if(spellcooldown_4 != null)
			{
				sb.AppendLine("`spellcooldown_4`='" + spellcooldown_4.Value.ToString() + "'");
			}
			if(spellcategory_4 != null)
			{
				sb.AppendLine("`spellcategory_4`='" + spellcategory_4.Value.ToString() + "'");
			}
			if(spellcategorycooldown_4 != null)
			{
				sb.AppendLine("`spellcategorycooldown_4`='" + spellcategorycooldown_4.Value.ToString() + "'");
			}
			if(spellid_5 != null)
			{
				sb.AppendLine("`spellid_5`='" + spellid_5.Value.ToString() + "'");
			}
			if(spelltrigger_5 != null)
			{
				sb.AppendLine("`spelltrigger_5`='" + spelltrigger_5.Value.ToString() + "'");
			}
			if(spellcharges_5 != null)
			{
				sb.AppendLine("`spellcharges_5`='" + spellcharges_5.Value.ToString() + "'");
			}
			if(spellppmrate_5 != null)
			{
				sb.AppendLine("`spellppmrate_5`='" + ((Decimal)spellppmrate_5.Value).ToString() + "'");
			}
			if(spellcooldown_5 != null)
			{
				sb.AppendLine("`spellcooldown_5`='" + spellcooldown_5.Value.ToString() + "'");
			}
			if(spellcategory_5 != null)
			{
				sb.AppendLine("`spellcategory_5`='" + spellcategory_5.Value.ToString() + "'");
			}
			if(spellcategorycooldown_5 != null)
			{
				sb.AppendLine("`spellcategorycooldown_5`='" + spellcategorycooldown_5.Value.ToString() + "'");
			}
			if(bonding != null)
			{
				sb.AppendLine("`bonding`='" + bonding.Value.ToString() + "'");
			}
			if(description != null)
			{
				sb.AppendLine("`description`='" + description.ToSQL() + "'");
			}
			if(pagetext != null)
			{
				sb.AppendLine("`pagetext`='" + pagetext.Value.ToString() + "'");
			}
			if(languageid != null)
			{
				sb.AppendLine("`languageid`='" + languageid.Value.ToString() + "'");
			}
			if(pagematerial != null)
			{
				sb.AppendLine("`pagematerial`='" + pagematerial.Value.ToString() + "'");
			}
			if(startquest != null)
			{
				sb.AppendLine("`startquest`='" + startquest.Value.ToString() + "'");
			}
			if(lockid != null)
			{
				sb.AppendLine("`lockid`='" + lockid.Value.ToString() + "'");
			}
			if(material != null)
			{
				sb.AppendLine("`material`='" + material.Value.ToString() + "'");
			}
			if(sheath != null)
			{
				sb.AppendLine("`sheath`='" + sheath.Value.ToString() + "'");
			}
			if(randomproperty != null)
			{
				sb.AppendLine("`randomproperty`='" + randomproperty.Value.ToString() + "'");
			}
			if(randomsuffix != null)
			{
				sb.AppendLine("`randomsuffix`='" + randomsuffix.Value.ToString() + "'");
			}
			if(block != null)
			{
				sb.AppendLine("`block`='" + block.Value.ToString() + "'");
			}
			if(itemset != null)
			{
				sb.AppendLine("`itemset`='" + itemset.Value.ToString() + "'");
			}
			if(maxdurability != null)
			{
				sb.AppendLine("`maxdurability`='" + maxdurability.Value.ToString() + "'");
			}
			if(area != null)
			{
				sb.AppendLine("`area`='" + area.Value.ToString() + "'");
			}
			if(map != null)
			{
				sb.AppendLine("`map`='" + map.Value.ToString() + "'");
			}
			if(bagfamily != null)
			{
				sb.AppendLine("`bagfamily`='" + bagfamily.Value.ToString() + "'");
			}
			if(totemcategory != null)
			{
				sb.AppendLine("`totemcategory`='" + totemcategory.Value.ToString() + "'");
			}
			if(socketcolor_1 != null)
			{
				sb.AppendLine("`socketcolor_1`='" + socketcolor_1.Value.ToString() + "'");
			}
			if(socketcontent_1 != null)
			{
				sb.AppendLine("`socketcontent_1`='" + socketcontent_1.Value.ToString() + "'");
			}
			if(socketcolor_2 != null)
			{
				sb.AppendLine("`socketcolor_2`='" + socketcolor_2.Value.ToString() + "'");
			}
			if(socketcontent_2 != null)
			{
				sb.AppendLine("`socketcontent_2`='" + socketcontent_2.Value.ToString() + "'");
			}
			if(socketcolor_3 != null)
			{
				sb.AppendLine("`socketcolor_3`='" + socketcolor_3.Value.ToString() + "'");
			}
			if(socketcontent_3 != null)
			{
				sb.AppendLine("`socketcontent_3`='" + socketcontent_3.Value.ToString() + "'");
			}
			if(socketbonus != null)
			{
				sb.AppendLine("`socketbonus`='" + socketbonus.Value.ToString() + "'");
			}
			if(gemproperties != null)
			{
				sb.AppendLine("`gemproperties`='" + gemproperties.Value.ToString() + "'");
			}
			if(requireddisenchantskill != null)
			{
				sb.AppendLine("`requireddisenchantskill`='" + requireddisenchantskill.Value.ToString() + "'");
			}
			if(armordamagemodifier != null)
			{
				sb.AppendLine("`armordamagemodifier`='" + ((Decimal)armordamagemodifier.Value).ToString() + "'");
			}
			if(duration != null)
			{
				sb.AppendLine("`duration`='" + duration.Value.ToString() + "'");
			}
			if(itemlimitcategory != null)
			{
				sb.AppendLine("`itemlimitcategory`='" + itemlimitcategory.Value.ToString() + "'");
			}
			if(holidayid != null)
			{
				sb.AppendLine("`holidayid`='" + holidayid.Value.ToString() + "'");
			}
			if(scriptname != null)
			{
				sb.AppendLine("`scriptname`='" + scriptname.ToSQL() + "'");
			}
			if(disenchantid != null)
			{
				sb.AppendLine("`disenchantid`='" + disenchantid.Value.ToString() + "'");
			}
			if(foodtype != null)
			{
				sb.AppendLine("`foodtype`='" + foodtype.Value.ToString() + "'");
			}
			if(minmoneyloot != null)
			{
				sb.AppendLine("`minmoneyloot`='" + minmoneyloot.Value.ToString() + "'");
			}
			if(maxmoneyloot != null)
			{
				sb.AppendLine("`maxmoneyloot`='" + maxmoneyloot.Value.ToString() + "'");
			}
			if(extraflags != null)
			{
				sb.AppendLine("`extraflags`='" + extraflags.Value.ToString() + "'");
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

		public item_template() : base(TableName) 
        {
        }
	}
}
