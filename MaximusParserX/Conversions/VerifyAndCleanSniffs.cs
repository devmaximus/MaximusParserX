using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Conversions
{
    public static class VerifyAndCleanSniffs
    {
        public static void ProcessSniffs()
        {
            ProcessSniffs(@"E:\HFS\WOWDEV\SNIFFS", @"E:\HFS\WOWDEV\SNIFFS_CLEAN\");
        }

        public static void ProcessSniffs(string fromdir, string todir)
        {
            var files = System.IO.Directory.GetFiles(fromdir, "*.sqlite", System.IO.SearchOption.AllDirectories);

            foreach (var file in files)
            {
                ProcessSniff(file, todir);
            }
        }

        public static void ProcessSniff(string filename, string todir)
        {
            var clientbuild = 0u;
            var accountname = string.Empty;

            var logstarted = DateTime.Now;
            bool found = false;
            bool empty = false;

            using (var findcon = new System.Data.SQLite.SQLiteConnection())
            {
                findcon.ConnectionString = "Data Source=" + filename;
                findcon.Open();

                using (var tSQLiteCommand = findcon.CreateCommand())
                {
                    var CMSG_AUTH_SESSION = 0x1ED;
                    tSQLiteCommand.CommandText = string.Format("select id, timestamp, direction, opcode, data from packets where opcode = {0} limit 1", CMSG_AUTH_SESSION);
                    using (var tempreader = tSQLiteCommand.ExecuteReader())
                    {
                        while (tempreader.Read())
                        {
                            var id = tempreader.GetInt32(0);
                            logstarted = tempreader.GetDateTime(1);
                            var direction = tempreader.GetInt32(2);
                            var opcode = tempreader.GetInt32(3);
                            var blob = (byte[])tempreader.GetValue(4);

                            using (var qs = new Reading.ReadingBase(blob))
                            {
                                found = true;

                                clientbuild = qs.ReadUInt32();

                                qs.ReadUInt32();

                                accountname = qs.ReadCString();

                                if (accountname.IsEmpty())
                                {
                                    Console.WriteLine("Error");
                                }
                                break;
                            }

                        }
                        tempreader.Close();

                        empty = (clientbuild == 0);

                    }
                }

                if (!empty)
                {
                    if (!found) throw new Exception("Invalid file");
                    string newdir = string.Format("{0}{1}\\", todir, clientbuild);
                    string newfile = string.Format(@"{0}{1}_{2}_{3}.sqlite", newdir, logstarted.ToString("yyyy-MM-dd-HH-mm"), clientbuild, accountname);

                    if (System.IO.File.Exists(newfile)) System.IO.File.Delete(newfile);// throw new Exception("File exists");
                    if (!System.IO.Directory.Exists(newdir)) System.IO.Directory.CreateDirectory(newdir);

                    System.Data.SQLite.SQLiteConnection.CreateFile(newfile);

                    var builder = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                    builder.DataSource = newfile;
                    builder.CacheSize = builder.CacheSize * 100;
                    builder.PageSize = builder.PageSize * 100;
                    builder.JournalMode = System.Data.SQLite.SQLiteJournalModeEnum.Off;
                    builder.Pooling = false;

                    DateTime tstart = DateTime.Now;
                    using (var con = new System.Data.SQLite.SQLiteConnection(builder.ConnectionString))
                    {
                        con.Open();

                        //create tables
                        var sb = new StringBuilder();

                        sb.AppendLine("create table packets (id integer primary key autoincrement, timestamp datetime, direction integer, opcode integer, data blob);");
                        sb.AppendLine("create table header (key string primary key, value string);");
                        sb.AppendLine(string.Format("insert into header(key, value) values ('clientBuild', '{0}');", clientbuild));
                        sb.AppendLine("insert into header(key, value) values ('clientLang', 'enUS');");
                        sb.AppendLine(string.Format("insert into header(key, value) values ('accountName', '{0}');", accountname));

                        using (System.Data.SQLite.SQLiteCommand command = con.CreateCommand())
                        {
                            command.CommandText = sb.ToString();
                            command.ExecuteNonQuery();
                        }

                        Console.WriteLine("start processing newfile: {0} filename: {1}", tstart, newfile);

                        try
                        {

                            using (var dbTrans = con.BeginTransaction())
                            {
                                using (var command = con.CreateCommand())
                                {
                                    command.CommandText = "insert into packets (timestamp, direction, opcode, data) VALUES (?,?,?,?)";

                                    var timestamp = command.CreateParameter();
                                    timestamp.DbType = System.Data.DbType.DateTime;
                                    command.Parameters.Add(timestamp);

                                    var direction = command.CreateParameter();
                                    direction.DbType = System.Data.DbType.Int32;
                                    command.Parameters.Add(direction);

                                    var opcode = command.CreateParameter();
                                    opcode.DbType = System.Data.DbType.Int32;
                                    command.Parameters.Add(opcode);

                                    var data = command.CreateParameter();
                                    data.DbType = System.Data.DbType.Binary;
                                    command.Parameters.Add(data);

                                    using (var tSQLiteCommand = findcon.CreateCommand())
                                    {
                                        var t = DateTime.Now;

                                        tSQLiteCommand.CommandText = "select * from packets ";
                                        using (var tempreader = tSQLiteCommand.ExecuteReader())
                                        {
                                            bool badopcode = false;

                                            try
                                            {

                                                while (tempreader.Read())
                                                {
                                                    var _id = tempreader.GetInt32(0);
                                                    var _timestamp = tempreader.GetDateTime(1);
                                                    var _direction = tempreader.GetInt32(2);
                                                    var _opcode = tempreader.GetInt32(3);
                                                    var _blob = (byte[])tempreader.GetValue(4);

                                                    if (_opcode > 1311)
                                                    {
                                                        Console.WriteLine("Error: Invalid opcode {0}", _opcode);
                                                        break;
                                                    }
                                                    else if (!badopcode)
                                                    {
                                                        try
                                                        {
                                                            timestamp.Value = _timestamp;
                                                            direction.Value = _direction;
                                                            opcode.Value = _opcode;
                                                            data.Value = _blob;

                                                            if (command.ExecuteNonQuery() <= 0)
                                                            {
                                                                throw new Exception("record not inserted?");
                                                            }
                                                        }
                                                        catch (Exception exc)
                                                        {
                                                            Console.WriteLine("Error: {0}", exc.Message);
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception exc)
                                            {
                                                Console.WriteLine("Error: {0}", exc.Message);
                                            }

                                            tempreader.Close();
                                        }
                                    }
                                }

                                dbTrans.Commit();
                            }
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine("Error: {0}", exc.Message);

                        }

                        con.Close();
                    }

                }
            }



        }
    }
}
