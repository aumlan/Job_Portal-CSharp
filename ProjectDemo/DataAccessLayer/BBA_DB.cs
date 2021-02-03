using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectDemo
{
    class BBA_DB
    {
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=job_portal1";
        public static ApplicantBBA ExecuteQueryCSE(string query, ApplicantBBA applicantBBA)
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


                        applicantBBA.A_name = mySqlDataReader.GetString("name");
                        applicantBBA.A_email = mySqlDataReader.GetString("email");
                        applicantBBA.A_pass = mySqlDataReader.GetString("pass");
                        applicantBBA.A_address = mySqlDataReader.GetString("address");
                        applicantBBA.A_contact = mySqlDataReader.GetString("contact");
                        applicantBBA.A_eduInstitution = mySqlDataReader.GetString("edu_institution");
                        applicantBBA.A_degree = mySqlDataReader.GetString("degree");
                        applicantBBA.A_cgpa = mySqlDataReader.GetString("cgpa");
                        applicantBBA.A_passYear = mySqlDataReader.GetString("passYear");

                        applicantBBA.A_skill = mySqlDataReader.GetString("skill");
                        applicantBBA.A_experience = mySqlDataReader.GetString("experience");
                        applicantBBA.A_expectedSalary = mySqlDataReader.GetString("expSalay");
                        applicantBBA.A_projects = mySqlDataReader.GetString("project");
                        return applicantBBA;

                    }
                }
                else
                {


                }
            }
            catch (Exception) { throw; }
            mySqlConnection.Close();

            return applicantBBA;
        }
    }
}
