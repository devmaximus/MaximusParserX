using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{

    public class CMSG_QUEST_QUERY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var entry = ReadInt32("entry");

            return Validate();
        }
    }
 
    public class CMSG_QUEST_POI_QUERY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var count = ReadInt32("count");

            for (var i = 0; i < count; i++)
            {
                var questId = ReadInt32("questId");
            }
            return Validate();
        }
    }
     
    public class SMSG_QUEST_FORCE_REMOVE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var questId = ReadInt32("questId");
            return Validate();
        }
    }

    public class SMSG_QUESTGIVER_OFFER_REWARD_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadPackedWoWGuid("guid");

            var quest_id = ReadInt32("quest_id");

            var title = ReadCString("title");

            var reward_text = ReadCString("reward_text");

            var next_avail = ReadByte("next_avail");

            var quest_flag = ReadUInt32("quest_flag");

            var group_size = ReadUInt32("group_size");

            var emote_count = ReadUInt32("emote_count");
            uint[] emote_delay = { 0, 0, 0, 0 };
            uint[] emotes = { 0, 0, 0, 0 };
            for (var i = 0; i < emote_count; i++)
            {
                emote_delay[i] = ReadUInt32();

                emotes[i] = ReadUInt32();
            }
            //Store.WriteData(Store.Quests.GetCommand("OfferReward", quest_id, reward_text, emotes, emote_count, emote_delay, true));
            return Validate();
        }
    }

    public class SMSG_QUESTGIVER_REQUEST_ITEMS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadPackedWoWGuid("guid");

            var quest_id = ReadInt32("quest_id");

            var title = ReadCString("title");

            var req_item_text = ReadCString("req_item_text");

            UInt32[] emote_delay = { 0 };
            emote_delay[0] = ReadUInt32();

            UInt32[] emote = { 0 };
            emote[0] = ReadUInt32();

            var unk = ReadUInt32("unk");

            var quest_flag = ReadUInt32("quest_flag");

            var group_size = ReadUInt32("group_size");

            var req_money = ReadUInt32("req_money");

            var req_item_count = ReadUInt32("req_item_count");

            for (var i = 0; i < req_item_count; i++)
            {
                var item = ReadUInt32("item");

                var item_count = ReadUInt32("item_count");

                var displayid = ReadUInt32("displayid");
            }

            var flag = ReadUInt32("flag");

            var flag2 = ReadUInt32("flag2");

            var flag3 = ReadUInt32("flag3");

            var flag4 = ReadUInt32("flag4");

            //Store.WriteData(Store.Quests.GetCommand("RequestItems", quest_id, req_item_text, emote, 1, emote_delay, true));
            return Validate();
        }
    }

    public class SMSG_QUESTGIVER_QUEST_DETAILS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadUInt64("guid");

            var unk1 = ReadUInt64("unk1");

            var quest_id = ReadUInt32("quest_id");

            var title = ReadCString("title");

            var details = ReadCString("details");

            var obj = ReadCString("obj");

            var auto_finish = ReadByte("auto_finish");

            var flags = (QuestFlag)ReadUInt32();

            var suggested_players = ReadUInt32("suggested_players");

            var quest_accepted = ReadByte("quest_accepted");

            if (flags.HasFlag(QuestFlag.HiddenRewards))
            {

            }
            return Validate();
        }
    }


}
