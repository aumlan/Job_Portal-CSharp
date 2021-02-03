using System;
using System.Collections.Generic;
using System.Data;
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

namespace ProjectDemo
{
    /// <summary>
    /// Interaction logic for Job_Search.xaml
    /// </summary>
    public partial class Job_Search : Window
    {
        CSE_Profile cse_Profile;
        Applicant_LoginEEE eee_Profile;
        Applicant_LoginBBA bba_Profile;
        public string applicantEmail=null;
        public string companyEmail=null;
        string jobTitle=null;
        string status = null;
        public Job_Search(CSE_Profile cse_Profile, string applicantEmail)
        {
            InitializeComponent();
            status = "cse";
            itSector.IsSelected = true;
            engineeringSector.IsSelected = false;
            marketingSector.IsSelected = false;
            engineeringSector.IsEnabled = false;
            engineeringSector.Visibility = Visibility.Hidden;
            marketingSector.IsEnabled = false;
            marketingSector.Visibility = Visibility.Hidden;
            this.cse_Profile = cse_Profile;
            this.applicantEmail = applicantEmail;
            /*string query = "SELECT * FROM job_posted";
            DataTable companyDT = Database.ExecuteQueryVIEW(query);
            it_SearchResultDG.ItemsSource = companyDT.DefaultView;*/
        }
        public Job_Search(Applicant_LoginEEE eee_Profile, string applicantEmail)
        {
            InitializeComponent();
            status = "eee";
            itSector.IsSelected = false;
            engineeringSector.IsSelected = true;
            marketingSector.IsSelected = false;
            itSector.IsEnabled = false;
            itSector.Visibility = Visibility.Hidden;
            marketingSector.IsEnabled = false;
            marketingSector.Visibility = Visibility.Hidden;
            this.eee_Profile = eee_Profile;
            this.applicantEmail = applicantEmail;
        }
        public Job_Search(Applicant_LoginBBA bba_Profile, string applicantEmail)
        {
            InitializeComponent();
            status = "bba";
            itSector.IsSelected = false;
            engineeringSector.IsSelected = false;
            marketingSector.IsSelected = true;
            itSector.IsEnabled = false;
            itSector.Visibility = Visibility.Hidden;
            engineeringSector.IsEnabled = false;
            engineeringSector.Visibility = Visibility.Hidden;
            this.bba_Profile = bba_Profile;
            this.applicantEmail = applicantEmail;
        }




        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }
        private void it_Search_Click(object sender, RoutedEventArgs e)
        {
            ApplicantCSE applicantCSE = new ApplicantCSE();
            JobPosting jobPosting = new JobPosting();
            BusinessLogic bl = new BusinessLogic();


            CheckBox[] checkBoxes = new CheckBox[] { cs_Check, c_Check, java_Check, c_Check, cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
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
            applicantCSE.A_cgpa = cgpaTB.Text;

            ///type
            if (it_full_Check.IsChecked == false && it_half_Check.IsChecked == false)
            {
                MessageBox.Show("fill Type");
            }
            else
            {
                if (it_full_Check.IsChecked == true)
                {
                    jobPosting.Type = it_full_Check.Content.ToString();
                }
                else
                {
                    jobPosting.Type = it_half_Check.Content.ToString();
                }
            }

            //location
            if (it_location_Combo.SelectedIndex == -1) { jobPosting.Location = null; }
            else
            {
                jobPosting.Location = it_location_Combo.Text;
            }



            if (bl.NullCheck(applicantCSE.A_cgpa, applicantCSE.A_skill, applicantCSE.A_experience, applicantCSE.A_expectedSalary,jobPosting.Type,jobPosting.Location))
            {
                MessageBox.Show("FIll all Rquirment");
            }
            else
            {
                if (bl.IntegerCheck(applicantCSE.A_expectedSalary, applicantCSE.A_cgpa)==false)
                {
                    MessageBox.Show("input valid salary/cgpa");
                }
                else
                {
                    //MessageBox.Show("Db start");
                    string skill = null;
                    double experience = 0.0;
                    double expSalary = Convert.ToDouble(applicantCSE.A_expectedSalary); ;
                    double CGPA = Convert.ToDouble(cgpaTB.Text); ;
                    string type = jobPosting.Type;
                    string location = jobPosting.Location;
                    CheckBox[] checkBoxes2 = new CheckBox[] { cs_Check, c_Check, java_Check, c_Check, cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
                    for (int i = 0; i < checkBoxes.Length; i++)
                    {
                        if (checkBoxes[i].IsChecked.GetValueOrDefault())
                        {
                            skill = skill + checkBoxes[i].Content.ToString()+"1";
                        }
                    }
                    //MessageBox.Show("skill start");
                    string[] skill1 = new string[10];
                    skill1 = skill.Split('1');
                    // MessageBox.Show("Length"+Convert.ToString(skill1.Length));
                    string[] skill2 = new string[10] { null, null, null, null, null, null, null, null, null, null };
                    for (int i = 0; i < skill1.Length; i++)
                    {
                        skill2[i] = skill1[i];
                    }
                    /*for (int i = 0; i < skill2.Length; i++)
                   {
                       MessageBox.Show("10 value: "+ skill2[i]);
                   }
                   MessageBox.Show("before exe query" + skill1[0] + skill1[1]);*/

                    if (experience_Combo.SelectedIndex == -1) { experience = 0; }
                    else
                    {
                        if (experience_Combo.Text.Equals("Fresher")) { experience = 0; }
                        else { experience = Convert.ToDouble(experience_Combo.Text); }
                    }
                   // MessageBox.Show("query start");
                    //MessageBox.Show("" + skill + experience + expSalary + CGPA+type+location);
                    /*string query = "SELECT companyEmail,title FROM job_posted WHERE type= '" + type +"' AND cgpa <= '" + CGPA + "' AND skill LIKE '%" + skill + "%' AND experience <= '" + experience + "' AND salary >= '" + expSalary + "' AND location = '"+location+"' ;";
                    */
                    string query = "SELECT companyEmail,title FROM job_posted WHERE (skill LIKE '%" + skill2[0] + "%' AND skill LIKE '%" + skill2[1] + "%' AND skill LIKE '%" + skill2[2] + "%' AND skill LIKE '%" + skill2[3] + "%' AND skill LIKE '%" + skill2[4] + "%' AND skill LIKE '%" + skill2[5] + "%' AND skill LIKE '%" + skill2[6] + "%' AND skill LIKE '%" + skill2[7] + "%' AND skill LIKE '%" + skill2[8] + "%' AND skill LIKE '%" + skill2[9] + "%') AND type= '" + type + "' AND sector = 'IT'  AND cgpa <= '" + CGPA + "' AND experience <= '" + experience + "' AND salary >= '" + expSalary + "' AND location = '" + location + "' ;";

                    DataTable dataTable = Database.ExecuteQueryVIEW(query);
                   // MessageBox.Show("query finished");
                    it_SearchResultDG.ItemsSource = dataTable.DefaultView;
                }
            }
        }

       
        
        private void back_click(object sender, RoutedEventArgs e)
        {
            if (status.Equals("cse"))
            {
                this.Visibility = Visibility.Hidden;
                cse_Profile.Show();
            }
            else if (status.Equals("eee"))
            {
                this.Visibility = Visibility.Hidden;
                eee_Profile.Show();
            }
            else
            {
                this.Visibility = Visibility.Hidden;
                bba_Profile.Show();
            }

            
        }

        private void it_SearchResultDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (it_SearchResultDG.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = it_SearchResultDG.SelectedItem as DataRowView;

                companyEmail = dataRowView["companyEmail"].ToString();
                jobTitle = dataRowView["title"].ToString();
            }
        }
        private void it_SearchResultDG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (it_SearchResultDG1.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = it_SearchResultDG1.SelectedItem as DataRowView;

                companyEmail = dataRowView["companyEmail"].ToString();
                jobTitle = dataRowView["title"].ToString();
            }
        }

