using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_ACTION_BUTTONS : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var talentSpec = ReadByte("talentSpec");

            for (var i = 0; i < 144; i++)
            {
                var packed = ReadInt32("packed");

                if (packed == 0)
                    continue;

                var action = packed & 0x00FFFFFF;

                var type = (ActionButtonType)((packed & 0xFF000000) >> 24);

                //var chr = SessionHandler.LoggedInCharacter;
                //if (!chr.FirstLogin)
                //    continue;

                //Store.WriteData(Store.StartActions.GetCommand(chr.Race, chr.Class, action, i, type));
            }
            return Validate();
        }

    }
}
 
