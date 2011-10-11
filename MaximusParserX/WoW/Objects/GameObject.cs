using System;

namespace MaximusParserX.WoW
{
    public class GameObject : ObjectBase
    {
        public Int32 PhaseMask { get; private set; }

        public UInt32 MapID { get; private set; }

        public GameObject(Core core, WoWGuid guid, TypeID typeid)
            : base(core, guid, typeid)
        {
            PhaseMask = core.CurrentPlayerPhaseMask;
            MapID = core.CurrentPlayerMapID;
        }

        ~GameObject()
        {
            Dump.SQL.GameObjectSpawnHandler.AddGameObjectSpawn(this);
        }
    }
}
