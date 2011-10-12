using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public enum CharacterFlags : uint
    {
        CHARACTER_FLAG_NONE = 0x00000000,
        CHARACTER_FLAG_UNK1 = 0x00000001,
        CHARACTER_FLAG_UNK2 = 0x00000002,
        CHARACTER_LOCKED_FOR_TRANSFER = 0x00000004,
        CHARACTER_FLAG_UNK4 = 0x00000008,
        CHARACTER_FLAG_UNK5 = 0x00000010,
        CHARACTER_FLAG_UNK6 = 0x00000020,
        CHARACTER_FLAG_UNK7 = 0x00000040,
        CHARACTER_FLAG_UNK8 = 0x00000080,
        CHARACTER_FLAG_UNK9 = 0x00000100,
        CHARACTER_FLAG_UNK10 = 0x00000200,
        CHARACTER_FLAG_HIDE_HELM = 0x00000400,
        CHARACTER_FLAG_HIDE_CLOAK = 0x00000800,
        CHARACTER_FLAG_UNK13 = 0x00001000,
        CHARACTER_FLAG_GHOST = 0x00002000,
        CHARACTER_FLAG_RENAME = 0x00004000,
        CHARACTER_FLAG_UNK16 = 0x00008000,
        CHARACTER_FLAG_UNK17 = 0x00010000,
        CHARACTER_FLAG_UNK18 = 0x00020000,
        CHARACTER_FLAG_UNK19 = 0x00040000,
        CHARACTER_FLAG_UNK20 = 0x00080000,
        CHARACTER_FLAG_UNK21 = 0x00100000,
        CHARACTER_FLAG_UNK22 = 0x00200000,
        CHARACTER_FLAG_UNK23 = 0x00400000,
        CHARACTER_FLAG_UNK24 = 0x00800000,
        CHARACTER_FLAG_LOCKED_BY_BILLING = 0x01000000,
        CHARACTER_FLAG_DECLINED = 0x02000000,
        CHARACTER_FLAG_UNK27 = 0x04000000,
        CHARACTER_FLAG_UNK28 = 0x08000000,
        CHARACTER_FLAG_UNK29 = 0x10000000,
        CHARACTER_FLAG_UNK30 = 0x20000000,
        CHARACTER_FLAG_UNK31 = 0x40000000,
        CHARACTER_FLAG_UNK32 = 0x80000000
    };

    public enum CharacterCustomizeFlags : int
    {
        CHAR_CUSTOMIZE_FLAG_NONE = 0x00000000,
        CHAR_CUSTOMIZE_FLAG_CUSTOMIZE = 0x00000001,       // name, gender, etc...
        CHAR_CUSTOMIZE_FLAG_FACTION = 0x00010000,       // name, gender, faction, etc...
        CHAR_CUSTOMIZE_FLAG_RACE = 0x00100000        // name, gender, race, etc...
    };
     
public enum SpellModType
{
    SPELLMOD_FLAT         = 107,                            // SPELL_AURA_ADD_FLAT_MODIFIER
    SPELLMOD_PCT          = 108                             // SPELL_AURA_ADD_PCT_MODIFIER
};

// 2^n values, Player::m_isunderwater is a bitmask. These are mangos internal values, they are never send to any client
public enum PlayerUnderwaterState
{
    UNDERWATER_NONE                     = 0x00,
    UNDERWATER_INWATER                  = 0x01,             // terrain type is water and player is afflicted by it
    UNDERWATER_INLAVA                   = 0x02,             // terrain type is lava and player is afflicted by it
    UNDERWATER_INSLIME                  = 0x04,             // terrain type is lava and player is afflicted by it
    UNDERWATER_INDARKWATER              = 0x08,             // terrain type is dark water and player is afflicted by it

    UNDERWATER_EXIST_TIMERS             = 0x10
};

public enum BuyBankSlotResult
{
    ERR_BANKSLOT_FAILED_TOO_MANY    = 0,
    ERR_BANKSLOT_INSUFFICIENT_FUNDS = 1,
    ERR_BANKSLOT_NOTBANKER          = 2,
    ERR_BANKSLOT_OK                 = 3
};

public enum PlayerSpellState
{
    PLAYERSPELL_UNCHANGED = 0,
    PLAYERSPELL_CHANGED   = 1,
    PLAYERSPELL_NEW       = 2,
    PLAYERSPELL_REMOVED   = 3
};
 
