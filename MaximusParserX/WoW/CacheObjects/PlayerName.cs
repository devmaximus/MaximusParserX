using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW.CacheObjects
{
    public class PlayerName
    {
        public WoWGuid guid { get; set; }
        public string name { get; set; }
        public string bgrealm { get; set; }
        public byte unk { get; set; }
        public byte race { get; set; }
        public byte gender { get; set; }
        public byte class_ { get; set; }
        public byte declined { get; set; }
        public List<string> declinename = new List<string>();
    }
}
