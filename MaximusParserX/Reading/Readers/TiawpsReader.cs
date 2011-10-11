using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Frame;

namespace MaximusParserX.Reading.Readers
{
    public class TiawpsReader : ReaderBase
    {
        private class Header
        {
            public ClientBuild ClientBuild { get; private set; }
            public string AccountName { get; private set; }
            public string RealmName { get; private set; }
            public string RealmServer { get; private set; }

            public Header(System.Data.SQLite.SQLiteConnection connection)
            {
                System.Collections.Hashtable hash = null;

                using (var sqlcommand = connection.CreateCommand())
                {

                    sqlcommand.CommandText = clientBuildCommand;
                    using (var reader = sqlcommand.ExecuteReader())
                    {
                        var total = reader.RecordsAffected;
                        hash = new System.Collections.Hashtable(total);
                        while (reader.Read())
                        {
                            hash[reader.GetString(0)] = reader.GetValue(1);
                        }
                        reader.Close();
                    }


                }

                ClientBuild = (ClientBuild)int.Parse((string)hash["clientBuild"]);
                AccountName = (string)hash["accountName"];
                RealmName = (string)hash["realmName"];
                RealmServer = (string)hash["realmServer"];


                //connection.Close();
            }
        }

        private Guid readrguid;
        private string name = string.Empty;
        private string fileName = string.Empty;
        private System.Data.SQLite.SQLiteConnection con;
        private System.Data.SQLite.SQLiteDataReader reader;
        private int currentIndex = 0;
        private int maxProcessCount = 300;
        private int? packettotalcount;
        private Header header;
        private UI.DelegateManager delegatemanager;
        private readonly static string clientBuildCommand = "select key, value from header";

        public override Guid ReaderGUID
        {
            get { return readrguid; }
        }

        public override int PacketTotalCount
        {
            get
            {
                if (packettotalcount == null)
                {
                    packettotalcount = GetPacketTotalCount();
                }
                return packettotalcount.Value;
            }
        }

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override int CurrentIndex
        {
            get
            {
                return currentIndex;
            }

            set
            {
                currentIndex = value;
            }
        }

        public override int MaxProcessCount
        {
            get
            {
                return maxProcessCount;
            }

            set
            {
                maxProcessCount = value;
            }
        }

        public override ClientBuild ClientBuild
        {
            get
            {
                return LogHeader.ClientBuild;
            }
        }

        public override int ClientBuildAmount
        {
            get
            {
                return (int)LogHeader.ClientBuild;
            }
        }

        public override string ClientBuildName
        {
            get
            {
                return ClientBuildInfo.clientVersionList[ClientBuildAmount];
            }
        }

        public override string AccountName
        {
            get
            {
                return LogHeader.AccountName;
            }
        }

        public TiawpsReader(UI.DelegateManager delegatemanager, string filename)
        {
            this.delegatemanager = delegatemanager;
            readrguid = Guid.NewGuid();
            this.fileName = filename;
            name = System.IO.Path.GetFileNameWithoutExtension(fileName);
        }

        ~TiawpsReader()
        {
            Close();
        }

        public override void Load()
        {
            Load(string.Empty);
        }

        public override void Load(string filter)
        {
            try
            {
                var sqlcommand = Con.CreateCommand();
                sqlcommand.CommandText = string.Format("select id, timestamp, direction, opcode, data from packets where id >= {0} {1} Limit({2})", currentIndex, filter, maxProcessCount);
                reader = sqlcommand.ExecuteReader();
            }
            catch (Exception exc)
            {
                delegatemanager.AddException(exc);
            }
        }

        public override int GetPacketTotalCount()
        {
            return GetPacketTotalCountByQuery(string.Empty);
        }

        public override int GetPacketTotalCountByQuery(string query)
        {
            var total = 0;

            using (var sqlcommand = Con.CreateCommand())
            {
                sqlcommand.CommandText = string.Format("select count(*) from packets {0}", query);
                using (var tempreader = sqlcommand.ExecuteReader())
                {
                    total = tempreader.RecordsAffected;
                    if (tempreader.Read())
                    {
                        total = tempreader.GetInt32(0);
                    }
                    tempreader.Close();
                }
            }

            return total;
        }

        public static Result IsValid(UI.DelegateManager delegatemanager, string fileName)
        {
            var result = new Result();
            try
            {
                using (var test = new TiawpsReader(delegatemanager,fileName))
                {
                    result.AddResult(test.ValidateFields());
                }
            }
            catch (Exception ex)
            {
                result.AddResult(ex);
            }

            return result;
        }

