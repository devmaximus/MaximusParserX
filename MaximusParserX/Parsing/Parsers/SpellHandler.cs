using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_SEND_UNLEARN_SPELLS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var count = ReadInt32("Count");

            for (var i = 0; i < count; i++)
            {
                var spellId = ReadInt32("Spell ID " + i);
            }

            return Validate();
        }
    }

    public class SMSG_POWER_UPDATE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            if (ClientBuildAmount <= 11403)
            {
                var guid = ReadPackedWoWGuid("guid");
            }
            var type = ReadEnum<Powers>("Power", TypeCode.Byte);
            var value = ReadInt32("Power value");
            return Validate();
        }
    }

    public class SMSG_UNIT_SPELLCAST_START_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var casterGuid = ReadPackedWoWGuid("casterGuid");
            var targetGuid = ReadPackedWoWGuid("targetGuid");
            var spellId = ReadInt32("spellId");
            var castTime = ReadInt32("castTime");
            var unkInt = ReadInt32("unkInt");

            return Validate();
        }
    }

    public class SMSG_INITIAL_SPELLS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var talentSpec = ReadByte("talentSpec");
            var count = ReadInt16("count");

            for (var i = 0; i < count; i++)
            {
                var spellId = ReadInt32("spellId");
                var unk16 = ReadInt16("unk16");
                //var chr = SessionHandler.LoggedInCharacter;
                //if (!chr.FirstLogin)
                //    continue;

                //Store.WriteData(Store.StartSpells.GetCommand(chr.Race, chr.Class, spellId));
            }

            var cooldownCount = ReadInt16("cooldownCount");

            for (var i = 0; i < cooldownCount; i++)
            {
                var spellId = ReadInt32("spellId");
                var castItemId = ReadInt16("castItemId");
                var spellCat = ReadInt16("spellCat");
                var cooldown = ReadInt32("cooldown");
                var catCooldown = ReadInt32("catCooldown");
            }
            return Validate();
        }
    }

    public class SMSG_AURA_UPDATE_DEF : SMSG_AURA_UPDATE_ALL_DEF { }
    public class SMSG_AURA_UPDATE_ALL_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var targetguid = ReadPackedWoWGuid("targetguid");

            while (AvailableBytes > 0)
            {
                var slot = ReadByte("slot");

                var id = ReadInt32("id");

                if (id > 0)
                {

                    var flags = ReadEnum<AuraFlags>("AuraFlag", TypeCode.Byte);

                    var level = ReadByte("level");

                    var charges = ReadByte("charges");

                    if (!flags.HasFlag(AuraFlags.AFLAG_NOT_CASTER))
                    {
                        //UInt32 UInt32_1 = ReadUInt32();
                        //UInt32 UInt32_2 = ReadUInt32();
                        //UInt32 UInt32_3 = ReadUInt32();
                        //UInt32 UInt32_4 = ReadUInt32();
                        //UInt32 UInt32_5 = ReadUInt32();

                        var unkGuid = ReadPackedWoWGuid("unkGuid");
                    }

                    if (flags.HasFlag(AuraFlags.AFLAG_DURATION))
                    {

                        var maxDura = ReadInt32("maxDura");

                        var dura = ReadInt32("dura");
                    }
                }
            }

            return Validate();
        }
    }

    public class SMSG_SPELL_START_DEF : SMSG_SPELL_GO_DEF { }
    public class SMSG_SPELL_GO_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var casterGuid = ReadPackedWoWGuid("casterGuid");
            var casterUnit = ReadPackedWoWGuid("casterUnit");
            var count = ReadByte("count");
            var spellId = ReadInt32("spellId");
            var flags = ReadEnum<SpellCastFlags>("SpellCastFlags");
            var time = ReadInt32("time");

            if (OpcodeName == "SMSG_SPELL_GO")
            {
                var hitCount = ReadByte("hitCount");

                for (var i = 0; i < hitCount; i++)
                {
                    var hitGuid = ReadPackedWoWGuid("hitGuid");
                }

                var missCount = ReadByte("missCount");

                for (var i = 0; i < missCount; i++)
                {
                    var missGuid = ReadPackedWoWGuid("missGuid");

                    var missType = ReadEnum<SpellMissInfo>("misstype");

                    if (missType != SpellMissInfo.REFLECT)
                        continue;

                    var reflectResult = ReadEnum<SpellMissInfo>("reflectResult");
                }
            }

            var targetFlags = ReadEnum<SpellCastTargetFlags>("targetFlags");

            if (targetFlags.HasAnyFlag(SpellCastTargetFlags.Unit | SpellCastTargetFlags.PvpCorpse | SpellCastTargetFlags.Object |
                SpellCastTargetFlags.Corpse | SpellCastTargetFlags.SpellDynamic4 | SpellCastTargetFlags.Item | SpellCastTargetFlags.TradeItem
                | SpellCastTargetFlags.SourceLocation | SpellCastTargetFlags.DestinationLocation))
            {
                var tGuid = ReadPackedWoWGuid("tGuid");
            }

            if (targetFlags.HasAnyFlag(SpellCastTargetFlags.SourceLocation | SpellCastTargetFlags.DestinationLocation))
            {
                var pos = ReadVector3("pos");
            }

            if (targetFlags.HasFlag(SpellCastTargetFlags.NameString))
            {
                var targetStr = ReadCString("targetStr");
            }

            if (flags.HasFlag(SpellCastFlags.CAST_FLAG_PREDICTED_POWER))
            {
                var runeCooldown = ReadInt32("runeCooldown");
            }

            if (flags.HasFlag(SpellCastFlags.CAST_FLAG_PREDICTED_RUNES))
            {
                var spellRuneState = ReadByte("spellRuneState");

                var playerRuneState = ReadByte("playerRuneState");

                for (var i = 0; i < 6; i++)
                {
                    var mask = 1 << i;
                    if ((mask & spellRuneState) == 0)
                        continue;

                    if ((mask & playerRuneState) != 0)
                        continue;

                    var unk = ReadByte("unk");
                }
            }

            if (OpcodeName == "SMSG_SPELL_GO")
            {
                if (flags.HasFlag(SpellCastFlags.CAST_FLAG_UNKNOWN15))
                {
                    var unk1 = ReadSingle("unk1");

                    var unk2 = ReadInt32("unk2");
                }
            }

            if (flags.HasFlag(SpellCastFlags.CAST_FLAG_AMMO))
            {
                var ammoDispId = ReadInt32("ammoDispId");

                var ammoInvType = ReadEnum<InventoryType>("ammoInvType", TypeCode.Int32);
            }

            if (OpcodeName == "SMSG_SPELL_GO")
            {
                if (flags.HasFlag(SpellCastFlags.CAST_FLAG_UNKNOWN17))
                {
                    var unk5 = ReadInt32("unk5");

                    var unk6 = ReadInt32("unk6");
                }
            }

            if (OpcodeName == "SMSG_SPELL_START")
            {
                if (flags.HasFlag(SpellCastFlags.CAST_FLAG_IMMUNITY))
                {
                    var unk4 = ReadInt32("unk4");

                    var unk5 = ReadInt32("unk5");
                }
            }

            if (OpcodeName == "SMSG_SPELL_GO")
            {

                if (targetFlags.HasFlag(SpellCastTargetFlags.DestinationLocation))
                {
                    var unkByte = ReadByte("unkByte");
                }

                if (targetFlags.HasFlag(SpellCastTargetFlags.ExtraTargets))
                {

                    var unkInt = ReadInt32("unkInt");

                    for (var i = 0; i < unkInt; i++)
                    {
                        var pos = ReadVector3("pos");

                        var guid = ReadPackedWoWGuid("guid");
                    }
                }
            }

            return Validate();
        }
    }

    public class SMSG_LEARNED_SPELL_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var spellId = ReadInt32("spellId");

            var unk = ReadInt16("unk");

            return Validate();
        }
    }

    public class CMSG_UPDATE_PROJECTILE_POSITION_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadPackedWoWGuid("guid");
            var spellId = ReadInt32("spellId");
            var castId = ReadByte("castId");
            var pos = ReadVector3("pos");

            return Validate();
        }
    }

    public class SMSG_SET_PROJECTILE_POSITION_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadPackedWoWGuid("guid");
            var castId = ReadByte("castId");
            var pos = ReadVector3("pos");

            return Validate();
        }
    }
}

