using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectDemo
{
    class CSE_DB
    {
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job_portal1";
        public static ApplicantCSE ExecuteQueryCSE(string query, ApplicantCSE applicantCSE)
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


                        applicantCSE.A_name = mySqlDataReader.GetString("name");
                        applicantCSE.A_email = mySqlDataReader.GetString("email");
                        applicantCSE.A_pass = mySqlDataReader.GetString("pass");
                        applicantCSE.A_address = mySqlDataReader.GetString("address");
                        applicantCSE.A_contact = mySqlDataReader.GetString("contact");
                        applicantCSE.A_eduInstitution = mySqlDataReader.GetString("edu_institution");
                        applicantCSE.A_degree = mySqlDataReader.GetString("degree");
                        applicantCSE.A_cgpa = mySqlDataReader.GetString("cgpa");
                        applicantCSE.A_passYear = mySqlDataReader.GetString("passYear");

                        applicantCSE.A_skill = mySqlDataReader.GetString("skill");
                        applicantCSE.A_experience = mySqlDataReader.GetString("experience");
                        applicantCSE.A_expectedSalary = mySqlDataReader.GetString("expSalay");
                        applicantCSE.A_projects = mySqlDataReader.GetString("project");
                        return applicantCSE;

                    }
                }
                else
                {


                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return applicantCSE;
        }
    }
}