public enum TrainerSpellState : byte
{
    TRAINER_SPELL_GREEN = 0,
    TRAINER_SPELL_RED   = 1,
    TRAINER_SPELL_GRAY  = 2,
    TRAINER_SPELL_GREEN_DISABLED = 10                       // custom value, not send to client: formally green but learn not allowed
};

public enum ActionButtonUpdateState
{
    ACTIONBUTTON_UNCHANGED = 0,
    ACTIONBUTTON_CHANGED   = 1,
    ACTIONBUTTON_NEW       = 2,
    ACTIONBUTTON_DELETED   = 3
};

public enum ActionButtonType
{
    ACTION_BUTTON_SPELL     = 0x00,
    ACTION_BUTTON_C         = 0x01,                         // click?
    ACTION_BUTTON_EQSET     = 0x20,
    ACTION_BUTTON_MACRO     = 0x40,
    ACTION_BUTTON_CMACRO    = ACTION_BUTTON_C | ACTION_BUTTON_MACRO,
    ACTION_BUTTON_ITEM      = 0x80
};
     
public enum ActionButtonIndex
{
    ACTION_BUTTON_SHAMAN_TOTEMS_BAR = 132,
};
     
public enum GlyphUpdateState
{
    GLYPH_UNCHANGED = 0,
    GLYPH_CHANGED   = 1,
    GLYPH_NEW       = 2,
    GLYPH_DELETED   = 3
};
     
public enum RuneType
{
    RUNE_BLOOD      = 0,
    RUNE_UNHOLY     = 1,
    RUNE_FROST      = 2,
    RUNE_DEATH      = 3,
    NUM_RUNE_TYPES  = 4
};
     
public enum LfgRoles
{
    LEADER  = 0x01,
    TANK    = 0x02,
    HEALER  = 0x04,
    DAMAGE  = 0x08
};

public enum RaidGroupError
{
    ERR_RAID_GROUP_NONE                 = 0,
    ERR_RAID_GROUP_LOWLEVEL             = 1,
    ERR_RAID_GROUP_ONLY                 = 2,
    ERR_RAID_GROUP_FULL                 = 3,
    ERR_RAID_GROUP_REQUIREMENTS_UNMATCH = 4
};

public enum PlayerMovementType
{
    MOVE_ROOT       = 1,
    MOVE_UNROOT     = 2,
    MOVE_WATER_WALK = 3,
    MOVE_LAND_WALK  = 4
};

public enum DrunkenState
{
    DRUNKEN_SOBER   = 0,
    DRUNKEN_TIPSY   = 1,
    DRUNKEN_DRUNK   = 2,
    DRUNKEN_SMASHED = 3
};
 
public enum PlayerFlags
{
    PLAYER_FLAGS_NONE                   = 0x00000000,
    PLAYER_FLAGS_GROUP_LEADER           = 0x00000001,
    PLAYER_FLAGS_AFK                    = 0x00000002,
    PLAYER_FLAGS_DND                    = 0x00000004,
    PLAYER_FLAGS_GM                     = 0x00000008,
    PLAYER_FLAGS_GHOST                  = 0x00000010,
    PLAYER_FLAGS_RESTING                = 0x00000020,
    PLAYER_FLAGS_UNK7                   = 0x00000040,       // admin?
    PLAYER_FLAGS_UNK8                   = 0x00000080,       // pre-3.0.3 PLAYER_FLAGS_FFA_PVP flag for FFA PVP state
    PLAYER_FLAGS_CONTESTED_PVP          = 0x00000100,       // Player has been involved in a PvP combat and will be attacked by contested guards
    PLAYER_FLAGS_IN_PVP                 = 0x00000200,
    PLAYER_FLAGS_HIDE_HELM              = 0x00000400,
    PLAYER_FLAGS_HIDE_CLOAK             = 0x00000800,
    PLAYER_FLAGS_PARTIAL_PLAY_TIME      = 0x00001000,       // played long time
    PLAYER_FLAGS_NO_PLAY_TIME           = 0x00002000,       // played too long time
    PLAYER_FLAGS_IS_OUT_OF_BOUNDS       = 0x00004000,       // Lua_IsOutOfBounds
    PLAYER_FLAGS_DEVELOPER              = 0x00008000,       // <Dev> chat tag, name prefix
    PLAYER_FLAGS_ENABLE_LOW_LEVEL_RAID  = 0x00010000,       // triggers lua event EVENT_ENABLE_LOW_LEVEL_RAID
    PLAYER_FLAGS_TAXI_BENCHMARK         = 0x00020000,       // taxi benchmark mode (on/off) (2.0.1)
    PLAYER_FLAGS_PVP_TIMER              = 0x00040000,       // 3.0.2, pvp timer active (after you disable pvp manually)
    PLAYER_FLAGS_COMMENTATOR            = 0x00080000,
    PLAYER_FLAGS_UNK21                  = 0x00100000,
    PLAYER_FLAGS_UNK22                  = 0x00200000,
    PLAYER_FLAGS_COMMENTATOR_UBER       = 0x00400000,       // something like COMMENTATOR_CAN_USE_INSTANCE_COMMAND
    PLAYER_FLAGS_UNK24                  = 0x00800000,       // EVENT_SPELL_UPDATE_USABLE and EVENT_UPDATE_SHAPESHIFT_USABLE, disabled all abilitys on tab except autoattack
    PLAYER_FLAGS_UNK25                  = 0x01000000,       // EVENT_SPELL_UPDATE_USABLE and EVENT_UPDATE_SHAPESHIFT_USABLE, disabled all melee ability on tab include autoattack
    PLAYER_FLAGS_XP_USER_DISABLED       = 0x02000000,
};
 
