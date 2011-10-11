using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_ACHIEVEMENT_DELETED_DEF : SMSG_CRITERIA_DELETED_DEF { }
    public class SMSG_CRITERIA_DELETED_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var id = ReadInt32("id");
            return Validate();
        }
    }

    public class SMSG_SERVER_FIRST_ACHIEVEMENT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var name = ReadCString("name");
            var guid = ReadWoWGuid("guid");
            var achId = ReadInt32("achId");
            var linkName = ReadInt32("linkName");

            return Validate();
        }
    }

    public class SMSG_ACHIEVEMENT_EARNED_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");
            var achId = ReadInt32("achId");
            var time = ReadPackedTime("time");
            var unkInt = ReadInt32("unkInt");

            return Validate();
        }
    }

    public class SMSG_CRITERIA_UPDATE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var id = ReadInt32("id");
            var counter = ReadPackedWoWGuid("counter");
            var guid = ReadPackedWoWGuid("guid");
            var unk = ReadInt32("unk");
            var time = ReadPackedTime("time");

            for (var i = 0; i < 2; i++)
            {
                var timer = ReadInt32("timer");
            }

            return Validate();
        }
    }

    public class SMSG_ALL_ACHIEVEMENT_DATA_DEF : ReadAllAchievementDataDef
    {
        public override bool Parse()
        {
            ResetPosition();
            ReadAllAchievementData();
            return Validate();
        }
    }


    public class CMSG_QUERY_INSPECT_ACHIEVEMENTS_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            return Validate();
        }
    }

    public class SMSG_RESPOND_INSPECT_ACHIEVEMENTS_DEF : ReadAllAchievementDataDef
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");
            ReadAllAchievementData();

            return Validate();
        }
    }

    public class ReadAllAchievementDataDef : DefinitionBase
    {
        public void ReadAllAchievementData()
        {
            while (true)
            {
                var id = ReadInt32("id");

                if (id == -1)
                    break;

                var time = ReadPackedTime("time");
            }

            while (true)
            {
                var id = ReadInt32("id");

                if (id == -1)
                    break;

                var counter = ReadPackedWoWGuid("counter");
                var guid = ReadPackedWoWGuid("guid");
                var unk = ReadInt32("unk");
                var time = ReadPackedTime("time");

                for (var i = 0; i < 2; i++)
                {
                    var timer = ReadInt32("timer");
                }
            }
        }
    }
}



