﻿using System;
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
    /// Interaction logic for Applicant_LoginBBA.xaml
    /// </summary>
    public partial class Applicant_LoginBBA : Window
    {
        public string email = null;
        public string companyEmail;
        
        public Applicant_LoginBBA(string email)
        {
            InitializeComponent();
            this.email = email;
            TextBoxHidden();
            //MessageBox.Show(email);

            string query = "SELECT * FROM info_bba WHERE email='" + email + "';";
            ApplicantBBA applicantBBA = new ApplicantBBA();
            applicantBBA = BBA_DB.ExecuteQueryCSE(query, applicantBBA);
            //MessageBox.Show("CSE Loaded---" + applicantBBA.A_pass);

            if (applicantBBA == null)
            {
                MessageBox.Show("NUllll-----" + applicantBBA.A_name);
            }
            else
            {
                MessageBox.Show(applicantBBA.A_projects);
                cseName.Content = applicantBBA.A_name;
                cseEmail.Content = applicantBBA.A_email;
                csePass.Content = applicantBBA.A_pass;
                cseAddress.Content = applicantBBA.A_address;
                cseContact.Content = applicantBBA.A_contact;
                cseEduInstitution.Content = applicantBBA.A_eduInstitution;
                cseDegree.Content = applicantBBA.A_degree;
                cseCGPA.Content = applicantBBA.A_cgpa;
                csePassYear.Content = applicantBBA.A_passYear;
                cseSkill.Content = applicantBBA.A_skill;
                cseExperience.Content = applicantBBA.A_experience;
                cseExpSalary.Content = applicantBBA.A_expectedSalary;
                cseProjects.Content = applicantBBA.A_projects;

            }
            string query1 = "SELECT * FROM selected_bba WHERE applicant_email='" + email + "';";
            DataTable dt = Database.ExecuteQueryVIEW(query1);
            //MessageBox.Show("CSE Loaded---" + applicantBBA.A_pass);

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


            digital_Check.Visibility = Visibility.Hidden;
            market_Check.Visibility = Visibility.Hidden; corporate_Check.Visibility = Visibility.Hidden; strategy_Check.Visibility = Visibility.Hidden; promotional_Check.Visibility = Visibility.Hidden; agency_Check.Visibility = Visibility.Hidden; powerpoint_Check.Visibility = Visibility.Hidden; communication_Check.Visibility = Visibility.Hidden;
            experience_Combo.Visibility = Visibility.Hidden;
            A_L_expSalaryTB.Visibility = Visibility.Hidden;
            A_L_projectsTB.Visibility = Visibility.Hidden;
        }

        public void TextBoxShow()
        {
            A_L_nameTB.Visibility = Visibility.Visible;
            A_L_passPB.Visibility = Visibility.Visible;
            A_L_emailTB.Visibility = Visibility.Visible;
            A_L_addressTB.Visibility = Visibility.Visible;
            A_L_contactTB.Visibility = Visibility.Visible;
            A_L_eduInstitutionTB.Visibility = Visibility.Visible;
            A_L_degreeTB.Visibility = Visibility.Visible;
            A_L_cgpaTB.Visibility = Visibility.Visible;
            A_L_passYearTB.Visibility = Visibility.Visible;
            A_L_expSalaryTB.Visibility = Visibility.Visible;
            A_L_projectsTB.Visibility = Visibility.Visible;

            digital_Check.Visibility = Visibility.Visible;
            market_Check.Visibility = Visibility.Visible; corporate_Check.Visibility = Visibility.Visible; strategy_Check.Visibility = Visibility.Visible; promotional_Check.Visibility = Visibility.Visible; agency_Check.Visibility = Visibility.Visible; powerpoint_Check.Visibility = Visibility.Visible; communication_Check.Visibility = Visibility.Visible;
            experience_Combo.Visibility = Visibility.Visible;

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
       //A_L_passPB. = true;
       A_L_emailTB.Text = cseEmail.Content.ToString();
       A_L_addressTB.Text = cseAddress.Content.ToString();
       A_L_contactTB.Text = cseContact.Content.ToString();
       A_L_eduInstitutionTB.Text = cseEduInstitution.Content.ToString();
       A_L_degreeTB.Text = cseDegree.Content.ToString();
       A_L_cgpaTB.Text = cseCGPA.Content.ToString();
       A_L_passYearTB.Text = csePassYear.Content.ToString();
       A_L_expSalaryTB.Text = cseExpSalary.Content.ToString();
       A_L_projectsTB.Text = cseProjects.Content.ToString();

       

   }
   if (button.Name.Equals("update_button"))
   {
       A_L_nameTB.IsEnabled = false;
       A_L_passPB.IsEnabled = false;
       A_L_emailTB.IsEnabled = false;
       A_L_addressTB.IsEnabled = false;
       A_L_contactTB.IsEnabled = false;
       A_L_eduInstitutionTB.IsEnabled = false;
       A_L_degreeTB.IsEnabled = false;
       A_L_cgpaTB.IsEnabled = false;
       A_L_passYearTB.IsEnabled = false;
       A_L_expSalaryTB.IsEnabled = false;
       A_L_projectsTB.IsEnabled = false;

      

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
          // MessageBox.Show(companyEmail);
           Company_Resume company_Resume = new Company_Resume(companyEmail, email, "bba", this);
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
   Job_Search job_Search = new Job_Search(this, email);
   this.Visibility = Visibility.Hidden;
   job_Search.Show();
}
    }
}
