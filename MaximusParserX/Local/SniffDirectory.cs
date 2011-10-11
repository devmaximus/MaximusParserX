using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Local
{
    public class SniffDirectory : Base.DataObjectBase
    {
        public string Directory { get; set; }
        public bool Include { get; set; }
        public string SearchPattern { get; set; }
        public bool Recursive { get; set; }

        public SniffDirectory() : base() { }
        public SniffDirectory(bool isnew) : base(isnew) { }

        public bool DirectoryExists()
        {
            return System.IO.Directory.Exists(Directory);
        }

        public System.IO.DirectoryInfo DirectoryInfo
        {
            get
            {
                if (DirectoryExists())
                    return new System.IO.DirectoryInfo(Directory);
                else
                    return null;
            }
        }

        public List<System.IO.FileInfo> GetFiles()
        {
            var files = new List<System.IO.FileInfo>();
            var directoryInfo = DirectoryInfo;

            if (directoryInfo != null && !SearchPattern.IsEmpty())
            {
                var patternArray = SearchPattern.Split(new char[] { ';' });

                foreach (var pattern in patternArray)
                {
                    files.AddRange(directoryInfo.GetFiles(SearchPattern, Recursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly));
                }
            }
            return files;
        }
    }
}
