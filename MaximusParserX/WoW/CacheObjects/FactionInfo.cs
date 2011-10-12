using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW.CacheObjects
{
    public class FactionInfo
    {
        public int Index;
        public FactionFlags Flags;
        public int Standing;

        public FactionInfo(int index, FactionFlags flags, int standing)
        {
            Index = index;
            Flags = flags;
            Standing = standing;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{0}: {1}", "Index", Index);
            sb.AppendLine("{0}: {1}", "Flags", Flags);
            sb.AppendLine("{0}: {1}", "Standing", Standing);
            return sb.ToString();
        }

    }
}
