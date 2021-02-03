using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class CSE_BL
    {

        public bool NullCheck(ApplicantCSE applicantCSE)
        {
            if (string.IsNullOrEmpty(applicantCSE.A_name) || string.IsNullOrEmpty(applicantCSE.A_email) || string.IsNullOrEmpty(applicantCSE.A_pass) || string.IsNullOrEmpty(applicantCSE.A_pass) ||
              string.IsNullOrEmpty(applicantCSE.A_address) || string.IsNullOrEmpty(applicantCSE.A_contact) ||
              string.IsNullOrEmpty(applicantCSE.A_eduInstitution) || string.IsNullOrEmpty(applicantCSE.A_degree) ||
              string.IsNullOrEmpty(applicantCSE.A_cgpa)||
              string.IsNullOrEmpty(applicantCSE.A_passYear) || string.IsNullOrEmpty(applicantCSE.A_skill) ||
              string.IsNullOrEmpty(applicantCSE.A_experience)|| string.IsNullOrEmpty(applicantCSE.A_projects))

            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NullCheck(JobPosting jobPosting)
        {
            if (string.IsNullOrEmpty(jobPosting.Type) || string.IsNullOrEmpty(jobPosting.Id) || string.IsNullOrEmpty(jobPosting.Title) || string.IsNullOrEmpty(jobPosting.Experience) || string.IsNullOrEmpty(jobPosting.Salary) ||
              string.IsNullOrEmpty(jobPosting.Vacancy) || string.IsNullOrEmpty(jobPosting.Location) ||
              string.IsNullOrEmpty(jobPosting.Cgpa) || string.IsNullOrEmpty(jobPosting.Skill) ||
              string.IsNullOrEmpty(jobPosting.Description))

            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IntegerCheck(params string[] str)
        {
            double value = 0;
            bool result = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (Double.TryParse(str[i], out value))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }





    }
}