// used in (PLAYER_FIELD_BYTES, 0) byte values
public enum PlayerFieldByteFlags
{
    PLAYER_FIELD_BYTE_TRACK_STEALTHED   = 0x02,
    PLAYER_FIELD_BYTE_RELEASE_TIMER     = 0x08,             // Display time till auto release spirit
    PLAYER_FIELD_BYTE_NO_RELEASE_WINDOW = 0x10              // Display no "release spirit" window at all
};

// used in byte (PLAYER_FIELD_BYTES2,3) values
public enum PlayerFieldByte2Flags
{
    PLAYER_FIELD_BYTE2_NONE              = 0x00,
    PLAYER_FIELD_BYTE2_DETECT_AMORE_0    = 0x02,            // SPELL_AURA_DETECT_AMORE, not used as value and maybe not relcted to, but used in code as base for mask apply
    PLAYER_FIELD_BYTE2_DETECT_AMORE_1    = 0x04,            // SPELL_AURA_DETECT_AMORE value 1
    PLAYER_FIELD_BYTE2_DETECT_AMORE_2    = 0x08,            // SPELL_AURA_DETECT_AMORE value 2
    PLAYER_FIELD_BYTE2_DETECT_AMORE_3    = 0x10,            // SPELL_AURA_DETECT_AMORE value 3
    PLAYER_FIELD_BYTE2_STEALTH           = 0x20,
    PLAYER_FIELD_BYTE2_INVISIBILITY_GLOW = 0x40
};

public enum ActivateTaxiReplies
{
    ERR_TAXIOK                      = 0,
    ERR_TAXIUNSPECIFIEDSERVERERROR  = 1,
    ERR_TAXINOSUCHPATH              = 2,
    ERR_TAXINOTENOUGHMONEY          = 3,
    ERR_TAXITOOFARAWAY              = 4,
    ERR_TAXINOVENDORNEARBY          = 5,
    ERR_TAXINOTVISITED              = 6,
    ERR_TAXIPLAYERBUSY              = 7,
    ERR_TAXIPLAYERALREADYMOUNTED    = 8,
    ERR_TAXIPLAYERSHAPESHIFTED      = 9,
    ERR_TAXIPLAYERMOVING            = 10,
    ERR_TAXISAMENODE                = 11,
    ERR_TAXINOTSTANDING             = 12
};

public enum MirrorTimerType
{
    FATIGUE_TIMER      = 0,
    BREATH_TIMER       = 1,
    FIRE_TIMER         = 2
};
 
