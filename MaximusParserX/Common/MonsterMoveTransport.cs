using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class MonsterMoveTransport
    {
     
        public ulong guid;


        public ulong transportGuid;
        public byte seatPos;


        public Vector3 positionInfo;
        public UInt32 ServerTime;
        public byte type;
        public UInt32 count;
        public UInt32 flags;


        public Vector3 transportpositionInfo;

        public ulong targetGuid;

        public float targetRot;

        public byte byte_1;
        public UInt32 someMSTime;

        public UInt32 moveTime;
        public float float_1;
        public UInt32 UInt32_1;

        public SortedList<int, Vector3> positions;


        public Int32 packedFloat;

    }

}
