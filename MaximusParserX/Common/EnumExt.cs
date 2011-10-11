using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public static class EnumExt
    {

        //public static string DumpFlags(this  SplineFlag flags)
        //{
        //    uint i = 0;
        //    var sb = new StringBuilder();

        //    while (i <= Enum.GetValues(typeof(SplineFlag)).Cast<uint>().Max())
        //    {
        //        if (i < 2) { i++; } else { i *= 2; }
        //        var has = ((uint)flags & i) > 0;

        //        if (has)
        //        {
        //            var temp = (SplineFlag)i;
        //            flags = (SplineFlag)((uint)flags & ~i);
        //            sb.AppendLine(string.Format("{0} 0x{1} = {2}", temp.ToString(), ((uint)temp).ToString("X4"), has));
        //        }
        //    }

        //    return sb.ToString();
        //}

        //public static string DumpFlags(this  OBJECT_UPDATE_FLAGS flags)
        //{
        //    uint i = 0;
        //    var sb = new StringBuilder();

        //    while (i <= Enum.GetValues(typeof(OBJECT_UPDATE_FLAGS)).Cast<uint>().Max())
        //    {
        //        if (i < 2) { i++; } else { i *= 2; }
        //        var has = ((uint)flags & i) > 0;

        //        if (has)
        //        {
        //            var temp = (OBJECT_UPDATE_FLAGS)i;
        //            flags = (OBJECT_UPDATE_FLAGS)((uint)flags & ~i);
        //            sb.AppendLine(string.Format("{0} 0x{1} = {2}", temp.ToString(), ((uint)temp).ToString("X4"), has));
        //        }
        //    }

        //    return sb.ToString();
        //}

        //public static string DumpFlags(this  MoveFlag flags)
        //{
        //    uint i = 0;
        //    var sb = new StringBuilder();

        //    while (i <= Enum.GetValues(typeof(MoveFlag)).Cast<uint>().Max())
        //    {
        //        if (i < 2) { i++; } else { i *= 2; }
        //        var has = ((uint)flags & i) > 0;

        //        if (has)
        //        {
        //            var temp = (MoveFlag)i;
        //            flags = (MoveFlag)((uint)flags & ~i);
        //            sb.AppendLine(string.Format("{0} 0x{1} = {2}", temp.ToString(), ((uint)temp).ToString("X4"), has));
        //        }
        //    }

        //    return sb.ToString();
        //}

        //public static string DumpFlags(this  MoveFlagExtra flags)
        //{
        //    uint i = 0;
        //    var sb = new StringBuilder();

        //    while (i <= Enum.GetValues(typeof(MoveFlagExtra)).Cast<ushort>().Max())
        //    {
        //        if (i < 2) { i++; } else { i *= 2; }
        //        var has = ((ushort)flags & i) > 0;


        //        var temp = (MoveFlagExtra)i;


        //        if (has)
        //        {
        //            flags = (MoveFlagExtra)((ushort)flags & ~i);
        //            sb.AppendLine(string.Format("{0} 0x{1} = {2}", temp.ToString(), ((ushort)temp).ToString("X4"), has));
        //        }

        //    }



        //    return sb.ToString();
        //}

         

    }
}
