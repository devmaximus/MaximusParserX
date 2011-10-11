using System;
using MaximusParserX.Reading;
using System.IO;

namespace MaximusParserX
{
    public static class ReadingExt
    {

        public static WoWGuid ReadWoWGuid(this System.Collections.Generic.IDictionary<int, UpdateField> updatefields, int key)
        {
            var low = (uint)updatefields[key].Int32Value;
            var high = (uint)updatefields[key + 1].Int32Value;
            ulong mixed = (ulong)high << 32 | low;
            return new WoWGuid(mixed);
        }

        public static Vector3 ReadVector3(this ReadingBase reader)
        {
            return new Vector3(reader);
        }

        public static Vector3 ReadVector3(this byte[] bytes)
        {
            return new Vector3(bytes);
        }

        public static Vector4 ReadVector4(this ReadingBase reader)
        {
            return new Vector4(reader);
        }

        public static Vector4 ReadVector4(this byte[] bytes)
        {
            return new Vector4(bytes);
        }

        public static MovementJump ReadMovementJump(this ReadingBase reader)
        {
            return new MovementJump(reader);
        }

        public static MovementFall ReadMovementFall(this ReadingBase reader)
        {
            return new MovementFall(reader);
        }

        public static MovementTransport ReadMovementTransport(this ReadingBase reader, int clientbuild, bool readTransportTime2)
        {
            return new MovementTransport(reader, clientbuild, readTransportTime2);
        }

        public static MovementJump ReadMovementJump(this byte[] bytes)
        {
            return new MovementJump(bytes);
        }

        public static WoWGuid ReadPackedWoWGuid(this byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            using (var br = new BinaryReader(ms))
            {
                return br.ReadPackedWoWGuid();
            }
        }

        public static WoWGuid ReadPackedWoWGuid(this System.IO.BinaryReader br)
        {
            var mask = br.ReadByte();

            if (mask == 0)
                return new WoWGuid(0);

            ulong res = 0;

            var i = 0;
            while (i < 8)
            {
                if ((mask & (1 << i)) != 0)
                    res |= (ulong)br.ReadByte() << (i * 8);

                i++;
            }

            return new WoWGuid(res);
        }

        public static WoWGuid ReadWoWGuid(this byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            using (var br = new BinaryReader(ms))
            {
                return new WoWGuid(br.ReadUInt64());
            }
        }

        public static WoWGuid ReadWoWGuid(this System.IO.BinaryReader br)
        {
            return new WoWGuid(br.ReadUInt64());
        }

 

        public static string ValuesDump(this System.IO.BinaryReader reader, int count)
        {
            long position = reader.BaseStream.Position;
            byte[] array = reader.ReadBytes(count);
 
            var dictionary = new System.Collections.Generic.Dictionary<System.TypeCode, System.Collections.Generic.IDictionary<int, object>>();

            dictionary[TypeCode.Byte] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.Int16] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.UInt16] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.Int32] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.UInt32] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.Single] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.Int64] = new System.Collections.Generic.Dictionary<int, object>();
            dictionary[TypeCode.UInt64] = new System.Collections.Generic.Dictionary<int, object>();
            

            for (int j = 0; j < count; j++)
            {

                if ((array.Length - j) >= 1)
                {
                    dictionary[TypeCode.Byte][j] = array[j]; 
                }

                if ((array.Length - j) >= 2)
                {
                    dictionary[TypeCode.Int16][j] = BitConverter.ToInt16(array, j);
                    dictionary[TypeCode.UInt16][j] = BitConverter.ToUInt16(array, j); 
                }

                if ((array.Length - j) >= 4)
                {
                    dictionary[TypeCode.Int32][j] = BitConverter.ToInt32(array, j);
                    dictionary[TypeCode.UInt32][j] = BitConverter.ToUInt32(array, j);
                    dictionary[TypeCode.Single][j] = BitConverter.ToSingle(array, j); 
                }

                if ((array.Length - j) >= 8)
                {
                    dictionary[TypeCode.Int64][j] = BitConverter.ToInt64(array, j);
                    dictionary[TypeCode.UInt64][j] = BitConverter.ToUInt64(array, j);
                }
            }

            var sb = new System.Text.StringBuilder();

            foreach (var item in dictionary)
            {
                sb.AppendLine(item.Key + ":");

                foreach (var subitem in item.Value)
                {
                    sb.AppendLine("\t\t" + subitem.Key + ": " + subitem.Value);
                }
            }

            Console.WriteLine(sb.ToString());
            reader.BaseStream.Position = position;

            return sb.ToString();
        }
    }
}
