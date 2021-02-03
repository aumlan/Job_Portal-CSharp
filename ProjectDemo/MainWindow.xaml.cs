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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace ProjectDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessLogic bl = new BusinessLogic();
        public MainWindow()
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
            SignUp signUp = new SignUp();
            this.Visibility = Visibility.Hidden;
            signUp.Show();

        }

        private void login_Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = username_TB.Text;
            string pass = passPB.Password.ToString();
            //MessageBox.Show(pass);
            if (bl.IsValidEmail(userName))
            {
                if (bl.NullCheck(userName,pass)){ MessageBox.Show("input username/pass"); }
                else
                {
                    String query = "SELECT username, pass,status FROM login WHERE username='" + userName + "' AND pass='" + pass + "';";
                    string status = Database.ExecuteQueryLogin(query);
                    //MessageBox.Show(status);
                    if (status == null){ MessageBox.Show("Incorrect name/pass \n Your Account haven't Approved yet"); }
                    else if (status.Equals("company"))
                    {
                        Company_Login company_Login = new Company_Login(userName);
                        this.Visibility = Visibility.Hidden;
                        company_Login.Show();
                    }
                    else if (status.Equals("admin"))
                    {
                        Admin admin = new Admin();
                        this.Visibility = Visibility.Hidden;
                        admin.Show();
                    }
                    else if (status.Equals("cse"))
                    {
                        CSE_Profile applicant_LoginCSE = new CSE_Profile(userName);
                        this.Visibility = Visibility.Hidden;
                        applicant_LoginCSE.Show();
                    }
                    else if (status.Equals("eee"))
                    {
                        Applicant_LoginEEE applicant_LoginEEE = new Applicant_LoginEEE(userName);
                        this.Visibility = Visibility.Hidden;
                        applicant_LoginEEE.Show();
                    }
                    else if (status.Equals("bba"))
                    {
                        Applicant_LoginBBA applicant_LoginBBA = new Applicant_LoginBBA(userName);
                        this.Visibility = Visibility.Hidden;
                        applicant_LoginBBA.Show();
                    }

                }    
            }
            else { MessageBox.Show("Insert Valid Email"); }
        }
    }

   


}
