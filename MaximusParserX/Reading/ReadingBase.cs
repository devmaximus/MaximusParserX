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

        private long lastPosition = 0;
        private long customPosition = 0;
        private long customSize = 0;
        private long previousPosition = 0;

        public bool LogToFieldLog { get; set; }

        public void Load(byte[] data)
        {
            base.BaseStream.Write(data, 0, data.Length);
        }

        public IDictionary<string, object> FieldLog { get; set; }

        public long AvailableBytes
        {
            get
            {
                return (long)(this.BaseStream.Length - Position);
            }
        }

        public long TotalBytes
        {
            get
            {
                return (long)(this.BaseStream.Length);
            }
        }

        public long SetPosition()
        {
            this.lastPosition = (long)Position;
            return this.lastPosition;
        }

        public long ResetPosition()
        {
            Position = (long)lastPosition;
            return lastPosition;
        }

        public void SetPreviousPosition()
        {
            this.previousPosition = Position;
        }

        public void ResetPreviousPosition()
        {
            Position = this.previousPosition;
        }

        public long Position { get { return this.BaseStream.Position; } set { this.BaseStream.Position = value; } }

        public void SetCustomPositionAndSize(long position, long size)
        {
            this.customPosition = position;
            this.customSize = size;
        }

        public long AvailableBytesCustom
        {
            get
            {
                return this.CalcAvailableBytesCustom(this.customPosition, this.customSize);
            }
        }

        public long CalcAvailableBytesCustom(long position, long size)
        {
            var leftovers = 0L;
            var readsize = Position - (position - 2);
            if (readsize < (size + 2))
            {
                leftovers = (size + 2) - readsize;
            }
            return leftovers;
        }

        public byte ReadByte(string name)
        {
            var val = ReadByte();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public bool ReadBoolean(string name)
        {
            var val = ReadBoolean();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public decimal ReadDecimal(string name)
        {
            var val = ReadDecimal();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public double ReadDouble(string name)
        {
            var val = ReadDouble();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public short ReadInt16(string name)
        {
            var val = ReadInt16();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public int ReadInt32(string name)
        {
            var val = ReadInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public uint ReadUInt(string name)
        {
            var val = ReadUInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public int ReadInt(string name)
        {
            var val = ReadInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public float ReadFloat(string name)
        {
            var val = ReadSingle();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public long ReadInt64(string name)
        {
            var val = ReadInt64();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public sbyte ReadSByte(string name)
        {
            var val = ReadSByte();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public float ReadSingle(string name)
        {
            var val = ReadSingle();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
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

        public T ReadEnum<T>(string name, TypeCode code = TypeCode.Empty)
        {
            KeyValuePair<long, T> val = ReadEnum<T>(code);
            if (CanLogField(name)) FieldLog[name] = val.Value;
            return val.Value;
        }


        public OBJECT_UPDATE_TYPE ReadByte_OBJECT_UPDATE_TYPE(string name)
        {
            var val = (OBJECT_UPDATE_TYPE)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public SplineMode ReadByte_SplineMode(string name)
        {
            var val = (SplineMode)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }
 
        public OBJECT_UPDATE_FLAGS ReadUInt16_OBJECT_UPDATE_FLAGS(string name)
        {
            var val = (OBJECT_UPDATE_FLAGS)ReadUInt16();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public SplineFlag ReadInt32_SplineFlags(string name)
        {
            var val = (SplineFlag)ReadInt32();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (Int32)val, val.ToString());
            return val;
        }


        public OBJECT_UPDATE_FLAGS ReadByte_OBJECT_UPDATE_FLAGS(string name)
        {
            var val = (OBJECT_UPDATE_FLAGS)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public uint ReadUInt32(string name)
        {
            var val = ReadUInt32();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public MoveFlag ReadUInt32_MoveFlag(string name)
        {
            var val = (MoveFlag)ReadUInt32();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (UInt32)val, val.ToString());
            return val;
        }

        public MoveFlagExtra ReadByte_MoveFlagExtra(string name)
        {
            var val = (MoveFlagExtra)ReadByte();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (byte)val, val.ToString());
            return val;
        }

        public MoveFlagExtra ReadUInt16_MoveFlagExtra(string name)
        {
            var val = (MoveFlagExtra)ReadUInt16();
            if (CanLogField(name)) FieldLog[name] = string.Format("val: {0}, Name: {1}", (ushort)val, val.ToString());
            return val;
        }

        public ulong ReadUInt64(string name)
        {
            var val = ReadUInt64();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
        }

        public WoWGuid ReadPackedWoWGuid(string name)
        {
            var val = this.ReadPackedWoWGuid();
            if (CanLogField(name)) FieldLog[name] = val;
            return val;
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

        public MovementFall ReadMovementFall(string name)
        {
            var t = new MovementFall(this);
            if (CanLogField(name)) 
            {
                FieldLog[name] = t.ToString();
            }
            return t;
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

        public UpdateField ReadUpdateField(string name)
        {
            var pos = Position;
            var svalue = ReadInt32();
            Position = pos;
            var fvalue = ReadSingle();
            var field = new UpdateField(svalue, fvalue);
            if (CanLogField(name)) FieldLog[name] = field.ToString();
            return field;
        }

        public string ReadCString()
        {
            return ReadCString(Encoding.UTF8);
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
            get { return 0; }
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
            Position = offset;
            var buffer = ReadBytes(length);
            Position = pos;
            return buffer;
        }
    }
}
