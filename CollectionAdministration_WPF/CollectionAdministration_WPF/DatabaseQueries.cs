using System;
using System.Collections.Generic;
using System.Data.OleDb;
using CollectionAdministration_WPF.DTO;
using CollectionAdministration_WPF.Enums;

namespace CollectionAdministration_WPF
{
    public static class DatabaseQueries
    {
        private static readonly string ConnectionString;

        static DatabaseQueries()
        {
            ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0.;Data Source=.\CollectionCount.mdb;User Id=admin; Password=;";
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

            string insertString = $"insert into CollectionCount ({fields}) values ({formattedValues});";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmd = new OleDbCommand(insertString, connection);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void DeleteCount(int pkCountResult)
        {
            string deleteString = $"delete from CollectionCount where id={pkCountResult};";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand command = new OleDbCommand(deleteString, connection);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static CollectionCount GetCollectionCount(int collectionCountId)
        {
            string selectCountString = $"select * from TellingCollecte where CollectionCountId = {collectionCountId};";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand command = new OleDbCommand(selectCountString);

                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                return GetCountCollectionFromDataReaderFields(reader);
            };
        }

        public static List<CollectionCount> GetCollectionCounts()
        {
            List<CollectionCount> collectionCountsList = new List<CollectionCount>();

            string selectAllString = $"select * from CollectionCount;";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbCommand command = new OleDbCommand(selectAllString, connection);

                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    collectionCountsList.Add(GetCountCollectionFromDataReaderFields(reader));
                }

                return collectionCountsList;
            };
        }

        private static CollectionCount GetCountCollectionFromDataReaderFields(OleDbDataReader reader)
        {
            return new CollectionCount()
            {
                CollectionCountId = reader.GetInt32(reader.GetOrdinal("CollectionCountId")),
                DtCountDate = reader.GetDateTime(reader.GetOrdinal("DtCountDate")),
                ChurchCommunity = (ChurchCommunity)Enum.Parse(typeof(ChurchCommunity), reader.GetString(reader.GetOrdinal("ChurchCommunity"))),
                CollectionRound = (CollectionRound)Enum.Parse(typeof(CollectionRound), reader.GetString(reader.GetOrdinal("CollectionRound"))),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                AmtYellowCollectionCoin = reader.GetString(reader.GetOrdinal("AmtYellowCollectionCoin")),
                AmtGreenCollectionCoin = reader.GetString(reader.GetOrdinal("AmtGreenCollectionCoin")),
                AmtRedCollectionCoin = reader.GetString(reader.GetOrdinal("AmtRedCollectionCoin")),
                AmtBlueCollectionCoin = reader.GetString(reader.GetOrdinal("AmtBlueCollectionCoin")),
                AmtFiveEuroBill = reader.GetString(reader.GetOrdinal("AmtFiveEuroBill")),
                AmtTenEuroBill = reader.GetString(reader.GetOrdinal("AmtTenEuroBill")),
                AmtTwentyEuroBill = reader.GetString(reader.GetOrdinal("AmtTwentyEuroBill")),
                AmtFiftyEuroBill = reader.GetString(reader.GetOrdinal("AmtFiftyEuroBill")),
                AmtHundredEuroBill = reader.GetString(reader.GetOrdinal("AmtHundredEuroBill")),
                AmtTwoHundredEuroBill = reader.GetString(reader.GetOrdinal("AmtTwoHundredEuroBill")),
                AmtEuroCoinsTotalValue = reader.GetString(reader.GetOrdinal("AmtEuroCoinsTotalValue"))
            };
        }
    }
}