// 2^n values
public enum PlayerExtraFlags
{
    // gm abilities
    PLAYER_EXTRA_GM_ON              = 0x0001,
    PLAYER_EXTRA_GM_ACCEPT_TICKETS  = 0x0002,
    PLAYER_EXTRA_ACCEPT_WHISPERS    = 0x0004,
    PLAYER_EXTRA_TAXICHEAT          = 0x0008,
    PLAYER_EXTRA_GM_INVISIBLE       = 0x0010,
    PLAYER_EXTRA_GM_CHAT            = 0x0020,               // Show GM badge in chat messages
    PLAYER_EXTRA_AUCTION_NEUTRAL    = 0x0040,
    PLAYER_EXTRA_AUCTION_ENEMY      = 0x0080,               // overwrite PLAYER_EXTRA_AUCTION_NEUTRAL

    // other states
    PLAYER_EXTRA_PVP_DEATH          = 0x0100                // store PvP death status until corpse creating.
};

// 2^n values
public enum AtLoginFlags
{
    AT_LOGIN_NONE              = 0x00,
    AT_LOGIN_RENAME            = 0x01,
    AT_LOGIN_RESET_SPELLS      = 0x02,
    AT_LOGIN_RESET_TALENTS     = 0x04,
    AT_LOGIN_CUSTOMIZE         = 0x08,
    AT_LOGIN_RESET_PET_TALENTS = 0x10,
    AT_LOGIN_FIRST             = 0x20,
};
     
public enum QuestSlotOffsets
{
    QUEST_ID_OFFSET         = 0,
    QUEST_STATE_OFFSET      = 1,
    QUEST_COUNTS_OFFSET     = 2,                            // 2 and 3
    QUEST_TIME_OFFSET       = 4
};
     
public enum QuestSlotStateMask
{
    QUEST_STATE_NONE     = 0x0000,
    QUEST_STATE_COMPLETE = 0x0001,
    QUEST_STATE_FAIL     = 0x0002
};

public enum SkillUpdateState
{
    SKILL_UNCHANGED     = 0,
    SKILL_CHANGED       = 1,
    SKILL_NEW           = 2,
    SKILL_DELETED       = 3
};
     
public enum PlayerSlots
{
    // first slot for item stored (in any way in player m_items data)
    PLAYER_SLOT_START           = 0,
    // last+1 slot for item stored (in any way in player m_items data)
    PLAYER_SLOT_END             = 150,
    PLAYER_SLOTS_COUNT          = (PLAYER_SLOT_END - PLAYER_SLOT_START)
};
     
public enum EquipmentSlots                                         // 19 slots
{
    EQUIPMENT_SLOT_START        = 0,
    EQUIPMENT_SLOT_HEAD         = 0,
    EQUIPMENT_SLOT_NECK         = 1,
    EQUIPMENT_SLOT_SHOULDERS    = 2,
    EQUIPMENT_SLOT_BODY         = 3,
    EQUIPMENT_SLOT_CHEST        = 4,
    EQUIPMENT_SLOT_WAIST        = 5,
    EQUIPMENT_SLOT_LEGS         = 6,
    EQUIPMENT_SLOT_FEET         = 7,
    EQUIPMENT_SLOT_WRISTS       = 8,
    EQUIPMENT_SLOT_HANDS        = 9,
    EQUIPMENT_SLOT_FINGER1      = 10,
    EQUIPMENT_SLOT_FINGER2      = 11,
    EQUIPMENT_SLOT_TRINKET1     = 12,
    EQUIPMENT_SLOT_TRINKET2     = 13,
    EQUIPMENT_SLOT_BACK         = 14,
    EQUIPMENT_SLOT_MAINHAND     = 15,
    EQUIPMENT_SLOT_OFFHAND      = 16,
    EQUIPMENT_SLOT_RANGED       = 17,
    EQUIPMENT_SLOT_TABARD       = 18,
    EQUIPMENT_SLOT_END          = 19
};

public enum InventorySlots                                         // 4 slots
{
    INVENTORY_SLOT_BAG_START    = 19,
    INVENTORY_SLOT_BAG_END      = 23
};

public enum InventoryPackSlots                                     // 16 slots
{
    INVENTORY_SLOT_ITEM_START   = 23,
    INVENTORY_SLOT_ITEM_END     = 39
};

public enum BankItemSlots                                          // 28 slots
{
    BANK_SLOT_ITEM_START        = 39,
    BANK_SLOT_ITEM_END          = 67
};

public enum BankBagSlots                                           // 7 slots
{
    BANK_SLOT_BAG_START         = 67,
    BANK_SLOT_BAG_END           = 74
};

