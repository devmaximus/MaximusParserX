using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_TRAINER_LIST_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            var type = ReadEnum<TrainerType>("TrainerType", TypeCode.Int32);

            var count = ReadInt32("count");

            for (var i = 0; i < count; i++)
            {
                var spell = ReadInt32(i, "spell");
                var state = ReadEnum<TrainerSpellState>(i, "TrainerSpellState", TypeCode.Byte);
                var cost = ReadInt32(i, "cost");
                var profDialog = ReadBoolean(i, "profDialog");
                var profButton = ReadBoolean(i, "profButton");
                var reqLevel = ReadInt32(i, "reqLevel");
                var reqSkill = ReadInt32(i, "reqSkill");
                var reqSkLvl = ReadInt32(i, "reqSkLvl");
                var chainNode1 = ReadInt32(i, "chainNode1");
                var chainNode2 = ReadInt32(i, "chainNode2");
                var unk = ReadInt32(i, "unk");

                //TODO store TrainerSpells guid.GetEntry(), spell, cost, reqLevel, reqSkill, reqSkLvl 
            }

            var titleStr = ReadCString("titleStr");
            return Validate();
        }
    }
    public class SMSG_LIST_INVENTORY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            var itemCount = ReadByte("itemCount");

            for (var i = 0; i < itemCount; i++)
            {
                var position = ReadInt32(i, "position");
                var itemId = ReadInt32(i, "itemId");
                var dispid = ReadInt32(i, "dispid");
                var maxCount = ReadInt32(i, "maxCount");
                var price = ReadInt32(i, "price");
                var maxDura = ReadInt32(i, "maxDura");
                var buyCount = ReadInt32(i, "buyCount");
                var extendedCost = ReadInt32(i, "extendedCost");

                //TODO store VendorItems guid.GetEntry(), itemId, maxCount, extendedCost
            }
            return Validate();
        }

        public class CMSG_GOSSIP_HELLO_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class CMSG_TRAINER_LIST_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class CMSG_BATTLEMASTER_HELLO_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class CMSG_LIST_INVENTORY_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class MSG_TABARDVENDOR_ACTIVATE_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class CMSG_BANKER_ACTIVATE_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class CMSG_SPIRIT_HEALER_ACTIVATE_DEF : CMSG_BINDER_ACTIVATE_DEF { }
        public class CMSG_BINDER_ACTIVATE_DEF : DefinitionBase
        {
            public override bool Parse()
            {
                ResetPosition();
                var guid = ReadPackedWoWGuid("guid");
                return Validate();
            }
        }
    }
}

