using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{

    public class CMSG_GAMEOBJECT_QUERY : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var entry = ReadInt32("entry");
            var guid = ReadPackedWoWGuid("guid");

            return Validate();
        }
    }

    public class CMSG_GAMEOBJ_USE : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadPackedWoWGuid("guid");
            return Validate();
        }
    }

    public class SMSG_DESTRUCTIBLE_BUILDING_DAMAGE : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var goguid = ReadPackedWoWGuid("goguid");
            var vehicleguid = ReadPackedWoWGuid("vehicleguid");
            var playerguid = ReadPackedWoWGuid("playerguid");
            var damage = ReadInt32("damage");
            var spellId = ReadInt32("spellId");

            return Validate();
        }
    }
}

