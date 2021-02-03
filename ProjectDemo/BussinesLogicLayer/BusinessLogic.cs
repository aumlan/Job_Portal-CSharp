using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class BusinessLogic
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
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
        public bool NullCheck(params string[] n)
        {
            bool result = false;
            for (int i = 0; i < n.Length; i++)
            {
                if (string.IsNullOrEmpty(n[i]))
                {
                    result = true;
                    break;
                }
                else { } 
            }
            return result;
        }
    }
}
