using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_ACCOUNT_DATA_TIMES_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var unkTime = ReadTime("unkTime");
            var unkByte = ReadByte("unkByte");
            var mask = ReadInt32("mask");
            for (var i = 0; i < 8; i++)
            {
                if ((mask & (1 << i)) == 0)
                    continue;

                var unkTime2 = ReadInt32("[" + i + "] unkTime2");
            }

            return Validate();
        }
    }

    public class CMSG_REQUEST_ACCOUNT_DATA_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var type = ReadEnum<AccountDataType>("type");
            return Validate();
        }
    }

    public class CMSG_UPDATE_ACCOUNT_DATA_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var type = ReadEnum<AccountDataType>("type");
            var unkTime = ReadTime("unkTime");
            var decompCount = ReadInt32("decompCount");
            var reader = Inflate(decompCount);
            var data = reader.ReadBytes(decompCount);
            return Validate();
        }
    }

    public class SMSG_UPDATE_ACCOUNT_DATA_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadWoWGuid("guid");
            var type = ReadEnum<AccountDataType>("type");
            var unkTime = ReadTime("unkTime");
            var decompCount = ReadInt32("decompCount");
            var reader = Inflate(decompCount);
            var data = reader.ReadBytes(decompCount);
            return Validate();
        }
    }

    public class SMSG_UPDATE_ACCOUNT_DATA_COMPLETE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var type = ReadEnum<AccountDataType>("type");
            var unkInt = ReadInt32("unkInt");
            return Validate();
        }
    }
}