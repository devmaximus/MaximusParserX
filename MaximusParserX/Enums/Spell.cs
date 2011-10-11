using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    [Flags]
    public enum SpellCastFlags : int
    {
        CAST_FLAG_NONE = 0x00000000,
        CAST_FLAG_HIDDEN_COMBATLOG = 0x00000001,               // hide in combat log?
        CAST_FLAG_UNKNOWN2 = 0x00000002,
        CAST_FLAG_UNKNOWN3 = 0x00000004,
        CAST_FLAG_UNKNOWN4 = 0x00000008,
        CAST_FLAG_UNKNOWN5 = 0x00000010,
        CAST_FLAG_AMMO = 0x00000020,               // Projectiles visual
        CAST_FLAG_UNKNOWN7 = 0x00000040,               // !0x41 mask used to call CGTradeSkillInfo::DoRecast
        CAST_FLAG_UNKNOWN8 = 0x00000080,
        CAST_FLAG_UNKNOWN9 = 0x00000100,
        CAST_FLAG_UNKNOWN10 = 0x00000200,
        CAST_FLAG_UNKNOWN11 = 0x00000400,
        CAST_FLAG_PREDICTED_POWER = 0x00000800,               // wotlk, trigger rune cooldown
        CAST_FLAG_UNKNOWN13 = 0x00001000,
        CAST_FLAG_UNKNOWN14 = 0x00002000,
        CAST_FLAG_UNKNOWN15 = 0x00004000,
        CAST_FLAG_UNKNOWN16 = 0x00008000,
        CAST_FLAG_UNKNOWN17 = 0x00010000,
        CAST_FLAG_ADJUST_MISSILE = 0x00020000,               // wotlk
        CAST_FLAG_UNKNOWN19 = 0x00040000,               // spell cooldown related (may be category cooldown)
        CAST_FLAG_VISUAL_CHAIN = 0x00080000,               // wotlk
        CAST_FLAG_UNKNOWN21 = 0x00100000,
        CAST_FLAG_PREDICTED_RUNES = 0x00200000,               // wotlk, rune cooldown list
        CAST_FLAG_IMMUNITY = 0x04000000                // spell cast school imminity info
 
    };

    public enum SpellFlags
    {
        SPELL_FLAG_NORMAL = 0x00,
        SPELL_FLAG_REFLECTED = 0x01,     // reflected spell
        SPELL_FLAG_REDIRECTED = 0x02      // redirected spell
    };

    enum SpellNotifyPushType
    {
        PUSH_IN_FRONT,
        PUSH_IN_FRONT_90,
        PUSH_IN_FRONT_30,
        PUSH_IN_FRONT_15,
        PUSH_IN_BACK,
        PUSH_SELF_CENTER,
        PUSH_DEST_CENTER,
        PUSH_TARGET_CENTER
    };

    enum SpellState
    {
        SPELL_STATE_PREPARING = 0,                              // cast time delay period, non channeled spell
        SPELL_STATE_CASTING = 1,                              // channeled time period spell casting state
        SPELL_STATE_FINISHED = 2,                              // cast finished to success or fail
        SPELL_STATE_DELAYED = 3                               // spell casted but need time to hit target(s)
    };

    enum SpellTargets
    {
        SPELL_TARGETS_HOSTILE,
        SPELL_TARGETS_NOT_FRIENDLY,
        SPELL_TARGETS_NOT_HOSTILE,
        SPELL_TARGETS_FRIENDLY,
        SPELL_TARGETS_AOE_DAMAGE,
        SPELL_TARGETS_ALL
    };

    enum ReplenishType
    {
        REPLENISH_UNDEFINED = 0,
        REPLENISH_HEALTH = 20,
        REPLENISH_MANA = 21,
        REPLENISH_RAGE = 22
    };

}
