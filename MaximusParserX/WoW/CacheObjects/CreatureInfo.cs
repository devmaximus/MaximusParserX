using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW.CacheObjects
{
    public class CreatureInfo
    {
        public uint Entry;

        public String Name;

        public String SubName;

        public String IconName;

        public CreatureTypeFlags TypeFlags;

        public CreatureType Type;

        public CreatureFamily Family;

        public CreatureRank Rank;

        public CreatureInfo(Dump.SQL.Custom.creature_template creature_template)
        {
            Entry = creature_template.entry.GetValueOrDefault();
            Name = creature_template.name;
            SubName = creature_template.subname;
            IconName = creature_template.iconname;
            TypeFlags = (CreatureTypeFlags)creature_template.flags_extra.GetValueOrDefault();
            Type = (CreatureType)creature_template.type.GetValueOrDefault();
            Family = (CreatureFamily)creature_template.family.GetValueOrDefault();
            Rank = (CreatureRank)creature_template.rank.GetValueOrDefault();
        }


    }
}
