using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL.Custom
{
    public class gossip_poi : DumpObjectBase
    {
        public const string TableName = "gossip_poi";

        public System.UInt32? id;
        public System.UInt16? map;
        public System.UInt16? phasemask;
        public System.Int32? clientbuild;
        public UInt32? Flags;
        public float? X;
        public float? Y;
        public UInt32? Icon;
        public UInt32? DataInfo;
        public string IconName;
        
        public override string GetInsertCommand()
        {
            return string.Format("INSERT IGNORE INTO `{0}` (`Id`, `map`, `phasemask`, `clientbuild`, `Flags`, `x`, `y`, `Icon`, `DataInfo`, `IconName`) VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');",
                TableName, 
                id.GetValueOrDefault(),
                map.GetValueOrDefault(),
                phasemask.GetValueOrDefault(),
                clientbuild.GetValueOrDefault(),
                Flags.GetValueOrDefault(), 
                ((Decimal)X.GetValueOrDefault()), 
                ((Decimal)Y.GetValueOrDefault()),
                Icon.GetValueOrDefault(), 
                DataInfo.GetValueOrDefault(),
                IconName.ToSQL());
        }

        public gossip_poi()
            : base(TableName)
        {

        }
    }

}
 
