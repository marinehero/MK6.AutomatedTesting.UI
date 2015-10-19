using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MK6.AutomatedTesting.ETL.Extensions
{

    public static class DBExtensions
    {
        public static string BuildSQL(string fileName, string fieldName = null)
        {
            var sqlFile = string.Format(@"..\SqlScripts\{0}.sql", fileName);

            string result;
            try
            {
                result = File.ReadAllText(sqlFile);
                //using (var sqlStream = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(sqlFile)))
                //{
                //    result = sqlStream.ReadToEnd();
                //}
            }
            catch (Exception e)
            {
                throw new FileNotFoundException(
                    $"File not found: {sqlFile}\r\nCurrent path is {Directory.GetCurrentDirectory()}");
            }
            if (fieldName != null)
            {
                result = result.Replace("COLUMN_TO_BE_REPLACED", fieldName);
            }
            var environment = BuildConfiguration();

            result = result.Replace("$env$", environment);
            return result;
        }

        public static string BuildConfiguration()
        {
            var environment = "DEV";
#if QA
            environment= "QA";
#endif
            return environment;
        }

        public static string BuildSQL(string fileName, Dictionary<string, string> parameters)
        {
            string environmentCorrectedSQL = BuildSQL(fileName);
            return environmentCorrectedSQL.ReplaceParametersFromDictionary(parameters);
        }


    }
}
