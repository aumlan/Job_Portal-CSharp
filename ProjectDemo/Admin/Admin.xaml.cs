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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        Admin admin;
        DataTable companydt = new DataTable();
        DataTable cseDT = new DataTable();
        DataTable eeeDT = new DataTable();
        DataTable bbaDT = new DataTable();

        public Admin()
        {
            InitializeComponent();

            adminName.Content = "Aumlan";
            adminEmail.Content = "admin@gmail.com";
            adminPass.Content = "12345";
            adminContact.Content = "017123456789";
            adminAddress.Content = "Dhaka";

            string query = "SELECT * FROM info_company";
            companydt = Database.ExecuteQueryVIEW(query);
            company_infoDG.ItemsSource = companydt.DefaultView;

            string query1 = "SELECT * FROM info_cse";
            cseDT = Database.ExecuteQueryVIEW(query1);
            cse_infoDG.ItemsSource = cseDT.DefaultView;

            string query2 = "SELECT * FROM info_eee";
            eeeDT = Database.ExecuteQueryVIEW(query2);
            eee_infoDG.ItemsSource = eeeDT.DefaultView;

            string query3 = "SELECT * FROM info_bba";
            bbaDT = Database.ExecuteQueryVIEW(query3);
            bba_infoDG.ItemsSource = bbaDT.DefaultView;

        }

        public Admin(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }


        private void logOut_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
        private void pending_Request_Button_Click(object sender, RoutedEventArgs e)
        {
            Admin_PendingReq admin_PendingReq = new Admin_PendingReq(this);
            this.Visibility = Visibility.Hidden;
            admin_PendingReq.Show();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

     
        /// ///////////Company////////////////////
        
        private void companyDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (company_infoDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = company_infoDG.SelectedItem as DataRowView;

                companyName.Content = dataRowView["name"].ToString();
                companyEmail.Content = dataRowView["email"].ToString();
                companyPass.Content = dataRowView["pass"].ToString();
                companyAddress.Content = dataRowView["address"].ToString();
                companyContact.Content = dataRowView["contact"].ToString();
                companyType.Content = dataRowView["type"].ToString();
                companyWebsite.Content = dataRowView["website"].ToString();
                companyTLicense.Content = dataRowView["t_license"].ToString();
                companyDescription.Content = dataRowView["description"].ToString();
            }

        }

        private void company_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bool result = Database.UserSignUp(company, "company");
                string query1 = "DELETE FROM info_company WHERE email='" + companyEmail.Content + "';";
                bool deleteResult = Database.ExecuteQueryInsert(query1);
                string query2 = "DELETE FROM login WHERE username='" + companyEmail.Content + "';";
                bool deleteResult2 = Database.ExecuteQueryInsert(query2);

                if (deleteResult == true && deleteResult2 == true)
                {
                    MessageBox.Show("Company REMOVED");
                    string q = "SELECT * FROM info_company";
                   companydt = Database.ExecuteQueryVIEW(q);
                    company_infoDG.ItemsSource = companydt.DefaultView;
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

        /// ///////////CSE////////////////////
        private void cse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bool result = Database.UserSignUp(company, "company");
                string query1 = "DELETE FROM info_cse WHERE email='" + cseEmail.Content + "';";
                bool deleteResult = Database.ExecuteQueryInsert(query1);
                string query2 = "DELETE FROM login WHERE username='" + cseEmail.Content + "';";
                bool deleteResult2 = Database.ExecuteQueryInsert(query2);

                if (deleteResult == true && deleteResult2 == true)
                {
                    MessageBox.Show("Company REMOVED");
                    string q = "SELECT * FROM info_cse";
                    cseDT = Database.ExecuteQueryVIEW(q);
                    cse_infoDG.ItemsSource = cseDT.DefaultView;
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

        private void cseDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cse_infoDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = cse_infoDG.SelectedItem as DataRowView;

                cseName.Content = dataRowView["name"].ToString();
                cseEmail.Content = dataRowView["email"].ToString();
                csePass.Content = dataRowView["pass"].ToString();
                cseAddress.Content = dataRowView["address"].ToString();
                cseContact.Content = dataRowView["contact"].ToString();
                cseEduInstitution.Content = dataRowView["edu_institution"].ToString();
                cseDegree.Content = dataRowView["degree"].ToString();
                cseCGPA.Content = dataRowView["cgpa"].ToString();
                csePassYear.Content = dataRowView["passYear"].ToString();
                cseSkill.Content = dataRowView["skill"].ToString();
                cseExperience.Content = dataRowView["experience"].ToString();
                cseExpSalary.Content = dataRowView["expSalay"].ToString();
                cseProjects.Content = dataRowView["project"].ToString();
            }
        }

        /// ///////////EEE////////////////////
        private void eee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bool result = Database.UserSignUp(company, "company");
                string query1 = "DELETE FROM info_eee WHERE email='" + eeeEmail.Content + "';";
                bool deleteResult = Database.ExecuteQueryInsert(query1);
                string query2 = "DELETE FROM login WHERE username='" + eeeEmail.Content + "';";
                bool deleteResult2 = Database.ExecuteQueryInsert(query2);

                if (deleteResult == true && deleteResult2 == true)
                {
                    MessageBox.Show("EEE REMOVED");
                    string q = "SELECT * FROM info_eee";
                    eeeDT = Database.ExecuteQueryVIEW(q);
                    eee_infoDG.ItemsSource = cseDT.DefaultView;
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
        private void eeeDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (eee_infoDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = eee_infoDG.SelectedItem as DataRowView;

                eeeName.Content = dataRowView["name"].ToString();
                eeeEmail.Content = dataRowView["email"].ToString();
                eeePass.Content = dataRowView["pass"].ToString();
                eeeAddress.Content = dataRowView["address"].ToString();
                eeeContact.Content = dataRowView["contact"].ToString();
                eeeEduInstitution.Content = dataRowView["edu_institution"].ToString();
                eeeDegree.Content = dataRowView["degree"].ToString();
                eeeCGPA.Content = dataRowView["cgpa"].ToString();
                eeePassYear.Content = dataRowView["passYear"].ToString();
                eeeSkill.Content = dataRowView["skill"].ToString();
                eeeExperience.Content = dataRowView["experience"].ToString();
                eeeExpSalary.Content = dataRowView["expSalay"].ToString();
                eeeProjects.Content = dataRowView["project"].ToString();
            }
        }

        /// ///////////BBA////////////////////

        private void bba_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bool result = Database.UserSignUp(company, "company");
                string query1 = "DELETE FROM info_bbba WHERE email='" + bbaEmail.Content + "';";
                bool deleteResult = Database.ExecuteQueryInsert(query1);
                string query2 = "DELETE FROM login WHERE username='" + bbaEmail.Content + "';";
                bool deleteResult2 = Database.ExecuteQueryInsert(query2);

                if (deleteResult == true && deleteResult2 == true)
                {
                    MessageBox.Show("BBA REMOVED");
                    string q = "SELECT * FROM info_bba";
                    bbaDT = Database.ExecuteQueryVIEW(q);
                    bba_infoDG.ItemsSource = bbaDT.DefaultView;
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

        private void bbaDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bba_infoDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = bba_infoDG.SelectedItem as DataRowView;

                bbaName.Content = dataRowView["name"].ToString();
                bbaEmail.Content = dataRowView["email"].ToString();
                bbaPass.Content = dataRowView["pass"].ToString();
                bbaAddress.Content = dataRowView["address"].ToString();
                bbaContact.Content = dataRowView["contact"].ToString();
                bbaEduInstitution.Content = dataRowView["edu_institution"].ToString();
                bbaDegree.Content = dataRowView["degree"].ToString();
                bbaCGPA.Content = dataRowView["cgpa"].ToString();
                bbaPassYear.Content = dataRowView["passYear"].ToString();
                bbaSkill.Content = dataRowView["skill"].ToString();
                bbaExperience.Content = dataRowView["experience"].ToString();
                bbaExpSalary.Content = dataRowView["expSalay"].ToString();
                bbaProjects.Content = dataRowView["project"].ToString();
            }
        }










        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
