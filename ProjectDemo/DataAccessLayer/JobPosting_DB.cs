using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectDemo
{
    class JobPosting_DB
    {
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job_portal1";
        public static JobPosting ExecuteQueryJObPosting(string query, JobPosting jobPosting)
        {

            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.CommandTimeout = 60;

            try
            {
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        jobPosting.Id = mySqlDataReader.GetString("jobID");
                        jobPosting.CompanyEmail = mySqlDataReader.GetString("companyEmail");
                        jobPosting.Sector = mySqlDataReader.GetString("sector");
                        jobPosting.Type = mySqlDataReader.GetString("type");
                        jobPosting.Title = mySqlDataReader.GetString("title");
                        jobPosting.Experience = mySqlDataReader.GetString("experience");
                        jobPosting.Salary = mySqlDataReader.GetString("salary");
                        jobPosting.Vacancy = mySqlDataReader.GetString("vacancy");
                        jobPosting.Location = mySqlDataReader.GetString("location");
                        jobPosting.Cgpa = mySqlDataReader.GetString("cgpa");
                        jobPosting.Skill = mySqlDataReader.GetString("skill");
                        jobPosting.Description = mySqlDataReader.GetString("description");
                        
                        return jobPosting;

                    }
                }
                else
                {


                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return jobPosting;
        }



    }
}
