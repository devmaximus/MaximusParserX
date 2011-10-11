using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{

    public class SMSG_INITIALIZE_FACTIONS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var flags = ReadInt32("flags");

            for (var i = 0; i < 128; i++)
            {
                var sFlags = ReadEnum<FactionFlags>("[" + i + "] FactionFlags");
                var sStand = ReadInt32("[" + i + "] sStand");
            }
            return Validate();
        }
    }
}

