using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ProjectDemo
{
    class Database
    {
        
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job_portal1";

        public static bool ExecuteQueryInsert(string query)
        {
            bool result = false;

            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.CommandTimeout = 60;
            
            try
            {
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read()) { result = false; }
                }
                else {
                    result = true; }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return result;
        }
        public static DataTable ExecuteQueryVIEW(string query)
        {
           
            DataTable dt = new DataTable();
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.CommandTimeout = 60;

            try
            {
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                    dt.Load(mySqlDataReader);
                    return dt;
                    
                }
                

            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return dt;
        }

        public static bool ExecuteQueryDELETE(string query)
        {
            bool result = false;

            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.CommandTimeout = 60;

            try
            {
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read()) { result = true; }
                }
                
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return result;
        }

        public static string ExecuteQueryLogin(string query)
        {
            string status = null;
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.CommandTimeout = 60;

            try
            {
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read()) {
                        status = mySqlDataReader.GetString("status");
                        return status;
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return status;
        }

        


    }
}
