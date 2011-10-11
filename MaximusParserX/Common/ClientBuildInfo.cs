using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximusParserX
{
    public static class ClientBuildInfo
    {
        public static IDictionary<int, string> clientVersionList = GetClientVersionList(); 

        private static IDictionary<int, string> GetClientVersionList()
        {
            var clientBuildList = new Dictionary<int, string>();

            var names = Enum.GetNames(typeof(MaximusParserX.ClientBuild));

            Parallel.ForEach(names, name =>
                {
                    MaximusParserX.ClientBuild value;
                    Enum.TryParse<MaximusParserX.ClientBuild>(name, out value);
                    clientBuildList.Add((int)value, name.ToString().Replace("v", string.Empty).Replace("_", "."));
                });
             
            return clientBuildList;
        }
    }
}
