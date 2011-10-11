using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    [Flags]
    public enum MonsterMoveFlag : uint
    {
        None = 0x00000000,
        Forward = 0x00000001,
        Backward = 0x00000002,
        StrafeLeft = 0x00000004,
        StrafeRight = 0x00000008,
        Left = 0x00000010,               // turn
        Right = 0x00000020,               // turn
        PitchUp = 0x00000040,
        PitchDown = 0x00000080,
        Teleport = 0x00000100,
        Teleport2 = 0x00000200,
        Levitating = 0x00000400,
        Unknown1 = 0x00000800,               // float+uint32
        Walk = 0x00001000,               // run2?
        Spline = 0x00002000,               // spline n*(float x,y,z)
        // 0x4000, 0x8000, 0x10000, 0x20000 run
        Spline2 = 0x00040000,               // spline n*(float x,y,z)
        Unknown2 = 0x00080000,               // used for flying mobs
        Unknown3 = 0x00100000,               // used for flying mobs
        Unknown4 = 0x00200000,               // uint8+uint32
        Unknown5 = 0x00400000,               // run in place, then teleport to final point
        Unknown6 = 0x00800000,               // teleport
        Unknown7 = 0x01000000,               // run
        Fly = 0x02000000,               // swimming/flying (depends on mob?)
        Unknown9 = 0x04000000,               // run
        Unknown10 = 0x08000000,               // run
        Unknown11 = 0x10000000,               // run
        Unknown12 = 0x20000000,               // run
        Unknown13 = 0x40000000,               // levitating

        // masks
        SplineFly = 0x00003000,               // fly by points
    }
}
