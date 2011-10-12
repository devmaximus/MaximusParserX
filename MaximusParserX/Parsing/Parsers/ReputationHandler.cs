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

            var count = ReadInt32("count");

            Core.CurrentPlayer.FactionInfos.Clear();

            for (var i = 0; i < count; i++)
            {
                var flags = ReadEnum<FactionFlags>("[" + i + "] flags");
                var standing = ReadInt32("[" + i + "] standing");

                Core.CurrentPlayer.FactionInfos.Add(i, new WoW.CacheObjects.FactionInfo(i, flags, standing));
            }

            return Validate();
        }
    }
}

