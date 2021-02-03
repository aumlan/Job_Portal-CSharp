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

namespace ProjectDemo
{
    /// <summary>
    /// Interaction logic for Job_Posting.xaml
    /// </summary>
    public partial class Job_Posting : Window
    {
        Company_Login company_Login;
        public string companyEmail;
        CSE_BL cse_BL = new CSE_BL();
        public Job_Posting(string companyEmail, Company_Login company_Login)
        {
            InitializeComponent();
            //this.company_Login = company_Login;
            this.companyEmail =companyEmail;
            this.company_Login = company_Login;
            string[] s = companyEmail.Split('@');
            it_id_Copy.Text = s[0];
            it_id_Copy1.Text = s[0];
            it_id_Copy2.Text = s[0];

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            company_Login.Show();
            
        }

       
        private void cseJobPost_Click(object sender, RoutedEventArgs e)
        {

            JobPosting jobPosting = new JobPosting();
            jobPosting.Id =it_id.Text;
            if (it_full_Check.IsChecked==false&& it_half_Check.IsChecked==false )
            {
                MessageBox.Show("fill all The requirment");
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
                } }

            jobPosting.Title = it_title.Text;

            if (it_experience_Combo.SelectedIndex == -1) { jobPosting.Experience = null; }
            else
            {
                if (it_experience_Combo.Text.Equals("Fresher")) { jobPosting.Experience = "0"; }
                else { jobPosting.Experience = it_experience_Combo.Text; }
            }
            jobPosting.Salary = it_salary.Text;
            jobPosting.Vacancy = it_vacancy.Text;

            if (it_location_Combo.SelectedIndex == -1) { jobPosting.Location = null; }
            else
            {
jobPosting.Location = it_location_Combo.Text; 
            }

            jobPosting.Cgpa = it_cgpa.Text;

            CheckBox[] checkBoxes = new CheckBox[] { cs_Check, c_Check, java_Check, c_Check, cpp_Check, ruby_Check, python_Check, php_Check, html_Check, javaScript_Check };
            jobPosting.Skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    jobPosting.Skill = jobPosting.Skill + checkBoxes[i].Content.ToString();
                }
            }
            jobPosting.Description = it_description.Text;


            if (cse_BL.NullCheck(jobPosting)==true)
            {
                MessageBox.Show("fill all The Requirment");
            }
            else
            {
                jobPosting.Id = it_id_Copy.Text + it_id.Text;
                MessageBox.Show(jobPosting.Id);
                if (cse_BL.IntegerCheck(it_salary.Text,it_vacancy.Text,it_cgpa.Text)==false)
                {
                    MessageBox.Show("Insert valid salary,vacancy,cgpa");
                }
                else
                {
                    try 
                    { 

                        //MessageBox.Show("ok");
                        double cgpa = Convert.ToDouble(jobPosting.Cgpa);
                        double experience = Convert.ToDouble(jobPosting.Experience);
                        double salary = double.Parse(jobPosting.Salary);
                        double vacancy = Convert.ToDouble(jobPosting.Vacancy);
                        string sector = "IT";
                        string query1 = " INSERT INTO job_posted (jobID,companyEmail,sector,type, title, experience, salary, vacancy, location,cgpa, skill, description) VALUES('" +jobPosting.Id + "','" + companyEmail + "','" + sector + "','" + jobPosting.Type + "','" + jobPosting.Title + "','" +experience + "','" + salary + "','" + vacancy + "','" + jobPosting.Location + "','" + cgpa + "','" + jobPosting.Skill + "','" + jobPosting.Description+ "')";
                        bool jobPostresult = Database.ExecuteQueryInsert(query1);

                        if (jobPostresult == true)
                        {
                            MessageBox.Show("Job Posted");
                            company_Login = new Company_Login(companyEmail);
                            this.Visibility = Visibility.Hidden;
                            company_Login.Show();
                        }
                        else
                        {
                            MessageBox.Show("fill up all the information");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }



        }

        private void eeeJobPost_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.Id = eng_id.Text;
            if (eng_full_Check.IsChecked == false && eng_half_Check.IsChecked == false)
            {
                MessageBox.Show("fill all The requirment");
            }
            else
            {
                if (eng_full_Check.IsChecked == true)
                {
                    jobPosting.Type = eng_full_Check.Content.ToString();
                }
                else
                {
                    jobPosting.Type = eng_half_Check.Content.ToString();
                }
            }

            jobPosting.Title = eng_title.Text;

            if (eng_experience_Combo.SelectedIndex == -1) { jobPosting.Experience = null; }
            else
            {
                if (eng_experience_Combo.Text.Equals("Fresher")) { jobPosting.Experience = "0"; }
                else { jobPosting.Experience = eng_experience_Combo.Text; }
            }
            jobPosting.Salary = eng_salary.Text;
            jobPosting.Vacancy = eng_vacancy.Text;

            if (eng_location_Combo.SelectedIndex == -1) { jobPosting.Location = null; }
            else
            {
                jobPosting.Location = eng_location_Combo.Text;
            }

            jobPosting.Cgpa = eng_cgpa.Text;

            CheckBox[] checkBoxes = new CheckBox[] { fitting_Check, scripting_Check, scripting_Check, certifiedELB_Check, powerGeneration_Check, sql_Check, mechanicalActivities_Check };
            jobPosting.Skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    jobPosting.Skill = jobPosting.Skill + checkBoxes[i].Content.ToString();
                }
            }
            jobPosting.Description = eng_description.Text;


            if (cse_BL.NullCheck(jobPosting) == true)
            {
                MessageBox.Show("fill all The Requirment");
            }
            else
            {
                jobPosting.Id = it_id_Copy.Text + eng_id.Text;
                MessageBox.Show(jobPosting.Id);
                if (cse_BL.IntegerCheck(eng_salary.Text, eng_vacancy.Text, eng_cgpa.Text) == false)
                {
                    MessageBox.Show("Insert valid salary,vacancy,cgpa");
                }
                else
                {
                    try
                    {

                      //  MessageBox.Show("ok");
                        double cgpa = Convert.ToDouble(jobPosting.Cgpa);
                        double experience = Convert.ToDouble(jobPosting.Experience);
                        double salary = double.Parse(jobPosting.Salary);
                        double vacancy = Convert.ToDouble(jobPosting.Vacancy);
                        string sector = "Engineering";
                        string query1 = " INSERT INTO job_posted (jobID,companyEmail,sector,type, title, experience, salary, vacancy, location,cgpa, skill, description) VALUES('" + jobPosting.Id + "','" + companyEmail + "','" + sector + "','" + jobPosting.Type + "','" + jobPosting.Title + "','" + experience + "','" + salary + "','" + vacancy + "','" + jobPosting.Location + "','" + cgpa + "','" + jobPosting.Skill + "','" + jobPosting.Description + "')";
                        bool jobPostresult = Database.ExecuteQueryInsert(query1);

                        if (jobPostresult == true)
                        {
                            MessageBox.Show("Job Posted");
                            company_Login = new Company_Login(companyEmail);
                            this.Visibility = Visibility.Hidden;
                            company_Login.Show();
                        }
                        else
                        {
                            MessageBox.Show("fill up all the information");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

        private void bbaJobPost_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
