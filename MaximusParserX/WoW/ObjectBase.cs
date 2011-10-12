using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MaximusParserX.WoW
{
    public abstract class ObjectBase
    {
        public WoWGuid Guid { get; private set; }
        public TypeID TypeID { get; private set; }
        internal string _name = null;
        public virtual string Name { get; internal set; }
        public string SubName { get; private set; }
        public UInt32 SubType { get; private set; }
        public MovementInfo MovementInfo { get; set; }
        
        public IDictionary<int, UpdateField> UpdateFields { get; private set; }
        public Core Core { get; private set; }

        public ObjectBase(Core core)
        {
            Core = core;
            UpdateFields = new Dictionary<int, UpdateField>();
        }

        public ObjectBase(Core core, WoWGuid guid, TypeID typeid)
        {
            Core = core;
            Guid = guid;
            TypeID = typeid;
            UpdateFields = new Dictionary<int, UpdateField>();
        }

        public virtual void ObjectUpdate(OBJECT_UPDATE_TYPE updatetype)
        {
        }


        public WoWGuid OBJECT_FIELD_GUID
        {
            get
            {
                return this.UpdateFields.ReadWoWGuid((int)MaximusParserX.UpdateFields.OBJECT_FIELD_GUID);
            }
        }

        public int OBJECT_FIELD_TYPE
        {
            get
            {
                return this.UpdateFields[(int)MaximusParserX.UpdateFields.OBJECT_FIELD_TYPE].Int32Value;
            }
        }

        public uint OBJECT_FIELD_ENTRY
        {
            get
            {
                return (uint)this.UpdateFields[(int)MaximusParserX.UpdateFields.OBJECT_FIELD_ENTRY].Int32Value;
            }
        }

        public float OBJECT_FIELD_SCALE_X
        {
            get
            {
                return this.UpdateFields[(int)MaximusParserX.UpdateFields.OBJECT_FIELD_SCALE_X].FloatValue;
            }
        }

        public virtual float X
        {
            get
            {
                if (MovementInfo != null && MovementInfo.PositionInfo != null)
                    return MovementInfo.PositionInfo.X;
                else
                    return 0f;
            }
        }

        public virtual float Y
        {
            get
            {
                if (MovementInfo != null && MovementInfo.PositionInfo != null)
                    return MovementInfo.PositionInfo.Y;
                else
                    return 0f;
            }
        }

        public virtual float Z
        {
            get
            {
                if (MovementInfo != null && MovementInfo.PositionInfo != null)
                    return MovementInfo.PositionInfo.Z;
                else
                    return 0f;
            }
        }

        public virtual float O
        {
            get
            {
                if (MovementInfo != null && MovementInfo.PositionInfo != null)
                    return MovementInfo.PositionInfo.O;
                else
                    return 0f;
            }
        }

        public bool HasPosition()
        {
            return !(X == 0f && Y == 0f && Z == 0f && O == 0f);
        }

    }
}
