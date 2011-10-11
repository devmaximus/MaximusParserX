using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL
{
    public static class GameObjectSpawnHandler
    {
        public static IDictionary<string, Custom.gameobject_spawn> GameObjectSpawnList = new Dictionary<string, Custom.gameobject_spawn>();

        public static void AddGameObjectSpawn(WoW.GameObject gameobject)
        {
            var gameobjectspawn = new Custom.gameobject_spawn()
            {
                guid = gameobject.Guid.Full,
                map = (ushort?)gameobject.MapID,
                clientbuild =  gameobject.Core.ClientBuildAmount,
                phasemask = (ushort?)gameobject.PhaseMask,
                position_x = gameobject.MovementInfo.PositionInfo_0x100.X,
                position_y = gameobject.MovementInfo.PositionInfo_0x100.Y,
                position_z = gameobject.MovementInfo.PositionInfo_0x100.Z,
                orientation = gameobject.MovementInfo.PositionInfo_0x100_2.O,
                rotation0 = gameobject.MovementInfo.GameObjectRotation.X,
                rotation1 = gameobject.MovementInfo.GameObjectRotation.Y,
                rotation2 = gameobject.MovementInfo.GameObjectRotation.Z,
                rotation3 = gameobject.MovementInfo.GameObjectRotation.W,
                state = 1,
            };

            if (gameobject.MovementInfo.UpdateFlags.HasFlag(MaximusParserX.OBJECT_UPDATE_FLAGS.UPDATEFLAG_TRANSPORT))
            {
                gameobjectspawn.position_x = gameobject.MovementInfo.PositionInfo_0x40.X;
                gameobjectspawn.position_y = gameobject.MovementInfo.PositionInfo_0x40.Y;
                gameobjectspawn.position_z = gameobject.MovementInfo.PositionInfo_0x40.Z;
                gameobjectspawn.orientation = gameobject.MovementInfo.PositionInfo_0x40.O;
            }

            var key = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", gameobject.Core.ClientBuildAmount, gameobject.Guid.Full, gameobjectspawn.position_x, gameobjectspawn.position_y, gameobjectspawn.position_z, gameobjectspawn.orientation, gameobjectspawn.phasemask);

            if (gameobjectspawn.position_x == 0 && gameobjectspawn.position_y == 0 && gameobjectspawn.position_z == 0)
            {

            }
            else
            {
                if (!GameObjectSpawnList.ContainsKey(key))
                {
                    var shouldcommit = true;

                    foreach (var updatefield in gameobject.UpdateFields)
                    {
                        var updatefieldname = MaximusParserX.Parsing.ParsingHandler.GetGameObjectUpdateFieldName(updatefield.Key, (ClientBuild)gameobject.Core.ClientBuildAmount);

                        switch (updatefieldname)
                        {
                            case "OBJECT_FIELD_CREATED_BY":
                                {
                                    shouldcommit = false;
                                    break;
                                }
                            case "OBJECT_FIELD_ENTRY":
                                {
                                    gameobjectspawn.entry = (uint?)updatefield.Value.Int32Value;
                                    break;
                                }
                            case "GAMEOBJECT_ANIMPROGRESS":
                                {
                                    gameobjectspawn.animprogress = (byte?)updatefield.Value.Int32Value;
                                    break;
                                }
                            case "GAMEOBJECT_STATE":
                                {
                                    gameobjectspawn.state = (byte?)updatefield.Value.Int32Value;
                                    break;
                                }
                            case "GAMEOBJECT_ROTATION":
                                {
                                    if (gameobject.Core.ClientBuildAmount >= 9183 && gameobject.Core.ClientBuildAmount <= 9551)
                                    {
                                        var low = (uint)gameobject.UpdateFields[updatefield.Key].Int32Value;
                                        var high = (uint)0;

                                        if (gameobject.UpdateFields.ContainsKey(updatefield.Key + 1)) high = (uint)gameobject.UpdateFields[updatefield.Key + 1].Int32Value;
                                        long packed = (long)((ulong)high << 32 | low);

                                        var x = (packed >> 42) * (1.0f / 2097152.0f);
                                        var y = (((packed << 22) >> 32) >> 11) * (1.0f / 1048576.0f);
                                        var z = (packed << 43 >> 43) * (1.0f / 1048576.0f);

                                        var w = x * x + y * y + z * z;
                                        if (Math.Abs(w - 1.0f) >= (1 / 1048576.0f))
                                            w = (float)Math.Sqrt(1.0f - w);
                                        else
                                            w = 0.0f;

                                        var t = new Quaternion(x, y, z, w);

                                        gameobjectspawn.rotation0 = x;
                                        gameobjectspawn.rotation1 = y;
                                        gameobjectspawn.rotation2 = z;
                                        gameobjectspawn.rotation3 = w;
                                    }
                                    else if (gameobject.Core.ClientBuildAmount <= 8125)
                                    {
                                        gameobjectspawn.rotation0 = updatefield.Value.FloatValue;
                                    }
                                    break;
                                }

                            case "GAMEOBJECT_ROTATION_1":
                                {
                                    gameobjectspawn.rotation1 = updatefield.Value.FloatValue;
                                    break;
                                }
                            case "GAMEOBJECT_ROTATION_2":
                                {
                                    gameobjectspawn.rotation2 = updatefield.Value.FloatValue;
                                    break;
                                }
                            case "GAMEOBJECT_ROTATION_3":
                                {
                                    gameobjectspawn.rotation3 = updatefield.Value.FloatValue;
                                    break;
                                }
                            case "GAMEOBJECT_PARENTROTATION":
                                {
                                    gameobjectspawn.parentrotation0 = updatefield.Value.FloatValue;
                                    break;
                                }
                            case "GAMEOBJECT_PARENTROTATION_1":
                                {
                                    gameobjectspawn.parentrotation1 = updatefield.Value.FloatValue;
                                    break;
                                }
                            case "GAMEOBJECT_PARENTROTATION_2":
                                {
                                    gameobjectspawn.parentrotation2 = updatefield.Value.FloatValue;
                                    break;
                                }
                            case "GAMEOBJECT_PARENTROTATION_3":
                                {
                                    gameobjectspawn.parentrotation3 = updatefield.Value.FloatValue;
                                    break;
                                }
                        }

                        if (gameobjectspawn.animprogress == 100)
                        {
                            gameobjectspawn.parentrotation0 = null;
                            gameobjectspawn.parentrotation1 = null;
                            gameobjectspawn.parentrotation2 = null;
                            gameobjectspawn.parentrotation3 = null;
                        }

                        if (!shouldcommit) break;
                    }

                    if (shouldcommit)
                        GameObjectSpawnList.Add(key, gameobjectspawn);
                }
            }
        }

        public static string DumpToSQLFile()
        {
            var file = "GameObjectSpawnLog_" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".sql";
            var items = MaximusParserX.Dump.SQL.GameObjectSpawnHandler.GameObjectSpawnList.OrderByDescending(t => t.Key);
            using (var sw = new System.IO.StreamWriter(file))
            {
                uint id = 0;

                foreach (var item in items)
                {
                    id++;
                    item.Value.id = id;
                    sw.WriteLine(item.Value.GetInsertCommand());
                }
            }

            GameObjectSpawnList.Clear();

            return file;
        }
    }
}
