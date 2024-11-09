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
using MessageBox = System.Windows.Forms.MessageBox;

namespace Project
{
    /// <summary>
    /// Interaction logic for ManagerEmployees.xaml
    /// </summary>
    public partial class ManagerEmployees : Window
    {
        public ManagerEmployees()
        {
            InitializeComponent();
            this.Loaded += loadedData;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = dtDate.SelectedDate;
            DateOnly dateOnly = DateOnly.FromDateTime(selectedDate.Value);
            var emp = new Employee
            {
                UserName = txtName.Text,
                D
            };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
             "Exit Confirmation",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
             );
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
        }
        private void loadedData(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Employee> categories = ManageEmployee.Instance.GetEmployees();
                lvCar.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
