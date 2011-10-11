using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Dump.SQL
{
    public abstract class DumpObjectBase
    {

        public DumpObjectBase(string tablename)
        {
        }

        public virtual string GetInsertCommand()
        {
            return null;
        }

        public virtual string GetUpdateCommand()
        {
            return null;
        }

        public virtual string GetDeleteCommand()
        {
            return null;
        }

        public virtual void WriteSQLToFile()
        {
            var dir = @".\sqlupdates\";
            if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            var insertsql = GetInsertCommand();
            var dirandname = dir + this.GetType().FullName;

            if (!insertsql.IsEmpty())
            {
                using (var sw = new System.IO.StreamWriter(dirandname + "_insert.sql", true))
                {
                    sw.WriteLine(insertsql);
                    sw.Close();
                }
            }
            var updatesql = GetUpdateCommand();
            if (!updatesql.IsEmpty())
            {
                using (var sw = new System.IO.StreamWriter(dirandname + "_update.sql", true))
                {
                    sw.WriteLine();
                    sw.Close();
                }
            }
        }
    }
}
