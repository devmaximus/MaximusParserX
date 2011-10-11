using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{

    public class gameobject_spawn : DumpObjectBase
    {
        public const string TableName = "gameobject_spawn";

        public System.UInt32? id;
        public System.UInt64? guid;
        public System.UInt32? entry;
        public System.UInt16? map;
        public System.Byte? spawnmask;
        public System.UInt16? phasemask;
        public float? position_x;
        public float? position_y;
        public float? position_z;
        public float? orientation;
        public float? rotation0;
        public float? rotation1;
        public float? rotation2;
        public float? rotation3;
        public float? parentrotation0;
        public float? parentrotation1;
        public float? parentrotation2;
        public float? parentrotation3;
        public System.Int32? spawntimesecs;
        public System.Byte? animprogress;
        public System.Byte? state;
        public System.Int32? clientbuild;

        public override string GetInsertCommand()
        {
            return string.Format("INSERT IGNORE INTO `{0}` (`Id`, `guid`, `Entry`, `map`, `spawnmask`, `phasemask`, `position_x`, `position_y`, `position_z`, `orientation`, `rotation0`, `rotation1`, `rotation2`, `rotation3`, `parentrotation0`, `parentrotation1`, `parentrotation2`, `parentrotation3`, `spawntimesecs`, `animprogress`, `state`, `clientbuild`) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}');", TableName, id.GetValueOrDefault(), guid.GetValueOrDefault(), entry.GetValueOrDefault(), map.GetValueOrDefault(), spawnmask.GetValueOrDefault(), phasemask.GetValueOrDefault(), ((Decimal)position_x.GetValueOrDefault()), ((Decimal)position_y.GetValueOrDefault()), ((Decimal)position_z.GetValueOrDefault()), ((Decimal)orientation.GetValueOrDefault()), ((Decimal)rotation0.GetValueOrDefault()), ((Decimal)rotation1.GetValueOrDefault()), ((Decimal)rotation2.GetValueOrDefault()), ((Decimal)rotation3.GetValueOrDefault()), ((Decimal)parentrotation0.GetValueOrDefault()), ((Decimal)parentrotation1.GetValueOrDefault()), ((Decimal)parentrotation2.GetValueOrDefault()), ((Decimal)parentrotation3.GetValueOrDefault()), spawntimesecs.GetValueOrDefault(), animprogress.GetValueOrDefault(), state.GetValueOrDefault(), clientbuild.GetValueOrDefault());
        }

        public gameobject_spawn()
            : base(TableName)
        {

        }

    }

}
