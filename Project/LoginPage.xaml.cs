using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Project
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        PRNDBContext pRNDBContext = new PRNDBContext();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var acc = new Account
            {
                UserName = txtUserName.Text,
                Password = txtPassWord.Text
            };
           Account b =  pRNDBContext.GetAccounts(acc);
            if(b != null )
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                System.Windows.MessageBox.Show("Wrong Pass or UserName!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
             "Exit Confirmation",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
             );
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
