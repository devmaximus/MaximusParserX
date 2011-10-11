using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Mangos
{
	public class creature_template : DumpObjectBase
    {
        public const string TableName = "creature_template";
		public System.UInt32? entry;
		public System.UInt32? difficulty_entry_1;
		public System.UInt32? difficulty_entry_2;
		public System.UInt32? difficulty_entry_3;
		public System.UInt32? killcredit1;
		public System.UInt32? killcredit2;
		public System.UInt32? modelid_1;
		public System.UInt32? modelid_2;
		public System.UInt32? modelid_3;
		public System.UInt32? modelid_4;
		public System.String name;
		public System.String subname;
		public System.String iconname;
		public System.UInt32? gossip_menu_id;
		public System.Byte? minlevel;
		public System.Byte? maxlevel;
		public System.UInt32? minhealth;
		public System.UInt32? maxhealth;
		public System.UInt32? minmana;
		public System.UInt32? maxmana;
		public System.UInt32? armor;
		public System.UInt16? faction_a;
		public System.UInt16? faction_h;
		public System.UInt32? npcflag;
		public System.Single? speed_walk;
		public System.Single? speed_run;
		public System.Single? scale;
		public System.Byte? rank;
		public System.Single? mindmg;
		public System.Single? maxdmg;
		public System.SByte? dmgschool;
		public System.UInt32? attackpower;
		public System.Single? dmg_multiplier;
		public System.UInt32? baseattacktime;
		public System.UInt32? rangeattacktime;
		public System.Byte? unit_class;
		public System.UInt32? unit_flags;
		public System.UInt32? dynamicflags;
		public System.SByte? family;
		public System.SByte? trainer_type;
		public System.UInt32? trainer_spell;
		public System.Byte? trainer_class;
		public System.Byte? trainer_race;
		public System.Single? minrangedmg;
		public System.Single? maxrangedmg;
		public System.UInt16? rangedattackpower;
		public System.Byte? type;
		public System.UInt32? type_flags;
		public System.UInt32? lootid;
		public System.UInt32? pickpocketloot;
		public System.UInt32? skinloot;
		public System.Int16? resistance1;
		public System.Int16? resistance2;
		public System.Int16? resistance3;
		public System.Int16? resistance4;
		public System.Int16? resistance5;
		public System.Int16? resistance6;
		public System.UInt32? spell1;
		public System.UInt32? spell2;
		public System.UInt32? spell3;
		public System.UInt32? spell4;
		public System.UInt32? petspelldataid;
		public System.UInt32? mingold;
		public System.UInt32? maxgold;
		public System.String ainame;
		public System.Byte? movementtype;
		public System.Byte? inhabittype;
		public System.Single? unk16;
		public System.Single? unk17;
		public System.Byte? racialleader;
		public System.UInt32? questitem1;
		public System.UInt32? questitem2;
		public System.UInt32? questitem3;
		public System.UInt32? questitem4;
		public System.UInt32? questitem5;
		public System.UInt32? questitem6;
		public System.UInt32? movementid;
		public System.Byte? regenhealth;
		public System.UInt32? vehicle_id;
		public System.UInt32? equipment_id;
		public System.UInt32? trainer_id;
		public System.UInt32? vendor_id;
		public System.UInt32? mechanic_immune_mask;
		public System.UInt32? flags_extra;
		public System.String scriptname;


		public override string GetInsertCommand()
		{
			return string.Format("INSERT IGNORE INTO `" + TableName + "` (`entry`, `difficulty_entry_1`, `difficulty_entry_2`, `difficulty_entry_3`, `killcredit1`, `killcredit2`, `modelid_1`, `modelid_2`, `modelid_3`, `modelid_4`, `name`, `subname`, `iconname`, `gossip_menu_id`, `minlevel`, `maxlevel`, `minhealth`, `maxhealth`, `minmana`, `maxmana`, `armor`, `faction_a`, `faction_h`, `npcflag`, `speed_walk`, `speed_run`, `scale`, `rank`, `mindmg`, `maxdmg`, `dmgschool`, `attackpower`, `dmg_multiplier`, `baseattacktime`, `rangeattacktime`, `unit_class`, `unit_flags`, `dynamicflags`, `family`, `trainer_type`, `trainer_spell`, `trainer_class`, `trainer_race`, `minrangedmg`, `maxrangedmg`, `rangedattackpower`, `type`, `type_flags`, `lootid`, `pickpocketloot`, `skinloot`, `resistance1`, `resistance2`, `resistance3`, `resistance4`, `resistance5`, `resistance6`, `spell1`, `spell2`, `spell3`, `spell4`, `petspelldataid`, `mingold`, `maxgold`, `ainame`, `movementtype`, `inhabittype`, `unk16`, `unk17`, `racialleader`, `questitem1`, `questitem2`, `questitem3`, `questitem4`, `questitem5`, `questitem6`, `movementid`, `regenhealth`, `vehicle_id`, `equipment_id`, `trainer_id`, `vendor_id`, `mechanic_immune_mask`, `flags_extra`, `scriptname`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}', '{79}', '{80}', '{81}', '{82}', '{83}', '{84}');", entry.GetValueOrDefault(), difficulty_entry_1.GetValueOrDefault(), difficulty_entry_2.GetValueOrDefault(), difficulty_entry_3.GetValueOrDefault(), killcredit1.GetValueOrDefault(), killcredit2.GetValueOrDefault(), modelid_1.GetValueOrDefault(), modelid_2.GetValueOrDefault(), modelid_3.GetValueOrDefault(), modelid_4.GetValueOrDefault(), name.ToSQL(), subname.ToSQL(), iconname.ToSQL(), gossip_menu_id.GetValueOrDefault(), minlevel.GetValueOrDefault(), maxlevel.GetValueOrDefault(), minhealth.GetValueOrDefault(), maxhealth.GetValueOrDefault(), minmana.GetValueOrDefault(), maxmana.GetValueOrDefault(), armor.GetValueOrDefault(), faction_a.GetValueOrDefault(), faction_h.GetValueOrDefault(), npcflag.GetValueOrDefault(), ((Decimal)speed_walk.GetValueOrDefault()), ((Decimal)speed_run.GetValueOrDefault()), ((Decimal)scale.GetValueOrDefault()), rank.GetValueOrDefault(), ((Decimal)mindmg.GetValueOrDefault()), ((Decimal)maxdmg.GetValueOrDefault()), dmgschool.GetValueOrDefault(), attackpower.GetValueOrDefault(), ((Decimal)dmg_multiplier.GetValueOrDefault()), baseattacktime.GetValueOrDefault(), rangeattacktime.GetValueOrDefault(), unit_class.GetValueOrDefault(), unit_flags.GetValueOrDefault(), dynamicflags.GetValueOrDefault(), family.GetValueOrDefault(), trainer_type.GetValueOrDefault(), trainer_spell.GetValueOrDefault(), trainer_class.GetValueOrDefault(), trainer_race.GetValueOrDefault(), ((Decimal)minrangedmg.GetValueOrDefault()), ((Decimal)maxrangedmg.GetValueOrDefault()), rangedattackpower.GetValueOrDefault(), type.GetValueOrDefault(), type_flags.GetValueOrDefault(), lootid.GetValueOrDefault(), pickpocketloot.GetValueOrDefault(), skinloot.GetValueOrDefault(), resistance1.GetValueOrDefault(), resistance2.GetValueOrDefault(), resistance3.GetValueOrDefault(), resistance4.GetValueOrDefault(), resistance5.GetValueOrDefault(), resistance6.GetValueOrDefault(), spell1.GetValueOrDefault(), spell2.GetValueOrDefault(), spell3.GetValueOrDefault(), spell4.GetValueOrDefault(), petspelldataid.GetValueOrDefault(), mingold.GetValueOrDefault(), maxgold.GetValueOrDefault(), ainame.ToSQL(), movementtype.GetValueOrDefault(), inhabittype.GetValueOrDefault(), ((Decimal)unk16.GetValueOrDefault()), ((Decimal)unk17.GetValueOrDefault()), racialleader.GetValueOrDefault(), questitem1.GetValueOrDefault(), questitem2.GetValueOrDefault(), questitem3.GetValueOrDefault(), questitem4.GetValueOrDefault(), questitem5.GetValueOrDefault(), questitem6.GetValueOrDefault(), movementid.GetValueOrDefault(), regenhealth.GetValueOrDefault(), vehicle_id.GetValueOrDefault(), equipment_id.GetValueOrDefault(), trainer_id.GetValueOrDefault(), vendor_id.GetValueOrDefault(), mechanic_immune_mask.GetValueOrDefault(), flags_extra.GetValueOrDefault(), scriptname.ToSQL());
		}

		public override string GetUpdateCommand()
		{
            var sb = new StringBuilder();
						sb.Append("UPDATE `" + TableName + "` SET ");
			if(difficulty_entry_1 != null)
			{
				sb.AppendLine("`difficulty_entry_1`='" + difficulty_entry_1.Value.ToString() + "'");
			}
			if(difficulty_entry_2 != null)
			{
				sb.AppendLine("`difficulty_entry_2`='" + difficulty_entry_2.Value.ToString() + "'");
			}
			if(difficulty_entry_3 != null)
			{
				sb.AppendLine("`difficulty_entry_3`='" + difficulty_entry_3.Value.ToString() + "'");
			}
			if(killcredit1 != null)
			{
				sb.AppendLine("`killcredit1`='" + killcredit1.Value.ToString() + "'");
			}
			if(killcredit2 != null)
			{
				sb.AppendLine("`killcredit2`='" + killcredit2.Value.ToString() + "'");
			}
			if(modelid_1 != null)
			{
				sb.AppendLine("`modelid_1`='" + modelid_1.Value.ToString() + "'");
			}
			if(modelid_2 != null)
			{
				sb.AppendLine("`modelid_2`='" + modelid_2.Value.ToString() + "'");
			}
			if(modelid_3 != null)
			{
				sb.AppendLine("`modelid_3`='" + modelid_3.Value.ToString() + "'");
			}
			if(modelid_4 != null)
			{
				sb.AppendLine("`modelid_4`='" + modelid_4.Value.ToString() + "'");
			}
			if(name != null)
			{
				sb.AppendLine("`name`='" + name.ToSQL() + "'");
			}
			if(subname != null)
			{
				sb.AppendLine("`subname`='" + subname.ToSQL() + "'");
			}
			if(iconname != null)
			{
				sb.AppendLine("`iconname`='" + iconname.ToSQL() + "'");
			}
			if(gossip_menu_id != null)
			{
				sb.AppendLine("`gossip_menu_id`='" + gossip_menu_id.Value.ToString() + "'");
			}
			if(minlevel != null)
			{
				sb.AppendLine("`minlevel`='" + minlevel.Value.ToString() + "'");
			}
			if(maxlevel != null)
			{
				sb.AppendLine("`maxlevel`='" + maxlevel.Value.ToString() + "'");
			}
			if(minhealth != null)
			{
				sb.AppendLine("`minhealth`='" + minhealth.Value.ToString() + "'");
			}
			if(maxhealth != null)
			{
				sb.AppendLine("`maxhealth`='" + maxhealth.Value.ToString() + "'");
			}
			if(minmana != null)
			{
				sb.AppendLine("`minmana`='" + minmana.Value.ToString() + "'");
			}
			if(maxmana != null)
			{
				sb.AppendLine("`maxmana`='" + maxmana.Value.ToString() + "'");
			}
			if(armor != null)
			{
				sb.AppendLine("`armor`='" + armor.Value.ToString() + "'");
			}
			if(faction_a != null)
			{
				sb.AppendLine("`faction_a`='" + faction_a.Value.ToString() + "'");
			}
			if(faction_h != null)
			{
				sb.AppendLine("`faction_h`='" + faction_h.Value.ToString() + "'");
			}
			if(npcflag != null)
			{
				sb.AppendLine("`npcflag`='" + npcflag.Value.ToString() + "'");
			}
			if(speed_walk != null)
			{
				sb.AppendLine("`speed_walk`='" + ((Decimal)speed_walk.Value).ToString() + "'");
			}
			if(speed_run != null)
			{
				sb.AppendLine("`speed_run`='" + ((Decimal)speed_run.Value).ToString() + "'");
			}
			if(scale != null)
			{
				sb.AppendLine("`scale`='" + ((Decimal)scale.Value).ToString() + "'");
			}
			if(rank != null)
			{
				sb.AppendLine("`rank`='" + rank.Value.ToString() + "'");
			}
			if(mindmg != null)
			{
				sb.AppendLine("`mindmg`='" + ((Decimal)mindmg.Value).ToString() + "'");
			}
			if(maxdmg != null)
			{
				sb.AppendLine("`maxdmg`='" + ((Decimal)maxdmg.Value).ToString() + "'");
			}
			if(dmgschool != null)
			{
				sb.AppendLine("`dmgschool`='" + dmgschool.Value.ToString() + "'");
			}
			if(attackpower != null)
			{
				sb.AppendLine("`attackpower`='" + attackpower.Value.ToString() + "'");
			}
			if(dmg_multiplier != null)
			{
				sb.AppendLine("`dmg_multiplier`='" + ((Decimal)dmg_multiplier.Value).ToString() + "'");
			}
			if(baseattacktime != null)
			{
				sb.AppendLine("`baseattacktime`='" + baseattacktime.Value.ToString() + "'");
			}
			if(rangeattacktime != null)
			{
				sb.AppendLine("`rangeattacktime`='" + rangeattacktime.Value.ToString() + "'");
			}
			if(unit_class != null)
			{
				sb.AppendLine("`unit_class`='" + unit_class.Value.ToString() + "'");
			}
			if(unit_flags != null)
			{
				sb.AppendLine("`unit_flags`='" + unit_flags.Value.ToString() + "'");
			}
			if(dynamicflags != null)
			{
				sb.AppendLine("`dynamicflags`='" + dynamicflags.Value.ToString() + "'");
			}
			if(family != null)
			{
				sb.AppendLine("`family`='" + family.Value.ToString() + "'");
			}
			if(trainer_type != null)
			{
				sb.AppendLine("`trainer_type`='" + trainer_type.Value.ToString() + "'");
			}
			if(trainer_spell != null)
			{
				sb.AppendLine("`trainer_spell`='" + trainer_spell.Value.ToString() + "'");
			}
			if(trainer_class != null)
			{
				sb.AppendLine("`trainer_class`='" + trainer_class.Value.ToString() + "'");
			}
			if(trainer_race != null)
			{
				sb.AppendLine("`trainer_race`='" + trainer_race.Value.ToString() + "'");
			}
			if(minrangedmg != null)
			{
				sb.AppendLine("`minrangedmg`='" + ((Decimal)minrangedmg.Value).ToString() + "'");
			}
			if(maxrangedmg != null)
			{
				sb.AppendLine("`maxrangedmg`='" + ((Decimal)maxrangedmg.Value).ToString() + "'");
			}
			if(rangedattackpower != null)
			{
				sb.AppendLine("`rangedattackpower`='" + rangedattackpower.Value.ToString() + "'");
			}
			if(type != null)
			{
				sb.AppendLine("`type`='" + type.Value.ToString() + "'");
			}
			if(type_flags != null)
			{
				sb.AppendLine("`type_flags`='" + type_flags.Value.ToString() + "'");
			}
			if(lootid != null)
			{
				sb.AppendLine("`lootid`='" + lootid.Value.ToString() + "'");
			}
			if(pickpocketloot != null)
			{
				sb.AppendLine("`pickpocketloot`='" + pickpocketloot.Value.ToString() + "'");
			}
			if(skinloot != null)
			{
				sb.AppendLine("`skinloot`='" + skinloot.Value.ToString() + "'");
			}
			if(resistance1 != null)
			{
				sb.AppendLine("`resistance1`='" + resistance1.Value.ToString() + "'");
			}
			if(resistance2 != null)
			{
				sb.AppendLine("`resistance2`='" + resistance2.Value.ToString() + "'");
			}
			if(resistance3 != null)
			{
				sb.AppendLine("`resistance3`='" + resistance3.Value.ToString() + "'");
			}
			if(resistance4 != null)
			{
				sb.AppendLine("`resistance4`='" + resistance4.Value.ToString() + "'");
			}
			if(resistance5 != null)
			{
				sb.AppendLine("`resistance5`='" + resistance5.Value.ToString() + "'");
			}
			if(resistance6 != null)
			{
				sb.AppendLine("`resistance6`='" + resistance6.Value.ToString() + "'");
			}
			if(spell1 != null)
			{
				sb.AppendLine("`spell1`='" + spell1.Value.ToString() + "'");
			}
			if(spell2 != null)
			{
				sb.AppendLine("`spell2`='" + spell2.Value.ToString() + "'");
			}
			if(spell3 != null)
			{
				sb.AppendLine("`spell3`='" + spell3.Value.ToString() + "'");
			}
			if(spell4 != null)
			{
				sb.AppendLine("`spell4`='" + spell4.Value.ToString() + "'");
			}
			if(petspelldataid != null)
			{
				sb.AppendLine("`petspelldataid`='" + petspelldataid.Value.ToString() + "'");
			}
			if(mingold != null)
			{
				sb.AppendLine("`mingold`='" + mingold.Value.ToString() + "'");
			}
			if(maxgold != null)
			{
				sb.AppendLine("`maxgold`='" + maxgold.Value.ToString() + "'");
			}
			if(ainame != null)
			{
				sb.AppendLine("`ainame`='" + ainame.ToSQL() + "'");
			}
			if(movementtype != null)
			{
				sb.AppendLine("`movementtype`='" + movementtype.Value.ToString() + "'");
			}
			if(inhabittype != null)
			{
				sb.AppendLine("`inhabittype`='" + inhabittype.Value.ToString() + "'");
			}
			if(unk16 != null)
			{
				sb.AppendLine("`unk16`='" + ((Decimal)unk16.Value).ToString() + "'");
			}
			if(unk17 != null)
			{
				sb.AppendLine("`unk17`='" + ((Decimal)unk17.Value).ToString() + "'");
			}
			if(racialleader != null)
			{
				sb.AppendLine("`racialleader`='" + racialleader.Value.ToString() + "'");
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
			if(movementid != null)
			{
				sb.AppendLine("`movementid`='" + movementid.Value.ToString() + "'");
			}
			if(regenhealth != null)
			{
				sb.AppendLine("`regenhealth`='" + regenhealth.Value.ToString() + "'");
			}
			if(vehicle_id != null)
			{
				sb.AppendLine("`vehicle_id`='" + vehicle_id.Value.ToString() + "'");
			}
			if(equipment_id != null)
			{
				sb.AppendLine("`equipment_id`='" + equipment_id.Value.ToString() + "'");
			}
			if(trainer_id != null)
			{
				sb.AppendLine("`trainer_id`='" + trainer_id.Value.ToString() + "'");
			}
			if(vendor_id != null)
			{
				sb.AppendLine("`vendor_id`='" + vendor_id.Value.ToString() + "'");
			}
			if(mechanic_immune_mask != null)
			{
				sb.AppendLine("`mechanic_immune_mask`='" + mechanic_immune_mask.Value.ToString() + "'");
			}
			if(flags_extra != null)
			{
				sb.AppendLine("`flags_extra`='" + flags_extra.Value.ToString() + "'");
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

		public creature_template() : base(TableName) 
        {
        }
	}
}
