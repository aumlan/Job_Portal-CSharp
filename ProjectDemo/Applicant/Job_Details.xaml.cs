using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace ProjectDemo
{
    /// <summary>
    /// Interaction logic for Job_Details.xaml
    /// </summary>
    public partial class Job_Details : Window
    {
        //CSE_Profile cse_Profile;
        public string applicantEmail;
        public string companyEmail;
        Job_Search job_Search;
        Company_Login company_Login;
        Company_ManageJobs company_ManageJobs;
        string status = null;
        string jobID = null;
        string jobTitle = null;
        string jobSector = null;
      


        public Job_Details(Job_Search Job_Search,string companyEmail, string jobTitle,string applicantEmail)
        {
            InitializeComponent();
            delete_button.Visibility = Visibility.Hidden;
            this.job_Search = Job_Search;
            this.companyEmail = companyEmail;
            this.jobTitle = jobTitle;
            this.applicantEmail = applicantEmail;
            this.status = "jobSearch";

           // MessageBox.Show(companyEmail+jobTitle+applicantEmail+"job search result start");
            string query = "SELECT * FROM job_posted WHERE companyEmail ='" + companyEmail+ "' AND title ='" + jobTitle + "' ";
            JobPosting jobPosting = new JobPosting();
            jobPosting = JobPosting_DB.ExecuteQueryJObPosting(query,jobPosting);
           // MessageBox.Show(companyEmail + "execute query");
            if (jobPosting == null)
            {
                MessageBox.Show("No Job has been Posted");
            }
            else
            {
                jobSector = jobPosting.Sector;
                jobID = jobPosting.Id;
                type.Content = jobPosting.Type;
                title.Content = jobPosting.Title;
                experience.Content = jobPosting.Experience;
                salary.Content = jobPosting.Salary;
                vacancy.Content = jobPosting.Vacancy;
                location.Content = jobPosting.Location;
                cgpa.Content = jobPosting.Cgpa;
                skill.Content = jobPosting.Skill;
                description.Content = jobPosting.Description;
            }
           

        }
        public Job_Details(string companyEmail,string jobTitle, Company_ManageJobs company_ManageJobs)
        {
            InitializeComponent();
            this.company_ManageJobs = company_ManageJobs; 
            apply_button.Visibility = Visibility.Hidden;
            //this.company_Login = company_Login;
            this.companyEmail = companyEmail;
            this.jobTitle = jobTitle;
            this.status = "company";


          //  MessageBox.Show(companyEmail + "Company Manage posted Jobs");
            string query = "SELECT * FROM job_posted WHERE companyEmail ='" + companyEmail + "' AND title ='" + jobTitle + "' ";
            JobPosting jobPosting = new JobPosting();
            jobPosting = JobPosting_DB.ExecuteQueryJObPosting(query, jobPosting);
          //  MessageBox.Show(companyEmail + "execute query");
            if (jobPosting == null)
            {
                MessageBox.Show("No Job has been Posted");
            }
            else
            {
                jobID = jobPosting.Id;
                type.Content = jobPosting.Type;
                title.Content = jobPosting.Title;
                experience.Content = jobPosting.Experience;
                salary.Content = jobPosting.Salary;
                vacancy.Content = jobPosting.Vacancy;
                location.Content = jobPosting.Location;
                cgpa.Content = jobPosting.Cgpa;
                skill.Content = jobPosting.Skill;
                description.Content = jobPosting.Description;
            }


        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (status.Equals("jobSearch"))
            {
                this.Visibility = Visibility.Hidden;
                job_Search.Show();
            }
            else 
            {
                
                this.Visibility = Visibility.Hidden;
                company_ManageJobs.Show();
            }
        }
        private void companyDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*if (company_infoDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = company_infoDG.SelectedItem as DataRowView;

                type.Content = dataRowView["type"].ToString();
                title.Content = dataRowView["title"].ToString();
                experience.Content = dataRowView["experience"].ToString();
                salary.Content = dataRowView["salary"].ToString();
                vacancy.Content = dataRowView["vacancy"].ToString();
                location.Content = dataRowView["location"].ToString();
                cgpa.Content = dataRowView["cgpa"].ToString();
                skill.Content = dataRowView["skill"].ToString();
                description.Content = dataRowView["description"].ToString();
                
            }*/

        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            /* string query1 = "INSERT INTO job_applied(applicantEmail,companyEmail,sector,jobID) VALUES('" + applicantEmail+ "','" + companyEmail + "','" +jobSector + "','" + jobID + "')";*/

            MessageBox.Show("apply start");
            string query = "INSERT INTO job_applied(applicantEmail,companyEmail,sector,jobID) SELECT * FROM (SELECT '" + applicantEmail + "','" + companyEmail + "','" + jobSector + "','" + jobID + "') AS tmp WHERE NOT EXISTS( SELECT applicantEmail,jobID FROM job_applied WHERE applicantEmail = '" + applicantEmail + "' AND jobID ='" + jobID + "' ) LIMIT 1;";
            

            bool insertResult = Database.ExecuteQueryInsert(query);
            MessageBox.Show("apply finish");
            if (insertResult == false)
            {
                MessageBox.Show("Something went wrong");
            }
            else
            {
                MessageBox.Show("Successfully Applied");
                
                    this.Visibility = Visibility.Hidden;
                    job_Search.Show();
                
            }
        }

        private void DeleteJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bool result = Database.UserSignUp(company, "company");
                string query1 = "DELETE FROM job_posted WHERE jobID='" + jobID + "';";
                bool deleteResult = Database.ExecuteQueryInsert(query1);

                if (deleteResult == true )
                {
                    MessageBox.Show("job REMOVED");
                    this.Visibility = Visibility.Hidden;
                    company_ManageJobs.Show();
                }
                else
                {
                    MessageBox.Show("something went wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
