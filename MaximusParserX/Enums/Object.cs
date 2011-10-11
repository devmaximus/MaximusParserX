using System;

namespace MaximusParserX
{

    public enum OBJECT_UPDATE_TYPE : int
    {
        UPDATETYPE_VALUES = 0,
        UPDATETYPE_MOVEMENT = 1,
        UPDATETYPE_CREATE_OBJECT = 2,
        UPDATETYPE_CREATE_OBJECT2 = 3,
        UPDATETYPE_OUT_OF_RANGE_OBJECTS = 4,
        UPDATETYPE_NEAR_OBJECTS = 5
    };

    [Flags]
    public enum OBJECT_UPDATE_FLAGS : uint
    {
        UPDATEFLAG_NONE = 0x0000,
        UPDATEFLAG_SELF = 0x0001,
        UPDATEFLAG_TRANSPORT = 0x0002,
        UPDATEFLAG_HAS_TARGET = 0x0004,
        UPDATEFLAG_LOWGUID = 0x0008,
        UPDATEFLAG_HIGHGUID = 0x0010,
        UPDATEFLAG_LIVING = 0x0020,
        UPDATEFLAG_HAS_POSITION = 0x0040,
        UPDATEFLAG_VEHICLE = 0x0080,
        UPDATEFLAG_POSITION = 0x0100,
        UPDATEFLAG_ROTATION = 0x0200
    };

    [Flags]
    public enum TypeMask : int
    {
        TYPEMASK_OBJECT = 0x0001,
        TYPEMASK_ITEM = 0x0002,
        TYPEMASK_CONTAINER = 0x0006,                       // TYPEMASK_ITEM | 0x0004
        TYPEMASK_UNIT = 0x0008,
        TYPEMASK_PLAYER = 0x0010,
        TYPEMASK_GAMEOBJECT = 0x0020,
        TYPEMASK_DYNAMICOBJECT = 0x0040,
        TYPEMASK_CORPSE = 0x0080,
        TYPEMASK_AIGROUP = 0x0100,
        TYPEMASK_AREATRIGGER = 0x0200
    };

    public enum TypeID : byte
    {
        TYPEID_OBJECT = 0,
        TYPEID_ITEM = 1,
        TYPEID_CONTAINER = 2,
        TYPEID_UNIT = 3,
        TYPEID_PLAYER = 4,
        TYPEID_GAMEOBJECT = 5,
        TYPEID_DYNAMICOBJECT = 6,
        TYPEID_CORPSE = 7,
        TYPEID_AIGROUP = 8,
        TYPEID_AREATRIGGER = 9
    };

 
}
