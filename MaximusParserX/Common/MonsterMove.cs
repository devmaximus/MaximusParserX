using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX;

namespace MaximusParserX
{
    public class MonsterMove
    {
        public ulong guid;

        public Vector3 PositionInfo;
        public UInt32 mstime;
        public byte type;
        public UInt32 moveTime;
        public UInt32 count;
        public MonsterMoveFlag MonsterMoveFlag;
        public byte unkb1;

        public float facing0;
        public float facing1;
        public float facing2;
        public float facing3;
        public UInt64 targetguid;

        public Vector3 BasePositionInfo;
        public float SomeX;

        public SortedList<int, MonsterMoveNode> PositionList;
        public SortedList<int, MonsterMoveNode> SubPositionList;

        public Vector3 transportpositionInfo;
        public ulong transportGuid;
        public byte seatPos;

        public class MonsterMoveNode
        {
            public Vector3 node;
            public float Vector;
            public string VectorType;
            public Int32 packedFloat;

            public float X
            {
                get
                {
                    return (float)((packedFloat & 0x7FF) << 21 >> 21) * 0.25f;
                }
            }

            public float Y
            {
                get
                {
                    return (float)((((packedFloat >> 11) & 0x7FF) << 21) >> 21) * 0.25f;
                }
            }

            public float Z
            {
                get
                {
                    return (float)((packedFloat >> 22 << 22) >> 22) * 0.25f;
                }
            }

        }
    }

   
}
