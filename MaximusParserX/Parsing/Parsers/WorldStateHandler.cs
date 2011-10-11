using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{

    public class SMSG_INIT_WORLD_STATES_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var mapid = ReadUInt32("MapID");
            var zoneid = ReadUInt32("ZoneID");
            var areaid = ReadUInt32("AreaID");
            var blockcount = ReadUInt16("BlockCount");

            for (int i = 0; i < blockcount; i++)
            {
                var state = ReadUInt32("State");
                var value = ReadInt32("Value");
            }

            this.Core.SetCurrentPlayerMapID(mapid);

            return Validate();
        }
    }

    public class SMSG_UPDATE_WORLD_STATE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var fieldId = ReadInt32("fieldId");
            var fieldVal = ReadInt32("fieldVal");
            return Validate();
        }
    }

    public class SMSG_WORLD_STATE_UI_TIMER_UPDATE : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var time = ReadTime("time");
            return Validate();
  
        }
    }
}

