using SchemaDataBase.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaDataBase.implementation
{
    public class SchemaTableDao  : ISchemaTable
    {
        
        public List<string> GetAllTableFromDatabase(string conectionString, string databaseName)
        {
            List<String> listTablesNames = null;
            using (var connection = new SqlConnection(conectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.Parameters.Add("@param", SqlDbType.NVarChar);
                command.Parameters["@param"].Value = databaseName;
                command.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where Table_Catalog = @param and TABLE_NAME != 'sysdiagrams'";
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        listTablesNames = new List<string>();
                        while (reader.Read())
                        {
                            listTablesNames.Add(Convert.ToString(reader["TABLE_NAME"]));
                        }
                    }

                }
            }
            return listTablesNames;
        }

        public DataTable ExecuteQuery(string conectionString, string query)
        {
            DataTable dataTeble = null;

            using (var connection = new SqlConnection(conectionString))
            {
                SqlCommand command = connection.CreateCommand();
#pragma warning disable S3649 // User-provided values should be sanitized before use in SQL statements
                command.CommandText = query;
#pragma warning restore S3649 // User-provided values should be sanitized before use in SQL statements
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTeble = new DataTable();
                    dataTeble.Load(reader);
                }
            }
            return dataTeble; 
        }

        public List<string> GetAllColumFromTable(string conectionString, string databaseName, string tableName)
        {
            List<String> listColum = null;

            using (var connection = new SqlConnection(conectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.Parameters.Add("@paramDatabase", SqlDbType.NVarChar);
                command.Parameters["@paramDatabase"].Value = databaseName;
                command.Parameters.Add("@paramsTable", SqlDbType.NVarChar);
                command.Parameters["@paramsTable"].Value = tableName;
                command.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@paramsTable AND TABLE_CATALOG = @paramDatabase";
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) 
                    {
                        listColum = new List<string>();
                        while (reader.Read())
                        {
                            listColum.Add(Convert.ToString(reader["COLUMN_NAME"]));
                        }
                    }

                }
            }
            return listColum;
        }

        public List<string> GetColumKeys(string conectionString, string databaseName, string tableName)
        {
            List<String> listColum = null;
            using (var connection = new SqlConnection(conectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.Parameters.Add("@tableName", SqlDbType.NVarChar);
                command.Parameters["@tableName"].Value = tableName;
                command.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME LIKE @tableName AND CONSTRAINT_NAME LIKE 'PK%'";
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        listColum = new List<string>();
                        while (reader.Read())
                        {
                            listColum.Add(Convert.ToString(reader["COLUMN_NAME"]));
                        }
                    }

                }
            }
            return listColum;
        }

    }
}
