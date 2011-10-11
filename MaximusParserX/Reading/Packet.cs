using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Frame;

namespace MaximusParserX.Reading
{
    public class Packet
    {
        public int Id { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public Direction Direction { get; private set; }
        public uint Opcode { get; private set; }
        public string OpcodeName { get; private set; }
        public byte[] Data { get; private set; }
        public ClientBuild ClientBuild { get; private set; }
        public int Size { get; private set; }
 
        public Frame.Result Result { get; set; }

        public IDictionary<string, object> FieldLog { get; set; }

        public Packet(int id, DateTime timestamp, Direction direction, uint opcode, byte[] data, int size, ClientBuild clientbuild)
        {
            Id = id;
            TimeStamp = timestamp;
            Direction = direction;
            Opcode = opcode;
            Data = data;
            Size = size;
            ClientBuild = clientbuild;
            OpcodeName = MaximusParserX.Parsing.ParsingHandler.GetOpcodeName(Opcode, Direction, ClientBuild);
            Result = new Frame.Result();
            FieldLog = new Dictionary<string, object>();
        }

    }
}
