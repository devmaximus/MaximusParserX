using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class NameQueryResponseInfo
    {
        public WoWGuid Guid { get; set; }
        public string Name { get; set; }
        public string BgRealm { get; set; }
        public UInt32 Race { get; set; }
        public UInt32 Gender { get; set; }
        public UInt32 Class { get; set; }
    }
}
