﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public struct WoWGuid
    {
        public readonly ulong Full;

        public WoWGuid(ulong id)
            : this()
        {
            Full = id;
        }

        public bool HasEntry()
        {
            switch (GetHighType())
            {
                case HighGuidType.NoEntry1:
                case HighGuidType.NoEntry2:
                    {
                        return false;
                    }
            }

            return true;
        }

        public ulong GetLow()
        {
            switch (GetHighType())
            {
                case HighGuidType.NoEntry1:
                case HighGuidType.NoEntry2:
                    {
                        return (Full & 0x000FFFFFFFFFFFFF) >> 0;
                    }
                case HighGuidType.GameObject:
                case HighGuidType.Transport:
                case HighGuidType.MOTransport:
                    {
                        return (Full & 0x0000000000FFFFFF) >> 0;
                    }
            }

            return (Full & 0x00000000FFFFFFFF) >> 0;
        }

        public uint GetEntry()
        {
            if (!HasEntry())
                return 0;

            return (uint)((Full & 0x000FFFFF00000000) >> 32);
        }

        public HighGuidType GetHighType()
        {
            return (HighGuidType)((Full & 0x00F0000000000000) >> 52);
        }

        public HighGuidMask GetHighMask()
        {
            return (HighGuidMask)((Full & 0xFF00000000000000) >> 56);
        }

        public static bool operator ==(WoWGuid first, WoWGuid other)
        {
            return first.Full == other.Full;
        }

        public static bool operator !=(WoWGuid first, WoWGuid other)
        {
            return !(first == other);
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is WoWGuid && Equals((WoWGuid)obj);
        }

        public bool Equals(WoWGuid other)
        {
            return other.Full == Full;
        }

        public override int GetHashCode()
        {
            return Full.GetHashCode();
        }

        public override string ToString()
        {
            return "Full: 0x" + Full.ToString("X8") + " Flags: " + GetHighMask() + " Type: " +
                GetHighType() + " Entry: " + GetEntry() + " Low: " + GetLow();
        }
    }
}
