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
    /// Interaction logic for Admin_PendingReq.xaml
    /// </summary>
    public partial class Admin_PendingReq : Window
    {
        DataTable companyDT = new DataTable();
        DataTable cseDT = new DataTable();
        DataTable eeeDT = new DataTable();
        DataTable bbaDT = new DataTable();
        Admin admin;
        public Admin_PendingReq(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            //List<string> l = new List<string>();
            string query = "SELECT * FROM pendingreq_company";
            companyDT = Database.ExecuteQueryVIEW(query);
            company_pendingDG.ItemsSource = companyDT.DefaultView;
            string query1 = "SELECT * FROM pendingreq_cse";
            cseDT = Database.ExecuteQueryVIEW(query1);
            cse_pendingDG.ItemsSource = cseDT.DefaultView;
            string query2 = "SELECT * FROM pendingreq_eee";
            eeeDT = Database.ExecuteQueryVIEW(query2);
            eee_pendingDG.ItemsSource = eeeDT.DefaultView;
            string query3 = "SELECT * FROM pendingreq_bba";
            bbaDT = Database.ExecuteQueryVIEW(query3);
            bba_pendingDG.ItemsSource = bbaDT.DefaultView;
        }
    protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void back_Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin1 = new Admin();
            this.Visibility = Visibility.Hidden;
            admin1.Show();
        }

        /// ///////Company////////
        private void companyDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (company_pendingDG.SelectedIndex== -1)
            {

            }
            else
            {
                DataRowView dataRowView = company_pendingDG.SelectedItem as DataRowView;

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
        private void Company_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Name.Equals("companyApprove"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");
                    string status = "company";
                    string query = " INSERT into login (username,pass,status) Values ('" + companyEmail.Content + "','" + companyPass.Content + "','" + status + "'); ";

                    bool loginresult = Database.ExecuteQueryInsert(query);

                    string query1 = " INSERT into info_company (name,email,pass,address,contact,type,website,t_license,description) " +
                        "Values ('" + companyName.Content + "','" + companyEmail.Content + "','" + companyPass.Content + "','" + companyAddress.Content + "','" + companyContact.Content + "','" + companyType.Content + "','" + companyWebsite.Content + "','" + companyTLicense.Content + "','" + companyDescription.Content + "'); ";

                    bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                    if (loginresult == true && pendingRequestresult == true)
                    {
                        MessageBox.Show("Company ADDED");

                        string qq = "DELETE FROM pendingreq_company WHERE email='" + companyEmail.Content + "';";
                        bool deleteResult = Database.ExecuteQueryInsert(qq);
                        if (deleteResult == true)
                        {
                            //company_pendingDG.ItemsSource = 
                            string q = "SELECT * FROM pendingreq_company";
                            companyDT = Database.ExecuteQueryVIEW(q);
                            company_pendingDG.ItemsSource = companyDT.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("not deleted after add");
                        }
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
            else if (button.Name.Equals("companyDecline"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");

                    string query1 = "DELETE FROM pendingreq_company WHERE email='" + companyEmail.Content + "';";
                    bool deleteResult = Database.ExecuteQueryInsert(query1);

                    if (deleteResult == true)
                    {
                        MessageBox.Show("Company REMOVED");
                        //string qq = "DELETE FROM pendingreq_company WHERE email='" + companyEmail.Content + "';";
                        // bool deleteResult2 = Database.ExecuteQueryDELETE(qq);
                        string q = "SELECT * FROM pendingreq_company";
                        companyDT = Database.ExecuteQueryVIEW(q);

                        company_pendingDG.ItemsSource = companyDT.DefaultView;
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
        /// ///////CSE////////
        private void CSE_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Name.Equals("cseApprove"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");
                    string status = "cse";
                    string query1 = " INSERT INTO info_cse (name, email, pass, address, contact, edu_institution,degree, cgpa, passYear, skill, experience, expSalay, project) VALUES('" +cseName.Content + "','" +cseEmail.Content  + "','" +csePass.Content + "','" +cseAddress.Content  + "','" +cseContact.Content  + "','" +cseEduInstitution.Content  + "','" + cseDegree.Content + "','" +cseCGPA.Content + "','" +csePassYear.Content  + "','" +cseSkill.Content  + "','" + cseExperience.Content + "','" +cseExpSalary.Content  + "','" +cseProjects.Content + "')";

                    bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                    string query = " INSERT into login (username,pass,status) Values ('" + cseEmail.Content + "','" + csePass.Content + "','" + status + "'); ";

                    bool loginresult = Database.ExecuteQueryInsert(query);

                    if (loginresult == true && pendingRequestresult == true)
                    {
                        MessageBox.Show("CSE ADDED");

                        string qq = "DELETE FROM pendingreq_cse WHERE email='" + cseEmail.Content + "';";
                        bool deleteResult = Database.ExecuteQueryInsert(qq);
                        if (deleteResult == true)
                        {
                            //company_pendingDG.ItemsSource = 
                            string q = "SELECT * FROM pendingreq_cse";
                            cseDT = Database.ExecuteQueryVIEW(q);
                            cse_pendingDG.ItemsSource = cseDT.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("not deleted after add");
                        }
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
            else if (button.Name.Equals("cseDecline"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");

                    string query1 = "DELETE FROM pendingreq_cse WHERE email='" + cseEmail.Content + "';";
                    bool deleteResult = Database.ExecuteQueryInsert(query1);

                    if (deleteResult == true)
                    {
                        MessageBox.Show("CSE REMOVED");
                        //string qq = "DELETE FROM pendingreq_company WHERE email='" + companyEmail.Content + "';";
                        // bool deleteResult2 = Database.ExecuteQueryDELETE(qq);
                        string q = "SELECT * FROM pendingreq_cse";
                        cseDT = Database.ExecuteQueryVIEW(q);

                        cse_pendingDG.ItemsSource = cseDT.DefaultView;
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
        private void cse_pendingDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cse_pendingDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = cse_pendingDG.SelectedItem as DataRowView;
                
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
        /// ///////EEE////////
        private void EEE_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Name.Equals("eeeApprove"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");
                    string status = "eee";
                    string query1 = " INSERT INTO info_eee (name, email, pass, address, contact, edu_institution,degree, cgpa, passYear, skill, experience, expSalay, project) VALUES('" + eeeName.Content + "','" + eeeEmail.Content + "','" + eeePass.Content + "','" + eeeAddress.Content + "','" + eeeContact.Content + "','" + eeeEduInstitution.Content + "','" + eeeDegree.Content + "','" + eeeCGPA.Content + "','" + eeePassYear.Content + "','" + eeeSkill.Content + "','" + eeeExperience.Content + "','" + eeeExpSalary.Content + "','" + eeeProjects.Content + "')";

                    bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                    string query = " INSERT into login (username,pass,status) Values ('" + eeeEmail.Content + "','" + eeePass.Content + "','" + status + "'); ";

                    bool loginresult = Database.ExecuteQueryInsert(query);

                    if (loginresult == true && pendingRequestresult == true)
                    {
                        MessageBox.Show("EEE ADDED");

                        string qq = "DELETE FROM pendingreq_eee WHERE email='" + eeeEmail.Content + "';";
                        bool deleteResult = Database.ExecuteQueryInsert(qq);
                        if (deleteResult == true)
                        {
                            //company_pendingDG.ItemsSource = 
                            string q = "SELECT * FROM pendingreq_eee";
                            eeeDT = Database.ExecuteQueryVIEW(q);
                            eee_pendingDG.ItemsSource = eeeDT.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("not deleted after add");
                        }
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
            else if (button.Name.Equals("eeeDecline"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");

                    string query1 = "DELETE FROM pendingreq_eee WHERE email='" + eeeEmail.Content + "';";
                    bool deleteResult = Database.ExecuteQueryInsert(query1);

                    if (deleteResult == true)
                    {
                        MessageBox.Show("EEE REMOVED");
                        //string qq = "DELETE FROM pendingreq_company WHERE email='" + companyEmail.Content + "';";
                        // bool deleteResult2 = Database.ExecuteQueryDELETE(qq);
                        string q = "SELECT * FROM pendingreq_eee";
                        eeeDT = Database.ExecuteQueryVIEW(q);

                        eee_pendingDG.ItemsSource = eeeDT.DefaultView;
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
        private void eee_pendingDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (eee_pendingDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = eee_pendingDG.SelectedItem as DataRowView;

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

        /// ///////BBA////////
        /// 
        private void BBA_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Name.Equals("bbaApprove"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");
                    string status = "bba";
                    string query1 = " INSERT INTO info_bba (name, email, pass, address, contact, edu_institution,degree, cgpa, passYear, skill, experience, expSalay, project) VALUES('" + bbaName.Content + "','" + bbaEmail.Content + "','" + bbaPass.Content + "','" + eeeAddress.Content + "','" + eeeContact.Content + "','" + bbaEduInstitution.Content + "','" + bbaDegree.Content + "','" + bbaCGPA.Content + "','" + bbaPassYear.Content + "','" + bbaSkill.Content + "','" + bbaExperience.Content + "','" + bbaExpSalary.Content + "','" + bbaProjects.Content + "')";

                    bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                    string query = " INSERT into login (username,pass,status) Values ('" + bbaEmail.Content + "','" + bbaPass.Content + "','" + status + "'); ";

                    bool loginresult = Database.ExecuteQueryInsert(query);

                    if (loginresult == true && pendingRequestresult == true)
                    {
                        MessageBox.Show("BBA ADDED");

                        string qq = "DELETE FROM pendingreq_bba WHERE email='" + bbaEmail.Content + "';";
                        bool deleteResult = Database.ExecuteQueryInsert(qq);
                        if (deleteResult == true)
                        {
                            //company_pendingDG.ItemsSource = 
                            string q = "SELECT * FROM pendingreq_bba";
                            bbaDT = Database.ExecuteQueryVIEW(q);
                            bba_pendingDG.ItemsSource = bbaDT.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("not deleted after add");
                        }
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
            else if (button.Name.Equals("bbaDecline"))
            {
                try
                {
                    //bool result = Database.UserSignUp(company, "company");

                    string query1 = "DELETE FROM pendingreq_bba WHERE email='" + bbaEmail.Content + "';";
                    bool deleteResult = Database.ExecuteQueryInsert(query1);

                    if (deleteResult == true)
                    {
                        MessageBox.Show("EEE REMOVED");
                        //string qq = "DELETE FROM pendingreq_company WHERE email='" + companyEmail.Content + "';";
                        // bool deleteResult2 = Database.ExecuteQueryDELETE(qq);
                        string q = "SELECT * FROM pendingreq_bba";
                        bbaDT = Database.ExecuteQueryVIEW(q);

                        bba_pendingDG.ItemsSource = bbaDT.DefaultView;
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
        private void bba_pendingDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bba_pendingDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = bba_pendingDG.SelectedItem as DataRowView;

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
    }
}
