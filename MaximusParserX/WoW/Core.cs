using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.WoW
{
    public class Core
    {
        public WoWGuid? CurrentPlayerWoWGuid { get; private set; }

        public static readonly Dictionary<uint, Dictionary<ulong, ObjectBase>> Objects = new Dictionary<uint, Dictionary<ulong, ObjectBase>>();

        public Int32 CurrentPlayerPhaseMask { get; private set; }

        public UInt32 PreviousPlayerMapID { get; private set; }

        public UInt32 CurrentPlayerMapID { get; private set; }

        public Vector4 CurrentPlayerPosition { get; private set; }

        public Int32 CurrentPlayerLevel { get; private set; }

        public Difficulty? CurrentPlayerInstanceDifficulty { get; private set; }

        public UI.DelegateManager DelegateManager { get; private set; }

        public Int32 ClientBuildAmount { get; private set; }

        public CacheObjects.CacheContainer Cache = new CacheObjects.CacheContainer();

        public Core(UI.DelegateManager delegateManager, int clientbuildamount)
        {
            this.ClientBuildAmount = clientbuildamount;
            this.CurrentPlayerPhaseMask = 1;
            this.CurrentPlayerPosition = new Vector4();
        }

        public ObjectBase CreateOrGetObject(WoWGuid guid, TypeID typeid)
        {
            var key = guid.Full;
            ObjectBase obj = null;


            if (Objects[CurrentPlayerMapID].TryGetValue(key, out obj))
                return obj;
            else
            {
                switch (typeid)
                {
                    case TypeID.TYPEID_CORPSE: obj = new Corpse(this, guid, typeid); break;
                    case TypeID.TYPEID_OBJECT: obj = new GenericObject(this, guid, typeid); break;
                    case TypeID.TYPEID_ITEM: obj = new Item(this, guid, typeid); break;
                    case TypeID.TYPEID_CONTAINER: obj = new Container(this, guid, typeid); break;
                    case TypeID.TYPEID_UNIT: obj = new Unit(this, guid, typeid); break;
                    case TypeID.TYPEID_PLAYER: obj = new Player(this, guid, typeid); break;
                    case TypeID.TYPEID_GAMEOBJECT: obj = new GameObject(this, guid, typeid); break;
                    case TypeID.TYPEID_DYNAMICOBJECT: obj = new DynamicObject(this, guid, typeid); break;
                    case TypeID.TYPEID_AIGROUP: obj = new AIGroup(this, guid, typeid); break;
                    case TypeID.TYPEID_AREATRIGGER: obj = new Areatrigger(this, guid, typeid); break;
                }

                Objects[CurrentPlayerMapID].Add(key, obj);
                return obj;
            }
        }

        public ObjectBase GetObjectByWoWGuid(WoWGuid guid)
        {
            var key = guid.Full;
            ObjectBase obj = null;
            if (Objects[CurrentPlayerMapID].TryGetValue(key, out obj))
                return obj;
            else
                return null;
        }

        public void AddOrUpdateObject(ObjectBase obj)
        {
            var key = obj.Guid.Full;

            if (!Objects[CurrentPlayerMapID].ContainsKey(key))
                Objects[CurrentPlayerMapID].Add(key, obj);
        }

        public void RemoveObjectByWoWGuid(WoWGuid guid)
        {
            var key = guid.Full;

            if (Objects[CurrentPlayerMapID].ContainsKey(key))
                Objects[CurrentPlayerMapID].Remove(key);
        }


        public void SetCurrentPlayerWoWGuid(WoWGuid currentplayerwowguid)
        {
            CurrentPlayerWoWGuid = currentplayerwowguid;
        }

        public void SetCurrentPlayerLevel(Int32 currentplayerlevel)
        {
            CurrentPlayerLevel = currentplayerlevel;
        }

        public void SetCurrentPlayerPhaseMask(Int32 phasemask)
        {
            CurrentPlayerPhaseMask = phasemask;
        }

        public void SetCurrentPlayerMapID(UInt32 mapid, Difficulty difficulty)
        {
            SetCurrentPlayerMapID(mapid);

            CurrentPlayerInstanceDifficulty = difficulty;
        }

        public void SetCurrentPlayerMapID(UInt32 mapid)
        {
            if (this.CurrentPlayerMapID != mapid)
            {
                CurrentPlayerInstanceDifficulty = null;
                //Console.WriteLine("CurrentPlayerMapID changed from {0} to {1}.", CurrentPlayerMapID, mapid);
            }


            this.CurrentPlayerMapID = mapid;

            if (!Objects.ContainsKey(mapid)) Objects.Add(mapid, new Dictionary<ulong, ObjectBase>());
        }

        public void SetCurrentPlayerPosition(Vector4 position)
        {
            //if (this.CurrentPlayerPosition != position)
            //    Console.WriteLine("CurrentPlayerPosition changed from {0} to {1}.", CurrentPlayerPosition, position);

            this.CurrentPlayerPosition = position;
        }

        public void SetPreviousPlayerMapID()
        {
            this.PreviousPlayerMapID = this.CurrentPlayerMapID;
        }

        public void ResetPlayerMapID()
        {
            //Console.WriteLine("Reseting CurrentPlayerMapID from {0} to {1}.", CurrentPlayerPosition, this.PreviousPlayerMapID);
            this.CurrentPlayerMapID = this.PreviousPlayerMapID;
        }

        public void LogOutCurrentPlayer()
        {
            Objects.Clear();

            CurrentPlayerWoWGuid = null;
            CurrentPlayerPhaseMask = 1;
            PreviousPlayerMapID = 0;
            CurrentPlayerMapID = 0;
            CurrentPlayerPosition = new Vector4();
            CurrentPlayerLevel = 0;
            CurrentPlayerInstanceDifficulty = null;
        }


    }
}
