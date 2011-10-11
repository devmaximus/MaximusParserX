using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class MovementJump
    {
        public float velocity;
        public float sinAngle;
        public float cosAngle;
        public float xyspeed;

        public MovementJump()
        {
        }

        public MovementJump(Reading.ReadingBase reader)
        {
            velocity = reader.ReadSingle("MovementJump velocity");
            sinAngle = reader.ReadSingle("MovementJump sinAngle");
            cosAngle = reader.ReadSingle("MovementJump cosAngle");
            xyspeed = reader.ReadSingle("MovementJump xyspeed");
        }

        public MovementJump(System.IO.BinaryReader reader)
        {
            velocity = reader.ReadSingle();
            sinAngle = reader.ReadSingle();
            cosAngle = reader.ReadSingle();
            xyspeed = reader.ReadSingle();
        }

        public MovementJump(byte[] bytes)
        {
            velocity = BitConverter.ToSingle(bytes, 0);
            sinAngle = BitConverter.ToSingle(bytes, 4);
            cosAngle = BitConverter.ToSingle(bytes, 8);
            xyspeed = BitConverter.ToSingle(bytes, 12);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("{0}: {1}", "velocity", velocity));
            sb.AppendLine(string.Format("{0}: {1}", "sinAngle", sinAngle));
            sb.AppendLine(string.Format("{0}: {1}", "cosAngle", cosAngle));
            sb.AppendLine(string.Format("{0}: {1}", "xyspeed", xyspeed));

            return sb.ToString();
        }

    }
}
