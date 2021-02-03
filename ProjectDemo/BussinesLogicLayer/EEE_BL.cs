using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class EEE_BL
    {
        public bool NullCheck(ApplicantEEE applicantEEE)
        {
            if (string.IsNullOrEmpty(applicantEEE.A_name) || string.IsNullOrEmpty(applicantEEE.A_email) || string.IsNullOrEmpty(applicantEEE.A_pass) || string.IsNullOrEmpty(applicantEEE.A_pass) ||
              string.IsNullOrEmpty(applicantEEE.A_address) || string.IsNullOrEmpty(applicantEEE.A_contact) ||
              string.IsNullOrEmpty(applicantEEE.A_eduInstitution) || string.IsNullOrEmpty(applicantEEE.A_degree) ||
              string.IsNullOrEmpty(applicantEEE.A_cgpa) ||
              string.IsNullOrEmpty(applicantEEE.A_passYear) || string.IsNullOrEmpty(applicantEEE.A_skill) ||
              string.IsNullOrEmpty(applicantEEE.A_experience))

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
