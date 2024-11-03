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
    /// Interaction logic for ManageCategory.xaml
    /// </summary>
    public partial class ManageCategory : Window
    {
        public ManageCategory()
        {
            InitializeComponent();
            LoadCarData();
        }
        PRNDBContext prnDB = new PRNDBContext();
        private void LoadCarData()
        {           
            List<Car> cars = prnDB.GetCars();
            listViewCars.ItemsSource = cars;
        }
        public void LoadView(object sender, RoutedEventArgs e) => LoadCarData();
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                CarName = txtName.Text,
                CarProducer = txtPro.Text,
                CarPrice = float.Parse(txtPrice.Text),
                Sold =0,
                Remain = int.Parse(txtremain.Text),
            };
            prnDB.AddCar(car);           
            System.Windows.MessageBox.Show("Successful!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
            LoadCarData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
