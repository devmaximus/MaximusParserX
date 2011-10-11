using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class SMSG_DESTROY_OBJECT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var guid = ReadWoWGuid("guid");
            Console.WriteLine("GUID: " + guid);

            var anim = ReadBoolean("anim");
            Console.WriteLine("Despawn Animation: " + anim);
            return Validate();
        }
    }

    public class SMSG_COMPRESSED_UPDATE_OBJECT_DEF : SMSG_UPDATE_OBJECT_DEF { }

    public class SMSG_UPDATE_OBJECT_DEF : DefinitionBase
    {
        public override bool Parse()
        {

#if DEBUG
            ResetPosition();

            //this.LogToFieldLog = true;
            //this.FieldLog.Clear();
            var savedposition = Position;

            Position = savedposition;
#endif
            try
            {
                var blockcount = ReadUInt32("blockcount");

                if (ClientBuildAmount < 9183)
                {
                    var unk1 = ReadByte("UnkByte");
                }

                for (int i = 0; i < blockcount; i++)
                {
                    var type = ReadByte_OBJECT_UPDATE_TYPE("[" + i + "] ObjUpdateType");

                    //if (i == 8)
                    //{
                    //    i = i;
                    //}
                    switch (type)
                    {
                        case OBJECT_UPDATE_TYPE.UPDATETYPE_VALUES:
                            {
                                var guid = ReadPackedWoWGuid("[" + i + "] UpdateValuesObjGuid");
                                var obj = Core.GetObjectByWoWGuid(guid);

                                UpdateFieldValues(i, obj);

                                if (obj == null)
                                {
                                    this.Result.AddError("[" + i + "] object not found with guid {0} during UpdateValues.", guid.Full);
                                }
                                else
                                {
                                    obj.ObjectUpdate(type);
                                }

                            } break;
                        case OBJECT_UPDATE_TYPE.UPDATETYPE_MOVEMENT:
                            {
                                var guid = ReadPackedWoWGuid("[" + i + "] UpdateMovementObjGuid");
                                var obj = Core.GetObjectByWoWGuid(guid);
                                UpdateMovement(i, obj.TypeID, guid);
                            } break;
                        case OBJECT_UPDATE_TYPE.UPDATETYPE_CREATE_OBJECT2:
                        case OBJECT_UPDATE_TYPE.UPDATETYPE_CREATE_OBJECT:
                            {
                                CreateObject(i, type);

                            } break;
                        case OBJECT_UPDATE_TYPE.UPDATETYPE_OUT_OF_RANGE_OBJECTS:
                            {
                                var count = ReadUInt32("count");
                                for (long j = 0; j < count; j++)
                                {
                                    var guid = ReadPackedWoWGuid("[" + i + "] OutOfRangeObjGuid [" + j + "]");
                                    Core.RemoveObjectByWoWGuid(guid);
                                }
                            } break;
                        case OBJECT_UPDATE_TYPE.UPDATETYPE_NEAR_OBJECTS:
                            {
                                var count = ReadUInt32("count");
                                for (long j = 0; j < count; j++)
                                {
                                    var guid = ReadPackedWoWGuid("[" + i + "] NearObjGuid [" + j + "]");
                                }
                            } break;
                        default:
                            {
                                throw new ApplicationException("[" + i + "] unknown updatetype " + type);
                            }
                    }
                }
            }
            catch (Exception exc)
            {
                this.Result.AddResult(exc);
            }

            return Validate();
        }

        private void CreateObject(int index, OBJECT_UPDATE_TYPE updatetype)
        {
#if DEBUG
            var savedposition = Position;

            Position = savedposition;
#endif
            var guid = ReadPackedWoWGuid("[" + index + "] guid");

            Core.RemoveObjectByWoWGuid(guid);

            var typeid = ReadEnum<TypeID>("[" + index + "] TypeID");
            var obj = Core.CreateOrGetObject(guid, typeid);

            UpdateMovement(index, obj, typeid);

            if (UpdateFieldValues(index, obj))
            {
                Core.AddOrUpdateObject(obj);

                obj.ObjectUpdate(updatetype);
            }
            else
            {
                throw new ApplicationException("UpdateFields failed. this is probebly corrupted packet.");
            }

        }

        private void UpdateFieldValues(int index, WoWGuid guid)
        {
            var obj = Core.GetObjectByWoWGuid(guid);
            UpdateFieldValues(index, obj);
        }

        private bool UpdateFieldValues(int index, ObjectBase obj)
        {
            var UpdateFieldBlockCount = ReadByte("[" + index + "] UpdateFieldBlockCount");

            var updateMask = new int[UpdateFieldBlockCount];
            for (var i = 0; i < UpdateFieldBlockCount; i++)
            {
                var blockIdx = ReadInt32("[" + index + "] blockIdx [" + i + "]");
                updateMask[i] = blockIdx;
            }

            var mask = new System.Collections.BitArray(updateMask);

            var max = 0u;

            if (obj != null)
            {
                max = MaximusParserX.Parsing.ParsingHandler.GetUpdateFieldMax(obj.TypeID, (ClientBuild)this.ClientBuildAmount);
            }

            var reached = 0;

            for (var i = 0; i < mask.Count; i++)
            {
                if (!mask[i])
                    continue;

                if (i > max) reached = i;

                var updatefield = ReadUpdateField("[" + index + "] UpdateField [" + i + "]");

                if (obj != null)
                    obj.UpdateFields[i] = updatefield;
            }

            if (reached > 0 && obj != null)
            {
                Console.WriteLine(MaximusParserX.Parsing.ParsingHandler.ValidateMaxUpdateFieldCount(reached, obj.TypeID, (ClientBuild)this.ClientBuildAmount));
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateMovement(int index, TypeID typeid, WoWGuid guid)
        {
            var obj = Core.GetObjectByWoWGuid(guid);
            UpdateMovement(index, obj, typeid);
        }

        private void UpdateMovement(int index, ObjectBase obj, TypeID typeid)
        {
#if DEBUG
            var savedposition = Position;

            Position = savedposition;
#endif
            if (obj.MovementInfo == null) obj.MovementInfo = new MovementInfo();

            if (ClientBuildAmount > 9551)
            {
                obj.MovementInfo.UpdateFlags = ReadUInt16_OBJECT_UPDATE_FLAGS("[" + index + "] UpdateFlags");
            }
            else
            {
                obj.MovementInfo.UpdateFlags = ReadByte_OBJECT_UPDATE_FLAGS("[" + index + "] UpdateFlags");
            }

            // 0x20
            if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_LIVING) != 0)
            {
                obj.MovementInfo.MoveFlag = ReadUInt32_MoveFlag("[" + index + "] MoveFlag");

                if (ClientBuildAmount >= 7561 && ClientBuildAmount < 9183)
                {
                    obj.MovementInfo.MoveFlagExtra = ReadByte_MoveFlagExtra("[" + index + "] MoveFlagExtra");   // unk 2.3.0
                }
                else if (ClientBuildAmount >= 9183)
                {
                    obj.MovementInfo.MoveFlagExtra = ReadUInt16_MoveFlagExtra("[" + index + "] MoveFlagExtra");
                }

                obj.MovementInfo.TimeStamp = ReadUInt32("[" + index + "] TimeStamp");

                obj.MovementInfo.PositionInfo = ReadVector4("[" + index + "] PositionInfo");

                if ((obj.MovementInfo.MoveFlag & MoveFlag.OnTransport) != 0)
                {
                    obj.MovementInfo.TransportInfo = ReadMovementTransport("[" + index + "] OnTransport", obj.MovementInfo.MoveFlagExtra.Value.HasFlag(MoveFlagExtra.InterpolatedPlayerMovement));
                }

                if (obj.MovementInfo.MoveFlag.Value.HasAnyFlag(MoveFlag.Swimming | MoveFlag.Flying) || obj.MovementInfo.MoveFlagExtra.Value.HasFlag(MoveFlagExtra.AlwaysAllowPitching))
                {
                    obj.MovementInfo.SwimPitch = ReadFloat("[" + index + "] SwimPitch");
                }

                obj.MovementInfo.FallTime = ReadUInt32("[" + index + "] FallTime");

                if (obj.MovementInfo.MoveFlag.Value.HasFlag(MoveFlag.Falling))
                {
                    obj.MovementInfo.JumpInfo = ReadMovementJump("[" + index + "] FallingJumpInfo");
                }

                if (obj.MovementInfo.MoveFlag.Value.HasFlag(MoveFlag.SplineElevation))
                {
                    obj.MovementInfo.SplineElevation = ReadFloat("[" + index + "] SplineElevation");
                }

                if (ClientBuildAmount >= 9183)
                    obj.MovementInfo.Speeds = new SortedList<string, float>(9);
                else
                    obj.MovementInfo.Speeds = new SortedList<string, float>(8);

                for (byte i = 0; i < obj.MovementInfo.Speeds.Capacity; ++i)
                    obj.MovementInfo.Speeds.Add(i.ToString(), ReadFloat(string.Format("[" + index + "] Speed [{0}]", i)));

                if (obj.MovementInfo.MoveFlag.Value.HasFlag(MoveFlag.SplineEnabled))
                {
                    obj.MovementInfo.SplineInfo.SplineFlags = ReadInt32_SplineFlags("[" + index + "] SplineFlags");

                    if (obj.MovementInfo.SplineInfo.SplineFlags.HasFlag(SplineFlag.FinalPoint))
                    {
                        obj.MovementInfo.SplineInfo.SplinePoint = ReadVector3("[" + index + "] SplinePoint");
                    }

                    if (obj.MovementInfo.SplineInfo.SplineFlags.HasFlag(SplineFlag.FinalTarget))
                    {
                        obj.MovementInfo.SplineInfo.SplineFinalTargetGuid = ReadInt64("[" + index + "] SplineFinalTargetGuid");
                    }

                    if (obj.MovementInfo.SplineInfo.SplineFlags.HasFlag(SplineFlag.FinalOrientation))
                    {
                        obj.MovementInfo.SplineInfo.SplineRotation = ReadFloat("[" + index + "] splineRotation");
                    }

                    if (obj.MovementInfo.SplineInfo.SplineFlags.HasFlag(SplineFlag.CatmullRom))
                    {
                        obj.MovementInfo.SplineInfo.SplineRotation = ReadFloat("[" + index + "] splineRotation");
                    }

                    obj.MovementInfo.SplineInfo.SplineCurTime = ReadUInt32("[" + index + "] splineCurTime");
                    obj.MovementInfo.SplineInfo.SplineFullTime = ReadUInt32("[" + index + "] splineFullTime");
                    obj.MovementInfo.SplineInfo.SplineUnk1 = ReadUInt32("[" + index + "] splineUnk1");

                    if (ClientBuildAmount >= 9767)
                    {

                        obj.MovementInfo.SplineInfo.SplineDurationMultiplier = ReadFloat("[" + index + "] splineDurationMultiplier");//3.1
                        obj.MovementInfo.SplineInfo.SplineUnitInterval = ReadFloat("[" + index + "] splineUnitInterval");//3.1
                        obj.MovementInfo.SplineInfo.SplineUnkFloat2 = ReadFloat("[" + index + "] splineUnkFloat2");//3.1
                        obj.MovementInfo.SplineInfo.SplineHeightTime = ReadUInt32("[" + index + "] splineHeightTime"); //3.1
                    }
                    else
                    {
                        if (obj.MovementInfo.SplineInfo.SplineFlags.HasFlag(SplineFlag.FinalOrientation))
                        {
                            obj.MovementInfo.SplineInfo.SplineUnkFloat2 = ReadFloat("[" + index + "] splineUnkFloat2");
                        }
                    }

                    obj.MovementInfo.SplineInfo.SplineCount = ReadUInt32("[" + index + "] splineCount");
                    obj.MovementInfo.SplineInfo.Splines = new SortedList<int, Vector3>();

                    for (int i = 0; i < obj.MovementInfo.SplineInfo.SplineCount; ++i)
                    {
                        obj.MovementInfo.SplineInfo.Splines.Add(i, ReadVector3(string.Format("[" + index + "] Spline [{0}]", i)));
                    }

                    if (ClientBuildAmount >= 9464)
                    {
                        obj.MovementInfo.SplineInfo.SplineMode = ReadByte_SplineMode("[" + index + "] SplineMode");  // added in 3.0.8
                    }

                    obj.MovementInfo.SplineInfo.SplineEndPoint = ReadVector3("[" + index + "] SplineEndPoint");
                }
            }
            else
            {
                // 0x100
                if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_POSITION) != 0)
                {
                    obj.MovementInfo.Guid_0x100 = ReadPackedWoWGuid("[" + index + "] Guid_0x100");
                    obj.MovementInfo.PositionInfo_0x100 = ReadVector3("[" + index + "] PositionInfo_0x100");
                    obj.MovementInfo.PositionInfo_0x100_2 = ReadVector4("[" + index + "] PositionInfo_0x100_2");
                    obj.MovementInfo.UnknownFloat_0x100 = ReadFloat("[" + index + "] UnknownFloat_0x100");
                }
                else
                {
                    // 0x40
                    if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_HAS_POSITION) != 0)
                    {
                        obj.MovementInfo.PositionInfo_0x40 = ReadVector4("[" + index + "] PositionInfo_0x40");
                    }
                }
            }

            if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_LOWGUID) != 0)
            {
                obj.MovementInfo.LowGuid = ReadInt32("[" + index + "] LowGuid");
            }

            if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_HIGHGUID) != 0)
            {
                obj.MovementInfo.HighGuid = ReadInt32("[" + index + "] HighGuid");
            }

            if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_HAS_TARGET) != 0)
            {
                obj.MovementInfo.FullGuid = ReadPackedWoWGuid("[" + index + "] FullGuid");
            }

            if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_TRANSPORT) != 0)
            {
                obj.MovementInfo.TransportTime = ReadUInt32("[" + index + "] TransportTime");
            }

            if (ClientBuildAmount >= 9183 && (obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_VEHICLE) != 0)
            {
                obj.MovementInfo.VehicleId = ReadInt32("[" + index + "] VehicleId");
                obj.MovementInfo.FacingAdjustement = ReadFloat("[" + index + "] FacingAdjustement");
            }

            if ((obj.MovementInfo.UpdateFlags & OBJECT_UPDATE_FLAGS.UPDATEFLAG_ROTATION) != 0)
            {
                obj.MovementInfo.GameObjectRotation = ReadPackedQuaternion("[" + index + "] GameObjectRotation");
            }
        }
    }
}


