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

            var type = (TrainerType)ReadInt32();

            var count = ReadInt32();

            for (var i = 0; i < count; i++)
            {
                var spell = ReadInt32();

                var state = (TrainerSpellState)ReadByte();

                var cost = ReadInt32();

                var profDialog = ReadBoolean();

                var profButton = ReadBoolean();

                var reqLevel = ReadInt32();

                var reqSkill = ReadInt32();

                var reqSkLvl = ReadInt32();

                var chainNode1 = ReadInt32();

                var chainNode2 = ReadInt32();

                var unk = ReadInt32();

                //Store.WriteData(Store.TrainerSpells.GetCommand(guid.GetEntry(), spell, cost, reqLevel,
                //    reqSkill, reqSkLvl));
            }

            var titleStr = ReadCString();
            return Validate();
        }
    }
    public class SMSG_LIST_INVENTORY_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadPackedWoWGuid("guid");

            var itemCount = ReadByte();

            for (var i = 0; i < itemCount; i++)
            {
                var position = ReadInt32("position");

                var itemId = ReadInt32();

                var dispid = ReadInt32();

                var maxCount = ReadInt32();

                var price = ReadInt32();

                var maxDura = ReadInt32();

                var buyCount = ReadInt32();

                var extendedCost = ReadInt32();

                //Store.WriteData(Store.VendorItems.GetCommand(guid.GetEntry(), itemId, maxCount,
                //    extendedCost));
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

