using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.WoW;
using MaximusParserX.Reading.Readers;

namespace MaximusParserX.Reading
{
    public class DefinitionContext
    {
        public DefinitionContext(Packet packet, ReaderBase reader, Core core)
        {
            Packet = packet;
            Reader = reader;
            Core = core;
        }

        public uint Opcode { get { return Packet.Opcode; } }
        public string OpcodeName { get { return Packet.OpcodeName; } }
        public Direction Direction { get { return Packet.Direction; } }
        public byte[] Data { get { return Packet.Data; } }
        public ClientBuild ClientBuild { get { return Reader.ClientBuild; } }
        public int ClientBuildAmount { get { return Reader.ClientBuildAmount; } }
        public string ClientBuildName { get { return Reader.ClientBuildName; } }
        public string AccountName { get { return Reader.AccountName; } }
 
        public Frame.Result Result { get { return Packet.Result; } set { Packet.Result = value; } }

        public DateTime TimeStamp { get { return Packet.TimeStamp; } }
        public ReaderBase Reader { get; private set; }
        public Core Core { get; private set; }
        private Packet Packet { get; set; }

        public DefinitionBase GetDefinition()
        {
            return MaximusParserX.Parsing.ParsingHandler.GetDefinition(this, this.ClientBuild, this.OpcodeName, this.Opcode);
        }



    }
}
