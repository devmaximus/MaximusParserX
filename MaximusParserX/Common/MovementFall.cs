using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public class MovementFall
    {
        public float velocity { get; set; }
        public float sinAngle { get; set; }
        public float cosAngle { get; set; }
        public float xyspeed { get; set; }

        public MovementFall()
        {
        }
        public MovementFall(Reading.ReadingBase reader)
        {
            sinAngle = reader.ReadSingle("MovementFall sinAngle");
            cosAngle = reader.ReadSingle("MovementFall cosAngle");
            xyspeed = reader.ReadSingle("MovementFall xyspeed");
            velocity = reader.ReadSingle("MovementFall velocity");
        }

        public MovementFall(System.IO.BinaryReader reader)
        {
            sinAngle = reader.ReadSingle();
            cosAngle = reader.ReadSingle();
            xyspeed = reader.ReadSingle();
            velocity = reader.ReadSingle();
        }

        public MovementFall(byte[] bytes)
        {
            sinAngle = BitConverter.ToSingle(bytes, 0);
            cosAngle = BitConverter.ToSingle(bytes, 4);
            xyspeed = BitConverter.ToSingle(bytes, 8);
            velocity = BitConverter.ToSingle(bytes, 12);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}: {1}", "sinAngle", sinAngle));
            sb.AppendLine(string.Format("{0}: {1}", "cosAngle", cosAngle));
            sb.AppendLine(string.Format("{0}: {1}", "xyspeed", xyspeed));
            sb.AppendLine(string.Format("{0}: {1}", "velocity", velocity));
            return sb.ToString();
        }
    }
}
