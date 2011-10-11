
using System.Runtime.InteropServices;

namespace MaximusParserX
{
    public struct Quaternion
    {
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public readonly float X;

        public readonly float Y;

        public readonly float Z;

        public readonly float W;

        public Quaternion(Reading.ReadingBase reader)
        {
            X = reader.ReadSingle("X");
            Y = reader.ReadSingle("Y");
            Z = reader.ReadSingle("Z");
            W = reader.ReadSingle("W");
        }

        public Quaternion(byte[] bytes)
        {
            X = System.BitConverter.ToSingle(bytes, 0);
            Y = System.BitConverter.ToSingle(bytes, 4);
            Z = System.BitConverter.ToSingle(bytes, 8);
            W = System.BitConverter.ToSingle(bytes, 12);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("{0}: {1}", "X", X));
            sb.AppendLine(string.Format("{0}: {1}", "Y", Y));
            sb.AppendLine(string.Format("{0}: {1}", "Z", Z));
            sb.AppendLine(string.Format("{0}: {1}", "W", W));
            return sb.ToString();
        }

        public static bool operator ==(Quaternion first, Quaternion other)
        {
            return first.Equals(other);
        }

        public static bool operator !=(Quaternion first, Quaternion other)
        {
            return !(first == other);
        }

        public override bool Equals(object obj)
        {
            if (obj is Quaternion)
                return Equals((Quaternion)obj);

            return false;
        }


        public bool Equals(Quaternion other)
        {
            return other.X == X && other.Y == Y && other.Z == Z && other.W == W;
        }

        public override int GetHashCode()
        {
            var result = X.GetHashCode();
            result = (result * 397) ^ Y.GetHashCode();
            result = (result * 397) ^ Z.GetHashCode();
            result = (result * 397) ^ W.GetHashCode();
            return result;
        }
    }
}

/// <summary>    /// Structure that represents a rotation in three dimensions.    /// </summary>    public struct Quaternion    {        const int PACK_COEFF_YZ = 1 << 20;        const int PACK_COEFF_X  = 1 << 21;        /// <summary>        /// The X component of the quaternion.        /// </summary>        public readonly double X;        /// <summary>        /// The Y component of the quaternion.        /// </summary>        public readonly double Y;        /// <summary>        /// The Z component of the quaternion.        /// </summary>        public readonly double Z;        /// <summary>        /// The W component of the quaternion.        /// </summary>        public readonly double W;        /// <summary>        /// Initializes a new instance of the Quaternion structure.        /// </summary>        /// <param name="x">        /// Type: System.Single        /// Value of the new Quaternion's X coordinate.        /// </param>        /// <param name="y">                /// Type: System.Single        /// Value of the new Quaternion's Y coordinate.        /// </param>        /// <param name="z">        /// Type: System.Single        /// Value of the new Quaternion's Z coordinate.        /// </param>        /// <param name="w">        /// Type: System.Single        /// Value of the new Quaternion's W coordinate.        /// </param>        public Quaternion(float x, float y, float z, float w)        {            X = x;            Y = y;            Z = z;            W = w;        }        /// <summary>        /// Initializes a new instance of the Quaternion structure.        /// </summary>        /// <param name="packedQuaternion">        /// Type: System.UInt64        /// Value of the packed quarterion        /// </param>        public Quaternion(ulong packedQuaternion)        {            X = (double)(packedQuaternion >> 42)       / (double)PACK_COEFF_X;            Y = (double)(packedQuaternion << 22 >> 43) / (double)PACK_COEFF_YZ;            Z = (double)(packedQuaternion << 43 >> 43) / (double)PACK_COEFF_YZ;            W = 1 - (X * X + Y * Y + Z * Z);            if (W < 0) W = Math.Sqrt(W);        }        /// <summary>        ///  Converts the quaternion values of this instance to its equivalent ulong value.        /// </summary>        public ulong ToUInt64()        {            byte w_sign = (byte)(this.W >= 0 ? 1 : -1);            ulong x = (ulong)((this.X * PACK_COEFF_X ) * w_sign) & ((1 << 22) - 1);            ulong y = (ulong)((this.Y * PACK_COEFF_YZ) * w_sign) & ((1 << 21) - 1);            ulong z = (ulong)((this.Z * PACK_COEFF_YZ) * w_sign) & ((1 << 21) - 1);            return (z | (y << 21) | (x << 42));        }        /// <summary>        ///  Converts the numeric values of this instance to its equivalent string representations, separator is space.        /// </summary>        public override string ToString()        {            return string.Format(CultureInfo.InvariantCulture, "(X:{0} Y:{1} Z:{2} W:{3})", this.X, this.Y, this.Z, this.W);        }    } 

