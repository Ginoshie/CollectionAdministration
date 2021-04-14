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
            if (countResult.Count != 15)
            {
                throw new IndexOutOfRangeException();
            }

            var fields = string.Join(", ", countResult.Keys);

            var formattedValues = string.Join(", ", countResult.Values);

            var insertCountQuery = $"insert into CollectionCount ({fields}) values ({formattedValues});";

            using var connection = new OleDbConnection(ConnectionString);

            OleDbCommand cmd = new OleDbCommand(insertCountQuery, connection);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void DeleteCount(int pkCountResult)
        {
            string deleteCountQuery = $"delete from CollectionCount where collectionCountId={pkCountResult};";

            using var connection = new OleDbConnection(ConnectionString);

            var command = new OleDbCommand(deleteCountQuery, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void UpdateCount(int pkCount, Dictionary<string, string> countResult)
        {
            if (countResult.Count != 15)
            {
                throw new IndexOutOfRangeException();
            }

            var fieldValuePairs = new List<string>();

            foreach (var kvp in countResult)
            {
                fieldValuePairs.Add(kvp.Key + " = " + kvp.Value);
            }

            var setClause = string.Join(", ", fieldValuePairs);

            var updateCountQuery = $"update CollectionCount set {setClause} where CollectionCountId = {pkCount};";

            using var connection = new OleDbConnection(ConnectionString);

            var cmd = new OleDbCommand(updateCountQuery, connection);

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static List<CollectionCount> GetCollectionCounts()
        {
            var collectionCountsList = new List<CollectionCount>();

            var selectAllCountsQuery = "select * from CollectionCount;";

            using var connection = new OleDbConnection(ConnectionString);

            var command = new OleDbCommand(selectAllCountsQuery, connection);

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                collectionCountsList.Add(GetCountCollectionFromDataReaderFields(reader));
            }

            return collectionCountsList;
        }

        private static CollectionCount GetCountCollectionFromDataReaderFields(OleDbDataReader reader)
        {
            return new CollectionCount
            {
                CollectionCountId = reader.GetInt32(reader.GetOrdinal("CollectionCountId")),
                DtCountDate = reader.GetDateTime(reader.GetOrdinal("DtCountDate")),
                ChurchCommunity = (ChurchCommunity) Enum.Parse(typeof(ChurchCommunity),
                    reader.GetString(reader.GetOrdinal("ChurchCommunity"))),
                CollectionRound = (CollectionRound) Enum.Parse(typeof(CollectionRound),
                    reader.GetString(reader.GetOrdinal("CollectionRound"))),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                CollectionCoins =
                {
                    AmtYellowCollectionCoin = reader.GetString(reader.GetOrdinal("AmtYellowCollectionCoin")),
                    AmtGreenCollectionCoin = reader.GetString(reader.GetOrdinal("AmtGreenCollectionCoin")),
                    AmtRedCollectionCoin = reader.GetString(reader.GetOrdinal("AmtRedCollectionCoin")),
                    AmtBlueCollectionCoin = reader.GetString(reader.GetOrdinal("AmtBlueCollectionCoin"))
                },
                EuroBills =
                {
                    AmtFiveEuroBill = reader.GetString(reader.GetOrdinal("AmtFiveEuroBill")),
                    AmtTenEuroBill = reader.GetString(reader.GetOrdinal("AmtTenEuroBill")),
                    AmtTwentyEuroBill = reader.GetString(reader.GetOrdinal("AmtTwentyEuroBill")),
                    AmtFiftyEuroBill = reader.GetString(reader.GetOrdinal("AmtFiftyEuroBill")),
                    AmtHundredEuroBill = reader.GetString(reader.GetOrdinal("AmtHundredEuroBill")),
                    AmtTwoHundredEuroBill = reader.GetString(reader.GetOrdinal("AmtTwoHundredEuroBill"))
                },
                AmtEuroCoinsTotalValue = reader.GetString(reader.GetOrdinal("AmtEuroCoinsTotalValue"))
            };
        }
    }
}