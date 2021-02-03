using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectDemo
{
    class Company_DB
    {
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job_portal1";

        public static Company ExecuteQueryCompany(string query, Company company)
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
                        company.C_name = mySqlDataReader.GetString("name");
                        company.C_email = mySqlDataReader.GetString("email");
                        company.C_pass = mySqlDataReader.GetString("pass");
                        company.C_address = mySqlDataReader.GetString("address");
                        company.C_contact = mySqlDataReader.GetString("contact");
                        company.C_type = mySqlDataReader.GetString("type");
                        company.C_website = mySqlDataReader.GetString("website");
                        company.C_tradeLicense = mySqlDataReader.GetString("t_license");
                        company.C_description = mySqlDataReader.GetString("description");
                        return company;

                    }
                }
                else
                {


                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return company;
        }

        public static SelectedApplicant ExecuteQuerySelectedApplicant(string query,SelectedApplicant selectedApplicant)
        {
            
            selectedApplicant.CseInterviewDate = null;
            selectedApplicant.CseInterviewTime = null;
            selectedApplicant.CseInterviewLoc = null;
          
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
                        selectedApplicant.CseInterviewDate = mySqlDataReader.GetString("interview_date");
                        selectedApplicant.CseInterviewTime = mySqlDataReader.GetString("interview_time");
                        selectedApplicant.CseInterviewLoc = mySqlDataReader.GetString("interview_loc");

                        
                        return selectedApplicant;
                    }
                }
                else
                {

                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return selectedApplicant;
        }

    }
    public class SelectedApplicant
    {
        private string cseInterviewDate;
        private string cseInterviewTime;
        private string cseInterviewLoc;

        public string CseInterviewDate { get => cseInterviewDate; set => cseInterviewDate = value; }
        public string CseInterviewTime { get => cseInterviewTime; set => cseInterviewTime = value; }
        public string CseInterviewLoc { get => cseInterviewLoc; set => cseInterviewLoc = value; }
    }

}
