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
using Microsoft.Win32;

namespace ProjectDemo
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        BusinessLogic bl = new BusinessLogic();
        CompanyBL company_bl = new CompanyBL();
        MainWindow mainWindow = new MainWindow();
        CSE_BL cse_bl = new CSE_BL();
        EEE_BL eee_bl = new EEE_BL();
        BBA_BL bba_bl = new BBA_BL();

        public SignUp()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void signUp_Button_Click(object sender, RoutedEventArgs e)
        {
            Company company = new Company();
            company.C_name = C_S_nameTB.Text;
            company.C_email = C_S_emailTB.Text;
            company.C_pass = C_S_passTB.Password.ToString();
            company.C_address = C_S_addressTB.Text;
            company.C_contact = C_S_contactTB.Text;
            if (C_S_typeCBox.SelectedIndex == -1)
            {
                company.C_type = null;
            }
            else
            {
                company.C_type = C_S_typeCBox.Text;
            }
            
            company.C_website = C_S_websiteTB.Text;
            company.C_tradeLicense = C_S_tlicenseTB.Text;
            company.C_description = C_S_descriptionTB.Text;

            if (company_bl.NullCheck(company) == true) 
            {
                MessageBox.Show(" fill all information");
            }
            else
            {
                if (bl.IsValidEmail(company.C_email) == false)
                {
                    MessageBox.Show("Invalid Email");
                   
                }
                else
                {
                    if (bl.IntegerCheck(company.C_contact,company.C_tradeLicense)== false)
                    {
                        MessageBox.Show("Insert valid contact/license");
                    }
                    else
                    {
                        try
                        {
                            string query1 = " INSERT into pendingreq_company (name,email,pass,address,contact,type,website,t_license,description) " +
                                "Values ('" + company.C_name + "','" + company.C_email + "','" + company.C_pass + "','" + company.C_address + "','" + company.C_contact + "','" + company.C_type + "','" + company.C_website + "','" + company.C_tradeLicense + "','" + company.C_description + "'); ";



                            bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                            if ( pendingRequestresult == true)
                            {
                                MessageBox.Show("SignUp Succesfull \n Waiting for Approval");
                                MainWindow mainWindow = new MainWindow();
                                this.Visibility = Visibility.Hidden;
                                mainWindow.Show();
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
            
        }

        private void signUpCSE_Button_Click(object sender, RoutedEventArgs e)
        {

            ApplicantCSE applicantCSE = new ApplicantCSE();
            applicantCSE.A_name = A_S_nameTB.Text;
            applicantCSE.A_email = A_S_emailTB.Text;
            applicantCSE.A_pass = A_S_passPB.Password;
            applicantCSE.A_address = A_S_addressTB.Text;
            applicantCSE.A_contact = A_S_contactTB.Text;
            applicantCSE.A_eduInstitution = A_S_eduInstitutionTB.Text;
            applicantCSE.A_degree = A_S_degreeTB.Text;
            applicantCSE.A_cgpa = A_S_cgpaTB.Text;
            applicantCSE.A_passYear = A_S_passYearTB.Text;


            CheckBox[] checkBoxes = new CheckBox[] { cs_Check,c_Check,java_Check,c_Check,cpp_Check,ruby_Check,python_Check,php_Check,html_Check,javaScript_Check};
            applicantCSE.A_skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    applicantCSE.A_skill = applicantCSE.A_skill+checkBoxes[i].Content.ToString();
                }
            }
                      
            
            if (experience_Combo.SelectedIndex == -1){ applicantCSE.A_experience = null; }
            else{ if (experience_Combo.Text.Equals("Fresher")) {applicantCSE.A_experience = "0";}
            else{ applicantCSE.A_experience = experience_Combo.Text; }}

            applicantCSE.A_expectedSalary = A_S_expSalaryTB.Text;
            applicantCSE.A_projects = A_S_projectsTB.Text;

            //MessageBox.Show(applicantCSE.A_experience);

            if (cse_bl.NullCheck(applicantCSE) == true)
            {
                MessageBox.Show(" fill all information");
            }
            else
            {
                if (bl.IsValidEmail(applicantCSE.A_email) == false)
                {
                    MessageBox.Show("Invalid Email");

                }
                else
                {
                    if (bl.IntegerCheck(applicantCSE.A_contact,applicantCSE.A_cgpa,applicantCSE.A_passYear,applicantCSE.A_expectedSalary) == false)
                    {
                        MessageBox.Show("Insert valid contact/cgpa/passYear/exp.salary");

                    }
                    else
                    {
                        try
                        {
                            double cgpa =Convert.ToDouble(applicantCSE.A_cgpa);
                            double experience = Convert.ToDouble(applicantCSE.A_experience);
                            double expsalary = double.Parse(applicantCSE.A_expectedSalary);
                            //bool result = Database.UserSignUp(company, "company");

                            string query1 = " INSERT INTO pendingreq_cse (name, email, pass, address, contact, edu_institution,degree, cgpa, passYear, skill, experience, expSalay, project) VALUES('"+applicantCSE.A_name+"','"+applicantCSE.A_email+"','"+applicantCSE.A_pass+ "','" + applicantCSE.A_address + "','" + applicantCSE.A_contact + "','" + applicantCSE.A_eduInstitution + "','" + applicantCSE.A_degree + "','" + cgpa+ "','" + applicantCSE.A_passYear + "','" + applicantCSE.A_skill + "','" + experience + "','" + expsalary + "','" + applicantCSE.A_projects + "')";
                            bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                            if ( pendingRequestresult == true)
                            {
                                MessageBox.Show("SignUp Succesfull \n Waiting for Approval");
                               
                                this.Visibility = Visibility.Hidden;
                                mainWindow.Show();
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
            
        }

        private void signUpEEE_Button_Click(object sender, RoutedEventArgs e)
        {

            ApplicantEEE applicantEEE = new ApplicantEEE();
            applicantEEE.A_name = A_S_nameTB1.Text;
            applicantEEE.A_email = A_S_emailTB1.Text;
            applicantEEE.A_pass = A_S_passPB1.Password;
            applicantEEE.A_address = A_S_addressTB1.Text;
            applicantEEE.A_contact = A_S_contactTB1.Text;
            applicantEEE.A_eduInstitution = A_S_eduInstitutionTB1.Text;
            applicantEEE.A_degree = A_S_degreeTB1.Text;
            applicantEEE.A_cgpa = A_S_cgpaTB1.Text;
            applicantEEE.A_passYear = A_S_passYearTB1.Text;


            CheckBox[] checkBoxes = new CheckBox[] { fitting_Check, mecha_Check,scrip_Check,elb_Check,power_Check,sql_Check };
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

            applicantEEE.A_expectedSalary = A_S_expSalaryTB1.Text;
            applicantEEE.A_projects = A_S_projectsTB1.Text;

            MessageBox.Show(applicantEEE.A_experience);

            if (eee_bl.NullCheck(applicantEEE) == true)
            {
                MessageBox.Show(" fill all information");
            }
            else
            {
                if (bl.IsValidEmail(applicantEEE.A_email) == false)
                {
                    MessageBox.Show("Invalid Email");

                }
                else
                {
                    if (bl.IntegerCheck(applicantEEE.A_contact, applicantEEE.A_cgpa, applicantEEE.A_passYear, applicantEEE.A_expectedSalary) == false)
                    {
                        MessageBox.Show("Insert valid contact/cgpa/passYear/exp.salary");

                    }
                    else
                    {
                        try
                        {
                            double cgpa = Convert.ToDouble(applicantEEE.A_cgpa);
                            double experience = Convert.ToDouble(applicantEEE.A_experience);
                            double expsalary = double.Parse(applicantEEE.A_expectedSalary);
                            //bool result = Database.UserSignUp(company, "company");

                            string query1 = " INSERT INTO pendingreq_eee (name, email, pass, address, contact, edu_institution,degree, cgpa, passYear, skill, experience, expSalay, project) VALUES('" + applicantEEE.A_name + "','" + applicantEEE.A_email + "','" + applicantEEE.A_pass + "','" + applicantEEE.A_address + "','" + applicantEEE.A_contact + "','" + applicantEEE.A_eduInstitution + "','" + applicantEEE.A_degree + "','" + cgpa + "','" + applicantEEE.A_passYear + "','" + applicantEEE.A_skill + "','" + experience + "','" + expsalary + "','" + applicantEEE.A_projects + "')";
                            bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                            if (pendingRequestresult == true)
                            {
                                MessageBox.Show("SignUp Succesfull \n Waiting for Approval");
                                
                                this.Visibility = Visibility.Hidden;
                                mainWindow.Show();
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
            
        }

        private void signUpBBA_Button_Click(object sender, RoutedEventArgs e)
        {

            ApplicantBBA applicantBBA = new ApplicantBBA();
            applicantBBA.A_name = A_S_nameTB2.Text;
            applicantBBA.A_email = A_S_emailTB2.Text;
            applicantBBA.A_pass = A_S_passPB2.Password;
            applicantBBA.A_address = A_S_addressTB2.Text;
            applicantBBA.A_contact = A_S_contactTB2.Text;
            applicantBBA.A_eduInstitution = A_S_eduInstitutionTB2.Text;
            applicantBBA.A_degree = A_S_degreeTB2.Text;
            applicantBBA.A_cgpa = A_S_cgpaTB2.Text;
            applicantBBA.A_passYear = A_S_passYearTB2.Text;


            CheckBox[] checkBoxes = new CheckBox[] { digital_Check, market_Check, corporate_Check, strategy_Check, promotional_Check, agency_Check, powerpoint_Check, communication_Check };
            applicantBBA.A_skill = null;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].IsChecked.GetValueOrDefault())
                {
                    applicantBBA.A_skill = applicantBBA.A_skill + checkBoxes[i].Content.ToString();
                }
            }


            if (experience_Combo2.SelectedIndex == -1) { applicantBBA.A_experience = null; }
            else
            {
                if (experience_Combo2.Text.Equals("Fresher")) { applicantBBA.A_experience = "0"; }
                else { applicantBBA.A_experience = experience_Combo2.Text; }
            }

            applicantBBA.A_expectedSalary = A_S_expSalaryTB2.Text;
            applicantBBA.A_projects = A_S_projectsTB2.Text;

            MessageBox.Show(applicantBBA.A_experience);

            if (bba_bl.NullCheck(applicantBBA) == true)
            {
                MessageBox.Show(" fill all information");
            }
            else
            {
                if (bl.IsValidEmail(applicantBBA.A_email) == false)
                {
                    MessageBox.Show("Invalid Email");

                }
                else
                {
                    if (bl.IntegerCheck(applicantBBA.A_contact, applicantBBA.A_cgpa, applicantBBA.A_passYear, applicantBBA.A_expectedSalary) == false)
                    {
                        MessageBox.Show("Insert valid contact/cgpa/passYear/exp.salary");

                    }
                    else
                    {
                        try
                        {
                            double cgpa = Convert.ToDouble(applicantBBA.A_cgpa);
                            double experience = Convert.ToDouble(applicantBBA.A_experience);
                            double expsalary = double.Parse(applicantBBA.A_expectedSalary);
                            //bool result = Database.UserSignUp(company, "company");

                            string query1 = " INSERT INTO pendingreq_bba (name, email, pass, address, contact, edu_institution,degree, cgpa, passYear, skill, experience, expSalay, project) VALUES('" + applicantBBA.A_name + "','" + applicantBBA.A_email + "','" + applicantBBA.A_pass + "','" + applicantBBA.A_address + "','" + applicantBBA.A_contact + "','" + applicantBBA.A_eduInstitution + "','" + applicantBBA.A_degree + "','" + cgpa + "','" + applicantBBA.A_passYear + "','" + applicantBBA.A_skill + "','" + experience + "','" + expsalary + "','" + applicantBBA.A_projects + "')";
                            bool pendingRequestresult = Database.ExecuteQueryInsert(query1);

                            if (pendingRequestresult == true)
                            {
                                MessageBox.Show("SignUp Succesfull \n Waiting for Approval");

                                this.Visibility = Visibility.Hidden;
                                mainWindow.Show();
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

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

/* upload image
Image dynamicImage = new Image();
dynamicImage.Stretch = Stretch.Fill;
            dynamicImage.StretchDirection = StretchDirection.Both;
            dynamicImage.Width = 300;
            dynamicImage.Height = 200;
            OpenFileDialog dlg = new OpenFileDialog();
dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.ShowDialog();
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
//FileNameLabel.Content = selectedFileName;
BitmapImage bitmap = new BitmapImage();
bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
bitmap.EndInit();
                //dynamicImage.Source = bitmap;
                imageView.Source = bitmap;
*/