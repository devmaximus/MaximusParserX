using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class CMSG_ITEM_QUERY_SINGLE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var entry = ReadInt32("entry");
            return Validate();
        }
    }

    public class SMSG_UPDATE_ITEM_ENCHANTMENTS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            for (var i = 0; i < 4; i++)
            {
                var enchId = ReadInt32(i, "enchId");
            }
            return Validate();
        }
    }
}

