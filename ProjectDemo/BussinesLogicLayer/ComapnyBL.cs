using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class CompanyBL
    {
        

        public bool NullCheck(Company c)
        {
            if (string.IsNullOrEmpty(c.C_name) || string.IsNullOrEmpty(c.C_email) || string.IsNullOrEmpty(c.C_pass) || string.IsNullOrEmpty(c.C_address) ||
              string.IsNullOrEmpty(c.C_contact) || string.IsNullOrEmpty(c.C_type) ||
              string.IsNullOrEmpty(c.C_website) || string.IsNullOrEmpty(c.C_tradeLicense) ||
              string.IsNullOrEmpty(c.C_description))
                
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }
        
            


           


            
        }





    }
