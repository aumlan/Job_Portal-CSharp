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
    /// Interaction logic for Company_Login.xaml
    /// </summary>
    public partial class Company_Login : Window
    {
        public Company_Login company_Login;
        public string email = null;
        DataTable jobPostingDT;
        string jobtitle = null;
        public Company_Login(string email)
        {
            InitializeComponent();
            this.email = email;
            companyNameTB.Visibility = Visibility.Hidden;
            companyEmailTB.Visibility = Visibility.Hidden;
            companyPassTB.Visibility = Visibility.Hidden;
            companyAddressTB.Visibility = Visibility.Hidden;
            companyContactTB.Visibility = Visibility.Hidden;
            companyTypeCBox.Visibility = Visibility.Hidden;
            companyWebsiteTB.Visibility = Visibility.Hidden;
            companyTLicenseTB.Visibility = Visibility.Hidden;
            companyDescriptionTB.Visibility = Visibility.Hidden;

           // MessageBox.Show(email);

            string query = "SELECT * FROM info_company WHERE email='" + email + "';";
            Company company = new Company();
            company=  Company_DB.ExecuteQueryCompany(query,company);
           // MessageBox.Show("Company Loaded---"+company.C_pass);
            
            if (company == null)
            {
                MessageBox.Show("dsfzdf"+company.C_name);
            }
            else
            {
                companyName.Content = company.C_name;
                companyEmail.Content = company.C_email;
                companyPass.Content = company.C_pass;
                companyAddress.Content = company.C_address;
                companyContact.Content = company.C_contact;
                companyType.Content = company.C_type;
                companyWebsite.Content = company.C_website;
                companyTLicense.Content = company.C_tradeLicense;
                companyDescription.Content = company.C_description;
            }
        }
        /*public Company_Login(Company_Login company_Login)
        {
            InitializeComponent();
            this.company_Login = company_Login;

        }*/
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Name.Equals("editButton"))
            {
                companyNameTB.Visibility = Visibility.Visible;
                companyEmailTB.Visibility = Visibility.Visible;
                companyPassTB.Visibility = Visibility.Visible;
                companyAddressTB.Visibility = Visibility.Visible;
                companyContactTB.Visibility = Visibility.Visible;
                companyTypeCBox.Visibility = Visibility.Visible;
                companyWebsiteTB.Visibility = Visibility.Visible;
                companyTLicenseTB.Visibility = Visibility.Visible;
                companyDescriptionTB.Visibility = Visibility.Visible;

                companyNameTB.Text = companyName.Content.ToString();
                companyEmailTB.Text =companyEmail.Content.ToString();
                companyPassTB.Text =companyPass.Content.ToString();
                companyAddressTB.Text =companyAddress.Content.ToString();
                companyContactTB.Text =companyContact.Content.ToString();
                companyTypeCBox.SelectedItem =companyType.Content.ToString();
                companyWebsiteTB.Text = companyWebsite.Content.ToString();
                companyTLicenseTB.Text = companyTLicense.Content.ToString();
                companyDescriptionTB.Text =companyDescription.Content.ToString();

                companyName.Visibility = Visibility.Hidden;
                companyEmail.Visibility = Visibility.Hidden;
                companyPass.Visibility = Visibility.Hidden;
                companyAddress.Visibility = Visibility.Hidden;
                companyContact.Visibility = Visibility.Hidden;
                companyType.Visibility = Visibility.Hidden;
                companyWebsite.Visibility = Visibility.Hidden;
                companyTLicense.Visibility = Visibility.Hidden;
                companyDescription.Visibility = Visibility.Hidden;

            }
        }

        private void searchEmployee_Click(object sender, RoutedEventArgs e)
        {
            Company_SearchResult company_SearchResult = new Company_SearchResult(this,companyEmail.Content.ToString());
           this.Visibility = Visibility.Hidden;
            company_SearchResult.Show();
        }

        private void postJob_Click(object sender, RoutedEventArgs e)
        {
            Job_Posting job_Posting = new Job_Posting(email,this);
            this.Visibility = Visibility.Hidden;
            job_Posting.Show();
        }

        private void ManageJob_Click(object sender, RoutedEventArgs e)
        {
            Company_ManageJobs company_ManageJobs = new Company_ManageJobs(email,this);
            this.Visibility = Visibility.Hidden;
            company_ManageJobs.Show();
        }
    }
}
