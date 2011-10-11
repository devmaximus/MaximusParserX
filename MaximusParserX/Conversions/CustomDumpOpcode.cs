using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Conversions
{

    public class ClientBuildCache
    {
        public uint ClientBuild { get; set; }
        public List<OpcodeCache> OpcodeList { get; set; }
    }

    public class OpcodeCache
    {
        public uint Opcode { get; set; }
        public uint Direction { get; set; }
    }

    public class CustomDumpOpcode
    {


        public static void DumpOpcodes()
        {
            var files = System.IO.Directory.GetFiles(@"E:\HFS\WOWDEV\SNIFFS_CLEAN\", "*.sqlite", System.IO.SearchOption.AllDirectories).OrderBy(t => t);

            var versionOpcodeList = new System.Collections.Generic.SortedList<uint, ClientBuildCache>();

            foreach (var file in files)
            {
                uint clientBuild = 0;

                using (var con = new System.Data.SQLite.SQLiteConnection("Data Source=" + file))
                {
                    con.Open();
                    using (var sqlcommand = con.CreateCommand())
                    {
                        sqlcommand.CommandText = "select key, value from header where key = 'clientBuild'";
                        var reader = sqlcommand.ExecuteReader();

                        while (reader.Read())
                        {
                            clientBuild = (uint)reader.GetInt32(1);
                            break;
                        }
                    }

                    if (!versionOpcodeList.ContainsKey(clientBuild))
                    {
                        versionOpcodeList.Add(clientBuild, new ClientBuildCache() { ClientBuild = clientBuild, OpcodeList = new List<OpcodeCache>() });
                    }

                    var clientBuildOpcodes = versionOpcodeList[clientBuild];

                    using (var sqlcommand = con.CreateCommand())
                    {
                        sqlcommand.CommandText = "select distinct opcode, direction from packets order by opcode , direction";
                        var reader = sqlcommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var opcode = (uint)reader.GetInt32(0);
                            var direction = (byte)reader.GetInt32(1);

                            if (!clientBuildOpcodes.OpcodeList.Exists(t => t.Opcode == opcode && t.Direction == direction))
                                clientBuildOpcodes.OpcodeList.Add(new OpcodeCache() { Direction = direction, Opcode = opcode });
                        }
                    }

                    con.Close();
                }
            }

            var clientBuildOpcodeList = versionOpcodeList.Select(t => t.Value).ToList();

            clientBuildOpcodeList.SaveObject("clientBuildOpcodeList.xml");
        }

    }
}
