using System;

namespace MaximusParserX.WoW
{
    public class DynamicObject : ObjectBase
    {
        public DynamicObject(Core core, WoWGuid guid, TypeID typeid)
            : base(core, guid, typeid)
        {
        }
    }
}