public enum BuyBackSlots                                           // 12 slots
{
    // stored in m_buybackitems
    BUYBACK_SLOT_START          = 74,
    BUYBACK_SLOT_END            = 86
};

public enum KeyRingSlots                                           // 32 slots
{
    KEYRING_SLOT_START          = 86,
    KEYRING_SLOT_END            = 118
};

public enum CurrencyTokenSlots                                     // 32 slots
{
    CURRENCYTOKEN_SLOT_START    = 118,
    CURRENCYTOKEN_SLOT_END      = 150
};

public enum EquipmentSetUpdateState
{
    EQUIPMENT_SET_UNCHANGED = 0,
    EQUIPMENT_SET_CHANGED   = 1,
    EQUIPMENT_SET_NEW       = 2,
    EQUIPMENT_SET_DELETED   = 3
};
     
public enum TradeSlots
{
    TRADE_SLOT_COUNT            = 7,
    TRADE_SLOT_TRADED_COUNT     = 6,
    TRADE_SLOT_NONTRADED        = 6
};

public enum TransferAbortReason : int
{
    TRANSFER_ABORT_NONE                         = 0x00,
    TRANSFER_ABORT_ERROR                        = 0x01,
    TRANSFER_ABORT_MAX_PLAYERS                  = 0x02,     // Transfer Aborted: instance is full
    TRANSFER_ABORT_NOT_FOUND                    = 0x03,     // Transfer Aborted: instance not found
    TRANSFER_ABORT_TOO_MANY_INSTANCES           = 0x04,     // You have entered too many instances recently.
    TRANSFER_ABORT_ZONE_IN_COMBAT               = 0x06,     // Unable to zone in while an encounter is in progress.
    TRANSFER_ABORT_INSUF_EXPAN_LVL              = 0x07,     // You must have <TBC,WotLK> expansion installed to access this area.
    TRANSFER_ABORT_DIFFICULTY                   = 0x08,     // <Normal,Heroic,Epic> difficulty mode is not available for %s.
    TRANSFER_ABORT_UNIQUE_MESSAGE               = 0x09,     // Until you've escaped TLK's grasp, you cannot leave this place!
    TRANSFER_ABORT_TOO_MANY_REALM_INSTANCES     = 0x0A,     // Additional instances cannot be launched, please try again later.
    TRANSFER_ABORT_NEED_GROUP                   = 0x0B,     // 3.1
    TRANSFER_ABORT_NOT_FOUND2                   = 0x0C,     // 3.1
    TRANSFER_ABORT_NOT_FOUND3                   = 0x0D,     // 3.1
    TRANSFER_ABORT_NOT_FOUND4                   = 0x0E,     // 3.2
    TRANSFER_ABORT_REALM_ONLY                   = 0x0F,     // All players on party must be from the same realm.
    TRANSFER_ABORT_MAP_NOT_ALLOWED              = 0x10,     // Map can't be entered at this time.
};

public enum InstanceResetWarningType
{
    RAID_INSTANCE_WARNING_HOURS     = 1,                    // WARNING! %s is scheduled to reset in %d hour(s).
    RAID_INSTANCE_WARNING_MIN       = 2,                    // WARNING! %s is scheduled to reset in %d minute(s)!
    RAID_INSTANCE_WARNING_MIN_SOON  = 3,                    // WARNING! %s is scheduled to reset in %d minute(s). Please exit the zone or you will be returned to your bind location!
    RAID_INSTANCE_WELCOME           = 4,                    // Welcome to %s. This raid instance is scheduled to reset in %s.
    RAID_INSTANCE_EXPIRED           = 5
};

// PLAYER_FIELD_ARENA_TEAM_INFO_1_1 offsets
public enum ArenaTeamInfoType
{
    ARENA_TEAM_ID               = 0,
    ARENA_TEAM_TYPE             = 1,                        // new in 3.2 - team type?
    ARENA_TEAM_MEMBER           = 2,                        // 0 - captain, 1 - member
    ARENA_TEAM_GAMES_WEEK       = 3,
    ARENA_TEAM_GAMES_SEASON     = 4,
    ARENA_TEAM_WINS_SEASON      = 5,
    ARENA_TEAM_PERSONAL_RATING  = 6,
    ARENA_TEAM_END              = 7
};

