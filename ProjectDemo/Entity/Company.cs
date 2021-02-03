using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class Company
    {
        //private int c_id;
        private string c_name;
        private string c_email;
        private string c_pass;
        private string c_address;
        private string c_contact;
        private string c_type;
        private string c_website;
        private string c_tradeLicense;
        private string c_description;

        //public int C_id { get => c_id; set => c_id = value; }
        public string C_name { get => c_name; set => c_name = value; }
        public string C_email { get => c_email; set => c_email = value; }
        public string C_pass { get => c_pass; set => c_pass = value; }
        public string C_address { get => c_address; set => c_address = value; }
        public string C_contact { get => c_contact; set => c_contact = value; }
        public string C_type { get => c_type; set => c_type = value; }
        public string C_website { get => c_website; set => c_website = value; }
        public string C_tradeLicense { get => c_tradeLicense; set => c_tradeLicense = value; }
        public string C_description { get => c_description; set => c_description = value; }
    }
}
