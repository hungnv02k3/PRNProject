using Project.Models;
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
using Project.Models;
namespace Project
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            string confirmPassword = txtConfirmPass.Text;
            if (password.Equals(confirmPassword))
            {
                ManageEmployee.Instance.AddAccount(username, password);
                System.Windows.MessageBox.Show("Registered successful!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
            else
            {
                System.Windows.MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassWord.Clear();
                txtConfirmPass.Clear();
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