public enum RestType
{
    REST_TYPE_NO        = 0,
    REST_TYPE_IN_TAVERN = 1,
    REST_TYPE_IN_CITY   = 2
};

public enum DuelCompleteType
{
    DUEL_INTERUPTED = 0,
    DUEL_WON        = 1,
    DUEL_FLED       = 2
};

public enum TeleportToOptions
{
    TELE_TO_GM_MODE             = 0x01,
    TELE_TO_NOT_LEAVE_TRANSPORT = 0x02,
    TELE_TO_NOT_LEAVE_COMBAT    = 0x04,
    TELE_TO_NOT_UNSUMMON_PET    = 0x08,
    TELE_TO_SPELL               = 0x10,
};

/// Type of environmental damages
public enum EnviromentalDamage
{
    DAMAGE_EXHAUSTED = 0,
    DAMAGE_DROWNING  = 1,
    DAMAGE_FALL      = 2,
    DAMAGE_LAVA      = 3,
    DAMAGE_SLIME     = 4,
    DAMAGE_FIRE      = 5,
    DAMAGE_FALL_TO_VOID = 6                                 // custom case for fall without durability loss
};

public enum PlayedTimeIndex
{
    PLAYED_TIME_TOTAL = 0,
    PLAYED_TIME_LEVEL = 1
};
     
public enum PlayerLoginQueryIndex
{
    PLAYER_LOGIN_QUERY_LOADFROM,
    PLAYER_LOGIN_QUERY_LOADGROUP,
    PLAYER_LOGIN_QUERY_LOADBOUNDINSTANCES,
    PLAYER_LOGIN_QUERY_LOADAURAS,
    PLAYER_LOGIN_QUERY_LOADSPELLS,
    PLAYER_LOGIN_QUERY_LOADQUESTSTATUS,
    PLAYER_LOGIN_QUERY_LOADDAILYQUESTSTATUS,
    PLAYER_LOGIN_QUERY_LOADREPUTATION,
    PLAYER_LOGIN_QUERY_LOADINVENTORY,
    PLAYER_LOGIN_QUERY_LOADITEMLOOT,
    PLAYER_LOGIN_QUERY_LOADACTIONS,
    PLAYER_LOGIN_QUERY_LOADSOCIALLIST,
    PLAYER_LOGIN_QUERY_LOADHOMEBIND,
    PLAYER_LOGIN_QUERY_LOADSPELLCOOLDOWNS,
    PLAYER_LOGIN_QUERY_LOADDECLINEDNAMES,
    PLAYER_LOGIN_QUERY_LOADGUILD,
    PLAYER_LOGIN_QUERY_LOADARENAINFO,
    PLAYER_LOGIN_QUERY_LOADACHIEVEMENTS,
    PLAYER_LOGIN_QUERY_LOADCRITERIAPROGRESS,
    PLAYER_LOGIN_QUERY_LOADEQUIPMENTSETS,
    PLAYER_LOGIN_QUERY_LOADBGDATA,
    PLAYER_LOGIN_QUERY_LOADACCOUNTDATA,
    PLAYER_LOGIN_QUERY_LOADSKILLS,
    PLAYER_LOGIN_QUERY_LOADGLYPHS,
    PLAYER_LOGIN_QUERY_LOADMAILS,
    PLAYER_LOGIN_QUERY_LOADMAILEDITEMS,
    PLAYER_LOGIN_QUERY_LOADTALENTS,
    PLAYER_LOGIN_QUERY_LOADWEEKLYQUESTSTATUS,
    PLAYER_LOGIN_QUERY_LOADMONTHLYQUESTSTATUS,

    MAX_PLAYER_LOGIN_QUERY
};

public enum PlayerDelayedOperations
{
    DELAYED_SAVE_PLAYER         = 0x01,
    DELAYED_RESURRECT_PLAYER    = 0x02,
    DELAYED_SPELL_CAST_DESERTER = 0x04,
    DELAYED_BG_MOUNT_RESTORE    = 0x08,                     ///< Flag to restore mount state after teleport from BG
    DELAYED_BG_TAXI_RESTORE     = 0x10,                     ///< Flag to restore taxi state after teleport from BG
    DELAYED_END
};

public enum ReputationSource
{
    REPUTATION_SOURCE_KILL,
    REPUTATION_SOURCE_QUEST,
    REPUTATION_SOURCE_SPELL
};
}