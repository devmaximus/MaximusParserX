
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MaximusParserX.Data
{
    public abstract class MySQLDBBase
    {
        private string connectionstring = string.Empty;

        public MySQLDBBase(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public MySQLDBBase(string server, uint port, string database, string userid, string password)
        {
            this.connectionstring = GetConnectionString(server, port, database, userid, password);
        }

        public MySqlConnection connection
        {
            get
            {
                return new MySqlConnection(connectionstring);
            }
        }

        public System.Data.DataSet ExecuteGetDataSet(string commandtext)
        {
            var dataset = new System.Data.DataSet();

            using (var con = connection)
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(commandtext, con))
            {
                adapter.UpdateBatchSize = 500;
                adapter.ContinueUpdateOnError = false;
                con.Open();
                adapter.Fill(dataset);
                con.Close();
            }

            return dataset;
        }

        public System.Data.DataTable ExecuteGetDataTable(string commandtext)
        {
            var datatable = new System.Data.DataTable();
            using (var con = connection)
            using (var adapter = new MySqlDataAdapter(commandtext, con))
            {
                adapter.ContinueUpdateOnError = false;
                con.Open();
                adapter.Fill(datatable);
                con.Close();
            }

            return datatable;
        }

        public int ExecuteNonQuery(string commandtext)
        {
            var result = 0;

            using (var con = connection)
            using (var adapter = new MySqlDataAdapter())
            {
                adapter.UpdateBatchSize = 500;
                adapter.ContinueUpdateOnError = false;
                adapter.SelectCommand = new MySqlCommand(commandtext, con);
                con.Open();
                result = adapter.SelectCommand.ExecuteNonQuery();
                con.Close();
            }

            return result;
        }

        public Exception TestConnection()
        {
            try
            {
                using (var con = connection)
                {
                    con.Open();
                    con.Close();
                }
            }
            catch (Exception exc)
            {
                return exc;
            }

            return null;
        }

        public List<string> GetDatabases()
        {
            return GetList("show databases;", "(not database = 'mysql' AND not database = 'information_schema')");
        }

        private List<string> GetList(string command, string select)
        {
            var list = new List<string>();

            using (var datatable = ExecuteGetDataTable(command))
            {
                var rows = datatable.Select(select, datatable.Columns[0].ColumnName + " asc");
                foreach (var row in rows)
                {
                    list.Add(row[0].ToString());
                }
            }

            return list;
        }

        public List<string> GetTables()
        {
            return GetList("show tables;", "");
        }

        public System.Data.DataTable GetTableColumns(string tablename)
        {
            return ExecuteGetDataTable("DESCRIBE `" + tablename + "`;");

        }

        public static string GetConnectionString(string server, uint port, string database, string userid, string password)
        {
            var builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder()
           {
               AllowBatch = true,
               Database = database,
               UserID = userid,
               Password = password,
               Server = server,
               Port = port, //3306
               PersistSecurityInfo = false,
           };

            return builder.ConnectionString;
        }
    }
}


