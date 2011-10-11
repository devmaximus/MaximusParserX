using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL
{
    public abstract class CustomDumpObjectBase : DumpObjectBase
    {
        public System.Int32? clientbuild;

        public CustomDumpObjectBase(string tablename)
            : base(tablename)
        {
        }

        public virtual string GetInsertCommandCustomFields()
        {
            return " ,`clientbuild`";
        }

        public virtual string GetInsertCommandCustomValues()
        {
            return string.Format(", '{0}'", clientbuild.GetValueOrDefault());
        }
    }
}
