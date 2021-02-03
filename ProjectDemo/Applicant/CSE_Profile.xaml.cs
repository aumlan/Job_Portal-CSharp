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
    /// Interaction logic for CSE_Profile.xaml
    /// </summary>
    public partial class CSE_Profile : Window
    {
        public string email = null;
        public string companyEmail;
        public CSE_Profile(string email)
        {
            InitializeComponent();
            this.email = email;
            TextBoxHidden();
            //MessageBox.Show(email);

            string query = "SELECT * FROM info_cse WHERE email='" + email + "';";
            ApplicantCSE applicantCSE = new ApplicantCSE();
            applicantCSE = CSE_DB.ExecuteQueryCSE(query, applicantCSE);
            //MessageBox.Show("CSE Loaded---" + applicantCSE.A_pass);

            if (applicantCSE == null)
            {
                MessageBox.Show("NUllll-----" + applicantCSE.A_name);
            }
            else
            {
                //MessageBox.Show(applicantCSE.A_projects);
                cseName.Content = applicantCSE.A_name;
                cseEmail.Content = applicantCSE.A_email;
                csePass.Content = applicantCSE.A_pass;
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
            string query1 = "SELECT * FROM selected_cse WHERE applicant_email='" + email + "';";
            DataTable dt = Database.ExecuteQueryVIEW(query1);
           // MessageBox.Show("CSE Loaded---" + applicantCSE.A_pass);

            selectedByCompany_DG.ItemsSource = dt.DefaultView;

        }
        public void TextBoxHidden()
        {
            A_L_nameTB.Visibility = Visibility.Hidden;
            A_L_passPB.Visibility = Visibility.Hidden;
            A_L_emailTB.Visibility = Visibility.Hidden;
            A_L_addressTB.Visibility = Visibility.Hidden;
            A_L_contactTB.Visibility = Visibility.Hidden;
            A_L_eduInstitutionTB.Visibility = Visibility.Hidden;
            A_L_degreeTB.Visibility = Visibility.Hidden;
            A_L_cgpaTB.Visibility = Visibility.Hidden;
            A_L_passYearTB.Visibility = Visibility.Hidden;
            A_L_expSalaryTB.Visibility = Visibility.Hidden;
            A_L_projectsTB.Visibility = Visibility.Hidden;

            cs_Check.Visibility = Visibility.Hidden;
            java_Check.Visibility = Visibility.Hidden;
            c_Check.Visibility = Visibility.Hidden;
            cpp_Check.Visibility = Visibility.Hidden;
            php_Check.Visibility = Visibility.Hidden;
            python_Check.Visibility = Visibility.Hidden;
            html_Check.Visibility = Visibility.Hidden;
            javaScript_Check.Visibility = Visibility.Hidden;
            ruby_Check.Visibility = Visibility.Hidden;

            experience_Combo.Visibility = Visibility.Hidden;
            A_L_expSalaryTB.Visibility = Visibility.Hidden;
            A_L_projectsTB.Visibility = Visibility.Hidden;
        }

        public void TextBoxShow()
        {
            A_L_nameTB.Visibility = Visibility.Visible;
            A_L_passPB.Visibility = Visibility.Visible;
            //A_L_emailTB.Visibility = Visibility.Visible;
            A_L_addressTB.Visibility = Visibility.Visible;
            A_L_contactTB.Visibility = Visibility.Visible;
            A_L_eduInstitutionTB.Visibility = Visibility.Visible;
            A_L_degreeTB.Visibility = Visibility.Visible;
            A_L_cgpaTB.Visibility = Visibility.Visible;
            A_L_passYearTB.Visibility = Visibility.Visible;
            A_L_expSalaryTB.Visibility = Visibility.Visible;
            A_L_projectsTB.Visibility = Visibility.Visible;

            cs_Check.Visibility = Visibility.Visible;
            java_Check.Visibility = Visibility.Visible;
            c_Check.Visibility = Visibility.Visible;
            cpp_Check.Visibility = Visibility.Visible;
            php_Check.Visibility = Visibility.Visible;
            python_Check.Visibility = Visibility.Visible;
            html_Check.Visibility = Visibility.Visible;
            javaScript_Check.Visibility = Visibility.Visible;
            ruby_Check.Visibility = Visibility.Visible;

            experience_Combo.Visibility = Visibility.Visible;
            A_L_expSalaryTB.Visibility = Visibility.Visible;
            A_L_projectsTB.Visibility = Visibility.Visible;
        }

        public void LabelHide()
        {
            cseName.Visibility = Visibility.Hidden;
            cseEmail.Visibility = Visibility.Hidden;
            csePass.Visibility = Visibility.Hidden;
            cseAddress.Visibility = Visibility.Hidden;
            cseContact.Visibility = Visibility.Hidden;
            cseEduInstitution.Visibility = Visibility.Hidden;
            cseDegree.Visibility = Visibility.Hidden;
            cseCGPA.Visibility = Visibility.Hidden;
            csePassYear.Visibility = Visibility.Hidden;
            cseSkill.Visibility = Visibility.Hidden;
            cseExperience.Visibility = Visibility.Hidden;
            cseExpSalary.Visibility = Visibility.Hidden;
            cseProjects.Visibility = Visibility.Hidden;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Name.Equals("edit_button"))
            {

                TextBoxShow();
                LabelHide();
                A_L_nameTB.Text = cseName.Content.ToString();
                A_L_passPB.Password = csePass.Content.ToString();
                //A_L_emailTB.Text = cseEmail.Content.ToString();
                A_L_addressTB.Text = cseAddress.Content.ToString();
                A_L_contactTB.Text = cseContact.Content.ToString();
                A_L_eduInstitutionTB.Text = cseEduInstitution.Content.ToString();
                experience_Combo.Text = cseExperience.Content.ToString();
                A_L_degreeTB.Text = cseDegree.Content.ToString();
                A_L_cgpaTB.Text = cseCGPA.Content.ToString();
                A_L_passYearTB.Text = csePassYear.Content.ToString();
                A_L_expSalaryTB.Text = cseExpSalary.Content.ToString();
                A_L_projectsTB.Text = cseProjects.Content.ToString();
            }
            if (button.Name.Equals("update_button"))
            {
                string exp = null;
                if (experience_Combo.SelectedIndex == -1) { exp = null; }
                else
                {
                    if (experience_Combo.Text.Equals("Fresher")) { exp = "0"; }
                    else { exp = experience_Combo.Text; }
                }

                CheckBox[] checkBoxes = new CheckBox[] { cs_Check, c_Check, java_Check, c_Check, cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
                string skill = null;
                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    if (checkBoxes[i].IsChecked.GetValueOrDefault())
                    {
                        skill = skill + checkBoxes[i].Content.ToString();
                    }
                }

                try
                {

                    string query = "UPDATE info_cse SET name ='" + A_L_nameTB.Text + "',  pass='" + A_L_passPB.Password.ToString() + "',contact='" + A_L_contactTB.Text + "', address='" + A_L_addressTB.Text + "',  edu_institution ='" + A_L_eduInstitutionTB.Text + "' ,degree='" + A_L_degreeTB.Text + "' , cgpa='" + A_L_cgpaTB.Text + "',passYear='" + A_L_passYearTB.Text + "', expSalay='" + A_L_expSalaryTB.Text + "',project='" + A_L_projectsTB.Text + "',experience='" + exp + "',skill='" + skill + "'  WHERE email= '" + cseEmail.Content.ToString() + "'";



                    bool updateResult = Database.ExecuteQueryInsert(query);

                    if (updateResult)
                    {
                        MessageBox.Show("Updated successfully");
                        MainWindow mainWindow = new MainWindow();
                        this.Visibility = Visibility.Hidden;
                        mainWindow.Show();
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
            if (button.Name.Equals("logout_button"))
            {
                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                mainWindow.Show();
            }
            if (button.Name.Equals("view_company"))
            {
                if (selectedByCompany_DG.Items.Count == 0 || selectedByCompany_DG.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Company to View RESUME");
                }
                else
                {
                   // MessageBox.Show("fffffff");
                    //MessageBox.Show(companyEmail);
                    Company_Resume company_Resume = new Company_Resume(companyEmail, email, "cse", this);
                    //Company_Resume company_Resume = new Company_Resume();
                    this.Visibility = Visibility.Hidden;
                    company_Resume.Show();

                }
            }

        }

        private void selectedByCompanyDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedByCompany_DG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = selectedByCompany_DG.SelectedItem as DataRowView;
                this.companyEmail = dataRowView["company_email"].ToString();
            }
        }

        private void jobSearch_Click(object sender, RoutedEventArgs e)
        {
            Job_Search job_Search = new Job_Search(this,email);
            this.Visibility = Visibility.Hidden;
            job_Search.Show();
        }
    }
}
