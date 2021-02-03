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
    /// Interaction logic for Company_Resume.xaml
    /// </summary>
    public partial class Company_Resume : Window
    {
        //public string comEmail;
        //public string applicantEmail;
        public string status;
        CSE_Profile cse_Profile;
        Applicant_LoginBBA bba_Profile;
        Applicant_LoginEEE eee_Profile;
        public Company_Resume(string compEmail, string applicantEmail , string status, CSE_Profile cse_Profile)
        {
            InitializeComponent();
            //this.comEmail = compEmail;
            //this.applicantEmail = applicantEmail;
            this.cse_Profile = cse_Profile;
            this.status = status;
            //MessageBox.Show(status);
            string query = "SELECT * FROM info_company WHERE email='" + compEmail + "';";
            Company company = new Company();
            company = Company_DB.ExecuteQueryCompany(query, company);
          //  MessageBox.Show("Company Loaded---" + company.C_name);
            
            
          //  MessageBox.Show("Applicant Loaded---" + applicantEmail);

            
            string query1 = "SELECT * FROM selected_cse WHERE applicant_email='" + applicantEmail + "' AND company_email='"+compEmail+"';";
            SelectedApplicant selectedApplicant = new SelectedApplicant();
            selectedApplicant = Company_DB.ExecuteQuerySelectedApplicant(query1,selectedApplicant);
          //  MessageBox.Show("selected Loaded---" + selectedApplicant.CseInterviewDate);




            if (company == null || selectedApplicant.CseInterviewDate == null)
            {
                MessageBox.Show("dsfzdf" + company.C_name);
            }
            else
            {
            //    MessageBox.Show("interview selected MFFFFFFFFFFFFFF");
            //    MessageBox.Show(selectedApplicant.CseInterviewDate);
                companyName.Content = company.C_name;
                companyEmail.Content = company.C_email;
                companyPass.Content = company.C_pass;
                companyAddress.Content = company.C_address;
                companyContact.Content = company.C_contact;
                companyType.Content = company.C_type;
                companyWebsite.Content = company.C_website;
                companyTLicense.Content = company.C_tradeLicense;
                companyDescription.Content = company.C_description;
                cseInterViewDate.Content = selectedApplicant.CseInterviewDate;
                cseInterViewTime.Content = selectedApplicant.CseInterviewTime;
                cseInterViewLoc.Content = selectedApplicant.CseInterviewLoc;
            }


        }


        public Company_Resume(string compEmail, string applicantEmail, string status, Applicant_LoginBBA bba_Profile)
        {
            InitializeComponent();
            //this.comEmail = compEmail;
            //this.applicantEmail = applicantEmail;
            this.bba_Profile = bba_Profile;
            this.status = status;
          //  MessageBox.Show(status);
            string query = "SELECT * FROM info_company WHERE email='" + compEmail + "';";
            Company company = new Company();
            company = Company_DB.ExecuteQueryCompany(query, company);
          //  MessageBox.Show("Company Loaded---" + company.C_name);


         //   MessageBox.Show("Applicant Loaded---" + applicantEmail);


            string query1 = "SELECT * FROM selected_bba WHERE applicant_email='" + applicantEmail + "' AND company_email='" + compEmail + "';";
            SelectedApplicant selectedApplicant = new SelectedApplicant();
            selectedApplicant = Company_DB.ExecuteQuerySelectedApplicant(query1, selectedApplicant);
         //   MessageBox.Show("selected Loaded---" + selectedApplicant.CseInterviewDate);




            if (company == null || selectedApplicant.CseInterviewDate == null)
            {
                MessageBox.Show("dsfzdf" + company.C_name);
            }
            else
            {
              //  MessageBox.Show("interview selected MFFFFFFFFFFFFFF");
              //  MessageBox.Show(selectedApplicant.CseInterviewDate);
                companyName.Content = company.C_name;
                companyEmail.Content = company.C_email;
                companyPass.Content = company.C_pass;
                companyAddress.Content = company.C_address;
                companyContact.Content = company.C_contact;
                companyType.Content = company.C_type;
                companyWebsite.Content = company.C_website;
                companyTLicense.Content = company.C_tradeLicense;
                companyDescription.Content = company.C_description;
                cseInterViewDate.Content = selectedApplicant.CseInterviewDate;
                cseInterViewTime.Content = selectedApplicant.CseInterviewTime;
                cseInterViewLoc.Content = selectedApplicant.CseInterviewLoc;
            }


        }

        public Company_Resume(string compEmail, string applicantEmail, string status, Applicant_LoginEEE eee_Profile)
        {
            InitializeComponent();
            //this.comEmail = compEmail;
            //this.applicantEmail = applicantEmail;
            this.eee_Profile = eee_Profile;
            this.status = status;
           // MessageBox.Show(status);
            string query = "SELECT * FROM info_company WHERE email='" + compEmail + "';";
            Company company = new Company();
            company = Company_DB.ExecuteQueryCompany(query, company);
         //   MessageBox.Show("Company Loaded---" + company.C_name);


          //  MessageBox.Show("Applicant Loaded---" + applicantEmail);


            string query1 = "SELECT * FROM selected_eee WHERE applicant_email='" + applicantEmail + "' AND company_email='" + compEmail + "';";
            SelectedApplicant selectedApplicant = new SelectedApplicant();
            selectedApplicant = Company_DB.ExecuteQuerySelectedApplicant(query1, selectedApplicant);
          //  MessageBox.Show("selected Loaded---" + selectedApplicant.CseInterviewDate);




            if (company == null || selectedApplicant.CseInterviewDate == null)
            {
                MessageBox.Show("dsfzdf" + company.C_name);
            }
            else
            {
            //    MessageBox.Show("interview selected MFFFFFFFFFFFFFF");
            //    MessageBox.Show(selectedApplicant.CseInterviewDate);
                companyName.Content = company.C_name;
                companyEmail.Content = company.C_email;
                companyPass.Content = company.C_pass;
                companyAddress.Content = company.C_address;
                companyContact.Content = company.C_contact;
                companyType.Content = company.C_type;
                companyWebsite.Content = company.C_website;
                companyTLicense.Content = company.C_tradeLicense;
                companyDescription.Content = company.C_description;
                cseInterViewDate.Content = selectedApplicant.CseInterviewDate;
                cseInterViewTime.Content = selectedApplicant.CseInterviewTime;
                cseInterViewLoc.Content = selectedApplicant.CseInterviewLoc;
            }


        }




        public Company_Resume ()
        {
            InitializeComponent();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (status.Equals("cse"))
            {
                this.Visibility = Visibility.Hidden;
                cse_Profile.Show();
            }
            else if (status.Equals("bba"))
            {
                this.Visibility = Visibility.Hidden;
                bba_Profile.Show();
            }
            else
            {
                this.Visibility = Visibility.Hidden;
                eee_Profile.Show();
            }

        }
    }
}
