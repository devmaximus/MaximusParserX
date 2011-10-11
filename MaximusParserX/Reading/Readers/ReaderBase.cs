using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Reading.Readers
{
    public abstract class ReaderBase : IDisposable
    {
        public abstract Guid ReaderGUID { get; }
        public abstract Packet GetNextPacket();
        public abstract void Load();
        public abstract void Load(string query);
        public abstract int GetPacketTotalCount();
        public abstract int GetPacketTotalCountByQuery(string query);
        public abstract void Reset();
        public abstract void Close();
        public abstract string Name { get; }
        public abstract int CurrentIndex { get; set; }
        public abstract int PacketTotalCount { get; }
        public abstract ClientBuild ClientBuild { get; }
        public abstract int ClientBuildAmount { get; }
        public abstract string ClientBuildName { get; }
        public abstract string AccountName { get; }
        public abstract int MaxProcessCount { get; set; }
        public abstract string FileName { get; }
        public abstract int SkipPackets(int count);
        public abstract DateTime CreatedDateTime { get; }
        public abstract string TypeName { get; }
        public abstract string FileSize { get; }

        private int ReadLength(System.IO.BinaryReader reader)
        {
            int len = reader.ReadByte();

            if ((len & 0x80) != 0x00)
            {
                len &= 0x7f;
                len = (len << 0x08) | reader.ReadByte();
            }

            len = (len << 0x08) | reader.ReadByte();
            return len;
        }

        void IDisposable.Dispose()
        {
            this.Close();
        }
    }
}
