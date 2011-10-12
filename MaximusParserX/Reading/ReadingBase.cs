using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace MaximusParserX.Reading
{
    public class ReadingBase : System.IO.BinaryReader
    {
        public ReadingBase()
            : base(new System.IO.MemoryStream())
        {
            this.FieldLog = new Dictionary<string, object>();
            LogToFieldLog = false;
        }

        public ReadingBase(byte[] bytes)
            : base(new System.IO.MemoryStream(bytes))
        {
            this.FieldLog = new Dictionary<string, object>();
            LogToFieldLog = false;
        }

        public ReadingBase(System.IO.Stream stream)
            : base(stream)
        {
            this.FieldLog = new Dictionary<string, object>();
            LogToFieldLog = false;
        }

        private long bookmarkPosition = 0;

        private bool logtofieldlog = false;
        public bool LogToFieldLog
        {
            get
            {
                return logtofieldlog;
            }
            set
            {
                logtofieldlog = value; FieldLog.Clear();
            }
        }
        public long Position
        {
            get
            {
                return this.BaseStream.Position;
            }
        }

        public void Load(byte[] data)
        {
            base.BaseStream.Write(data, 0, data.Length);
        }

        public IDictionary<string, object> FieldLog { get; set; }

        public long AvailableBytes
        {
            get
            {
                return this.BaseStream.Length - Position;
            }
        }

        public long TotalBytes
        {
            get
            {
                return this.BaseStream.Length;
            }
        }

        public void SetBookmarkPosition()
        {
            this.bookmarkPosition = Position;
        }

        public void GotoBookmarkPosition()
        {
            this.BaseStream.Position = this.bookmarkPosition;
        }

        public void ResetPosition()
        {
            this.BaseStream.Position = 0;
        }

        public void SetPosition(long position)
        {
            this.BaseStream.Position = position;
        }

        public void MarkAsRead()
        {
            this.BaseStream.Position = TotalBytes;
        }

        public string FormatFieldName(int index, string name)
        {
            return string.Format("[{0}] {1}", index, name);
        }

        public string FormatFieldName(int index, int index2, string name)
        {
            return string.Format("[{0}] {1} [{2}]", index, name, index2);
        }

        public byte ReadByte(int index, string name)
        {
            return ReadByte(FormatFieldName(index, name));
        }

        public byte ReadByte(int index, int index2, string name)
        {
            return ReadByte(FormatFieldName(index, index2, name));
        }

        public byte ReadByte(string name)
        {
            var val = ReadByte();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public bool ReadBoolean(int index, string name)
        {
            return ReadBoolean(FormatFieldName(index, name));
        }

        public bool ReadBoolean(int index, int index2, string name)
        {
            return ReadBoolean(FormatFieldName(index, index2, name));
        }

        public bool ReadBoolean(string name)
        {
            var val = ReadBoolean();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public decimal ReadDecimal(int index, string name)
        {
            return ReadDecimal(FormatFieldName(index, name));
        }

        public decimal ReadDecimal(int index, int index2, string name)
        {
            return ReadDecimal(FormatFieldName(index, index2, name));
        }

        public decimal ReadDecimal(string name)
        {
            var val = ReadDecimal();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public double ReadDouble(int index, string name)
        {
            return ReadDouble(FormatFieldName(index, name));
        }

        public double ReadDouble(int index, int index2, string name)
        {
            return ReadDouble(FormatFieldName(index, index2, name));
        }

        public double ReadDouble(string name)
        {
            var val = ReadDouble();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public short ReadInt16(int index, string name)
        {
            return ReadInt16(FormatFieldName(index, name));
        }

        public short ReadInt16(int index, int index2, string name)
        {
            return ReadInt16(FormatFieldName(index, index2, name));
        }

        public short ReadInt16(string name)
        {
            var val = ReadInt16();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public int ReadInt32(int index, string name)
        {
            return ReadInt32(FormatFieldName(index, name));
        }

        public int ReadInt32(int index, int index2, string name)
        {
            return ReadInt32(FormatFieldName(index, index2, name));
        }

        public int ReadInt32(string name)
        {
            var val = ReadInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public uint ReadUInt(int index, string name)
        {
            return ReadUInt(FormatFieldName(index, name));
        }

        public uint ReadUInt(int index, int index2, string name)
        {
            return ReadUInt(FormatFieldName(index, index2, name));
        }

        public uint ReadUInt(string name)
        {
            var val = ReadUInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public int ReadInt(int index, string name)
        {
            return ReadInt(FormatFieldName(index, name));
        }

        public int ReadInt(int index, int index2, string name)
        {
            return ReadInt(FormatFieldName(index, index2, name));
        }

        public int ReadInt(string name)
        {
            var val = ReadInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public float ReadFloat(int index, string name)
        {
            return ReadFloat(FormatFieldName(index, name));
        }

        public float ReadFloat(int index, int index2, string name)
        {
            return ReadFloat(FormatFieldName(index, index2, name));
        }

        public float ReadFloat(string name)
        {
            var val = ReadSingle();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public long ReadInt64(int index, string name)
        {
            return ReadInt64(FormatFieldName(index, name));
        }

        public long ReadInt64(int index, int index2, string name)
        {
            return ReadInt64(FormatFieldName(index, index2, name));
        }

        public long ReadInt64(string name)
        {
            var val = ReadInt64();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public sbyte ReadSByte(int index, string name)
        {
            return ReadSByte(FormatFieldName(index, name));
        }

        public sbyte ReadSByte(int index, int index2, string name)
        {
            return ReadSByte(FormatFieldName(index, index2, name));
        }

        public sbyte ReadSByte(string name)
        {
            var val = ReadSByte();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public float ReadSingle(int index, string name)
        {
            return ReadSingle(FormatFieldName(index, name));
        }

        public float ReadSingle(int index, int index2, string name)
        {
            return ReadSingle(FormatFieldName(index, index2, name));
        }

        public float ReadSingle(string name)
        {
            var val = ReadSingle();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public ushort ReadUInt16(int index, string name)
        {
            return ReadUInt16(FormatFieldName(index, name));
        }

        public ushort ReadUInt16(int index, int index2, string name)
        {
            return ReadUInt16(FormatFieldName(index, index2, name));
        }

        public ushort ReadUInt16(string name)
        {
            var val = ReadUInt16();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        private KeyValuePair<long, T> ReadEnum<T>(TypeCode code)
        {
            var type = typeof(T);
            object value = null;
            long rawVal = 0;

            if (code == TypeCode.Empty)
                code = Type.GetTypeCode(type.GetEnumUnderlyingType());

            switch (code)
            {
                case TypeCode.SByte:
                    rawVal = ReadSByte();
                    break;
                case TypeCode.Byte:
                    rawVal = ReadByte();
                    break;
                case TypeCode.Int16:
                    rawVal = ReadInt16();
                    break;
                case TypeCode.UInt16:
                    rawVal = ReadUInt16();
                    break;
                case TypeCode.Int32:
                    rawVal = ReadInt32();
                    break;
                case TypeCode.UInt32:
                    rawVal = ReadUInt32();
                    break;
                case TypeCode.Int64:
                    rawVal = ReadInt64();
                    break;
                case TypeCode.UInt64:
                    rawVal = (long)ReadUInt64();
                    break;
            }
            value = System.Enum.ToObject(type, rawVal);

            return new KeyValuePair<long, T>(rawVal, (T)value);
        }

        public T ReadEnum<T>(int index, string name, TypeCode code = TypeCode.Empty)
        {
            return ReadEnum<T>(FormatFieldName(index, name), code);
        }

        public T ReadEnum<T>(int index, int index2, string name, TypeCode code = TypeCode.Empty)
        {
            return ReadEnum<T>(FormatFieldName(index, index2, name), code);
        }

        public T ReadEnum<T>(string name, TypeCode code = TypeCode.Empty)
        {
            KeyValuePair<long, T> val = ReadEnum<T>(code);
            if (CanLogField(name)) FieldLog[name] = val.Value;
            return val.Value;
        }


        public OBJECT_UPDATE_TYPE ReadByte_OBJECT_UPDATE_TYPE(int index, string name)
        {
            return ReadByte_OBJECT_UPDATE_TYPE(FormatFieldName(index, name));
        }

        public OBJECT_UPDATE_TYPE ReadByte_OBJECT_UPDATE_TYPE(int index, int index2, string name)
        {
            return ReadByte_OBJECT_UPDATE_TYPE(FormatFieldName(index, index2, name));
        }

        public OBJECT_UPDATE_TYPE ReadByte_OBJECT_UPDATE_TYPE(string name)
        {
            var val = (OBJECT_UPDATE_TYPE)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public SplineMode ReadByte_SplineMode(int index, string name)
        {
            return ReadByte_SplineMode(FormatFieldName(index, name));
        }

        public SplineMode ReadByte_SplineMode(int index, int index2, string name)
        {
            return ReadByte_SplineMode(FormatFieldName(index, index2, name));
        }

        public SplineMode ReadByte_SplineMode(string name)
        {
            var val = (SplineMode)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public OBJECT_UPDATE_FLAGS ReadUInt16_OBJECT_UPDATE_FLAGS(int index, string name)
        {
            return ReadUInt16_OBJECT_UPDATE_FLAGS(FormatFieldName(index, name));
        }

        public OBJECT_UPDATE_FLAGS ReadUInt16_OBJECT_UPDATE_FLAGS(int index, int index2, string name)
        {
            return ReadUInt16_OBJECT_UPDATE_FLAGS(FormatFieldName(index, index2, name));
        }

        public OBJECT_UPDATE_FLAGS ReadUInt16_OBJECT_UPDATE_FLAGS(string name)
        {
            var val = (OBJECT_UPDATE_FLAGS)ReadUInt16();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public SplineFlag ReadInt32_SplineFlags(int index, string name)
        {
            return ReadInt32_SplineFlags(FormatFieldName(index, name));
        }

        public SplineFlag ReadInt32_SplineFlags(int index, int index2, string name)
        {
            return ReadInt32_SplineFlags(FormatFieldName(index, index2, name));
        }

        public SplineFlag ReadInt32_SplineFlags(string name)
        {
            var val = (SplineFlag)ReadInt32();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (Int32)val, val.ToString());
            return val;
        }


        public OBJECT_UPDATE_FLAGS ReadByte_OBJECT_UPDATE_FLAGS(int index, string name)
        {
            return ReadByte_OBJECT_UPDATE_FLAGS(FormatFieldName(index, name));
        }

        public OBJECT_UPDATE_FLAGS ReadByte_OBJECT_UPDATE_FLAGS(int index, int index2, string name)
        {
            return ReadByte_OBJECT_UPDATE_FLAGS(FormatFieldName(index, index2, name));
        }

        public OBJECT_UPDATE_FLAGS ReadByte_OBJECT_UPDATE_FLAGS(string name)
        {
            var val = (OBJECT_UPDATE_FLAGS)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public uint ReadUInt32(int index, string name)
        {
            return ReadUInt32(FormatFieldName(index, name));
        }

        public uint ReadUInt32(int index, int index2, string name)
        {
            return ReadUInt32(FormatFieldName(index, index2, name));
        }

        public uint ReadUInt32(string name)
        {
            var val = ReadUInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public MoveFlag ReadUInt32_MoveFlag(int index, string name)
        {
            return ReadUInt32_MoveFlag(FormatFieldName(index, name));
        }

        public MoveFlag ReadUInt32_MoveFlag(int index, int index2, string name)
        {
            return ReadUInt32_MoveFlag(FormatFieldName(index, index2, name));
        }

        public MoveFlag ReadUInt32_MoveFlag(string name)
        {
            var val = (MoveFlag)ReadUInt32();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (UInt32)val, val.ToString());
            return val;
        }

        public MoveFlagExtra ReadByte_MoveFlagExtra(int index, string name)
        {
            return ReadByte_MoveFlagExtra(FormatFieldName(index, name));
        }

        public MoveFlagExtra ReadByte_MoveFlagExtra(int index, int index2, string name)
        {
            return ReadByte_MoveFlagExtra(FormatFieldName(index, index2, name));
        }

        public MoveFlagExtra ReadByte_MoveFlagExtra(string name)
        {
            var val = (MoveFlagExtra)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public MoveFlagExtra ReadUInt16_MoveFlagExtra(int index, string name)
        {
            return ReadUInt16_MoveFlagExtra(FormatFieldName(index, name));
        }

        public MoveFlagExtra ReadUInt16_MoveFlagExtra(int index, int index2, string name)
        {
            return ReadUInt16_MoveFlagExtra(FormatFieldName(index, index2, name));
        }

        public MoveFlagExtra ReadUInt16_MoveFlagExtra(string name)
        {
            var val = (MoveFlagExtra)ReadUInt16();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (ushort)val, val.ToString());
            return val;
        }

        public ulong ReadUInt64(int index, string name)
        {
            return ReadUInt64(FormatFieldName(index, name));
        }

        public ulong ReadUInt64(int index, int index2, string name)
        {
            return ReadUInt64(FormatFieldName(index, index2, name));
        }

        public ulong ReadUInt64(string name)
        {
            var val = ReadUInt64();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public WoWGuid ReadPackedWoWGuid(int index, string name)
        {
            return ReadPackedWoWGuid(FormatFieldName(index, name));
        }

        public WoWGuid ReadPackedWoWGuid(int index, int index2, string name)
        {
            return ReadPackedWoWGuid(FormatFieldName(index, index2, name));
        }

        public WoWGuid ReadPackedWoWGuid(string name)
        {
            var val = this.ReadPackedWoWGuid();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public WoWGuid ReadWoWGuid(int index, string name)
        {
            return ReadWoWGuid(FormatFieldName(index, name));
        }

        public WoWGuid ReadWoWGuid(int index, int index2, string name)
        {
            return ReadWoWGuid(FormatFieldName(index, index2, name));
        }

        public WoWGuid ReadWoWGuid(string name)
        {
            var val = this.ReadWoWGuid();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public Vector2 ReadVector2()
        {
            return ReadVector2(null);
        }

        public Vector2 ReadVector2(int index, string name)
        {
            return ReadVector2(FormatFieldName(index, name));
        }

        public Vector2 ReadVector2(int index, int index2, string name)
        {
            return ReadVector2(FormatFieldName(index, index2, name));
        }

        public Vector2 ReadVector2(string name)
        {
            var t = new Vector2(this);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public Vector3 ReadVector3()
        {
            return ReadVector3(null);
        }

        public Vector3 ReadVector3(int index, string name)
        {
            return ReadVector3(FormatFieldName(index, name));
        }

        public Vector3 ReadVector3(int index, int index2, string name)
        {
            return ReadVector3(FormatFieldName(index, index2, name));
        }

        public Vector3 ReadVector3(string name)
        {
            var t = new Vector3(this);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public Vector4 ReadVector4()
        {
            return ReadVector4(null);
        }

        public Vector4 ReadVector4(int index, string name)
        {
            return ReadVector4(FormatFieldName(index, name));
        }

        public Vector4 ReadVector4(int index, int index2, string name)
        {
            return ReadVector4(FormatFieldName(index, index2, name));
        }

        public Vector4 ReadVector4(string name)
        {
            var t = new Vector4(this);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public MovementJump ReadMovementJump()
        {
            return ReadMovementJump(null);
        }

        public MovementJump ReadMovementJump(int index, string name)
        {
            return ReadMovementJump(FormatFieldName(index, name));
        }

        public MovementJump ReadMovementJump(int index, int index2, string name)
        {
            return ReadMovementJump(FormatFieldName(index, index2, name));
        }

        public MovementJump ReadMovementJump(string name)
        {
            var t = new MovementJump(this);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public MovementFall ReadMovementFall()
        {
            return ReadMovementFall(null);
        }

        public MovementFall ReadMovementFall(int index, string name)
        {
            return ReadMovementFall(FormatFieldName(index, name));
        }

        public MovementFall ReadMovementFall(int index, int index2, string name)
        {
            return ReadMovementFall(FormatFieldName(index, index2, name));
        }

        public MovementFall ReadMovementFall(string name)
        {
            var t = new MovementFall(this);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public MovementTransport ReadMovementTransport(int index, string name, bool readTime2)
        {
            return ReadMovementTransport(FormatFieldName(index, name), readTime2);
        }

        public MovementTransport ReadMovementTransport(int index, int index2, string name, bool readTime2)
        {
            return ReadMovementTransport(FormatFieldName(index, index2, name), readTime2);
        }

        public MovementTransport ReadMovementTransport(bool readTime2)
        {
            return ReadMovementTransport(null, readTime2);
        }

        public MovementTransport ReadMovementTransport(string name, bool readTime2)
        {
            var t = new MovementTransport(this, this.ClientBuildAmount, readTime2);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public DateTime ReadTime()
        {
            return ReadTime(null);
        }

        public DateTime ReadTime(int index, string name)
        {
            return ReadTime(FormatFieldName(index, name));
        }

        public DateTime ReadTime(int index, int index2, string name)
        {
            return ReadTime(FormatFieldName(index, index2, name));
        }

        public DateTime ReadTime(string name)
        {
            var val = ReadInt32();
            var t = val.GetDateTimeFromUnixTime();
            if (CanLogField(name))
            {
                FieldLog[name] = string.Format("val Int32: {0}{1}DateTime: {3}", val, Environment.NewLine, t);
            }
            return t;
        }

        public DateTime ReadPackedTime()
        {
            return ReadPackedTime(null);
        }

        public DateTime ReadPackedTime(int index, string name)
        {
            return ReadPackedTime(FormatFieldName(index, name));
        }

        public DateTime ReadPackedTime(int index, int index2, string name)
        {
            return ReadPackedTime(FormatFieldName(index, index2, name));
        }

        public DateTime ReadPackedTime(string name)
        {
            var val = ReadInt32();
            var t = val.GetDateTimeFromGameTime();
            if (CanLogField(name))
            {
                FieldLog[name] = string.Format("packed Int32: {0}{1}DateTime: {3}", val, Environment.NewLine, t);
            }
            return t;
        }

        public DateTime ReadMillisecondTime()
        {
            return ReadMillisecondTime(null);
        }

        public DateTime ReadMillisecondTime(int index, string name)
        {
            return ReadMillisecondTime(FormatFieldName(index, name));
        }

        public DateTime ReadMillisecondTime(int index, int index2, string name)
        {
            return ReadMillisecondTime(FormatFieldName(index, index2, name));
        }

        public DateTime ReadMillisecondTime(string name)
        {
            var val = ReadInt32() / 1000;
            var t = val.GetDateTimeFromUnixTime();
            if (CanLogField(name))
            {
                FieldLog[name] = string.Format("var Int32: {0}{1}MillisecondTime: {3}", val, Environment.NewLine, t);
            }
            return t;
        }

        public Vector3 ReadPackedVector3()
        {
            return ReadPackedVector3(null);
        }

        public Vector3 ReadPackedVector3(int index, string name)
        {
            return ReadPackedVector3(FormatFieldName(index, name));
        }

        public Vector3 ReadPackedVector3(int index, int index2, string name)
        {
            return ReadPackedVector3(FormatFieldName(index, index2, name));
        }

        public Vector3 ReadPackedVector3(string name)
        {
            var packed = ReadInt32();
            var x = ((packed & 0x7FF) << 21 >> 21) * 0.25f;
            var y = ((((packed >> 11) & 0x7FF) << 21) >> 21) * 0.25f;
            var z = ((packed >> 22 << 22) >> 22) * 0.25f;
            var t = new Vector3(x, y, z);
            if (CanLogField(name))
            {
                FieldLog[name] = t.ToString();
            }
            return t;
        }

        public Quaternion ReadPackedQuaternion()
        {
            return ReadPackedQuaternion(null);
        }

        public Quaternion ReadPackedQuaternion(int index, string name)
        {
            return ReadPackedQuaternion(FormatFieldName(index, name));
        }

        public Quaternion ReadPackedQuaternion(int index, int index2, string name)
        {
            return ReadPackedQuaternion(FormatFieldName(index, index2, name));
        }

        public Quaternion ReadPackedQuaternion(string name)
        {
            var packed = ReadInt64();
            var x = (packed >> 42) * (1.0f / 2097152.0f);
            var y = (((packed << 22) >> 32) >> 11) * (1.0f / 1048576.0f);
            var z = (packed << 43 >> 43) * (1.0f / 1048576.0f);

            var w = x * x + y * y + z * z;
            if (Math.Abs(w - 1.0f) >= (1 / 1048576.0f))
                w = (float)Math.Sqrt(1.0f - w);
            else
                w = 0.0f;

            var t = new Quaternion(x, y, z, w);

            if (CanLogField(name))
            {
                FieldLog[name] = string.Format("packed Int64: {0}", packed) + Environment.NewLine + t.ToString();
            }

            return t;
        }

        public string ReadString(uint length)
        {
            return ReadString(null, (int)length);
        }

        public string ReadString(string name, uint length)
        {
            return ReadString(name, (int)length);
        }

        public string ReadString(int length)
        {
            return ReadString(null, length);
        }

        public string ReadString(string name, int length)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                byte b = ReadByte();
                if (b != 0)
                {
                    sb.Append(char.ConvertFromUtf32((int)b));
                }
            }
            var t = sb.ToString();
            if (CanLogField(name))
                FieldLog[name] = t;
            return t;
        }

        public UpdateField ReadUpdateField()
        {
            return ReadUpdateField(null);
        }

        public UpdateField ReadUpdateField(int index, string name)
        {
            return ReadUpdateField(FormatFieldName(index, name));
        }

        public UpdateField ReadUpdateField(int index, int index2, string name)
        {
            return ReadUpdateField(FormatFieldName(index, index2, name));
        }

        public UpdateField ReadUpdateField(string name)
        {
            var pos = Position;
            var svalue = ReadInt32();
            SetPosition(pos);
            var fvalue = ReadSingle();
            var field = new UpdateField(svalue, fvalue);
            if (CanLogField(name)) FieldLog[name] = field.ToString();
            return field;
        }

        public string ReadCString()
        {
            return ReadCString(Encoding.UTF8);
        }

        public string ReadCString(int index, string name)
        {
            return ReadCString(FormatFieldName(index, name));
        }

        public string ReadCString(int index, int index2, string name)
        {
            return ReadCString(FormatFieldName(index, index2, name));
        }

        public string ReadCString(string name)
        {
            return ReadCString(name, Encoding.UTF8);
        }

        public string ReadCString(Encoding encoding)
        {
            return ReadCString(null, encoding);
        }

        public string ReadCString(string name, Encoding encoding)
        {
            var bytes = new List<byte>();

            byte b;
            while ((b = ReadByte()) != 0)
                bytes.Add(b);

            var t = encoding.GetString(bytes.ToArray());
            if (CanLogField(name))
                FieldLog[name] = t;
            return t;
        }

        public System.Net.IPAddress ReadIPAddress()
        {
            return ReadIPAddress(null);
        }

        public System.Net.IPAddress ReadIPAddress(int index, string name)
        {
            return ReadIPAddress(FormatFieldName(index, name));
        }

        public System.Net.IPAddress ReadIPAddress(int index, int index2, string name)
        {
            return ReadIPAddress(FormatFieldName(index, index2, name));
        }

        public System.Net.IPAddress ReadIPAddress(string name)
        {
            var val = this.ReadBytes(4);
            var t = new System.Net.IPAddress(val);
            if (CanLogField(name))
                FieldLog[name] = t.ToString();
            return t;
        }

        public T ReadStruct<T>()
     where T : struct
        {
            var rawData = ReadBytes(Marshal.SizeOf(typeof(T)));
            var handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            var returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return returnObject;
        }

        public T Read<T>(string name)
             where T : struct
        {
            T val = ReadStruct<T>();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public virtual int ClientBuildAmount
        {
            get
            {
                return 0;
            }
        }

        private bool CanLogField(string name)
        {
            return (LogToFieldLog && !name.IsEmpty());
        }


        public ReadingBase Inflate(int inflatedSize)
        {
            var arr = GetStream(Position);
            var newarr = new byte[inflatedSize];
            var inflater = new Inflater();
            inflater.SetInput(arr, 0, arr.Length);
            inflater.Inflate(newarr, 0, inflatedSize);

            var pkt = new ReadingBase(newarr);
            return pkt;
        }

        public byte[] GetStream(long offset)
        {
            var length = (int)(BaseStream.Length - offset);
            var pos = Position;
            SetPosition(offset);
            var buffer = ReadBytes(length);
            SetPosition(pos);
            return buffer;
        }
    }
}
