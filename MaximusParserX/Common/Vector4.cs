using System.Runtime.InteropServices;

namespace MaximusParserX
{
    public struct Vector4
    {
        public Vector4(float x, float y, float z, float o)
        {
            X = x;
            Y = y;
            Z = z;
            O = o;
        }

        public readonly float X;

        public readonly float Y;

        public readonly float Z;

        public readonly float O;

        //public Vector4(Reading.ReadingBase reader, string name)
        //{
        //    X = reader.ReadSingle(name + "X");
        //    Y = reader.ReadSingle(name + "Y");
        //    Z = reader.ReadSingle(name + "Z");
        //    O = reader.ReadSingle(name + "O");
        //}

        public Vector4(Reading.ReadingBase reader)
        {
            X = reader.ReadSingle("X");
            Y = reader.ReadSingle("Y");
            Z = reader.ReadSingle("Z");
            O = reader.ReadSingle("O");
        }

        public Vector4(byte[] bytes)
        {
            X = System.BitConverter.ToSingle(bytes, 0);
            Y = System.BitConverter.ToSingle(bytes, 4);
            Z = System.BitConverter.ToSingle(bytes, 8);
            O = System.BitConverter.ToSingle(bytes, 12);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("{0}: {1}", "X", X));
            sb.AppendLine(string.Format("{0}: {1}", "Y", Y));
            sb.AppendLine(string.Format("{0}: {1}", "Z", Z));
            sb.AppendLine(string.Format("{0}: {1}", "O", O));
            return sb.ToString();
        }

        public static bool operator ==(Vector4 first, Vector4 other)
        {
            return first.Equals(other);
        }

        public static bool operator !=(Vector4 first, Vector4 other)
        {
            return !(first == other);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector4)
                return Equals((Vector4)obj);

            return false;
        }


        public bool Equals(Vector4 other)
        {
            return other.X == X && other.Y == Y && other.Z == Z && other.O == O;
        }

        public override int GetHashCode()
        {
            var result = X.GetHashCode();
            result = (result * 397) ^ Y.GetHashCode();
            result = (result * 397) ^ Z.GetHashCode();
            result = (result * 397) ^ O.GetHashCode();
            return result;
        }
    }
}
