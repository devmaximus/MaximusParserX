using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_QUERY_TIME_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var curTime = ReadTime("Current Time");

            var dailyReset = ReadInt32("Daily Quest Reset");

            return Validate();
        }
    }

    public class CMSG_NAME_QUERY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadWoWGuid("GUID");

            return Validate();
        }
    }

    public class ReadQueryHeaderBase : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var entry = ReadInt32("Entry");
            var guid = ReadWoWGuid("GUID");

            return Validate();
        }
    }

    public class CMSG_CREATURE_QUERY_DEF : ReadQueryHeaderBase { }

    public class CMSG_PAGE_TEXT_QUERY_DEF : ReadQueryHeaderBase { }

    public class CMSG_NPC_TEXT_QUERY_DEF : ReadQueryHeaderBase { }

    public class SMSG_CREATURE_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var creature_template = ParseCreatureTemplate();

            Dump.SQL.QueryResponseHandler.AddCreatureTemplate(this.ClientBuildAmount, creature_template);

            Core.Cache.AddCreatureInfo(new WoW.CacheObjects.CreatureInfo(creature_template));

            return Validate();
        }

        private MaximusParserX.Dump.SQL.Custom.creature_template ParseCreatureTemplate()
        {
            var creature_template = new MaximusParserX.Dump.SQL.Custom.creature_template();

            creature_template.entry = ReadUInt32("entry");
            creature_template.name = ReadCString("name");

            var name2 = ReadCString("name2");
            var name3 = ReadCString("name3");
            var name4 = ReadCString("name4");

            creature_template.subname = ReadCString("subname");

            if (ClientBuildAmount >= 7561)
            {
                creature_template.iconname = ReadCString("iconname");   //"Directions" for guard, string unk 2.3.0.7561
            }

            creature_template.flags_extra = (uint)ReadEnum<CreatureTypeFlags>("CreatureTypeFlags");  //flags
            creature_template.type = (byte)ReadEnum<CreatureType>("CreatureType");
            creature_template.family = (sbyte)ReadEnum<CreatureFamily>("CreatureFamily");     //family
            creature_template.rank = (byte)ReadEnum<CreatureRank>("CreatureRank");          //rank 

            if (ClientBuildAmount < 9183)
            {
                var unknown = ReadUInt32("unknown");                    //unknown
            }

            if (ClientBuildAmount >= 9767)
            {
                creature_template.killcredit1 = ReadUInt32("killcredit1");                  // new in 3.1, kill credit
                creature_template.killcredit2 = ReadUInt32("killcredit2");                  // new in 3.1, kill credit
            }

            if (ClientBuildAmount < 10314)
            {
                var spelldataid = ReadUInt32("spelldataid");//template.spelldataid Id from CreatureSpellData.dbc
            }

            creature_template.modelid_1 = ReadUInt32("modelid_1");
            creature_template.modelid_2 = ReadUInt32("modelid_2");
            creature_template.modelid_3 = ReadUInt32("modelid_3");
            creature_template.modelid_4 = ReadUInt32("modelid_4");
            creature_template.unk16 = ReadSingle("unk16");
            creature_template.unk17 = ReadSingle("unk17");
            creature_template.racialleader = ReadByte("racialleader");

            if (ClientBuildAmount > 9551)
            {
                creature_template.questitem1 = ReadUInt32("questitem1");
                creature_template.questitem2 = ReadUInt32("questitem2");
                creature_template.questitem3 = ReadUInt32("questitem3");
                creature_template.questitem4 = ReadUInt32("questitem4");

                if (ClientBuildAmount >= 10314)
                {
                    creature_template.questitem5 = ReadUInt32("questitem5");
                    creature_template.questitem6 = ReadUInt32("questitem6");
                }
            }

            if (ClientBuildAmount > 9947)
            {
                creature_template.movementid = ReadUInt32("movementid");
            }

            return creature_template;
        }
    }

    public class SMSG_GAMEOBJECT_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            if (BaseStream.Length > 4)
            {
                var gameobject_template = ParseGameObjectTemplate();
                Dump.SQL.QueryResponseHandler.AddGameObjectTemplate(this.ClientBuildAmount, gameobject_template);
            }
            else
            {
                MarkAsRead();
            }

            return Validate();
        }

        public MaximusParserX.Dump.SQL.Custom.gameobject_template ParseGameObjectTemplate()
        {
            ResetPosition();

            var gameobject_template = new MaximusParserX.Dump.SQL.Custom.gameobject_template();

            gameobject_template.entry = ReadUInt32("entry");
            gameobject_template.type = (byte)ReadUInt32("type");
            gameobject_template.displayid = ReadUInt32("displayid");

            gameobject_template.name = ReadCString("name");
            var name2 = ReadCString("name2");// name2, name3, name4
            var name3 = ReadCString("name3");
            var name4 = ReadCString("name4");
            gameobject_template.iconname = ReadCString("iconname");// 2.0.3, string
            gameobject_template.castbarcaption = ReadCString("castbarcaption");// 2.0.3, string
            gameobject_template.unk1 = ReadCString("unk1");// 2.0.3, probably string

            gameobject_template.data0 = ReadUInt32("data0");
            gameobject_template.data1 = ReadUInt32("data1");
            gameobject_template.data2 = ReadUInt32("data2");
            gameobject_template.data3 = ReadUInt32("data3");
            gameobject_template.data4 = ReadUInt32("data4");
            gameobject_template.data5 = ReadUInt32("data5");
            gameobject_template.data6 = ReadUInt32("data6");
            gameobject_template.data7 = ReadUInt32("data7");
            gameobject_template.data8 = ReadUInt32("data8");
            gameobject_template.data9 = ReadUInt32("data9");
            gameobject_template.data10 = ReadUInt32("data10");
            gameobject_template.data11 = ReadUInt32("data11");
            gameobject_template.data12 = ReadUInt32("data12");
            gameobject_template.data13 = ReadUInt32("data13");
            gameobject_template.data14 = ReadUInt32("data14");
            gameobject_template.data15 = ReadUInt32("data15");
            gameobject_template.data16 = ReadUInt32("data16");
            gameobject_template.data17 = ReadUInt32("data17");
            gameobject_template.data18 = ReadUInt32("data18");
            gameobject_template.data19 = ReadUInt32("data19");
            gameobject_template.data20 = ReadUInt32("data20");
            gameobject_template.data21 = ReadUInt32("data21");
            gameobject_template.data22 = ReadUInt32("data22");

            if (ClientBuildAmount >= 8606)
            {
                gameobject_template.data23 = ReadUInt32("data23");
            }

            gameobject_template.size = ReadSingle("size");

            if (ClientBuildAmount > 9551)
            {
                gameobject_template.questitem1 = ReadUInt32("questitem1");
                gameobject_template.questitem2 = ReadUInt32("questitem2");
                gameobject_template.questitem3 = ReadUInt32("questitem3");
                gameobject_template.questitem4 = ReadUInt32("questitem4");
                if (ClientBuildAmount >= 10314)
                {
                    gameobject_template.questitem5 = ReadUInt32("questitem5");
                    gameobject_template.questitem6 = ReadUInt32("questitem6");
                }
            }

            return gameobject_template;
        }
    }

    public class SMSG_ITEM_QUERY_MULTIPLE_RESPONSE_DEF : SMSG_ITEM_QUERY_SINGLE_RESPONSE_DEF { }

    public class SMSG_ITEM_QUERY_SINGLE_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var item_template = ParseItemTemplate();

            Dump.SQL.QueryResponseHandler.AddItemTemplate(this.ClientBuildAmount, item_template);


            return Validate();

        }

        public MaximusParserX.Dump.SQL.Custom.item_template ParseItemTemplate()
        {
            var item_template = new MaximusParserX.Dump.SQL.Custom.item_template();

            item_template.entry = ReadUInt32("entry");

            item_template.class_ = (byte)ReadUInt32("class");
            item_template.subclass = (byte)ReadUInt32("subclass");
            item_template.unk0 = (int)ReadUInt32("unk0");                                 // new 2.0.3, not exist in wdb cache?
            item_template.name = ReadCString("name");
            var name2 = ReadCString("name2"); //Name2
            var name3 = ReadCString("name3"); //Name3
            var name4 = ReadCString("name4"); //Name4
            item_template.displayid = ReadUInt32("displayid");
            item_template.quality = (byte)ReadUInt32("quality");
            item_template.flags = ReadUInt32("flags");

            if (ClientBuildAmount >= 10314)
            {
                item_template.flags2 = ReadUInt32("flags2");
            }

            item_template.buyprice = ReadUInt32("buyprice");
            item_template.sellprice = ReadUInt32("sellprice");
            item_template.inventorytype = (byte)ReadUInt32("inventorytype");
            item_template.allowableclass = (byte)ReadUInt32("allowableclass");

            item_template.allowablerace = (int)ReadUInt32("allowablerace");
            item_template.itemlevel = (ushort)ReadUInt32("itemlevel");
            item_template.requiredlevel = (byte)ReadUInt32("requiredlevel");
            item_template.requiredskill = (ushort)ReadUInt32("requiredskill");
            item_template.requiredskillrank = (ushort)ReadUInt32("requiredskillrank");
            item_template.requiredspell = ReadUInt32("requiredspell");
            item_template.requiredhonorrank = ReadUInt32("requiredhonorrank");
            item_template.requiredcityrank = ReadUInt32("requiredcityrank");
            item_template.requiredreputationfaction = (ushort)ReadUInt32("requiredreputationfaction");
            item_template.requiredreputationrank = (ushort)ReadUInt32("requiredreputationrank");
            item_template.maxcount = (short)ReadUInt32("maxcount");
            item_template.stackable = (short)ReadUInt32("stackable");
            item_template.containerslots = (byte)ReadUInt32("containerslots");

            if (ClientBuildAmount >= 9183)
            {
                item_template.statscount = (byte)ReadUInt32("statscount");
            }
            else
            {
                item_template.statscount = 10;
            }

            for (int i = 1; i <= item_template.statscount; i++)
            {

                switch (i)
                {
                    case 1:
                        {
                            item_template.stat_type1 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value1 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 2:
                        {
                            item_template.stat_type2 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value2 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 3:
                        {
                            item_template.stat_type3 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value3 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 4:
                        {
                            item_template.stat_type4 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value4 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 5:
                        {
                            item_template.stat_type5 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value5 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 6:
                        {
                            item_template.stat_type6 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value6 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 7:
                        {
                            item_template.stat_type7 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value7 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 8:
                        {
                            item_template.stat_type8 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value8 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 9:
                        {
                            item_template.stat_type9 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value9 = (short)ReadUInt32("stat_value" + i);
                        } break;
                    case 10:
                        {
                            item_template.stat_type10 = (byte)ReadUInt32("stat_type" + i);
                            item_template.stat_value10 = (short)ReadUInt32("stat_value" + i);
                        } break;
                }
            }

            if (ClientBuildAmount >= 9183)
            {
                item_template.scalingstatdistribution = (short)ReadUInt32("scalingstatdistribution");            // scaling stats distribution
                item_template.scalingstatvalue = ReadUInt32("scalingstatvalue");                   // some kind of flags used to determine stat values column
            }

            int DamageCount = 0;

            if (ClientBuildAmount > 9551)
            {
                DamageCount = 2;
            }
            else
            {
                DamageCount = 5;
            }

            for (int i = 1; i <= DamageCount; i++)
            {

                switch (i)
                {
                    case 1:
                        {
                            item_template.dmg_min1 = ReadSingle("dmg_min" + i);
                            item_template.dmg_max1 = ReadSingle("dmg_max" + i);
                            item_template.dmg_type1 = (byte)ReadUInt32("dmg_type" + i);
                        } break;
                    case 2:
                        {
                            item_template.dmg_min2 = ReadSingle("dmg_min" + i);
                            item_template.dmg_max2 = ReadSingle("dmg_max" + i);
                            item_template.dmg_type2 = (byte)ReadUInt32("dmg_type" + i);
                        } break;
                    default:
                        {
                            var dmg_min = ReadSingle("dmg_min" + i); //dmg_min2 3-5
                            var dmg_max = ReadSingle("dmg_max" + i); //dmg_max2 3-5
                            var dmg_type = ReadUInt32("dmg_type" + i); //dmg_type2 3-5
                        } break;
                }

            }

            // resistances (7)
            item_template.armor = (ushort)ReadUInt32("armor");
            item_template.holy_res = (byte)ReadUInt32("holy_res");
            item_template.fire_res = (byte)ReadUInt32("fire_res");
            item_template.nature_res = (byte)ReadUInt32("nature_res");
            item_template.frost_res = (byte)ReadUInt32("frost_res");
            item_template.shadow_res = (byte)ReadUInt32("shadow_res");
            item_template.arcane_res = (byte)ReadUInt32("arcane_res");

            item_template.delay = (ushort)ReadUInt32("delay");
            item_template.ammo_type = (byte)ReadUInt32("ammo_type");
            item_template.rangedmodrange = ReadSingle("rangedmodrange");

            var spellcount = 5;
            for (int i = 1; i <= spellcount; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            item_template.spellid_1 = ReadUInt32("spellid" + i);
                            item_template.spelltrigger_1 = (byte)ReadUInt32("spelltrigger" + i);
                            item_template.spellcharges_1 = (short)ReadInt32("spellcharges" + i);
                            item_template.spellcooldown_1 = ReadInt32("spellcooldown" + i);
                            item_template.spellcategory_1 = (ushort)ReadUInt32("spellcategory" + i);
                            item_template.spellcategorycooldown_1 = ReadInt32("spellcategorycooldown" + i);
                        } break;
                    case 2:
                        {
                            item_template.spellid_2 = ReadUInt32("spellid" + i);
                            item_template.spelltrigger_2 = (byte)ReadUInt32("spelltrigger" + i);
                            item_template.spellcharges_2 = (short)ReadInt32("spellcharges" + i);
                            item_template.spellcooldown_2 = ReadInt32("spellcooldown" + i);
                            item_template.spellcategory_2 = (ushort)ReadUInt32("spellcategory" + i);
                            item_template.spellcategorycooldown_2 = ReadInt32("spellcategorycooldown" + i);
                        } break;
                    case 3:
                        {
                            item_template.spellid_3 = ReadUInt32("spellid" + i);
                            item_template.spelltrigger_3 = (byte)ReadUInt32("spelltrigger" + i);
                            item_template.spellcharges_3 = (short)ReadInt32("spellcharges" + i);
                            item_template.spellcooldown_3 = ReadInt32("spellcooldown" + i);
                            item_template.spellcategory_3 = (ushort)ReadUInt32("spellcategory" + i);
                            item_template.spellcategorycooldown_3 = ReadInt32("spellcategorycooldown" + i);
                        } break;
                    case 4:
                        {
                            item_template.spellid_4 = ReadUInt32("spellid" + i);
                            item_template.spelltrigger_4 = (byte)ReadUInt32("spelltrigger" + i);
                            item_template.spellcharges_4 = (short)ReadInt32("spellcharges" + i);
                            item_template.spellcooldown_4 = ReadInt32("spellcooldown" + i);
                            item_template.spellcategory_4 = (ushort)ReadUInt32("spellcategory" + i);
                            item_template.spellcategorycooldown_4 = ReadInt32("spellcategorycooldown" + i);
                        } break;
                    case 5:
                        {
                            item_template.spellid_5 = ReadUInt32("spellid" + i);
                            item_template.spelltrigger_5 = (byte)ReadUInt32("spelltrigger" + i);
                            item_template.spellcharges_5 = (short)ReadInt32("spellcharges" + i);
                            item_template.spellcooldown_5 = ReadInt32("spellcooldown" + i);
                            item_template.spellcategory_5 = (ushort)ReadUInt32("spellcategory" + i);
                            item_template.spellcategorycooldown_5 = ReadInt32("spellcategorycooldown" + i);
                        } break;
                }

            }

            item_template.bonding = (byte)ReadUInt32("bonding");
            item_template.description = ReadCString("description");
            item_template.pagetext = ReadUInt32("pagetext");
            item_template.languageid = (byte)ReadUInt32("languageid");
            item_template.pagematerial = (byte)ReadUInt32("pagematerial");
            item_template.startquest = ReadUInt32("startquest");
            item_template.lockid = ReadUInt32("lockid");
            item_template.material = (sbyte)ReadUInt32("material");
            item_template.sheath = (byte)ReadUInt32("sheath");
            item_template.randomproperty = ReadUInt32("randomproperty");
            item_template.randomsuffix = ReadUInt32("randomsuffix");
            item_template.block = ReadUInt32("block");
            item_template.itemset = ReadUInt32("itemset");
            item_template.maxdurability = (ushort)ReadUInt32("maxdurability");
            item_template.area = ReadUInt32("area");
            item_template.map = (short)ReadUInt32("map");
            item_template.bagfamily = (int)ReadUInt32("bagfamily");
            item_template.totemcategory = (int)ReadUInt32("totemcategory");

            item_template.socketcolor_1 = (sbyte)ReadUInt32("socketcolor_1");
            item_template.socketcontent_1 = (int)ReadUInt32("socketcontent_1");

            item_template.socketcolor_2 = (sbyte)ReadUInt32("socketcolor_2");
            item_template.socketcontent_2 = (int)ReadUInt32("socketcontent_2");

            item_template.socketcolor_3 = (sbyte)ReadUInt32("socketcolor_3");
            item_template.socketcontent_3 = (int)ReadUInt32("socketcontent_3");

            item_template.socketbonus = (int)ReadUInt32("socketbonus");

            if (ClientBuildAmount >= 7561)
            {
                item_template.gemproperties = (int)ReadUInt32("gemproperties");
            }

            if (ClientBuildAmount <= 7799)
            {
                ReadUInt32("ExtendedCost"); //ExtendedCost
                ReadUInt32("RequiredArenaRank"); //RequiredArenaRank
            }

            item_template.requireddisenchantskill = (short)ReadUInt32("requireddisenchantskill");
            item_template.armordamagemodifier = ReadSingle("armordamagemodifier");

            if (ClientBuildAmount >= 8209)
            {
                item_template.duration = ReadUInt32("duration");// added in 2.4.2.8209, duration (seconds)
            }

            if (ClientBuildAmount >= 9183)
            {
                item_template.itemlimitcategory = (short)ReadUInt32("itemlimitcategory");
            }

            if (ClientBuildAmount > 9551)
            {
                item_template.holidayid = ReadUInt32("holidayid");
            }


            return item_template;
        }
    }

    public class SMSG_ITEM_NAME_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var itemname = new WoW.CacheObjects.ItemName();

            itemname.entry = ReadUInt32("entry");
            itemname.name = ReadCString("name");
            itemname.category = ReadUInt32("category");

            Core.Cache.AddItemName(itemname);

            return Validate();
        }
    }

    public class SMSG_ITEM_TEXT_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var itemtext = new WoW.CacheObjects.ItemText();

            itemtext.TextId = ReadUInt32("TextId");
            itemtext.Text = ReadCString("Text");

            Core.Cache.AddItemText(itemtext);

            return Validate();
        }
    }

    public class SMSG_NAME_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var playername = new WoW.CacheObjects.PlayerName();

            if (ClientBuildAmount > 9551)
            {
                playername.Guid = ReadPackedWoWGuid("Guid");
                playername.Unk = ReadByte("Unk"); // added in 3.1
                if (playername.Unk != 1)
                {
                    playername.Name = ReadCString("Name"); // 6898 = Name comes first
                    playername.BGRealm = ReadCString("BGRealm"); // realm name for cross realm BG usage
                    playername.Race = ReadEnum<Race>("Race", TypeCode.Byte);
                    playername.Gender = ReadEnum<Gender>("Gender", TypeCode.Byte);
                    playername.Class = ReadEnum<Class>("Class", TypeCode.Byte);
                }
            }
            else
            {
                playername.Guid = ReadWoWGuid("guid");

                if (ClientBuildAmount > 6803)
                {
                    playername.Name = ReadCString("Name"); // 6898 = Name comes first
                    playername.BGRealm = ReadCString("BGRealm"); // realm name for cross realm BG usage
                }
                else
                {
                    playername.BGRealm = ReadCString("BGRealm"); // realm name for cross realm BG usage
                    playername.Name = ReadCString("Name"); // 6898 = Name comes first
                }

                playername.Race = ReadEnum<Race>("Race", TypeCode.UInt32);
                playername.Gender = ReadEnum<Gender>("Gender", TypeCode.UInt32);
                playername.Class = ReadEnum<Class>("Class", TypeCode.UInt32);
            }

            if (ClientBuildAmount > 7799 && playername.Unk != 1)
            {
                playername.Declined = ReadByte("Declined");

                if (playername.Declined == 1)
                {
                    for (int i = 0; i < 5; ++i) //MAX_DECLINED_NAME_CASES
                    {
                        playername.DeclinedNames.Add(ReadCString("declinename" + i));
                    }
                }
            }

            Core.Cache.AddPlayerName(playername);

            return Validate();
        }
    }

    public class SMSG_NPC_TEXT_UPDATE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var npc_text = ParseNPCText();

            Dump.SQL.QueryResponseHandler.AddNPCText(ClientBuildAmount, npc_text);

            return Validate();

        }

        public MaximusParserX.Dump.SQL.Custom.npc_text ParseNPCText()
        {
            var npc_text = new MaximusParserX.Dump.SQL.Custom.npc_text();

            npc_text.id = ReadUInt32("id");

            npc_text.prob0 = ReadSingle("prob0");
            npc_text.text0_0 = ReadCString("text0_0");
            npc_text.text0_1 = ReadCString("text0_1");
            npc_text.lang0 = (byte)ReadUInt32("lang0");
            npc_text.em0_0 = (ushort)ReadUInt32("em0_0");
            npc_text.em0_1 = (ushort)ReadUInt32("em0_1");
            npc_text.em0_2 = (ushort)ReadUInt32("em0_2");
            npc_text.em0_3 = (ushort)ReadUInt32("em0_3");
            npc_text.em0_4 = (ushort)ReadUInt32("em0_4");
            npc_text.em0_5 = (ushort)ReadUInt32("em0_5");

            npc_text.prob1 = ReadSingle("prob1");
            npc_text.text1_0 = ReadCString("text1_0");
            npc_text.text1_1 = ReadCString("text1_1");
            npc_text.lang1 = (byte)ReadUInt32("lang1");
            npc_text.em1_0 = (ushort)ReadUInt32("em1_0");
            npc_text.em1_1 = (ushort)ReadUInt32("em1_1");
            npc_text.em1_2 = (ushort)ReadUInt32("em1_2");
            npc_text.em1_3 = (ushort)ReadUInt32("em1_3");
            npc_text.em1_4 = (ushort)ReadUInt32("em1_4");
            npc_text.em1_5 = (ushort)ReadUInt32("em1_5");

            npc_text.prob2 = ReadSingle("prob2");
            npc_text.text2_0 = ReadCString("text2_0");
            npc_text.text2_1 = ReadCString("text2_1");
            npc_text.lang2 = (byte)ReadUInt32("lang2");
            npc_text.em2_0 = (ushort)ReadUInt32("em2_0");
            npc_text.em2_1 = (ushort)ReadUInt32("em2_1");
            npc_text.em2_2 = (ushort)ReadUInt32("em2_2");
            npc_text.em2_3 = (ushort)ReadUInt32("em2_3");
            npc_text.em2_4 = (ushort)ReadUInt32("em2_4");
            npc_text.em2_5 = (ushort)ReadUInt32("em2_5");

            npc_text.prob3 = ReadSingle("prob3");
            npc_text.text3_0 = ReadCString("text3_0");
            npc_text.text3_1 = ReadCString("text3_1");
            npc_text.lang3 = (byte)ReadUInt32("lang3");
            npc_text.em3_0 = (ushort)ReadUInt32("em3_0");
            npc_text.em3_1 = (ushort)ReadUInt32("em3_1");
            npc_text.em3_2 = (ushort)ReadUInt32("em3_2");
            npc_text.em3_3 = (ushort)ReadUInt32("em3_3");
            npc_text.em3_4 = (ushort)ReadUInt32("em3_4");
            npc_text.em3_5 = (ushort)ReadUInt32("em3_5");

            npc_text.prob4 = ReadSingle("prob4");
            npc_text.text4_0 = ReadCString("text4_0");
            npc_text.text4_1 = ReadCString("text4_1");
            npc_text.lang4 = (byte)ReadUInt32("lang4");
            npc_text.em4_0 = (ushort)ReadUInt32("em4_0");
            npc_text.em4_1 = (ushort)ReadUInt32("em4_1");
            npc_text.em4_2 = (ushort)ReadUInt32("em4_2");
            npc_text.em4_3 = (ushort)ReadUInt32("em4_3");
            npc_text.em4_4 = (ushort)ReadUInt32("em4_4");
            npc_text.em4_5 = (ushort)ReadUInt32("em4_5");

            npc_text.prob5 = ReadSingle("prob5");
            npc_text.text5_0 = ReadCString("text5_0");
            npc_text.text5_1 = ReadCString("text5_1");
            npc_text.lang5 = (byte)ReadUInt32("lang5");
            npc_text.em5_0 = (ushort)ReadUInt32("em5_0");
            npc_text.em5_1 = (ushort)ReadUInt32("em5_1");
            npc_text.em5_2 = (ushort)ReadUInt32("em5_2");
            npc_text.em5_3 = (ushort)ReadUInt32("em5_3");
            npc_text.em5_4 = (ushort)ReadUInt32("em5_4");
            npc_text.em5_5 = (ushort)ReadUInt32("em5_5");

            npc_text.prob6 = ReadSingle("prob6");
            npc_text.text6_0 = ReadCString("text6_0");
            npc_text.text6_1 = ReadCString("text6_1");
            npc_text.lang6 = (byte)ReadUInt32("lang6");
            npc_text.em6_0 = (ushort)ReadUInt32("em6_0");
            npc_text.em6_1 = (ushort)ReadUInt32("em6_1");
            npc_text.em6_2 = (ushort)ReadUInt32("em6_2");
            npc_text.em6_3 = (ushort)ReadUInt32("em6_3");
            npc_text.em6_4 = (ushort)ReadUInt32("em6_4");
            npc_text.em6_5 = (ushort)ReadUInt32("em6_5");

            npc_text.prob7 = ReadSingle("prob7");
            npc_text.text7_0 = ReadCString("text7_0");
            npc_text.text7_1 = ReadCString("text7_1");
            npc_text.lang7 = (byte)ReadUInt32("lang7");
            npc_text.em7_0 = (ushort)ReadUInt32("em7_0");
            npc_text.em7_1 = (ushort)ReadUInt32("em7_1");
            npc_text.em7_2 = (ushort)ReadUInt32("em7_2");
            npc_text.em7_3 = (ushort)ReadUInt32("em7_3");
            npc_text.em7_4 = (ushort)ReadUInt32("em7_4");
            npc_text.em7_5 = (ushort)ReadUInt32("em7_5");

            return npc_text;
        }
    }

    public class SMSG_PAGE_TEXT_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var page_text = ParsePageText();

            Dump.SQL.QueryResponseHandler.AddPageText(ClientBuildAmount, page_text);

            return Validate();

        }

        public MaximusParserX.Dump.SQL.Custom.page_text ParsePageText()
        {
            var page_text = new MaximusParserX.Dump.SQL.Custom.page_text();

            page_text.entry = ReadUInt32("entry");
            page_text.text = ReadCString("text");
            page_text.next_page = ReadUInt32("next_page");

            return page_text;
        }
    }

    public class SMSG_PET_NAME_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var petname = new WoW.CacheObjects.PetName();

            petname.petnumber = ReadUInt32("petnumber");
            petname.name = ReadCString("name");
            petname.time = ReadUInt32("time");
            if (ClientBuildAmount > 7799)
            {
                petname.extra = ReadByte("extra");
            }
            Core.Cache.AddPetName(petname);

            return Validate();
        }
    }

    public class SMSG_QUEST_POI_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var count = ReadUInt32(); // quest count

            for (int i = 0; i < count; i++)
            {
                var questid = ReadUInt32("questid"); // quest ID
                var poicount = ReadUInt32("poicount"); // POI count

                for (int j = 0; j < poicount; j++)
                {
                    var quest_poi = new MaximusParserX.Dump.SQL.Custom.quest_poi() { questid = questid };
                    quest_poi.poiid = (sbyte?)ReadUInt32("poiid");
                    quest_poi.objindex = ReadInt32("objindex");
                    quest_poi.mapid = ReadUInt32("mapid");
                    quest_poi.mapareaid = ReadUInt32("mapareaid");
                    quest_poi.floorid = (byte)ReadUInt32("floorid");
                    quest_poi.unk3 = ReadUInt32("unk3");
                    quest_poi.unk4 = ReadUInt32("unk4");

                    var poipointscount = ReadUInt32("poipointscount");
                    for (int k = 1; k <= poipointscount; k++)
                    {
                        var quest_poi_points = new MaximusParserX.Dump.SQL.Custom.quest_poi_points() { questid = quest_poi.questid, poiid = quest_poi.poiid };
                        quest_poi_points.x = ReadInt32("quest_poi [" + i + "] quest_poi_point [" + k + "] X");             // POI point x
                        quest_poi_points.y = ReadInt32("quest_poi [" + i + "] quest_poi_point [" + k + "] Y");             // POI point y
                        quest_poi.quest_poi_points.Add(quest_poi_points.poiid.Value.ToString(), quest_poi_points);
                    }

                    var key = string.Format("{0}_{1}_{2}", ClientBuildAmount, questid, quest_poi.poiid);

                    if (!Dump.SQL.QueryResponseHandler.QuestPOIList.ContainsKey(key))
                        Dump.SQL.QueryResponseHandler.QuestPOIList.Add(key, quest_poi);
                }
            }

            return Validate();
        }
    }

    public class SMSG_QUEST_QUERY_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var quest_template = ParseQuestTemplate();
            Dump.SQL.QueryResponseHandler.AddQuestTemplate(ClientBuildAmount, quest_template);

            return Validate();
        }

        public MaximusParserX.Dump.SQL.Custom.quest_template ParseQuestTemplate()
        {
            var quest_template = new MaximusParserX.Dump.SQL.Custom.quest_template();

            quest_template.entry = ReadUInt32();
            quest_template.method = (byte)ReadUInt32();               // Accepted values: 0, 1 or 2. 0==IsAutoComplete() (skip objectives/details)
            quest_template.questlevel = (short)ReadInt32();                // may be 0
            if (ClientBuildAmount > 10505)// 10482)
            {
                quest_template.minlevel = (byte)ReadInt32();
            }
            quest_template.zoneorsort = (short)ReadUInt32();                // zone or sort to display in quest log
            quest_template.type = (ushort)ReadUInt32();
            quest_template.suggestedplayers = (byte)ReadUInt32();

            quest_template.repobjectivefaction = (ushort)ReadUInt32();       // shown in quest log as part of quest objective
            quest_template.repobjectivevalue = (int)ReadUInt32();         // shown in quest log as part of quest objective

            var requiredopositerepfaction = ReadUInt32();                                   // RequiredOpositeRepFaction
            var requiredopositerepvalue = ReadUInt32();                                      // RequiredOpositeRepValue, required faction value with another (oposite) faction (objective)

            quest_template.nextquestinchain = ReadUInt32();            // client will request this quest from NPC, if not 0

            if (ClientBuildAmount >= 10958)
            {
                quest_template.rewxpid = (byte)ReadUInt32();
            }

            quest_template.reworreqmoney = (int)ReadUInt32();   // Hide money rewarded
            quest_template.rewmoneymaxlevel = ReadUInt32();           // used in XP calculation at client
            quest_template.rewspell = ReadUInt32();                    // reward spell, this spell will display (icon) (casted if RewSpellCast==0)
            quest_template.rewspellcast = ReadUInt32();             // casted spell

            if (ClientBuildAmount >= 7561)
            {
                quest_template.rewhonoraddition = ReadUInt32(); // rewarded honor points 2.3.0, Honor points
            }

            if (ClientBuildAmount >= 10958)
            {
                quest_template.rewhonormultiplier = ReadSingle();
            }

            quest_template.srcitemid = ReadUInt32();
            quest_template.questflags = ReadUInt32();

            var questflags = (QuestFlag)quest_template.questflags;

            if (ClientBuildAmount >= 7561)
            {
                quest_template.chartitleid = (byte)ReadUInt32();                 // CharTitleId, new 2.4.0, player gets this title (id from CharTitles)
            }

            if (ClientBuildAmount >= 9183)
            {
                quest_template.playersslain = (byte)ReadUInt32();               // players slain
                quest_template.bonustalents = (byte)ReadUInt32();               // bonus talents
            }

            if (ClientBuildAmount >= 10958)
            {
                var bonusarenapoints = ReadUInt32();                                       // bonus arena points
                var rewrepshowmask = ReadUInt32();                                       // rew rep show mask?            }
            }

            quest_template.rewitemid1 = ReadUInt32();
            quest_template.rewitemcount1 = (ushort)ReadUInt32();

            quest_template.rewitemid2 = ReadUInt32();
            quest_template.rewitemcount2 = (ushort)ReadUInt32();

            quest_template.rewitemid3 = ReadUInt32();
            quest_template.rewitemcount3 = (ushort)ReadUInt32();

            quest_template.rewitemid4 = ReadUInt32();
            quest_template.rewitemcount4 = (ushort)ReadUInt32();


            quest_template.rewchoiceitemid1 = ReadUInt32();
            quest_template.rewchoiceitemcount1 = (ushort)ReadUInt32();

            quest_template.rewchoiceitemid2 = ReadUInt32();
            quest_template.rewchoiceitemcount2 = (ushort)ReadUInt32();

            quest_template.rewchoiceitemid3 = ReadUInt32();
            quest_template.rewchoiceitemcount3 = (ushort)ReadUInt32();

            quest_template.rewchoiceitemid4 = ReadUInt32();
            quest_template.rewchoiceitemcount4 = (ushort)ReadUInt32();

            quest_template.rewchoiceitemid5 = ReadUInt32();
            quest_template.rewchoiceitemcount5 = (ushort)ReadUInt32();

            quest_template.rewchoiceitemid6 = ReadUInt32();
            quest_template.rewchoiceitemcount6 = (ushort)ReadUInt32();

            if (ClientBuildAmount >= 10958)
            {
                // reward factions ids
                quest_template.rewrepfaction1 = (ushort)ReadUInt32();
                quest_template.rewrepfaction2 = (ushort)ReadUInt32();
                quest_template.rewrepfaction3 = (ushort)ReadUInt32();
                quest_template.rewrepfaction4 = (ushort)ReadUInt32();
                quest_template.rewrepfaction5 = (ushort)ReadUInt32();

                // columnid in QuestFactionReward.dbc (if negative, from second row)
                quest_template.rewrepvalueid1 = (sbyte)ReadInt32();
                quest_template.rewrepvalueid2 = (sbyte)ReadInt32();
                quest_template.rewrepvalueid3 = (sbyte)ReadInt32();
                quest_template.rewrepvalueid4 = (sbyte)ReadInt32();
                quest_template.rewrepvalueid5 = (sbyte)ReadInt32();

                // reward reputation override. No bonus is expected given
                // current field for store of rep value, can be reused to implement "override value"
                var rewardreputationoverride1 = (sbyte)ReadInt32();
                var rewardreputationoverride2 = (sbyte)ReadInt32();
                var rewardreputationoverride3 = (sbyte)ReadInt32();
                var rewardreputationoverride4 = (sbyte)ReadInt32();
                var rewardreputationoverride5 = (sbyte)ReadInt32();
            }

            quest_template.pointmapid = (ushort)ReadUInt32();
            quest_template.pointx = ReadSingle();
            quest_template.pointy = ReadSingle();
            quest_template.pointopt = ReadUInt32();

            quest_template.title = ReadCString();
            quest_template.objectives = ReadCString();
            quest_template.details = ReadCString();
            quest_template.endtext = ReadCString();

            if (ClientBuildAmount > 10505)// 10482)
            {
                quest_template.completedtext = ReadCString();
            }

            if (ClientBuildAmount >= 9183)
            {
                quest_template.reqcreatureorgoid1 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount1 = (ushort)ReadUInt32();
                quest_template.reqsourceid1 = ReadUInt32();
                if (ClientBuildAmount > 10505)// 10482)
                {
                    var reqsourcecount1 = ReadUInt32();
                }
                quest_template.reqcreatureorgoid2 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount2 = (ushort)ReadUInt32();
                quest_template.reqsourceid2 = ReadUInt32();
                if (ClientBuildAmount > 10505)// 10482)
                {
                    var reqsourcecount2 = ReadUInt32();
                }

                quest_template.reqcreatureorgoid3 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount3 = (ushort)ReadUInt32();
                quest_template.reqsourceid3 = ReadUInt32();
                if (ClientBuildAmount > 10505)// 10482)
                {
                    var reqsourcecount3 = ReadUInt32();
                }

                quest_template.reqcreatureorgoid4 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount4 = (ushort)ReadUInt32();
                quest_template.reqsourceid4 = ReadUInt32();
                if (ClientBuildAmount > 10505)// 10482)
                {
                    var reqsourcecount4 = ReadUInt32();
                }

                quest_template.reqitemid1 = ReadUInt32();
                quest_template.reqitemcount1 = (ushort)ReadUInt32();

                quest_template.reqitemid2 = ReadUInt32();
                quest_template.reqitemcount2 = (ushort)ReadUInt32();

                quest_template.reqitemid3 = ReadUInt32();
                quest_template.reqitemcount3 = (ushort)ReadUInt32();

                quest_template.reqitemid4 = ReadUInt32();
                quest_template.reqitemcount4 = (ushort)ReadUInt32();

                if (ClientBuildAmount > 9183)
                {
                    quest_template.reqitemid5 = ReadUInt32();
                    quest_template.reqitemcount5 = (ushort)ReadUInt32();

                    if (ClientBuildAmount >= 10314)
                    {
                        quest_template.reqitemid6 = ReadUInt32();
                        quest_template.reqitemcount6 = (ushort)ReadUInt32();
                    }
                }
                //if (ClientBuild > 9183)
                //{
                //    ReadUInt32(); //ReqItemIdExt
                //    quest_template.reqitemcount5 = (ushort)ReadUInt32();

                //    if (ClientBuild >= 10314)
                //    {
                //        ReadUInt32(); //ReqItemIdExt
                //        quest_template.reqitemcount6 = (ushort)ReadUInt32();
                //    }
                //}

            }
            else
            {
                quest_template.reqcreatureorgoid1 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount1 = (ushort)ReadUInt32();
                quest_template.reqitemid1 = ReadUInt32();
                quest_template.reqitemcount1 = (ushort)ReadUInt32();

                quest_template.reqcreatureorgoid2 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount2 = (ushort)ReadUInt32();
                quest_template.reqitemid2 = ReadUInt32();
                quest_template.reqitemcount2 = (ushort)ReadUInt32();

                quest_template.reqcreatureorgoid3 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount3 = (ushort)ReadUInt32();
                quest_template.reqitemid3 = ReadUInt32();
                quest_template.reqitemcount3 = (ushort)ReadUInt32();

                quest_template.reqcreatureorgoid4 = (int)ReadUInt32();
                quest_template.reqcreatureorgocount4 = (ushort)ReadUInt32();
                quest_template.reqitemid4 = ReadUInt32();
                quest_template.reqitemcount4 = (ushort)ReadUInt32();
            }

            quest_template.objectivetext1 = ReadCString();
            quest_template.objectivetext2 = ReadCString();
            quest_template.objectivetext3 = ReadCString();
            quest_template.objectivetext4 = ReadCString();

            return quest_template;
        }
    }
}
