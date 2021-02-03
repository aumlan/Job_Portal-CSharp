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
    /// Interaction logic for CSE_Resume.xaml
    /// </summary>
    public partial class CSE_Resume : Window
    {
        Company_SearchResult company_SearchResult;
        Company_ManageJobs company_ManageJobs;
        //DataTable cseDT = new DataTable();
        public string companyEmail;
        public string selectedApplicantEmail;
        //BusinessLogic bl = new BusinessLogic();

        string status=null;

        public CSE_Resume(string email,string selectedApplicantEmail,Company_SearchResult company_SearchResult)
        {
            InitializeComponent();
            status = "companySearch";
            this.companyEmail = email;
            this.selectedApplicantEmail = selectedApplicantEmail;
            this.company_SearchResult = company_SearchResult;
            
            string query = "SELECT * FROM info_cse WHERE email='" + selectedApplicantEmail + "';";
            ApplicantCSE applicantCSE = new ApplicantCSE();
            applicantCSE = CSE_DB.ExecuteQueryCSE(query, applicantCSE);
            //MessageBox.Show("Company Loaded---" + company.C_pass);

            if (applicantCSE == null)
            {
                MessageBox.Show("dsfzdf" + applicantCSE.A_name);
            }
            else
            {
                cseName.Content = applicantCSE.A_name;
                cseEmail.Content = applicantCSE.A_email;
                cseAddress.Content = applicantCSE.A_address;
                cseContact.Content = applicantCSE.A_contact;
                cseEduInstitution.Content = applicantCSE.A_eduInstitution;
                cseDegree.Content = applicantCSE.A_degree;
                cseCGPA.Content = applicantCSE.A_cgpa;
                csePassYear.Content = applicantCSE.A_passYear;
                cseSkill.Content = applicantCSE.A_skill;
                cseExperience.Content = applicantCSE.A_experience;
                cseExpSalary.Content = applicantCSE.A_expectedSalary;
                cseProjects.Content = applicantCSE.A_projects;

            }
        }

        public CSE_Resume(Company_ManageJobs company_ManageJobs,string applicantEmail)
        {
            InitializeComponent();
            this.company_ManageJobs = company_ManageJobs;
            status = "companyManage";
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            selectApplicant_button.Visibility
                = Visibility.Hidden;
            cseInterviewDate.Visibility = Visibility.Hidden;
            cseInterviewLoc.Visibility = Visibility.Hidden;
            cseInterviewTime.Visibility = Visibility.Hidden;



            string query = "SELECT * FROM info_cse WHERE email='" + applicantEmail + "';";
            ApplicantCSE applicantCSE = new ApplicantCSE();
            applicantCSE = CSE_DB.ExecuteQueryCSE(query, applicantCSE);
            //MessageBox.Show("Company Loaded---" + company.C_pass);

            if (applicantCSE == null)
            {
                MessageBox.Show("dsfzdf" + applicantCSE.A_name);
            }
            else
            {
                cseName.Content = applicantCSE.A_name;
                cseEmail.Content = applicantCSE.A_email;
                cseAddress.Content = applicantCSE.A_address;
                cseContact.Content = applicantCSE.A_contact;
                cseEduInstitution.Content = applicantCSE.A_eduInstitution;
                cseDegree.Content = applicantCSE.A_degree;
                cseCGPA.Content = applicantCSE.A_cgpa;
                csePassYear.Content = applicantCSE.A_passYear;
                cseSkill.Content = applicantCSE.A_skill;
                cseExperience.Content = applicantCSE.A_experience;
                cseExpSalary.Content = applicantCSE.A_expectedSalary;
                cseProjects.Content = applicantCSE.A_projects;

            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void SelectApplicant_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
               // MessageBox.Show("trying to select");

                /*string query = "INSERT INTO selected_cse(applicant_email, company_email) SELECT * FROM (SELECT '"+ cseEmail.Content + "', '" + companyEmail + "') AS tmp WHERE NOT EXISTS( SELECT applicant_email,company_email FROM selected_cse WHERE applicant_email = '" + cseEmail.Content + "' AND company_email ='" + companyEmail+ "' ) LIMIT 1;";*/

                string query = "INSERT INTO selected_cse(applicant_email, company_email,interview_date,interview_time,interview_loc) SELECT * FROM (SELECT '" + cseEmail.Content + "', '" + companyEmail + "','" + cseInterviewDate.SelectedDate.Value.Date.ToShortDateString() + "','" + cseInterviewTime.Text + "','" + cseInterviewLoc.Text + "') AS tmp WHERE NOT EXISTS( SELECT applicant_email,company_email FROM selected_cse WHERE applicant_email = '" + cseEmail.Content + "' AND company_email ='" + companyEmail + "' ) LIMIT 1;";


                bool existenceResult = Database.ExecuteQueryInsert(query);
               // MessageBox.Show("yes exists");
               // MessageBox.Show(companyEmail);
                string a = existenceResult.ToString();
              //  MessageBox.Show(a);
                if (existenceResult == false)
                {
                    MessageBox.Show("Applicant is already Selected");
                }
                else
                {
                    MessageBox.Show("CSE Selected");
                }
                this.Visibility = Visibility.Hidden;
                company_SearchResult.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (status.Equals("companyManage"))
            {
                this.Visibility = Visibility.Hidden;
                company_ManageJobs.Show();
            }
            else
            {
                this.Visibility = Visibility.Hidden;
                company_SearchResult.Show();
            }


            
        }
    }
}

