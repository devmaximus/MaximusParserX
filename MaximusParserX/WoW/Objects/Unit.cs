using System;
using System.Collections.Generic;

namespace MaximusParserX.WoW
{
    public class Unit : ObjectBase
    {
        public Int32 PhaseMask { get; set; }

        public Unit(Core core, WoWGuid guid, TypeID typeid)
            : base(core, guid, typeid)
        {
            PhaseMask = core.CurrentPlayerPhaseMask;
        }
    }
}


 