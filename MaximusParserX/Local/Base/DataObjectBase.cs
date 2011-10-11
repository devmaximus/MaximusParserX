using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Local.Base
{
    public abstract class DataObjectBase
    {
        public DataObjectBase() { }
        public DataObjectBase(bool isnew)
        {
            if (isnew)
            {
                DataObjectGUID = Guid.NewGuid();
                Created = DateTime.Now;
            }
        }

        public DateTime? Created { get; set; }
        public Guid DataObjectGUID { get; set; }
        public DateTime? Updated { get; set; }
    }
}
