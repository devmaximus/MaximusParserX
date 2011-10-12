using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW.CacheObjects
{
    public class PlayerName
    {
        public WoWGuid Guid { get; set; }
        public string Name { get; set; }
        public string BGRealm { get; set; }
        public byte Unk { get; set; }
        public Race Race { get; set; }
        public Gender Gender { get; set; }
        public Class Class { get; set; }
        public byte Declined { get; set; }
        public List<string> DeclinedNames = new List<string>();
    }
}
