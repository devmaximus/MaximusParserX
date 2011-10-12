using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;

namespace MaximusParserX
{
    public class MovementTransport
    {
        public WoWGuid TransportGUID;
        public Vector4 TransportOffset;
        public UInt32 TransportTime;
        public byte TransportSeat;
        public UInt32 TransportTime2;

        public MovementTransport()
        {
        }

        public MovementTransport(ReadingBase reader, int clientbuild, bool readTime2)
        {
            reader.SetBookmarkPosition();

            reader.GotoBookmarkPosition();

            if (clientbuild <= 9551)
            {
                TransportGUID = new WoWGuid(reader.ReadUInt64("Transport GUID"));
            }
            else
            {
                TransportGUID = reader.ReadPackedWoWGuid("Transport GUID");
            }
            TransportOffset = reader.ReadVector4();
            TransportTime = reader.ReadUInt32("Transport Time");

            if (clientbuild >= 9183)
                TransportSeat = reader.ReadByte("Transport Seat");
            else
                TransportSeat = 0;

            if (readTime2)
                TransportTime2 = reader.ReadUInt32("Transport Time2");
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("Guid: {0}", TransportGUID));
            sb.AppendLine(TransportOffset.ToString());
            sb.AppendLine(string.Format("Time: {0}", TransportTime));
            sb.AppendLine(string.Format("Seat: {0}", TransportSeat));
            sb.AppendLine(string.Format("Time2: {0}", TransportTime2));

            return sb.ToString();
        }
    }
}
