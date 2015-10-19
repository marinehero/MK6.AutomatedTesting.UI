using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MK6.AutomatedTesting.ETL.Extensions
{
    public static class UtilityExtension
    {
        public static IDbConnection GetConnection(string sqlSource)
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings[string.Format("{0}.DBConnString", sqlSource.ToUpperInvariant())].ConnectionString;
            var connection = new OdbcConnection(connectionString);
            connection.ConnectionTimeout = 120;
            connection.Open();
            return connection;
        }

        public static string ReplaceParametersFromDictionary(this string startString,
    IDictionary<string, string> parameters)
        {
            var upperCaseParameterDictionary = (from x in parameters
                                                select x).ToDictionary(x => x.Key.ToUpperInvariant(), x => x.Value);

            var matchString = new Regex(@"@\w*?@");

            Match m = matchString.Match(startString);
            while (m.Success)
            {
                Group g = m.Groups[0];
                var keySurroundedByAt = g.Captures[0].Value;
                var keyFound = keySurroundedByAt.Replace("@", string.Empty).ToUpperInvariant();
                if (upperCaseParameterDictionary.ContainsKey(keyFound))
                {
                    startString = startString.Replace(keySurroundedByAt, upperCaseParameterDictionary[keyFound]);
                }

                m = m.NextMatch();
            }
            return startString;
        }
    }
}
