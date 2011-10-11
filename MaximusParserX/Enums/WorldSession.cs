using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public enum AccountDataType : int
    {
        GLOBAL_CONFIG_CACHE = 0,                    // 0x01 g
        PER_CHARACTER_CONFIG_CACHE = 1,                    // 0x02 p
        GLOBAL_BINDINGS_CACHE = 2,                    // 0x04 g
        PER_CHARACTER_BINDINGS_CACHE = 3,                    // 0x08 p
        GLOBAL_MACROS_CACHE = 4,                    // 0x10 g
        PER_CHARACTER_MACROS_CACHE = 5,                    // 0x20 p
        PER_CHARACTER_LAYOUT_CACHE = 6,                    // 0x40 p
        PER_CHARACTER_CHAT_CACHE = 7,                    // 0x80 p
        NUM_ACCOUNT_DATA_TYPES = 8
    };

    public enum PartyOperation
    {
        PARTY_OP_INVITE = 0,
        PARTY_OP_LEAVE = 2,
        PARTY_OP_SWAP = 4
    };

    public enum PartyResult
    {
        ERR_PARTY_RESULT_OK = 0,
        ERR_BAD_PLAYER_NAME_S = 1,
        ERR_TARGET_NOT_IN_GROUP_S = 2,
        ERR_TARGET_NOT_IN_INSTANCE_S = 3,
        ERR_GROUP_FULL = 4,
        ERR_ALREADY_IN_GROUP_S = 5,
        ERR_NOT_IN_GROUP = 6,
        ERR_NOT_LEADER = 7,
        ERR_PLAYER_WRONG_FACTION = 8,
        ERR_IGNORING_YOU_S = 9,
        ERR_LFG_PENDING = 12,
        ERR_INVITE_RESTRICTED = 13,
        ERR_GROUP_SWAP_FAILED = 14,               // if (PartyOperation == PARTY_OP_SWAP) ERR_GROUP_SWAP_FAILED else ERR_INVITE_IN_COMBAT
        ERR_INVITE_UNKNOWN_REALM = 15,
        ERR_INVITE_NO_PARTY_SERVER = 16,
        ERR_INVITE_PARTY_BUSY = 17,
        ERR_PARTY_TARGET_AMBIGUOUS = 18,
        ERR_PARTY_LFG_INVITE_RAID_LOCKED = 19,
        ERR_PARTY_LFG_BOOT_LIMIT = 20,
        ERR_PARTY_LFG_BOOT_COOLDOWN_S = 21,
        ERR_PARTY_LFG_BOOT_IN_PROGRESS = 22,
        ERR_PARTY_LFG_BOOT_TOO_FEW_PLAYERS = 23,
        ERR_PARTY_LFG_BOOT_NOT_ELIGIBLE_S = 24,
        ERR_RAID_DISALLOWED_BY_LEVEL = 25,
        ERR_PARTY_LFG_BOOT_IN_COMBAT = 26,
        ERR_VOTE_KICK_REASON_NEEDED = 27,
        ERR_PARTY_LFG_BOOT_DUNGEON_COMPLETE = 28,
        ERR_PARTY_LFG_BOOT_LOOT_ROLLS = 29,
        ERR_PARTY_LFG_TELEPORT_IN_COMBAT = 30
    };

    public enum LfgJoinResult
    {
        ERR_LFG_OK = 0x00,
        ERR_LFG_ROLE_CHECK_FAILED = 0x01,
        ERR_LFG_GROUP_FULL = 0x02,
        ERR_LFG_NO_LFG_OBJECT = 0x04,
        ERR_LFG_NO_SLOTS_PLAYER = 0x05,
        ERR_LFG_NO_SLOTS_PARTY = 0x06,
        ERR_LFG_MISMATCHED_SLOTS = 0x07,
        ERR_LFG_PARTY_PLAYERS_FROM_DIFFERENT_REALMS = 0x08,
        ERR_LFG_MEMBERS_NOT_PRESENT = 0x09,
        ERR_LFG_GET_INFO_TIMEOUT = 0x0A,
        ERR_LFG_INVALID_SLOT = 0x0B,
        ERR_LFG_DESERTER_PLAYER = 0x0C,
        ERR_LFG_DESERTER_PARTY = 0x0D,
        ERR_LFG_RANDOM_COOLDOWN_PLAYER = 0x0E,
        ERR_LFG_RANDOM_COOLDOWN_PARTY = 0x0F,
        ERR_LFG_TOO_MANY_MEMBERS = 0x10,
        ERR_LFG_CANT_USE_DUNGEONS = 0x11,
        ERR_LFG_ROLE_CHECK_FAILED2 = 0x12,
    };

    public enum LfgUpdateType
    {
        LFG_UPDATE_JOIN = 5,
        LFG_UPDATE_LEAVE = 7,
    };

    public enum LfgType
    {
        LFG_TYPE_NONE = 0,
        LFG_TYPE_DUNGEON = 1,
        LFG_TYPE_RAID = 2,
        LFG_TYPE_QUEST = 3,
        LFG_TYPE_ZONE = 4,
        LFG_TYPE_HEROIC_DUNGEON = 5,
        LFG_TYPE_RANDOM_DUNGEON = 6
    };

    public enum ChatRestrictionType
    {
        ERR_CHAT_RESTRICTED = 0,
        ERR_CHAT_THROTTLED = 1,
        ERR_USER_SQUELCHED = 2,
        ERR_YELL_RESTRICTED = 3
    };

    public enum TutorialDataState
    {
        TUTORIALDATA_UNCHANGED = 0,
        TUTORIALDATA_CHANGED = 1,
        TUTORIALDATA_NEW = 2
    };

}
