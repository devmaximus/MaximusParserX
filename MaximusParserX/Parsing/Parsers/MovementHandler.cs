using System;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{

    public class MovementInfoBaseDef : DefinitionBase
    {
        public MovementInfo ReadMovementInfo(WoWGuid guid)
        {
            var info = new MovementInfo();

            info.MoveFlag = ReadUInt32_MoveFlag("MoveFlag");
            info.MoveFlagExtra = ReadUInt16_MoveFlagExtra("MoveFlagExtra");
            info.TimeStamp = ReadUInt32("TimeStamp");
            info.PositionInfo = ReadVector4("PositionInfo");

            if (info.MoveFlag.Value.HasFlag(MoveFlag.OnTransport))
            {
                info.TransportInfo = ReadMovementTransport("OnTransport", info.MoveFlagExtra.Value.HasFlag(MoveFlagExtra.InterpolatedPlayerMovement));
            }

            if (info.MoveFlag.Value.HasAnyFlag(MoveFlag.Swimming | MoveFlag.Flying) ||
                info.MoveFlagExtra.Value.HasFlag(MoveFlagExtra.AlwaysAllowPitching))
            {
                info.SwimPitch = ReadSingle("SwimPitch");
            }

            info.FallTime = ReadUInt32("FallTime");

            if (info.MoveFlag.Value.HasFlag(MoveFlag.Falling))
            {
                info.FallInfo = ReadMovementFall("FallInfo");
            }

            if (info.MoveFlag.Value.HasFlag(MoveFlag.SplineElevation))
            {
                info.SplineElevation = ReadFloat("SplineElevation");
            }

            return info;
        }
    }

    public class SMSG_MONSTER_MOVE_DEF : SMSG_MONSTER_MOVE_TRANSPORT_DEF { }
    public class SMSG_MONSTER_MOVE_TRANSPORT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();
            var Stop = false;

            var guid = ReadPackedWoWGuid("guid");

            if (OpcodeName == "SMSG_MONSTER_MOVE_TRANSPORT")
            {
                var transguid = ReadPackedWoWGuid("transguid");

                var transseat = ReadByte("transseat");
            }

            if (ClientBuildAmount > 9767)
            {
                var unkByte = ReadBoolean("unkByte");
            }
            var pos = ReadVector3("pos");
            var curTime = ReadInt32("curTime");

            var type = (SplineType)ReadByte("SplineType");

            switch (type)
            {
                case SplineType.FacingSpot:
                    {
                        var spot = ReadVector3("spot");
                        break;
                    }
                case SplineType.FacingTarget:
                    {
                        var tguid = ReadPackedWoWGuid("tguid");
                        break;
                    }
                case SplineType.FacingAngle:
                    {
                        var angle = ReadSingle("angle");
                        break;
                    }
                case SplineType.Stop:
                    {
                        Stop = true;
                        break;
                    }
            }

            if (!Stop)
            {
                var flags = ReadInt32_SplineFlags("SplineFlags");

                if (flags.HasFlag(SplineFlag.Animation))
                {
                    var MoveAnimationState = ReadEnum<MoveAnimationState>("MoveAnimationState", TypeCode.Byte);
                    var unkInt1 = ReadInt32("unkInt1");
                }

                var time = ReadInt32("time");

                if (flags.HasFlag(SplineFlag.Trajectory))
                {
                    var unkFloat = ReadSingle("unkFloat");
                    var unkInt2 = ReadInt32("unkInt2");
                }

                var waypoints = ReadInt32("waypoints");
                var newpos = ReadVector3("newpos");

                //  Store.WriteData(Store.CreatureMovement.GetCommand(guid.Full, 0, newpos));
                if (flags.HasFlag(SplineFlag.Flying) || flags.HasFlag(SplineFlag.CatmullRom))
                {
                    for (var i = 0; i < waypoints - 1; i++)
                    {
                        var vec = ReadVector3("vec");
                    }
                }
                else
                {
                    var mid = new Vector3();

                    var X = (pos.X + newpos.X) * 0.5f;
                    var Y = (pos.Y + newpos.Y) * 0.5f;
                    var Z = (pos.Z + newpos.Z) * 0.5f;

                    for (var i = 0; i < waypoints - 1; i++)
                    {
                        var vec = ReadPackedVector3("PackedPosition");

                        var calcvec = new Vector3(vec.X - mid.X, vec.Y - mid.Y, vec.Z - mid.Z);
                    }
                }
            }
            return Validate();
        }
    }

    public class SMSG_NEW_WORLD_DEF : SMSG_LOGIN_VERIFY_WORLD_DEF { }
    public class SMSG_LOGIN_VERIFY_WORLD_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var mapid = ReadUInt32("MapID");
            var position = ReadVector4("Position");

            this.Core.SetCurrentPlayerMapID(mapid);
            this.Core.SetCurrentPlayerPosition(position);

            return Validate();
        }
    }

    public class SMSG_LOGIN_SETTIMESPEED_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var gameTime = ReadPackedTime("gameTime");
            var gameSpeed = ReadSingle("gameSpeed");
            var unk = ReadInt32("unk");

            return Validate();
        }
    }

    public class SMSG_BINDPOINTUPDATE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var pos = ReadVector3("pos");
            var mapId = ReadInt32("mapId");

            var zoneId = ReadInt32("zoneId");
            return Validate();
        }
    }

    public class MSG_MOVE_TELEPORT_ACK_DEF : MovementInfoBaseDef
    {
        public override bool Parse()
        {
            ResetPosition();

            if (Direction == Direction.ServerToClient)
            {
                var guid = ReadPackedWoWGuid("guid");

                var unk = ReadInt32("unk");

                var movementinfo = ReadMovementInfo(guid);
            }
            else
            {
                var guid = ReadPackedWoWGuid("guid");

                var MoveFlag = ReadEnum<MoveFlag>("MoveFlag");

                var time = ReadInt32("time");

            }
            return Validate();
        }
    }

    public class MSG_MOVE_START_FORWARD_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_BACKWARD_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_STOP_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_STRAFE_LEFT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_STRAFE_RIGHT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_STOP_STRAFE_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_JUMP_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_TURN_LEFT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_TURN_RIGHT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_STOP_TURN_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_PITCH_UP_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_PITCH_DOWN_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_STOP_PITCH_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_SET_RUN_MODE_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_SET_WALK_MODE_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_FALL_LAND_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_SWIM_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_STOP_SWIM_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_SET_FACING_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_SET_PITCH_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_HEARTBEAT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_MOVE_FALL_RESET_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_MOVE_SET_FLY_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_ASCEND_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_STOP_ASCEND_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_MOVE_CHNG_TRANSPORT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_START_DESCEND_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class MSG_MOVE_TELEPORT_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_MOVE_NOT_ACTIVE_MOVER_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_DISMISS_CONTROLLED_VEHICLE_DEF : MovementInfoBaseDef
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            var movementinfo = ReadMovementInfo(guid);

            return Validate();
        }
    }

    public class CMSG_FORCE_RUN_SPEED_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_SWIM_SPEED_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_WALK_SPEED_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_TURN_RATE_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_FLIGHT_SPEED_CHANGE_ACK_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class CMSG_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK_DEF : MovementInfoBaseDef
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            var unk1 = ReadInt32("unk1");

            ReadMovementInfo(guid);

            var newSpeed = ReadSingle("newSpeed");

            return Validate();
        }
    }

    public class SMSG_MOVE_UNKNOWN_1304_DEF : MovementInfoBaseDef
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            ReadMovementInfo(guid);

            var unk = ReadSingle("unk");

            return Validate();
        }
    }

    public class CMSG_SET_ACTIVE_MOVER_DEF : CMSG_DISMISS_CONTROLLED_VEHICLE_DEF { }
    public class SMSG_MOUNTSPECIAL_ANIM_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");
            return Validate();
        }
    }

    public class CMSG_SUMMON_RESPONSE_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var summonerGuid = ReadPackedWoWGuid("summonerGuid");

            var agree = ReadBoolean("agree");

            return Validate();
        }
    }

    public class SMSG_FORCE_MOVE_ROOT : SMSG_MOVE_LAND_WALK_DEF { }
    public class SMSG_FORCE_MOVE_UNROOT : SMSG_MOVE_LAND_WALK_DEF { }
    public class SMSG_MOVE_WATER_WALK : SMSG_MOVE_LAND_WALK_DEF { }
    public class SMSG_MOVE_UNKNOWN_1302 : SMSG_MOVE_LAND_WALK_DEF { }
    public class SMSG_MOVE_LAND_WALK_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            var unk = ReadInt32("unk");

            if (OpcodeName == "SMSG_MOVE_UNKNOWN_1302")
            {
                var fl = ReadSingle("fl");
            }

            return Validate();
        }
    }

    public class CMSG_MOVE_KNOCK_BACK_ACK_DEF : CMSG_MOVE_HOVER_ACK_DEF { }
    public class CMSG_MOVE_WATER_WALK_ACK_DEF : CMSG_MOVE_HOVER_ACK_DEF { }
    public class CMSG_MOVE_HOVER_ACK_DEF : MovementInfoBaseDef
    {
        public override bool Parse()
        {
            ResetPosition();

            var guid = ReadPackedWoWGuid("guid");

            var unk1 = ReadInt32("unk1");

            ReadMovementInfo(guid);

            if (OpcodeName != "CMSG_MOVE_KNOCK_BACK_ACK")
            {
                var unk2 = ReadInt32("unk2");
            }
            return Validate();
        }
    }

    public class SMSG_SET_PHASE_SHIFT_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var phasemask = ReadInt32("Phase Mask");
            Core.SetCurrentPlayerPhaseMask(phasemask);

            return Validate();
        }
    }

    public class SMSG_TRANSFER_PENDING_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            this.Core.SetPreviousPlayerMapID();

            var mapid = ReadUInt32("MapID");

            if (AvailableBytes > 0)
            {
                var TransportEntry = ReadUInt32("TransportEntry");
                var TransportMapID = ReadUInt32("TransportMapID");
            }

            this.Core.SetCurrentPlayerMapID(mapid);

            return Validate();
        }
    }

    public class SMSG_TRANSFER_ABORTED_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var mapid = ReadUInt32("MapID");
            var reason = ReadEnum<TransferAbortReason>("TransferAbortReason", TypeCode.Byte);

            switch (reason)
            {
                case TransferAbortReason.TRANSFER_ABORT_INSUF_EXPAN_LVL:
                case TransferAbortReason.TRANSFER_ABORT_DIFFICULTY:
                case TransferAbortReason.TRANSFER_ABORT_UNIQUE_MESSAGE:
                    var arg = ReadEnum<TransferAbortReason>("TransferAbortReasonArg", TypeCode.Byte);
                    break;
            }

            this.Core.ResetPlayerMapID();

            return Validate();
        }
    }

    public class SMSG_FLIGHT_SPLINE_SYNC_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            var val = ReadSingle("val");

            var guid = ReadPackedWoWGuid("guid");

            return Validate();
        }
    }

    public class SMSG_COMPRESSED_MOVES_DEF : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            int i = 0;

            while (AvailableBytes > 0)
            {
                i++;

                var size = ReadByte("[" + i + "] size");
 
                SetBookmarkPosition();

                GotoBookmarkPosition();

                var opcodefieldkey = "[" + i + "] opcode";

                var opcode = ReadUInt16(opcodefieldkey);

                var opcodename = ParsingHandler.GetOpcodeName(opcode, MaximusParserX.Direction.ServerToClient, ClientBuild);

                if (FieldLog.ContainsKey(opcodefieldkey)) FieldLog[opcodefieldkey] = string.Format("val: {0}, Name: {1}", FieldLog[opcodefieldkey], opcodename);

                var packet = new Packet(i, base.Context.TimeStamp.AddMilliseconds(i), MaximusParserX.Direction.ServerToClient, opcode, ReadBytes(size - 2), size - 2, ClientBuild);

                var context = new DefinitionContext(packet, base.Context.Reader, base.Core);

                var definition = ParsingHandler.GetDefinition(context, ClientBuild, opcodename, opcode);

                definition.Parse();
            }

            return Validate();
        }
    }
}
