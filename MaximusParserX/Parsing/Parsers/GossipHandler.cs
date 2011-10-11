using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class CMSG_GOSSIP_SELECT_OPTION_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadWoWGuid("guid");
            var menuId = ReadUInt32("menuId");
            if (ClientBuildAmount > 7799)
            {
                var gossipListId = ReadUInt32("gossipListId");
            }
            if (AvailableBytes > 0)
            {
                var code = ReadCString("code"); //What version was this added in? 
            }

            return Validate();
        }
    }

    public class CMSG_GOSSIP_HELLO_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadWoWGuid("guid");
            return Validate();
        }
    }

    public class SMSG_GOSSIP_COMPLETE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            Console.WriteLine("SMSG_GOSSIP_COMPLETE");
            return Validate();
        }
    }

    public class SMSG_GOSSIP_MESSAGE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var gossip_menu = ParseGossipMenu();

            if (gossip_menu.entry == 0)
            {
                gossip_menu.entry = 0;
            }

            if (!MaximusParserX.Dump.SQL.GossipHandler.GossipMenuList.ContainsKey(gossip_menu.entry.StringValueOrEmpty()))
            {
                if (gossip_menu.entry != 0)
                {
                    MaximusParserX.Dump.SQL.GossipHandler.GossipMenuList.Add(gossip_menu.entry.StringValueOrEmpty(), gossip_menu);
                }
            }

            return Validate();
        }

        private Dump.SQL.Custom.gossip_menu ParseGossipMenu()
        {
            ResetPosition();

            var gossip_menu = new Dump.SQL.Custom.gossip_menu();

            var guid = ReadWoWGuid("Guid");

            var entry = guid.GetEntry();

            var entrytype = guid.GetHighType();

            if (entry == 0)
            {
                var obj = Core.GetObjectByWoWGuid(guid);

                if (obj != null)
                {
                    entry = (uint)obj.OBJECT_FIELD_ENTRY;
                    entrytype = (obj.OBJECT_FIELD_TYPE == 9 || entrytype == HighGuidType.Unit) ? HighGuidType.Unit : HighGuidType.NoEntry1;
                }
            }

            if (ClientBuildAmount >= 8089)
            {
                gossip_menu.entry = ReadUInt32("gossip_menu_id");// new 2.4.0
            }
            else
            {
                gossip_menu.entry = 0;//TODO/// entry.ToString("1000000").UIntValueOrDefault(0);
            }

            if (entrytype == HighGuidType.Unit)
            {
                gossip_menu.creature_template = new Dump.SQL.Mangos.creature_template() { entry = entry, gossip_menu_id = gossip_menu.entry };
            }

            gossip_menu.text_id = ReadUInt32("text_id");

            var gossip_menu_option_count = ReadUInt32("gossip_menu_option_count"); // max count 0x0F

            if (gossip_menu_option_count > 0) gossip_menu.gossip_menu_options = new System.Collections.Generic.Dictionary<string, Dump.SQL.Custom.gossip_menu_option>();

            for (int i = 0; i < gossip_menu_option_count; i++)
            {
                var gossip_menu_option = new Dump.SQL.Custom.gossip_menu_option() { menu_id = gossip_menu.entry };

                gossip_menu_option.id = ReadUInt32("gossip_menu_option [" + i + "] id");
                var option_icon = ReadEnum<GossipOptionIcon>("gossip_menu_option [" + i + "] option_icon");
                gossip_menu_option.option_icon = (uint?)option_icon;

                if (
                    (option_icon == GossipOptionIcon.GOSSIP_ICON_CHAT ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_VENDOR ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_TAXI ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_TRAINER ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_INTERACT_1 ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_INTERACT_2 ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_MONEY_BAG ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_BATTLE ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_CHAT_11 ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_CHAT_12 ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_CHAT_13)
                    ||
                    ((option_icon == GossipOptionIcon.GOSSIP_ICON_DOT ||
                    option_icon == GossipOptionIcon.GOSSIP_ICON_CHAT_19) &&
                    ClientBuildAmount >= 10314))
                {
                    var spec = ReadByte("gossip_menu_option [" + i + "] spec");
                    var byte_2 = ReadByte("gossip_menu_option [" + i + "] byte_2");
                    var byte_3 = ReadByte("gossip_menu_option [" + i + "] byte_3");

                    if (spec != 0 || byte_2 != 0 || byte_3 != 0)
                    {
                        System.Diagnostics.Debug.Assert(true);
                    }
                }

                gossip_menu_option.box_coded = ReadByte("gossip_menu_option [" + i + "] box_coded");
                gossip_menu_option.box_money = ReadByte("gossip_menu_option [" + i + "] box_money");// req money to open menu, 2.0.3
                gossip_menu_option.option_text = ReadCString("gossip_menu_option [" + i + "] option_text");
                gossip_menu_option.box_text = ReadCString("gossip_menu_option [" + i + "] box_text");// unknown, 2.0.3

                switch (option_icon)
                {
                    case GossipOptionIcon.GOSSIP_ICON_VENDOR: gossip_menu_option.option_id = 3; gossip_menu_option.npc_option_npcflag = 128; break;
                    case GossipOptionIcon.GOSSIP_ICON_TAXI: gossip_menu_option.option_id = 4; gossip_menu_option.npc_option_npcflag = 8192; break;
                    case GossipOptionIcon.GOSSIP_ICON_TRAINER: gossip_menu_option.option_id = 5; gossip_menu_option.npc_option_npcflag = 16; break;
                    default: break;
                };

                gossip_menu.gossip_menu_options.Add(string.Format("{0}_{1}", gossip_menu_option.menu_id, gossip_menu_option.id), gossip_menu_option);
            }

            var QuestMenuItemCount = ReadUInt32("QuestMenuItemCount");

            for (int i = 0; i < QuestMenuItemCount; i++)
            {
                var questID = ReadUInt32("questID");
                var icon = ReadUInt32("icon");
                var Level = ReadUInt32("Level");

                if (ClientBuildAmount > 10505)
                {
                    var questflags = ReadUInt32("questflags");  // 3.3.3 quest flags
                    var icon2 = ReadByte("icon2");              // 3.3.3 changes icon: blue question or yellow exclamation
                }
                var Title = ReadCString("Title");
            }

            return gossip_menu;
        }
    }

    public class SMSG_GOSSIP_POI_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var gossip_poi = ParseGossipPOI();

            MaximusParserX.Dump.SQL.GossipHandler.GossipPOIList.Add(string.Format("{0}_{1}_{2}_{3}_{4}_{5}", gossip_poi.clientbuild, gossip_poi.map, gossip_poi.phasemask, gossip_poi.X, gossip_poi.Y, gossip_poi.IconName), gossip_poi);

            return Validate();
        }

        private Dump.SQL.Custom.gossip_poi ParseGossipPOI()
        {
            var gossip_poi = new Dump.SQL.Custom.gossip_poi() { clientbuild = ClientBuildAmount, map = (ushort?)Core.CurrentPlayerMapID, phasemask = (ushort?)Core.CurrentPlayerPhaseMask };

            gossip_poi.Flags = ReadUInt32("Flags");
            var Position = ReadVector2("Position");
            gossip_poi.X = Position.X;
            gossip_poi.Y = Position.Y;
            var icon = ReadEnum<Poi_Icon>("Icon");
            gossip_poi.Icon = (uint)icon;
            gossip_poi.DataInfo = ReadUInt32("DataInfo");
            gossip_poi.IconName = ReadCString("IconName");

            return gossip_poi;
        }

    }
}