        public Result ValidateFields()
        {
            var result = new Result();

            using (var sqlcommand = Con.CreateCommand())
            {
                sqlcommand.CommandText = "select * from packets Limit(1)";
                reader = sqlcommand.ExecuteReader();
                var total = reader.RecordsAffected;
                if (reader.FieldCount != 5)
                {
                    result.AddResult(Result.NewError("Invalid FieldCount."));
                }
            }

            return result;
        }

        private Header LogHeader
        {
            get
            {
                if (header == null)
                {

                    header = new Header(Con);
                }

                return header;
            }

        }

        private System.Data.SQLite.SQLiteConnection Con
        {
            get
            {
                if (con == null)
                    con = new System.Data.SQLite.SQLiteConnection();

                if (con.State == System.Data.ConnectionState.Executing)
                    con.Close();

                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.ConnectionString = "Data Source=" + fileName;
                    con.Open();
                }

                if (con.State != System.Data.ConnectionState.Open)
                    throw new Exception(string.Format("failed to open connection {0}", con.ConnectionString));

                return con;
            }
        }

        public override Packet GetNextPacket()
        {
            Packet packet = null;
            try
            {
                if (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var datetime = reader.GetDateTime(1);
                    var direction = (Direction)reader.GetInt32(2);
                    var opcode = (uint)reader.GetInt32(3);
                    var blob = reader.GetValue(4);

                    var data = new byte[0];

                    if (!DBNull.Value.Equals(blob))
                    {
                        data = (byte[])blob;

                        //decompress
                        if (opcode == 502 || opcode == 763 || (ClientBuildAmount < 9183 && opcode == 751))
                        {
                            using (var ms = new System.IO.MemoryStream(data))
                            using (var br = new System.IO.BinaryReader(ms))
                            {
                                var zsstream = new ComponentAce.Compression.Libs.zlib.ZStream();
                                var compdata = new byte[data.Length - 4];
                                System.Array.Copy(data, 4, compdata, 0, data.Length - 4);
                                int decompsize = br.ReadInt32();
                                var decompdata = new byte[decompsize];
                                zsstream.inflateInit();
                                zsstream.avail_in = compdata.Length;
                                zsstream.next_in = compdata;
                                zsstream.avail_out = decompsize;
                                zsstream.next_out = decompdata;
                                var ret = zsstream.inflate(ComponentAce.Compression.Libs.zlib.zlibConst.Z_NO_FLUSH);
                                var ret2 = zsstream.inflateEnd();

                                data = decompdata;
                            }
                        }
                    }

                    packet = new Packet(id, datetime, direction, opcode, data, data.Length, ClientBuild);

                    currentIndex = id;
                }

            }
            catch (Exception exc)
            {
                delegatemanager.AddException(exc);
            }

            return packet;
        }

        public override int SkipPackets(int count)
        {
            if (reader != null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        currentIndex = id;
                    }
                }
            }

            return currentIndex;
        }

        public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
        {
            var buffer = new byte[2000];
            int len;
            while ((len = input.Read(buffer, 0, 2000)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }

        private byte[] decompress(byte[] inData)
        {
            byte[] result = null;
            using (var outMemoryStream = new System.IO.MemoryStream())
            using (var inMemoryStream = new System.IO.MemoryStream(inData))
            using (var outZStream = new ComponentAce.Compression.Libs.zlib.ZOutputStream(outMemoryStream))
            {
                try
                {
                    CopyStream(inMemoryStream, outZStream);
                    result = new byte[outMemoryStream.Length];
                    outMemoryStream.Position = 0;
                    var ok = outMemoryStream.Read(result, 0, (int)outMemoryStream.Length);
                }
                finally
                {
                    outZStream.Close();
                    outMemoryStream.Close();
                    inMemoryStream.Close();
                }
            }

            return result;

        }

        public override void Close()
        {
            if (reader != null)
            {
                if (con.State != System.Data.ConnectionState.Closed)
                    reader.Close();
                currentIndex = 0;
                packettotalcount = null;

            }
            if (con != null)
            {
                con.Close();
                con = null;
            }
            header = null;
            reader = null;
        }

        public override void Reset()
        {
            Close();
            Load();
        }

        public override string FileName
        {
            get { return fileName; }
        }

        public override DateTime CreatedDateTime
        {
            get { return (new System.IO.FileInfo(fileName)).CreationTime; }
        }

        public override string TypeName
        {
            get { return "SQLite"; }
        }

        public override string FileSize
        {
            get { return (new System.IO.FileInfo(fileName)).GetFileSize(); }
        }
    }

}
