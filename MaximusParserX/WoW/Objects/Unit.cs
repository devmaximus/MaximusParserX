using System;
using System.Collections.Generic;

namespace MaximusParserX.WoW
{
    public class Unit : ObjectBase
    {
        public IDictionary<int, CacheObjects.FactionInfo> FactionInfos { get; set; }

        public Int32 PhaseMask { get; set; }

        public Int32 Level { get; set; }

        public Unit(Core core, WoWGuid guid, TypeID typeid)
            : base(core, guid, typeid)
        {
            PhaseMask = core.CurrentPlayerPhaseMask;
            FactionInfos = new Dictionary<int, CacheObjects.FactionInfo>();
        }

        public override string Name
        {
            get
            {
                if (base.Name == null)
                {
                    if (UpdateFields == null) { return base.Name; }
                    CacheObjects.CreatureInfo info;
                    if (Core.Cache.CreatureInfoCache.TryGetValue(OBJECT_FIELD_ENTRY, out info))
                    {
                        if (info.SubName.HasValue())
                            base.Name = string.Format("{0} <{1}>", info.Name, info.SubName);
                        else
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


