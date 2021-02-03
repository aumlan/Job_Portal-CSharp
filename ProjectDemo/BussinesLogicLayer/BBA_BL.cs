using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class BBA_BL
    {
        public bool NullCheck(ApplicantBBA applicantBBA)
        {
            if (string.IsNullOrEmpty(applicantBBA.A_name) || string.IsNullOrEmpty(applicantBBA.A_email) || string.IsNullOrEmpty(applicantBBA.A_pass) || string.IsNullOrEmpty(applicantBBA.A_pass) ||
              string.IsNullOrEmpty(applicantBBA.A_address) || string.IsNullOrEmpty(applicantBBA.A_contact) ||
              string.IsNullOrEmpty(applicantBBA.A_eduInstitution) || string.IsNullOrEmpty(applicantBBA.A_degree) ||
              string.IsNullOrEmpty(applicantBBA.A_cgpa) ||
              string.IsNullOrEmpty(applicantBBA.A_passYear) || string.IsNullOrEmpty(applicantBBA.A_skill) ||
              string.IsNullOrEmpty(applicantBBA.A_experience))

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
