using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectDemo
{
    class EEE_DB
    {
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job_portal1";
        public static ApplicantEEE ExecuteQueryCSE(string query, ApplicantEEE applicantEEE)
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


                        applicantEEE.A_name = mySqlDataReader.GetString("name");
                        applicantEEE.A_email = mySqlDataReader.GetString("email");
                        applicantEEE.A_pass = mySqlDataReader.GetString("pass");
                        applicantEEE.A_address = mySqlDataReader.GetString("address");
                        applicantEEE.A_contact = mySqlDataReader.GetString("contact");
                        applicantEEE.A_eduInstitution = mySqlDataReader.GetString("edu_institution");
                        applicantEEE.A_degree = mySqlDataReader.GetString("degree");
                        applicantEEE.A_cgpa = mySqlDataReader.GetString("cgpa");
                        applicantEEE.A_passYear = mySqlDataReader.GetString("passYear");

                        applicantEEE.A_skill = mySqlDataReader.GetString("skill");
                        applicantEEE.A_experience = mySqlDataReader.GetString("experience");
                        applicantEEE.A_expectedSalary = mySqlDataReader.GetString("expSalay");
                        applicantEEE.A_projects = mySqlDataReader.GetString("project");
                        return applicantEEE;

                    }
                }
                else
                {


                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return applicantEEE;
        }
    }
}
