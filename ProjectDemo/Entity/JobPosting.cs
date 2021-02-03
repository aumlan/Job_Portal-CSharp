using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class JobPosting
    {
        private string id;
        private string companyEmail;
        private string sector;
        private string type;
        private string title;
        private string experience;
        private string salary;
        private string vacancy;
        private string location;
        private string cgpa;
        private string skill;
        private string description;

        public string Type { get => type; set => type = value; }
        public string Title { get => title; set => title = value; }
        public string Experience { get => experience; set => experience = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Vacancy { get => vacancy; set => vacancy = value; }
        public string Location { get => location; set => location = value; }
        public string Cgpa { get => cgpa; set => cgpa = value; }
        public string Skill { get => skill; set => skill = value; }
        public string Description { get => description; set => description = value; }
        public string Id { get => id; set => id = value; }
        public string CompanyEmail { get => companyEmail; set => companyEmail = value; }
        public string Sector { get => sector; set => sector = value; }
    }
}
