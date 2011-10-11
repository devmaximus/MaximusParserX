using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public enum UpdateFields : uint
    {
        OBJECT_FIELD_GUID = 0x000,	//  Size: 2, Type: GUID, Flags: 1
        OBJECT_FIELD_GUID_01 = 0x001,	//  Size: 2, Type: GUID, Flags: 1
        OBJECT_FIELD_TYPE = 0x002,    //  Size: 1, Type: Int32, Flags: 1
        OBJECT_FIELD_ENTRY = 0x003,	//  Size: 1, Type: Int32, Flags: 1
        OBJECT_FIELD_SCALE_X = 0x004,	//  Size: 1, Type: Float, Flags: 1
        OBJECT_FIELD_PADDING = 0x005,	//  Size: 1, Type: Int32, Flags: 0
        OBJECT_END = 0x006,
    };
}
