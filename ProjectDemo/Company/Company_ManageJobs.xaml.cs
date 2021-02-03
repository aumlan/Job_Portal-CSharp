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
    /// Interaction logic for Company_ManageJobs.xaml
    /// </summary>
    public partial class Company_ManageJobs : Window
    {
        string jobtitle;
        string companyEmail;
        string applicantEmail;
        Company_Login company_Login;
        
        public Company_ManageJobs(string companyEmail, Company_Login company_Login)
        {
            InitializeComponent();
            this.companyEmail = companyEmail;
            this.company_Login = company_Login;

            string query1 = "SELECT jobID,title,sector FROM job_posted WHERE companyEmail ='" + companyEmail + "' ";
            //JobPosting jobPosting = new JobPosting();
           DataTable jobPostingDT = Database.ExecuteQueryVIEW(query1);

            postedJobsDG.ItemsSource = jobPostingDT.DefaultView;

            string query2 = "SELECT jobID,applicantEmail,sector FROM job_applied WHERE companyEmail ='" + companyEmail + "' ";
            //JobPosting jobPosting = new JobPosting();
            DataTable applicantAppliedDT = Database.ExecuteQueryVIEW(query2);

            appliedAppplicantDG.ItemsSource = applicantAppliedDT.DefaultView;



        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            this.Visibility = Visibility.Hidden;
            company_Login.Show();
        }

        private void viewJobDetalis_Click(object sender, RoutedEventArgs e)
        {
            if (jobtitle == null)
            {
                MessageBox.Show("Select a job to View");
            }
            else
            {
                Job_Details jobSearch_Result = new Job_Details(companyEmail , jobtitle,this);
                this.Visibility = Visibility.Hidden;
                jobSearch_Result.Show();
            }
        }

        private void postedJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (postedJobsDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = postedJobsDG.SelectedItem as DataRowView;
                this.jobtitle = dataRowView["title"].ToString();
            }
        }

        private void appliedAppplicantDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appliedAppplicantDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = appliedAppplicantDG.SelectedItem as DataRowView;
                this.applicantEmail = dataRowView["applicantEmail"].ToString();
            }
        }

        private void viewApplicant_Click(object sender, RoutedEventArgs e)
        {
            CSE_Resume cSE_Resume = new CSE_Resume(this,applicantEmail);
            this.Visibility = Visibility.Hidden;
            cSE_Resume.Show();
        }
    }
}