        private void it_SearchResultDG2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (it_SearchResultDG2.SelectedIndex == -1)
            {

            }
            else
            {
                DataRowView dataRowView = it_SearchResultDG2.SelectedItem as DataRowView;

                companyEmail = dataRowView["companyEmail"].ToString();
                jobTitle = dataRowView["title"].ToString();
            }
        }

        private void ShowJobDetails_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(companyEmail + jobTitle + applicantEmail + "going to details");
            Job_Details jobSearch_Result = new Job_Details(this,companyEmail,jobTitle,applicantEmail);
            this.Visibility = Visibility.Hidden;
            jobSearch_Result.Show();
        }

        private void eng_Search_Click(object sender, RoutedEventArgs e)
        {
            
            ApplicantEEE applicantEEE = new ApplicantEEE();
            JobPosting jobPosting = new JobPosting();
            BusinessLogic bl = new BusinessLogic();


            CheckBox[] checkBoxes = new CheckBox[] { fitting_Check, mecha_Check, scrip_Check, elb_Check, power_Check, sql_Check };
            applicantEEE.A_skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    applicantEEE.A_skill = applicantEEE.A_skill + checkBoxes[i].Content.ToString();
                }
            }

            
            if (experience_Combo1.SelectedIndex == -1) { applicantEEE.A_experience = null; }
            else
            {
                if (experience_Combo1.Text.Equals("Fresher")) { applicantEEE.A_experience = "0"; }
                else { applicantEEE.A_experience = experience_Combo1.Text; }
            }
            applicantEEE.A_expectedSalary = expSalaryTB1.Text;
            applicantEEE.A_cgpa = cgpaTB1.Text;

            ///type
            if (it_full_Check1.IsChecked == false && it_half_Check1.IsChecked == false)
            {
                MessageBox.Show("fill Type");
            }
            else
            {
                if (it_full_Check1.IsChecked == true)
                {
                    jobPosting.Type = it_full_Check1.Content.ToString();
                }
                else
                {
                    jobPosting.Type = it_half_Check1.Content.ToString();
                }
            }

            //location
            if (it_location_Combo1.SelectedIndex == -1) { jobPosting.Location = null; }
            else
            {
                jobPosting.Location = it_location_Combo1.Text;
            }



            if (bl.NullCheck(applicantEEE.A_cgpa, applicantEEE.A_skill, applicantEEE.A_experience, applicantEEE.A_expectedSalary, jobPosting.Type, jobPosting.Location))
            {
                MessageBox.Show("FIll all Rquirment");
            }
            else
            {
                if (bl.IntegerCheck(applicantEEE.A_expectedSalary, applicantEEE.A_cgpa) == false)
                {
                    MessageBox.Show("input valid salary/cgpa");
                }
                else
                {
                    //MessageBox.Show("Db start");
                    string skill = null;
                    double experience = 0.0;
                    double expSalary = Convert.ToDouble(applicantEEE.A_expectedSalary); ;
                    double CGPA = Convert.ToDouble(cgpaTB1.Text); ;
                    string type = jobPosting.Type;
                    string location = jobPosting.Location;
                    CheckBox[] checkBoxes2 = new CheckBox[] { fitting_Check, mecha_Check, scrip_Check, elb_Check, power_Check, sql_Check };
                    for (int i = 0; i < checkBoxes.Length; i++)
                    {
                        if (checkBoxes[i].IsChecked.GetValueOrDefault())
                        {
                            skill = skill + checkBoxes[i].Content.ToString();
                        }
                    }
                    string[] skill1 = new string[10];
                    skill1 = skill.Split('1');
                    // MessageBox.Show("Length"+Convert.ToString(skill1.Length));
                    string[] skill2 = new string[10] { null, null, null, null, null, null, null, null, null, null };
                    for (int i = 0; i < skill1.Length; i++)
                    {
                        skill2[i] = skill1[i];
                    }

                    if (experience_Combo1.SelectedIndex == -1) { experience = 0; }
                    else
                    {
                        if (experience_Combo1.Text.Equals("Fresher")) { experience = 0; }
                        else { experience = Convert.ToDouble(experience_Combo1.Text); }
                    }
                   // MessageBox.Show("query start");
                    //MessageBox.Show("" + skill + experience + expSalary + CGPA + type + location);
                    /*string query = "SELECT companyEmail,title FROM job_posted WHERE type= '" + type +"' AND cgpa <= '" + CGPA + "' AND skill LIKE '%" + skill + "%' AND experience <= '" + experience + "' AND salary >= '" + expSalary + "' AND location = '"+location+"' ;";
                    */
                    string query = "SELECT companyEmail,title FROM job_posted WHERE (skill LIKE '%" + skill2[0] + "%' AND skill LIKE '%" + skill2[1] + "%' AND skill LIKE '%" + skill2[2] + "%' AND skill LIKE '%" + skill2[3] + "%' AND skill LIKE '%" + skill2[4] + "%' AND skill LIKE '%" + skill2[5] + "%' AND skill LIKE '%" + skill2[6] + "%' AND skill LIKE '%" + skill2[7] + "%' AND skill LIKE '%" + skill2[8] + "%' AND skill LIKE '%" + skill2[9] + "%') AND type= '" + type + "' AND sector = 'Engineering'  AND cgpa <= '" + CGPA + "' AND skill LIKE '%" + skill + "%' AND experience <= '" + experience + "' AND salary >= '" + expSalary + "' AND location = '" + location + "' ;";

                    DataTable dataTable = Database.ExecuteQueryVIEW(query);
                   // MessageBox.Show("query finished");
                    it_SearchResultDG1.ItemsSource = dataTable.DefaultView;
                }
            }


        }

        private void mar_Search_Click(object sender, RoutedEventArgs e)
        {
            ApplicantBBA applicantBBA = new ApplicantBBA();
            JobPosting jobPosting = new JobPosting();
            BusinessLogic bl = new BusinessLogic();


            CheckBox[] checkBoxes = new CheckBox[] { digital_Check, market_Check, corporate_Check, strategy_Check, promotional_Check, agency_Check, powerpoint_Check, communication_Check };
            applicantBBA.A_skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    applicantBBA.A_skill = applicantBBA.A_skill + checkBoxes[i].Content.ToString();
                }
            }

            if (experience_Combo.SelectedIndex == -1) { applicantBBA.A_experience = null; }
            else
            {
                if (experience_Combo.Text.Equals("Fresher")) { applicantBBA.A_experience = "0"; }
                else { applicantBBA.A_experience = experience_Combo.Text; }
            }
            applicantBBA.A_expectedSalary = expSalaryTB.Text;
            applicantBBA.A_cgpa = cgpaTB.Text;

            ///type
            if (it_full_Check.IsChecked == false && it_half_Check.IsChecked == false)
            {
                MessageBox.Show("fill Type");
            }
            else
            {
                if (it_full_Check.IsChecked == true)
                {
                    jobPosting.Type = it_full_Check.Content.ToString();
                }
                else
                {
                    jobPosting.Type = it_half_Check.Content.ToString();
                }
            }

            //location
            if (it_location_Combo.SelectedIndex == -1) { jobPosting.Location = null; }
            else
            {
                jobPosting.Location = it_location_Combo.Text;
            }



            if (bl.NullCheck(applicantBBA.A_cgpa, applicantBBA.A_skill, applicantBBA.A_experience, applicantBBA.A_expectedSalary, jobPosting.Type, jobPosting.Location))
            {
                MessageBox.Show("FIll all Rquirment");
            }
            else
            {
                if (bl.IntegerCheck(applicantBBA.A_expectedSalary, applicantBBA.A_cgpa) == false)
                {
                    MessageBox.Show("input valid salary/cgpa");
                }
                else
                {
                    MessageBox.Show("Db start");
                    string skill = null;
                    double experience = 0.0;
                    double expSalary = Convert.ToDouble(applicantBBA.A_expectedSalary); ;
                    double CGPA = Convert.ToDouble(cgpaTB.Text); ;
                    string type = jobPosting.Type;
                    string location = jobPosting.Location;
                    CheckBox[] checkBoxes2 = new CheckBox[] { cs_Check, c_Check, java_Check, c_Check, cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
                    for (int i = 0; i < checkBoxes.Length; i++)
                    {
                        if (checkBoxes[i].IsChecked.GetValueOrDefault())
                        {
                            skill = skill + checkBoxes[i].Content.ToString();
                        }
                    }

                    if (experience_Combo.SelectedIndex == -1) { experience = 0; }
                    else
                    {
                        if (experience_Combo.Text.Equals("Fresher")) { experience = 0; }
                        else { experience = Convert.ToDouble(experience_Combo.Text); }
                    }
                    MessageBox.Show("query start");
                    MessageBox.Show("" + skill + experience + expSalary + CGPA + type + location);
                    /*string query = "SELECT companyEmail,title FROM job_posted WHERE type= '" + type +"' AND cgpa <= '" + CGPA + "' AND skill LIKE '%" + skill + "%' AND experience <= '" + experience + "' AND salary >= '" + expSalary + "' AND location = '"+location+"' ;";
                    */
                    string query = "SELECT companyEmail,title FROM job_posted WHERE type= '" + type + "' AND sector = 'IT'  AND cgpa <= '" + CGPA + "' AND skill LIKE '%" + skill + "%' AND experience <= '" + experience + "' AND salary >= '" + expSalary + "' AND location = '" + location + "' ;";

                    DataTable dataTable = Database.ExecuteQueryVIEW(query);
                    MessageBox.Show("query finished");
                    it_SearchResultDG.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        
    }
}
