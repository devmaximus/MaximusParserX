using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Conversions
{
    public static class CustomFindOpcode
    {
        public static void FindOpcodes(string source, string query)
        {
            var files = System.IO.Directory.GetFiles(source, "*.sqlite", System.IO.SearchOption.AllDirectories).OrderByDescending(t => t);

            foreach (var file in files)
            {
                using (var con = new System.Data.SQLite.SQLiteConnection("Data Source=" + file))
                {
                    con.Open();
                    using (var sqlcommand = con.CreateCommand())
                    {
                        sqlcommand.CommandText = "select count(*) from packets where opcode in (" + query + ")";
                        var reader = sqlcommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var found = reader.GetInt32(0);
                            if (found > 0)
                            {
                                System.Diagnostics.Debug.WriteLine(file + "\t" + found);
                            }
                            break;
                        }
                    }

                    con.Close();
                }
            }
        }
    }
}
