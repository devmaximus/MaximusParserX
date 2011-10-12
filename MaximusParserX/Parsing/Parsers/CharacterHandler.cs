using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class CMSG_CHAR_CREATE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var name = ReadCString("name");

            var race = (Race)ReadByte();

            var chClass = (Class)ReadByte();

            var gender = (Gender)ReadByte();

            var skin = ReadByte("skin");

            var face = ReadByte("face");

            var hairStyle = ReadByte("hairStyle");

            var hairColor = ReadByte("hairColor");

            var facialHair = ReadByte("facialHair");

            var outfitId = ReadByte("outfitId");
            return Validate();
        }
    }

    public class CMSG_CHAR_DELETE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadWoWGuid("guid");
            return Validate();
        }
    }

    public class CMSG_CHAR_RENAME_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadWoWGuid("guid");

            var newName = ReadCString("newName");
            return Validate();
        }
    }

    public class SMSG_CHAR_RENAME_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var result = ReadEnum<ResponseCodes>("ResponseCodes", TypeCode.Byte);

            if (result == ResponseCodes.RESPONSE_SUCCESS)
            {
                var guid = ReadWoWGuid("guid");
                var name = ReadCString("name");
            }
            return Validate();
        }
    }

    public class SMSG_CHAR_CREATE_DEF : SMSG_CHAR_DELETE_DEF { }
    public class SMSG_CHAR_DELETE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var response = ReadEnum<ResponseCodes>("ResponseCodes");
            return Validate();
        }
    }

    public class CMSG_ALTER_APPEARANCE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var hairStyle = ReadByte("hairStyle");

            var hairColor = ReadByte("hairColor");

            var facialHair = ReadByte("facialHair");
            return Validate();
        }
    }

    //public class SMSG_BARBER_SHOP_RESULT_DEF : DefinitionBase
    //{
    //    public override bool Parse()
    //    {
    //        ResetPosition();
    //        var status = (BarberShopResult)ReadInt32();
    //        return Validate();
    //    }
    //}

    public class CMSG_CHAR_CUSTOMIZE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadWoWGuid("guid");

            var name = ReadCString("name");

            var gender = (Gender)ReadByte();

            var skin = ReadByte("skin");

            var face = ReadByte("face");

            var hairColor = ReadByte("hairColor");

            var hairStyle = ReadByte("hairStyle");

            var facialHair = ReadByte("facialHair");
            return Validate();
        }
    }

    public class SMSG_CHAR_CUSTOMIZE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var response = ReadEnum<ResponseCodes>("ResponseCode");

            if (response == ResponseCodes.RESPONSE_SUCCESS)
            {

                var guid = ReadWoWGuid("guid");

                var name = ReadCString("name");

                var gender = (Gender)ReadByte();

                var skin = ReadByte("skin");

                var face = ReadByte("face");

                var hairStyle = ReadByte("hairStyle");

                var hairColor = ReadByte("hairColor");

                var facialHair = ReadByte("facialHair");
            }
            return Validate();
        }
    }

    public class SMSG_CHAR_ENUM_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            Core.Cache.CharacterInfoCache.Clear();

            var count = ReadByte("count");

            for (var i = 0; i < count; i++)
            {
                var guid = ReadWoWGuid("guid");
                var name = ReadCString("name");
                var race = ReadEnum<Race>("Race");
                var clss = ReadEnum<Class>("Class");
                var gender = ReadEnum<Gender>("Gender");
                var skin = ReadByte("skin");
                var face = ReadByte("face");
                var hairStyle = ReadByte("hairStyle");
                var hairColor = ReadByte("hairColor");
                var facialHair = ReadByte("facialHair");
                var level = ReadByte("level");
                var zone = ReadInt32("zone");
                var mapId = ReadInt32("mapId");
                var pos = ReadVector3("pos");
                var guild = ReadInt32("guild");
                var flags = ReadEnum<CharacterFlags>("CharacterFlags");
                var customize = ReadEnum<CharacterCustomizeFlags>("CharacterCustomizeFlags");
                var firstLogin = ReadBoolean("firstLogin");
                var petDispId = ReadInt32("petDispId");
                var petLevel = ReadInt32("petLevel");
                var petFamily = ReadEnum<CreatureFamily>("CreatureFamily", TypeCode.Int32);

                var auracount = 19;

                for (var j = 0; j < auracount; j++)
                {
                    var dispId = ReadInt32(j, "dispId");
                    var invType = ReadEnum<InventoryType>(j, "invType");
                    var auraId = ReadInt32(j, "auraId");
                }

                var bagcount = 4;

                for (var j = 0; j < bagcount; j++)
                {
                    var bagDispId = ReadInt32(j, "bagDispId");

                    var bagInvType = ReadEnum<InventoryType>(j, "bagInvType");

                    var bagAuraId = ReadInt32(j, "bagAuraId");
                }

                if (firstLogin)
                {
                    var key = string.Format("{0}_{1}", race, clss);

                    if (!Core.Cache.StartInfoCache.ContainsKey(key))
                    {
                        var startInfo = new StartInfo();

                        startInfo.Race = race;
                        startInfo.Class = clss;
                        startInfo.Position = pos;
                        startInfo.Map = mapId;
                        startInfo.Zone = zone;

                        Core.Cache.AddStartInfoCache(startInfo);

                        //Store.WriteData(Store.StartPositions.GetCommand(race, clss, mapId, zone, pos));
                    }
                }

                var chInfo = new CharacterInfo();
                chInfo.Guid = guid;
                chInfo.Race = race;
                chInfo.Class = clss;
                chInfo.Name = name;
                chInfo.FirstLogin = firstLogin;
                chInfo.Level = level;
                Core.Cache.AddCharacterInfo(chInfo);


            }

            return Validate();
        }
    }
}

