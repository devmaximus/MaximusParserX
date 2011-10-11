using System.Runtime.InteropServices;

namespace MaximusParserX
{
    public struct Vector2
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;

        }

        public readonly float X;

        public readonly float Y;


        public Vector2(Reading.ReadingBase reader)
        {
            X = reader.ReadSingle("X");
            Y = reader.ReadSingle("Y");

        }

        public Vector2(byte[] bytes)
        {
            X = System.BitConverter.ToSingle(bytes, 0);
            Y = System.BitConverter.ToSingle(bytes, 4);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("{0}: {1}", "X", X));
            sb.AppendLine(string.Format("{0}: {1}", "Y", Y));
            return sb.ToString();
        }

        public static bool operator ==(Vector2 first, Vector2 other)
        {
            return first.Equals(other);
        }

        public static bool operator !=(Vector2 first, Vector2 other)
        {
            return !(first == other);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
                return Equals((Vector2)obj);

            return false;
        }


        public bool Equals(Vector2 other)
        {
            return other.X == X && other.Y == Y;
        }

        public override int GetHashCode()
        {
            var result = X.GetHashCode();
            result = (result * 397) ^ Y.GetHashCode();
            return result;
        }
    }
}
