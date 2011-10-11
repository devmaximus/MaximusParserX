using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
  
    public class SMSG_RESET_FAILED_NOTIFY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var mapid = ReadUInt32("MapID");

            return Validate();
        }
    }

    public class SMSG_INSTANCE_RESET_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var mapid = ReadUInt32("MapID");

            return Validate();
        }
    }

    public class SMSG_RAID_INSTANCE_MESSAGE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var type = ReadEnum<InstanceResetWarningType>("Type");
            var mapid = ReadUInt32("MapID");
            if (mapid == 1581)
            {
                mapid = 1581;
            }
            var difficulty = Difficulty.DUNGEON_DIFFICULTY_NORMAL;
            if (ClientBuildAmount > 9551)
                difficulty = ReadEnum<Difficulty>("Difficulty");                             // difficulty
            var time = ReadUInt32("Instance Time");
            if (ClientBuildAmount > 9551 && type == InstanceResetWarningType.RAID_INSTANCE_WELCOME)
            {
                var a = ReadByte("RAID_INSTANCE_WELCOME field1");                                   // is your (1)
                var b = ReadByte("RAID_INSTANCE_WELCOME field2");                                   // is extended (1), ignored if prev field is 0
            }

            this.Core.SetCurrentPlayerMapID(mapid, difficulty);

            return Validate();
        }
    }
}
