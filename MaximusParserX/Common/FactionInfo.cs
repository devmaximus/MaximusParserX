using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class FactionInfo
    {
        public int index;
        public byte flags;
        public int standing;

        public FactionInfo(int index, byte flags, int standing)
        {
            this.index = index;
            this.flags = flags;
            this.standing = standing;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}: {1}","Index" , index));
            sb.AppendLine(string.Format("{0}: {1}", "flags", flags));
            sb.AppendLine(string.Format("{0}: {1}", "standing", standing));
            return sb.ToString();
        }

    }
}
