using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class SplineInfo
    {
        public SplineFlag SplineFlags;
        public Vector3 SplinePoint;
        public Int64 SplineFinalTargetGuid;
        public float SplineRotation;
        public UInt32 SplineCurTime;
        public UInt32 SplineFullTime;
        public UInt32 SplineUnk1;
        public float SplineDurationMultiplier;
        public float SplineUnitInterval;
        public float SplineUnkFloat2;
        public UInt32 SplineHeightTime;
        public UInt32 SplineCount;
        public SortedList<int, Vector3> Splines;
        public SplineMode SplineMode;  // added in 3.0.8
        public Vector3 SplineEndPoint;

        public SplineInfo()
        {
        }

    }
}
