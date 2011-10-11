using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class MovementInfo
    {
        public WoWGuid Guid;
        public OBJECT_UPDATE_FLAGS UpdateFlags;

        public MoveFlag? MoveFlag;
        public MoveFlagExtra? MoveFlagExtra;
        public UInt32 TimeStamp;
        public UInt32 Unknown3;
        public Vector4 PositionInfo;
        public Vector4 PositionInfo_0x40;
        public UInt32 StartTime;

        public MovementTransport TransportInfo;
        public MovementJump JumpInfo;
        public MovementFall FallInfo;
        public SplineInfo SplineInfo;
        public SortedList<string, float> Speeds;

        public float SwimPitch;
        public UInt32 FallTime;
        public float  SplineElevation;
        public Int32 LowGuid;
        public Int32 HighGuid;
        public WoWGuid FullGuid;
        public UInt32 TransportTime;
        public Int32 VehicleId;
        public float FacingAdjustement;
        public Quaternion GameObjectRotation;

        public WoWGuid Guid_0x100;
        public Vector3 PositionInfo_0x100;
        public Vector4 PositionInfo_0x100_2;
        public float UnknownFloat_0x100;

        public MovementInfo()
        {
            PositionInfo = new Vector4();
            PositionInfo_0x40 = new Vector4();
            PositionInfo_0x100 = new Vector3();
            PositionInfo_0x100_2 = new Vector4();

            TransportInfo = new MovementTransport();
            JumpInfo = new MovementJump();
            FallInfo = new MovementFall();
            SplineInfo = new SplineInfo();
        }
    }
}
