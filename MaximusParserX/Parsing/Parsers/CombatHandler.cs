using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_AI_REACTION : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");
            var reaction = Read<AiReaction>("AiReaction");

            return Validate();
        }
    }

    public class SMSG_UPDATE_COMBO_POINTS : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");
            var amount = ReadByte("Combo Points");

            return Validate();
        }
    }
}

