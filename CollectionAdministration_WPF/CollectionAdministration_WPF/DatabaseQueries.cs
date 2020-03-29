using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace CollectionAdministration_WPF
{
    public static class DatabaseQueries
    {
        private static readonly OleDbConnection dbConnection;

        static DatabaseQueries()
        {
            dbConnection = new OleDbConnection()
            {
                ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0.;Data Source=.\CollecteTellingen.mdb;User Id=admin; Password=;"
            };
        }

        public static void InsertCountResult(Dictionary<string, string> countResult)
        {
            if(countResult.Count != 15)
            {
                throw new IndexOutOfRangeException();
            }

            string fields = "";

            string formattedValues = "";

            fields = string.Join(", ", countResult.Keys);

            formattedValues = string.Join(", ", countResult.Values);

            string insertString = $"insert into TellingCollecte ({fields}) values ({formattedValues})";

            using (OleDbCommand cmd = new OleDbCommand(insertString, dbConnection))
            {
                dbConnection.Open();

                cmd.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

        internal static void DeleteCount(int pkCountResult)
        {
            string deleteString = $"delete from TellingCollecte where id={pkCountResult}";

            using (OleDbCommand cmd = new OleDbCommand(deleteString, dbConnection))
            {
                dbConnection.Open();

                cmd.ExecuteNonQuery();

                dbConnection.Close();
            }
        }
    }
}
