using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MK6.AutomatedTesting.ETL.Extensions;

namespace MK6.AutomatedTesting.ETL.Database
{
    public class Database
    {
        private static string _connectionString;
        private static readonly Dictionary<string, string> ResultCache = new Dictionary<string, string>();


        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static IDbConnection GetConneciton()
        {
            var connection = new OdbcConnection(_connectionString);
            connection.ConnectionTimeout = 120;
            connection.Open();
            return connection;
        }

        public IDbConnection GetConnection()
        {
            return GetConneciton();
        }

        public string ExecuteSQL(string sqlQuery, string sqlSource = "")
        {
            string result;

            if (ResultCache.ContainsKey(sqlQuery))
            {
                return ResultCache[sqlQuery];
            }

            using (var con = UtilityExtension.GetConnection(sqlSource))
            {
                result = con.ExecuteScalar(sqlQuery).ToString();
            }
            ResultCache[sqlQuery] = result;
            return result;

        }
    }
}
