using System.Runtime.InteropServices;

namespace MaximusParserX
{
    public struct Vector3
    {
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public readonly float X;

        public readonly float Y;

        public readonly float Z;

        //public Vector3(Reading.ReadingBase reader, string name)
        //{
        //    X = reader.ReadSingle(name + "X");
        //    Y = reader.ReadSingle(name + "Y");
        //    Z = reader.ReadSingle(name + "Z");
        //}

        public Vector3(Reading.ReadingBase reader)
        {
            X = reader.ReadSingle("X");
            Y = reader.ReadSingle("Y");
            Z = reader.ReadSingle("Z");
        }

        public Vector3(byte[] bytes)
        {
            X = System.BitConverter.ToSingle(bytes, 0);
            Y = System.BitConverter.ToSingle(bytes, 4);
            Z = System.BitConverter.ToSingle(bytes, 8);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("{0}: {1}", "X", X));
            sb.AppendLine(string.Format("{0}: {1}", "Y", Y));
            sb.AppendLine(string.Format("{0}: {1}", "Z", Z));
            return sb.ToString();
        }

        public static bool operator ==(Vector3 first, Vector3 other)
        {
            return first.Equals(other);
        }

        public static bool operator !=(Vector3 first, Vector3 other)
        {
            return !(first == other);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3)
                return Equals((Vector3)obj);

            return false;
        }
 

        public bool Equals(Vector3 other)
        {
            return other.X == X && other.Y == Y && other.Z == Z;
        }

        public override int GetHashCode()
        {
            var result = X.GetHashCode();
            result = (result * 397) ^ Y.GetHashCode();
            result = (result * 397) ^ Z.GetHashCode();
            return result;
        }
    }
}
