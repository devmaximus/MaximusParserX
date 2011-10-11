using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MaximusParserX.Reading;

namespace MaximusParserX.Parsing
{
    public static class ParsingHandler
    {

        public static string GetOpcodeName(uint opcode, Direction direction, ClientBuild clientbuild)
        {
            var name = Enum.GetName(Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.Opcodes", clientbuild)), opcode);

            if (name == null)
                name = string.Format("U{0}_UNWKNOWN_{1}", direction == Direction.ServerToClient ? "SMSG" : "CMSG", opcode);

            return name;
        }

        public static string ValidateMaxUpdateFieldCount(int currentcount, TypeID typeid, ClientBuild clientbuild)
        {
            var max = 0u;
            var msg = string.Empty;
            const string msgformat = "{0} was exceeded with {1} > {2}  for build {3}";

            switch (typeid)
            {
                case TypeID.TYPEID_OBJECT:
                case TypeID.TYPEID_AIGROUP:
                case TypeID.TYPEID_AREATRIGGER:
                    {
                        max = 7;
                    } break;
                case TypeID.TYPEID_CONTAINER:
                case TypeID.TYPEID_ITEM:
                    {
                        max = GetItemUpdateFieldMax(clientbuild);
                        msg = string.Format(msgformat, "ItemUpdateFieldMax", currentcount, max, clientbuild);

                    } break;
                case TypeID.TYPEID_CORPSE:
                    {
                        max = GetCorpseUpdateFieldMax(clientbuild);
                        msg = string.Format(msgformat, "CorpseUpdateFieldMax", currentcount, max, clientbuild);

                    } break;
                case TypeID.TYPEID_DYNAMICOBJECT:
                    {
                        max = GetDynamicObjectUpdateFieldMax(clientbuild);
                        msg = string.Format(msgformat, "DynamicObjectUpdateFieldMax", currentcount, max, clientbuild);

                    } break;
                case TypeID.TYPEID_GAMEOBJECT:
                    {
                        max = GetGameObjectUpdateFieldMax(clientbuild);
                        msg = string.Format(msgformat, "GameObjectUpdateFieldMax", currentcount, max, clientbuild);
                    } break;
                case TypeID.TYPEID_UNIT:
                case TypeID.TYPEID_PLAYER:
                    {
                        max = GetUnitUpdateFieldMax(clientbuild);
                        msg = string.Format(msgformat, "UnitUpdateFieldMax", currentcount, max, clientbuild);
                    } break;
            }

            return msg;
        }

        public static uint GetUpdateFieldMax(TypeID typeid, ClientBuild clientbuild)
        {
            uint max = 7;

            switch (typeid)
            {
                //case TypeID.TYPEID_OBJECT:
                //case TypeID.TYPEID_AIGROUP:
                //case TypeID.TYPEID_AREATRIGGER:
                //    {
                //        max = 7;
                //    } break;
                case TypeID.TYPEID_CONTAINER:
                case TypeID.TYPEID_ITEM:
                    {
                        max = GetItemUpdateFieldMax(clientbuild);


                    } break;
                case TypeID.TYPEID_CORPSE:
                    {
                        max = GetCorpseUpdateFieldMax(clientbuild);


                    } break;
                case TypeID.TYPEID_DYNAMICOBJECT:
                    {
                        max = GetDynamicObjectUpdateFieldMax(clientbuild);


                    } break;
                case TypeID.TYPEID_GAMEOBJECT:
                    {
                        max = GetGameObjectUpdateFieldMax(clientbuild);

                    } break;
                case TypeID.TYPEID_UNIT:
                case TypeID.TYPEID_PLAYER:
                    {
                        max = GetUnitUpdateFieldMax(clientbuild);

                    } break;
            }
            return max;
        }

        public static string GetGameObjectUpdateFieldName(int index, ClientBuild clientbuild)
        {
            var name = Enum.GetName(GetGameObjectUpdateFieldType(clientbuild), index);
            return name;
        }

        public static Type GetGameObjectUpdateFieldType(ClientBuild clientbuild)
        {
            return Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.GameObjectUpdateFields", clientbuild));
        }

        public static uint GetGameObjectUpdateFieldMax(ClientBuild clientbuild)
        {
            var type = GetGameObjectUpdateFieldType(clientbuild);
            if (type != null)
            {
                return Enum.GetValues(type).Cast<uint>().Max();
            }
            else
            {
                return 0;
            }
        }

        public static string GetCorpseUpdateFieldName(int index, ClientBuild clientbuild)
        {
            var name = Enum.GetName(GetCorpseUpdateFieldType(clientbuild), index);
            return name;
        }

        public static Type GetCorpseUpdateFieldType(ClientBuild clientbuild)
        {
            return Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.CorpseUpdateFields", clientbuild));
        }

        public static uint GetCorpseUpdateFieldMax(ClientBuild clientbuild)
        {
            var type = GetCorpseUpdateFieldType(clientbuild);
            if (type != null)
            {
                return Enum.GetValues(type).Cast<uint>().Max();
            }
            else
            {
                return 0;
            }
        }

        public static string GetItemUpdateFieldName(int index, ClientBuild clientbuild)
        {
            var name = Enum.GetName(Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.ItemUpdateFields", clientbuild)), index);
            return name;
        }

        public static Type GetItemUpdateFieldType(ClientBuild clientbuild)
        {
            return Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.ItemUpdateFields", clientbuild));
        }

        public static uint GetItemUpdateFieldMax(ClientBuild clientbuild)
        {
            var type = GetItemUpdateFieldType(clientbuild);
            if (type != null)
            {
                return Enum.GetValues(type).Cast<uint>().Max();
            }
            else
            {
                return 0;
            }
        }

        public static string GetDynamicObjectUpdateFieldName(int index, ClientBuild clientbuild)
        {
            var name = Enum.GetName(GetDynamicObjectUpdateFieldType(clientbuild), index);
            return name;
        }

        public static Type GetDynamicObjectUpdateFieldType(ClientBuild clientbuild)
        {
            return Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.DynamicObjectUpdateFields", clientbuild));
        }

        public static uint GetDynamicObjectUpdateFieldMax(ClientBuild clientbuild)
        {
            var type = GetDynamicObjectUpdateFieldType(clientbuild);
            if (type != null)
            {
                return Enum.GetValues(type).Cast<uint>().Max();
            }
            else
            {
                return 0;
            }
        }

        public static string GetUnitUpdateFieldName(int index, ClientBuild clientbuild)
        {
            var name = Enum.GetName(GetUnitUpdateFieldType(clientbuild), index);
            return name;
        }

        public static Type GetUnitUpdateFieldType(ClientBuild clientbuild)
        {
            return Type.GetType(string.Format("MaximusParserX.Parsing.Version.{0}.Enums.UnitUpdateFields", clientbuild));
        }

        public static uint GetUnitUpdateFieldMax(ClientBuild clientbuild)
        {
            var type = GetUnitUpdateFieldType(clientbuild);
            if (type != null)
            {
                return Enum.GetValues(type).Cast<uint>().Max();
            }
            else
            {
                return 0;
            }
        }

        public static MaximusParserX.Reading.DefinitionBase GetDefinition(DefinitionContext context, ClientBuild clientbuild, string opcodename, uint opcode)
        {

            var obj = Type.GetType(string.Format("MaximusParserX.Parsing.Parsers.{0}_DEF", opcodename));

            if (obj == null)
            {
                obj = Type.GetType("MaximusParserX.Parsing.Parsing.UnknownDef");
            }

            if (obj != null)
            {
                var def = (DefinitionBase)Activator.CreateInstance(obj);
                def.Initialize(context);
                return def;
            }
            else
            {
                return null;
            }
        }
    }
}
