using System;

namespace MaximusParserX.WoW
{
    public class Player : Unit
    {
        public Player(Core core, WoWGuid guid, TypeID typeid)
            : base(core, guid, typeid)
        {

        }


        public override string Name
        {
            get
            {
                if (base.Name == null)
                {
                    CacheObjects.PlayerName info;

                    if (Core.Cache.PlayerNameCache.TryGetValue(Guid.Full, out info))
                    {
                        base.Name = info.Name;
                    }

                }

                return base.Name;
            }

            internal set
            {
                base.Name = value;
            }
        }
    }
}
