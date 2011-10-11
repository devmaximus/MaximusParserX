using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_EMOTE : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var EmoteID = ReadInt32("EmoteID");
            var guid = ReadWoWGuid("guid");
            return Validate();
        }
    }

    public class SMSG_MESSAGECHAT : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var type = ReadEnum<ChatMsg>("ChatMsgType");
            var lang = ReadEnum<Language>("Language");
            var guid = ReadWoWGuid("guid");
            var unkInt = ReadInt32("unkInt");

            switch (type)
            {
                case ChatMsg.CHAT_MSG_SAY:
                case ChatMsg.CHAT_MSG_YELL:
                case ChatMsg.CHAT_MSG_PARTY:
                case ChatMsg.CHAT_MSG_PARTY_LEADER:
                case ChatMsg.CHAT_MSG_RAID:
                case ChatMsg.CHAT_MSG_RAID_LEADER:
                case ChatMsg.CHAT_MSG_RAID_WARNING:
                case ChatMsg.CHAT_MSG_GUILD:
                case ChatMsg.CHAT_MSG_OFFICER:
                case ChatMsg.CHAT_MSG_EMOTE:
                case ChatMsg.CHAT_MSG_TEXT_EMOTE:
                case ChatMsg.CHAT_MSG_WHISPER:
                case ChatMsg.CHAT_MSG_WHISPER_INFORM:
                case ChatMsg.CHAT_MSG_SYSTEM:
                case ChatMsg.CHAT_MSG_CHANNEL:
                case ChatMsg.CHAT_MSG_BATTLEGROUND:
                case ChatMsg.CHAT_MSG_BG_SYSTEM_NEUTRAL:
                case ChatMsg.CHAT_MSG_BG_SYSTEM_ALLIANCE:
                case ChatMsg.CHAT_MSG_BG_SYSTEM_HORDE:
                case ChatMsg.CHAT_MSG_BATTLEGROUND_LEADER:
                case ChatMsg.CHAT_MSG_ACHIEVEMENT:
                case ChatMsg.CHAT_MSG_GUILD_ACHIEVEMENT:
                    {
                        if (type == ChatMsg.CHAT_MSG_CHANNEL)
                        {
                            var chanName = ReadCString("chanName");
                        }

                        var senderGuid = ReadWoWGuid("senderGuid");

                        break;
                    }
                case ChatMsg.CHAT_MSG_MONSTER_SAY:
                case ChatMsg.CHAT_MSG_MONSTER_YELL:
                case ChatMsg.CHAT_MSG_MONSTER_PARTY:
                case ChatMsg.CHAT_MSG_MONSTER_EMOTE:
                case ChatMsg.CHAT_MSG_MONSTER_WHISPER:
                case ChatMsg.CHAT_MSG_RAID_BOSS_EMOTE:
                case ChatMsg.CHAT_MSG_RAID_BOSS_WHISPER:
                case ChatMsg.CHAT_MSG_BATTLENET:
                    {
                        var nameLen = ReadInt32("namelength");
                        var name = ReadCString("name");
                        var target = ReadWoWGuid("target");

                        if (target.Full != 0)
                        {
                            var targetnamelength = ReadInt32("targetnamelength");
                            var targetname = ReadCString("targetname");
                        }
                        break;
                    }
            }

            var textLen = ReadInt32("textlength");
            var text = ReadCString("text");
            var chatTag = ReadEnum<ChatTag>("ChatTag");

            if (type == ChatMsg.CHAT_MSG_ACHIEVEMENT || type == ChatMsg.CHAT_MSG_GUILD_ACHIEVEMENT)
            {
                var achId = ReadInt32("achievementid");
            }
            return Validate();
        }
    }

    public class CMSG_MESSAGECHAT : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var type = ReadEnum<ChatMsg>("ChatMsgType");
            var lang = ReadEnum<Language>("Language");

            switch (type)
            {
                case ChatMsg.CHAT_MSG_WHISPER:
                    {
                        var to = ReadCString("Recipient");
                        goto default;
                    }
                case ChatMsg.CHAT_MSG_CHANNEL:
                    {
                        var chan = ReadCString("Channel");
                        goto default;
                    }
                default:
                    {
                        var msg = ReadCString("Message");
                        break;
                    }
            }
            return Validate();
        }
    }
}

