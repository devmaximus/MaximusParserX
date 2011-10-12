using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_FEATURE_SYSTEM_STATUS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var unknown = ReadByte("unknown");
            var voiceChatOn = ReadBoolean("voiceChatOn");

            return Validate();
        }
    }

    public class CMSG_REALM_SPLIT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var unk = ReadInt32();
            return Validate();
        }
    }

    public class SMSG_REALM_SPLIT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var unk = ReadInt32("unk");
            var RealmSplitState = ReadEnum<RealmSplitState>("RealmSplitState");
            var unkDate = ReadCString("unkDate");

            return Validate();
        }
    }

    public class CMSG_PING_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var ping = ReadInt32("ping");
            var latency = ReadInt32("latency");

            return Validate();
        }
    }

    public class SMSG_PONG_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var ping = ReadInt32();
            return Validate();
        }
    }

    public class SMSG_CLIENTCACHE_VERSION_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var version = ReadInt32();
            return Validate();
        }
    }

    public class SMSG_TIME_SYNC_REQ_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var gameTime = ReadInt32("gameTime");
            return Validate();
        }
    }

    public class SMSG_LEARNED_DANCE_MOVES_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var DanceMoveID = ReadInt64("DanceMoveID");
            return Validate();
        }
    }

    public class SMSG_TRIGGER_CINEMATIC_DEF : SMSG_TRIGGER_MOVIE_DEF { }
    public class SMSG_TRIGGER_MOVIE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var SequenceID = ReadInt32("SequenceID");
            return Validate();
        }
    }

    public class SMSG_PLAY_SOUND_DEF : SMSG_PLAY_OBJECT_SOUND_DEF { }
    public class SMSG_PLAY_MUSIC_DEF : SMSG_PLAY_OBJECT_SOUND_DEF { }
    public class SMSG_PLAY_OBJECT_SOUND_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var soundId = ReadInt32("soundId");

            if (OpcodeName == "SMSG_PLAY_OBJECT_SOUND")
            {
                var guid = ReadPackedWoWGuid("guid");
            }

            if (soundId == 5775 || soundId == 5777)
            {
                System.Diagnostics.Debug.WriteLine(base.ReaderFileName);
            }

            return Validate();
        }
    }

    public class SMSG_WEATHER_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var WeatherState = ReadEnum<WeatherState>("WeatherState");
            var grade = ReadSingle("grade");
            var unkByte = ReadByte("unkByte");

            return Validate();
        }
    }

    public class SMSG_LEVELUP_INFO_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var level = ReadInt32();
            var health = ReadInt32();
            for (var i = 0; i < 6; i++)
            {
                var power = ReadEnum<Powers>(i, "power");
            }

            for (var i = 0; i < 5; i++)
            {
                var stat = ReadEnum<Stats>(i, "stat");
            }

            Core.SetCurrentPlayerLevel(level);

            return Validate();
        }
    }

    public class CMSG_TUTORIAL_FLAG_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var flag = ReadInt32("flag");
            return Validate();
        }
    }

    public class SMSG_TUTORIAL_FLAGS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            for (var i = 0; i < 8; i++)
            {
                var flag = ReadInt32(i, "flag");
            }
            return Validate();
        }
    }

    public class CMSG_AREATRIGGER_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var areatriggerid = ReadInt32("areatriggerid");
            return Validate();
        }
    }

    public class CMSG_READY_FOR_ACCOUNT_DATA_TIMES_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_CALENDAR_GET_CALENDAR_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_CALENDAR_GET_NUM_PENDING_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_CHAR_ENUM_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_KEEP_ALIVE_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_TUTORIAL_RESET_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_TUTORIAL_CLEAR_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class MSG_MOVE_WORLDPORT_ACK_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_MOUNTSPECIAL_ANIM_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_QUERY_TIME_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_PLAYER_LOGOUT_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_LOGOUT_REQUEST_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_LOGOUT_CANCEL_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_LOGOUT_CANCEL_ACK_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_WORLD_STATE_UI_TIMER_UPDATE_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_HEARTH_AND_RESURRECT_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_LFD_PLAYER_LOCK_INFO_REQUEST_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_LFD_PARTY_LOCK_INFO_REQUEST_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_REQUEST_RAID_INFO_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_GMTICKET_GETTICKET_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_BATTLEFIELD_STATUS_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_MEETINGSTONE_INFO_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_LFG_DISABLED_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_QUESTLOG_FULL_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class CMSG_CHANNEL_VOICE_ON_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_COMSAT_CONNECT_FAIL_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_COMSAT_RECONNECT_TRY_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_COMSAT_DISCONNECT_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_VOICESESSION_FULL_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_UNKNOWN_1276_DEF : SMSG_FORCE_SEND_QUEUED_PACKETS_DEF { }
    public class SMSG_FORCE_SEND_QUEUED_PACKETS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            //ResetPosition();
            return Validate();
        }
    }


}

