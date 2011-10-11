﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{

    public enum ItemModType
    {
        ITEM_MOD_MANA = 0,
        ITEM_MOD_HEALTH = 1,
        ITEM_MOD_AGILITY = 3,
        ITEM_MOD_STRENGTH = 4,
        ITEM_MOD_INTELLECT = 5,
        ITEM_MOD_SPIRIT = 6,
        ITEM_MOD_STAMINA = 7,
        ITEM_MOD_DEFENSE_SKILL_RATING = 12,
        ITEM_MOD_DODGE_RATING = 13,
        ITEM_MOD_PARRY_RATING = 14,
        ITEM_MOD_BLOCK_RATING = 15,
        ITEM_MOD_HIT_MELEE_RATING = 16,
        ITEM_MOD_HIT_RANGED_RATING = 17,
        ITEM_MOD_HIT_SPELL_RATING = 18,
        ITEM_MOD_CRIT_MELEE_RATING = 19,
        ITEM_MOD_CRIT_RANGED_RATING = 20,
        ITEM_MOD_CRIT_SPELL_RATING = 21,
        ITEM_MOD_HIT_TAKEN_MELEE_RATING = 22,
        ITEM_MOD_HIT_TAKEN_RANGED_RATING = 23,
        ITEM_MOD_HIT_TAKEN_SPELL_RATING = 24,
        ITEM_MOD_CRIT_TAKEN_MELEE_RATING = 25,
        ITEM_MOD_CRIT_TAKEN_RANGED_RATING = 26,
        ITEM_MOD_CRIT_TAKEN_SPELL_RATING = 27,
        ITEM_MOD_HASTE_MELEE_RATING = 28,
        ITEM_MOD_HASTE_RANGED_RATING = 29,
        ITEM_MOD_HASTE_SPELL_RATING = 30,
        ITEM_MOD_HIT_RATING = 31,
        ITEM_MOD_CRIT_RATING = 32,
        ITEM_MOD_HIT_TAKEN_RATING = 33,
        ITEM_MOD_CRIT_TAKEN_RATING = 34,
        ITEM_MOD_RESILIENCE_RATING = 35,
        ITEM_MOD_HASTE_RATING = 36,
        ITEM_MOD_EXPERTISE_RATING = 37,
        ITEM_MOD_ATTACK_POWER = 38,
        ITEM_MOD_RANGED_ATTACK_POWER = 39,
        ITEM_MOD_FERAL_ATTACK_POWER = 40,                 // deprecated
        ITEM_MOD_SPELL_HEALING_DONE = 41,                 // deprecated
        ITEM_MOD_SPELL_DAMAGE_DONE = 42,                 // deprecated
        ITEM_MOD_MANA_REGENERATION = 43,
        ITEM_MOD_ARMOR_PENETRATION_RATING = 44,
        ITEM_MOD_SPELL_POWER = 45,
        ITEM_MOD_HEALTH_REGEN = 46,
        ITEM_MOD_SPELL_PENETRATION = 47,
        ITEM_MOD_BLOCK_VALUE = 48
    };


    public enum ItemSpelltriggerType
    {
        ITEM_SPELLTRIGGER_ON_USE = 0,                  // use after equip cooldown
        ITEM_SPELLTRIGGER_ON_EQUIP = 1,
        ITEM_SPELLTRIGGER_CHANCE_ON_HIT = 2,
        ITEM_SPELLTRIGGER_SOULSTONE = 4,
        ITEM_SPELLTRIGGER_ON_STORE = 5,                  // casted at add item to inventory/equip, applied aura removed at remove item, item deleted at aura cancel/expire/etc
        ITEM_SPELLTRIGGER_LEARN_SPELL_ID = 6                   // used in item_template.spell_2 with spell_id with SPELL_GENERIC_LEARN in spell_1
    };


    public enum ItemBondingType
    {
        NO_BIND = 0,
        BIND_WHEN_PICKED_UP = 1,
        BIND_WHEN_EQUIPPED = 2,
        BIND_WHEN_USE = 3,
        BIND_QUEST_ITEM = 4,
        BIND_QUEST_ITEM1 = 5         // not used in game
    };


    // Mask for ItemPrototype.Flags field
    public enum ItemPrototypeFlags : uint
    {
        ITEM_FLAG_UNK0 = 0x00000001, // not used
        ITEM_FLAG_CONJURED = 0x00000002,
        ITEM_FLAG_LOOTABLE = 0x00000004, // affect only non container items that can be "open" for loot. It or lockid set enable for client show "Right click to open". See also ITEM_DYNFLAG_UNLOCKED
        ITEM_FLAG_HEROIC = 0x00000008, // heroic item version
        ITEM_FLAG_UNK4 = 0x00000010, // can't repeat old note: appears red icon (like when item durability==0)
        ITEM_FLAG_INDESTRUCTIBLE = 0x00000020, // used for totem. Item can not be destroyed, except by using spell (item can be reagent for spell and then allowed)
        ITEM_FLAG_UNK6 = 0x00000040, // ? old note: usable
        ITEM_FLAG_NO_EQUIP_COOLDOWN = 0x00000080,
        ITEM_FLAG_UNK8 = 0x00000100, // saw this on item 47115, 49295...
        ITEM_FLAG_WRAPPER = 0x00000200, // used or not used wrapper
        ITEM_FLAG_IGNORE_BAG_SPACE = 0x00000400, // ignore bag space at new item creation?
        ITEM_FLAG_PARTY_LOOT = 0x00000800, // determines if item is party loot or not
        ITEM_FLAG_REFUNDABLE = 0x00001000, // item cost can be refunded within 2 hours after purchase
        ITEM_FLAG_CHARTER = 0x00002000, // arena/guild charter
        ITEM_FLAG_UNK14 = 0x00004000,
        ITEM_FLAG_UNK15 = 0x00008000, // a lot of items have this
        ITEM_FLAG_UNK16 = 0x00010000, // a lot of items have this
        ITEM_FLAG_UNK17 = 0x00020000,
        ITEM_FLAG_PROSPECTABLE = 0x00040000, // item can have prospecting loot (in fact some items expected have empty loot)
        ITEM_FLAG_UNIQUE_EQUIPPED = 0x00080000,
        ITEM_FLAG_UNK20 = 0x00100000,
        ITEM_FLAG_USEABLE_IN_ARENA = 0x00200000,
        ITEM_FLAG_THROWABLE = 0x00400000, // Only items of ITEM_SUBCLASS_WEAPON_THROWN have it but not all, so can't be used as in game check
        ITEM_FLAG_SPECIALUSE = 0x00800000, // last used flag in 2.3.0
        ITEM_FLAG_UNK24 = 0x01000000,
        ITEM_FLAG_UNK25 = 0x02000000,
        ITEM_FLAG_UNK26 = 0x04000000,
        ITEM_FLAG_BOA = 0x08000000, // bind on account (set in template for items that can binded in like way)
        ITEM_FLAG_ENCHANT_SCROLL = 0x10000000, // for enchant scrolls
        ITEM_FLAG_MILLABLE = 0x20000000, // item can have milling loot
        ITEM_FLAG_UNK30 = 0x40000000,
        ITEM_FLAG_BOP_TRADEABLE = 0x80000000, // bound item that can be traded
    };

    public enum ItemPrototypeFlags2
    {
        ITEM_FLAG2_HORDE_ONLY = 0x00000001, // drop in loot, sell by vendor and equipping only for horde
        ITEM_FLAG2_ALLIANCE_ONLY = 0x00000002, // drop in loot, sell by vendor and equipping only for alliance
        ITEM_FLAG2_EXT_COST_REQUIRES_GOLD = 0x00000004, // item cost include gold part in case extended cost use also
        ITEM_FLAG2_UNK4 = 0x00000008,
        ITEM_FLAG2_UNK5 = 0x00000010,
        ITEM_FLAG2_UNK6 = 0x00000020,
        ITEM_FLAG2_UNK7 = 0x00000040,
        ITEM_FLAG2_UNK8 = 0x00000080,
        ITEM_FLAG2_NEED_ROLL_DISABLED = 0x00000100, // need roll during looting is not allowed for this item
        ITEM_FLAG2_CASTER_WEAPON = 0x00000200, // uses caster specific dbc file for DPS calculations
    };

    public enum BagFamilyMask
    {
        BAG_FAMILY_MASK_NONE = 0x00000000,
        BAG_FAMILY_MASK_ARROWS = 0x00000001,
        BAG_FAMILY_MASK_BULLETS = 0x00000002,
        BAG_FAMILY_MASK_SOUL_SHARDS = 0x00000004,
        BAG_FAMILY_MASK_LEATHERWORKING_SUPP = 0x00000008,
        BAG_FAMILY_MASK_INSCRIPTION_SUPP = 0x00000010,
        BAG_FAMILY_MASK_HERBS = 0x00000020,
        BAG_FAMILY_MASK_ENCHANTING_SUPP = 0x00000040,
        BAG_FAMILY_MASK_ENGINEERING_SUPP = 0x00000080,
        BAG_FAMILY_MASK_KEYS = 0x00000100,
        BAG_FAMILY_MASK_GEMS = 0x00000200,
        BAG_FAMILY_MASK_MINING_SUPP = 0x00000400,
        BAG_FAMILY_MASK_SOULBOUND_EQUIPMENT = 0x00000800,
        BAG_FAMILY_MASK_VANITY_PETS = 0x00001000,
        BAG_FAMILY_MASK_CURRENCY_TOKENS = 0x00002000,
        BAG_FAMILY_MASK_QUEST_ITEMS = 0x00004000
    };

    public enum SocketColor
    {
        SOCKET_COLOR_META = 1,
        SOCKET_COLOR_RED = 2,
        SOCKET_COLOR_YELLOW = 4,
        SOCKET_COLOR_BLUE = 8
    };


    public enum InventoryType : byte
    {
        NON_EQUIP = 0,
        HEAD = 1,
        NECK = 2,
        SHOULDERS = 3,
        BODY = 4,
        CHEST = 5,
        WAIST = 6,
        LEGS = 7,
        FEET = 8,
        WRISTS = 9,
        HANDS = 10,
        FINGER = 11,
        TRINKET = 12,
        WEAPON = 13,
        SHIELD = 14,
        RANGED = 15,
        CLOAK = 16,
        TWOHWEAPON = 17,
        BAG = 18,
        TABARD = 19,
        ROBE = 20,
        WEAPONMAINHAND = 21,
        WEAPONOFFHAND = 22,
        HOLDABLE = 23,
        AMMO = 24,
        THROWN = 25,
        RANGEDRIGHT = 26,
        QUIVER = 27,
        RELIC = 28
    };


    public enum ItemClass
    {
        ITEM_CLASS_CONSUMABLE = 0,
        ITEM_CLASS_CONTAINER = 1,
        ITEM_CLASS_WEAPON = 2,
        ITEM_CLASS_GEM = 3,
        ITEM_CLASS_ARMOR = 4,
        ITEM_CLASS_REAGENT = 5,
        ITEM_CLASS_PROJECTILE = 6,
        ITEM_CLASS_TRADE_GOODS = 7,
        ITEM_CLASS_GENERIC = 8,
        ITEM_CLASS_RECIPE = 9,
        ITEM_CLASS_MONEY = 10,
        ITEM_CLASS_QUIVER = 11,
        ITEM_CLASS_QUEST = 12,
        ITEM_CLASS_KEY = 13,
        ITEM_CLASS_PERMANENT = 14,
        ITEM_CLASS_MISC = 15,
        ITEM_CLASS_GLYPH = 16
    };


    public enum ItemSubclassConsumable
    {
        ITEM_SUBCLASS_CONSUMABLE = 0,
        ITEM_SUBCLASS_POTION = 1,
        ITEM_SUBCLASS_ELIXIR = 2,
        ITEM_SUBCLASS_FLASK = 3,
        ITEM_SUBCLASS_SCROLL = 4,
        ITEM_SUBCLASS_FOOD = 5,
        ITEM_SUBCLASS_ITEM_ENHANCEMENT = 6,
        ITEM_SUBCLASS_BANDAGE = 7,
        ITEM_SUBCLASS_CONSUMABLE_OTHER = 8
    };


    public enum ItemSubclassContainer
    {
        ITEM_SUBCLASS_CONTAINER = 0,
        ITEM_SUBCLASS_SOUL_CONTAINER = 1,
        ITEM_SUBCLASS_HERB_CONTAINER = 2,
        ITEM_SUBCLASS_ENCHANTING_CONTAINER = 3,
        ITEM_SUBCLASS_ENGINEERING_CONTAINER = 4,
        ITEM_SUBCLASS_GEM_CONTAINER = 5,
        ITEM_SUBCLASS_MINING_CONTAINER = 6,
        ITEM_SUBCLASS_LEATHERWORKING_CONTAINER = 7,
        ITEM_SUBCLASS_INSCRIPTION_CONTAINER = 8
    };


    public enum ItemSubclassWeapon
    {
        ITEM_SUBCLASS_WEAPON_AXE = 0,
        ITEM_SUBCLASS_WEAPON_AXE2 = 1,
        ITEM_SUBCLASS_WEAPON_BOW = 2,
        ITEM_SUBCLASS_WEAPON_GUN = 3,
        ITEM_SUBCLASS_WEAPON_MACE = 4,
        ITEM_SUBCLASS_WEAPON_MACE2 = 5,
        ITEM_SUBCLASS_WEAPON_POLEARM = 6,
        ITEM_SUBCLASS_WEAPON_SWORD = 7,
        ITEM_SUBCLASS_WEAPON_SWORD2 = 8,
        ITEM_SUBCLASS_WEAPON_obsolete = 9,
        ITEM_SUBCLASS_WEAPON_STAFF = 10,
        ITEM_SUBCLASS_WEAPON_EXOTIC = 11,
        ITEM_SUBCLASS_WEAPON_EXOTIC2 = 12,
        ITEM_SUBCLASS_WEAPON_FIST = 13,
        ITEM_SUBCLASS_WEAPON_MISC = 14,
        ITEM_SUBCLASS_WEAPON_DAGGER = 15,
        ITEM_SUBCLASS_WEAPON_THROWN = 16,
        ITEM_SUBCLASS_WEAPON_SPEAR = 17,
        ITEM_SUBCLASS_WEAPON_CROSSBOW = 18,
        ITEM_SUBCLASS_WEAPON_WAND = 19,
        ITEM_SUBCLASS_WEAPON_FISHING_POLE = 20
    };

    public enum ItemSubclassGem
    {
        ITEM_SUBCLASS_GEM_RED = 0,
        ITEM_SUBCLASS_GEM_BLUE = 1,
        ITEM_SUBCLASS_GEM_YELLOW = 2,
        ITEM_SUBCLASS_GEM_PURPLE = 3,
        ITEM_SUBCLASS_GEM_GREEN = 4,
        ITEM_SUBCLASS_GEM_ORANGE = 5,
        ITEM_SUBCLASS_GEM_META = 6,
        ITEM_SUBCLASS_GEM_SIMPLE = 7,
        ITEM_SUBCLASS_GEM_PRISMATIC = 8
    };

    public enum ItemSubclassArmor
    {
        ITEM_SUBCLASS_ARMOR_MISC = 0,
        ITEM_SUBCLASS_ARMOR_CLOTH = 1,
        ITEM_SUBCLASS_ARMOR_LEATHER = 2,
        ITEM_SUBCLASS_ARMOR_MAIL = 3,
        ITEM_SUBCLASS_ARMOR_PLATE = 4,
        ITEM_SUBCLASS_ARMOR_BUCKLER = 5,
        ITEM_SUBCLASS_ARMOR_SHIELD = 6,
        ITEM_SUBCLASS_ARMOR_LIBRAM = 7,
        ITEM_SUBCLASS_ARMOR_IDOL = 8,
        ITEM_SUBCLASS_ARMOR_TOTEM = 9,
        ITEM_SUBCLASS_ARMOR_SIGIL = 10
    };

    public enum ItemSubclassReagent
    {
        ITEM_SUBCLASS_REAGENT = 0
    };

    public enum ItemSubclassProjectile
    {
        ITEM_SUBCLASS_WAND = 0,        // ABS
        ITEM_SUBCLASS_BOLT = 1,        // ABS
        ITEM_SUBCLASS_ARROW = 2,
        ITEM_SUBCLASS_BULLET = 3,
        ITEM_SUBCLASS_THROWN = 4         // ABS
    };

    public enum ItemSubclassTradeGoods
    {
        ITEM_SUBCLASS_TRADE_GOODS = 0,
        ITEM_SUBCLASS_PARTS = 1,
        ITEM_SUBCLASS_EXPLOSIVES = 2,
        ITEM_SUBCLASS_DEVICES = 3,
        ITEM_SUBCLASS_JEWELCRAFTING = 4,
        ITEM_SUBCLASS_CLOTH = 5,
        ITEM_SUBCLASS_LEATHER = 6,
        ITEM_SUBCLASS_METAL_STONE = 7,
        ITEM_SUBCLASS_MEAT = 8,
        ITEM_SUBCLASS_HERB = 9,
        ITEM_SUBCLASS_ELEMENTAL = 10,
        ITEM_SUBCLASS_TRADE_GOODS_OTHER = 11,
        ITEM_SUBCLASS_ENCHANTING = 12,
        ITEM_SUBCLASS_MATERIAL = 13,
        ITEM_SUBCLASS_ARMOR_ENCHANTMENT = 14,
        ITEM_SUBCLASS_WEAPON_ENCHANTMENT = 15
    };

    public enum ItemSubclassGeneric
    {
        ITEM_SUBCLASS_GENERIC = 0
    };

    public enum ItemSubclassRecipe
    {
        ITEM_SUBCLASS_BOOK = 0,
        ITEM_SUBCLASS_LEATHERWORKING_PATTERN = 1,
        ITEM_SUBCLASS_TAILORING_PATTERN = 2,
        ITEM_SUBCLASS_ENGINEERING_SCHEMATIC = 3,
        ITEM_SUBCLASS_BLACKSMITHING = 4,
        ITEM_SUBCLASS_COOKING_RECIPE = 5,
        ITEM_SUBCLASS_ALCHEMY_RECIPE = 6,
        ITEM_SUBCLASS_FIRST_AID_MANUAL = 7,
        ITEM_SUBCLASS_ENCHANTING_FORMULA = 8,
        ITEM_SUBCLASS_FISHING_MANUAL = 9,
        ITEM_SUBCLASS_JEWELCRAFTING_RECIPE = 10
    };

    public enum ItemSubclassMoney
    {
        ITEM_SUBCLASS_MONEY = 0
    };

    public enum ItemSubclassQuiver
    {
        ITEM_SUBCLASS_QUIVER0 = 0,        // ABS
        ITEM_SUBCLASS_QUIVER1 = 1,        // ABS
        ITEM_SUBCLASS_QUIVER = 2,
        ITEM_SUBCLASS_AMMO_POUCH = 3
    };

    public enum ItemSubclassQuest
    {
        ITEM_SUBCLASS_QUEST = 0
    };

    public enum ItemSubclassKey
    {
        ITEM_SUBCLASS_KEY = 0,
        ITEM_SUBCLASS_LOCKPICK = 1
    };

    public enum ItemSubclassPermanent
    {
        ITEM_SUBCLASS_PERMANENT = 0
    };

    public enum ItemSubclassJunk
    {
        ITEM_SUBCLASS_JUNK = 0,
        ITEM_SUBCLASS_JUNK_REAGENT = 1,
        ITEM_SUBCLASS_JUNK_PET = 2,
        ITEM_SUBCLASS_JUNK_HOLIDAY = 3,
        ITEM_SUBCLASS_JUNK_OTHER = 4,
        ITEM_SUBCLASS_JUNK_MOUNT = 5
    };

    public enum ItemSubclassGlyph
    {
        ITEM_SUBCLASS_GLYPH_WARRIOR = 1,
        ITEM_SUBCLASS_GLYPH_PALADIN = 2,
        ITEM_SUBCLASS_GLYPH_HUNTER = 3,
        ITEM_SUBCLASS_GLYPH_ROGUE = 4,
        ITEM_SUBCLASS_GLYPH_PRIEST = 5,
        ITEM_SUBCLASS_GLYPH_DEATH_KNIGHT = 6,
        ITEM_SUBCLASS_GLYPH_SHAMAN = 7,
        ITEM_SUBCLASS_GLYPH_MAGE = 8,
        ITEM_SUBCLASS_GLYPH_WARLOCK = 9,
        ITEM_SUBCLASS_GLYPH_DRUID = 11
    };

    [Flags]
    public enum ItemExtraFlags
    {
        ITEM_EXTRA_NON_CONSUMABLE = 0x01,                   // use as additional flag to spellcharges_N negative values, item not expire at no chanrges
        ITEM_EXTRA_REAL_TIME_DURATION = 0x02,                   // if set and have Duration time, then offline time included in counting, if not set then counted only in game time

        ITEM_EXTRA_ALL = 0x03                    // all used flags, used for check DB data (mask all above flags)
    };

}