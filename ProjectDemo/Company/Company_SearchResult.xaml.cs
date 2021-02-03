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
    /// Interaction logic for Company_SearchResult.xaml
    /// </summary>
    public partial class Company_SearchResult : Window
    {
        public Company_SearchResult company_SearchResult;
        public Company_Login company_Login;
        public string selectedApplicantEmail = null;
        public string email = null;
        public Company_SearchResult( Company_Login company_Login, string email)
        {

            InitializeComponent();
            this.company_Login = company_Login;
            this.email = email;
        }
        public Company_SearchResult(Company_SearchResult company_SearchResult)
        {

            InitializeComponent();
            this.company_SearchResult = company_SearchResult;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }


        private void search_Click(object sender, RoutedEventArgs e)
        {

            ApplicantCSE applicantCSE = new ApplicantCSE();
            BusinessLogic bl = new BusinessLogic();
           

            applicantCSE.A_cgpa = cgpaTB.Text;
            CheckBox[] checkBoxes = new CheckBox[] { cs_Check, c_Check, java_Check,cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
            applicantCSE.A_skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    applicantCSE.A_skill = applicantCSE.A_skill + checkBoxes[i].Content.ToString();
                }
            }

            if (experience_Combo.SelectedIndex == -1) { applicantCSE.A_experience = null; }
            else
            {
                if (experience_Combo.Text.Equals("Fresher")) { applicantCSE.A_experience = "0"; }
                else { applicantCSE.A_experience = experience_Combo.Text; }
            }
            applicantCSE.A_expectedSalary = expSalaryTB.Text;
            applicantCSE.A_projects = projectsTB.Text;

            if (bl.NullCheck(applicantCSE.A_cgpa, applicantCSE.A_skill, applicantCSE.A_experience, applicantCSE.A_expectedSalary))
            { MessageBox.Show("FIll all Rquirment"); }
            else
            {

                if (bl.IntegerCheck(applicantCSE.A_expectedSalary, applicantCSE.A_cgpa) == false)
                {
                    MessageBox.Show("input valid salary/cgpa");
                }
                else
                {
                    string skill = null;
                    double experience = 0.0;
                    double expSalary = 0.0;
                    double CGPA = 0.0;
                    string project = null;
                    
                    CheckBox[] checkBoxes2 = new CheckBox[] { cs_Check, c_Check, java_Check, cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
                    for (int i = 0; i < checkBoxes2.Length; i++)
                    {
                        if (checkBoxes2[i].IsChecked.GetValueOrDefault())
                        {
                              skill =skill+checkBoxes2[i].Content.ToString()+"1";
                        }
                    }

                   string[] skill1 = new string[10];
                  skill1 = skill.Split('1');
                   // MessageBox.Show("Length"+Convert.ToString(skill1.Length));
                    string[] skill2 = new string[10] { null,null,null, null, null, null, null, null, null,null };
                    for (int i = 0; i < skill1.Length; i++)
                    {
                        skill2[i] = skill1[i];
                    }

                   /* for (int i = 0; i < skill2.Length; i++)
                    {
                        MessageBox.Show("10 value "+ skill2[i]);
                    }
                    MessageBox.Show("before exe query" + skill1[0] + skill1[1]);*/

                    if (experience_Combo.SelectedIndex == -1) { experience = 0; }
                    else
                    {
                        if (experience_Combo.Text.Equals("Fresher")) { experience = 0; }
                        else { experience = Convert.ToDouble(experience_Combo.Text); }
                    }
                    expSalary = Convert.ToDouble(expSalaryTB.Text);
                    CGPA = Convert.ToDouble(cgpaTB.Text);
                    project = projectsTB.Text;
                    // applicantCSE.A_projects = projectsTB.Text;

                    MessageBox.Show("before exe query" + skill1[0]+skill1[1]);
                    //MessageBox.Show(skill + experience + expSalary + CGPA + project);

                    string query = "SELECT name, email FROM info_cse WHERE (skill LIKE '%"+skill2[0]+ "%' AND skill LIKE '%" + skill2[1]+ "%' AND skill LIKE '%" + skill2[2] + "%' AND skill LIKE '%" + skill2[3] + "%' AND skill LIKE '%" + skill2[4] + "%' AND skill LIKE '%" + skill2[5] + "%' AND skill LIKE '%" + skill2[6] + "%' AND skill LIKE '%" + skill2[7] + "%' AND skill LIKE '%" + skill2[8] + "%' AND skill LIKE '%" + skill2[9] + "%' ) AND cgpa >= '" + CGPA + "' AND experience >= '" + experience + "' AND expSalay <= '" + expSalary + "' AND project LIKE '%" + project + "%' ;";

                    // string query1 = "SELECT name FROM info_cse WHERE cgpa >= '" + cg + "' AND expSalay <= '" + expsal + "';";

                    DataTable dataTable = Database.ExecuteQueryVIEW(query);
                    searchResultDG.ItemsSource = dataTable.DefaultView;
                    
                }    
            }
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
          
            this.Visibility = Visibility.Hidden;
            company_Login.Show();
        }

        private void ShowResume_Click(object sender, RoutedEventArgs e)
        {
           
            if (searchResultDG.Items.Count == 0)
            {
                MessageBox.Show("Select Applicant to View RESUME");
            }
            else
            {
                MessageBox.Show(selectedApplicantEmail);
                CSE_Resume cse_Resume = new CSE_Resume(email, selectedApplicantEmail,this);
                this.Visibility = Visibility.Collapsed;
                cse_Resume.Show();
            }

        }

        private void searchResultDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchResultDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = searchResultDG.SelectedItem as DataRowView;
                this.selectedApplicantEmail = dataRowView["email"].ToString();
            }
        }
    }
}
