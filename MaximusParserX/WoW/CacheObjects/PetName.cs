using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW.CacheObjects
{
    public class PetName
    {
        public UInt32 petnumber { get; set; }
        public string name { get; set; }
        public UInt32 time { get; set; }
        public byte extra { get; set; }
    }
}
