using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for ManageBookWindow.xaml
    /// </summary>
    public partial class ManageBookWindow : Window
    {
        private void LoadGenres()
        {
            using (var _context = new QuanLyThuVienContext())
            {
                List<Genre> genres = _context.Genres.ToList();
                cmbGenre.ItemsSource = genres;
            }
        }

        private void LoadAuthor()
        {
            using (var _context = new QuanLyThuVienContext())
            {
                List<Author> authors = _context.Authors.ToList();
                cmbAuthor.ItemsSource = authors;
            }
        }
        private void LoadPublisher()
        {
            using (var _context = new QuanLyThuVienContext())
            {
                List<Publisher> publishers = _context.Publishers.ToList();
                cmbPublisher.ItemsSource = publishers;
            }
        }
        private void LoadPublisherYears()
        {
            // Lấy năm hiện tại
            int currentYear = DateTime.Now.Year;

            // Tạo danh sách các năm hợp lệ từ 1800 đến năm hiện tại
            List<int> years = new List<int>();
            for (int year = 1800; year <= currentYear; year++)
            {
                years.Add(year);
            }

            // Gán danh sách năm cho ComboBox
            cmbPubYear.ItemsSource = years;
            cmbPubYear.SelectedItem = currentYear;  // Chọn năm hiện tại mặc định
        }
        public ManageBookWindow()
        {
            InitializeComponent();
            LoadGenres();
            LoadAuthor();
            LoadPublisher();
            LoadPublisherYears();
        }
        private string GenerateUniqueIsbn(QuanLyThuVienContext context)
        {
            Random random = new Random();
            string isbn;

            do
            {
                // Sinh ngẫu nhiên số ISBN có 10 chữ số
                int part1 = random.Next(100000, 1000000);
                int part2 = random.Next(0, 1000000);
                isbn = $"{part1:D6}{part2:D4}";
            } while (context.Books.Any(b => b.Isbn == isbn)); // Kiểm tra trùng lặp trong cơ sở dữ liệu

            return isbn;
        }

        private void FillData()
        {
            BookDataGrid.ItemsSource = null;
            BookDataGrid.ItemsSource = ManageBook.Instance.GetAllBooks();
        }
        private void BookDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void BookDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void TxtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào là số và giá trị phải >= 0
            e.Handled = !IsTextAllowed(((TextBox)sender).Text + e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            // Kiểm tra chuỗi có phải là số nguyên không âm
            return int.TryParse(text, out int result) && result >= 0;
        }


        private void BookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBook = BookDataGrid.SelectedItem as Book;
            if (selectedBook != null)
            {
                txtBookId.Text = selectedBook.BookId.ToString();
                txtTitle.Text = selectedBook.Title;
                cmbGenre.Text = selectedBook.Genre?.Name;
                cmbAuthor.Text = selectedBook.Author?.Name;
                txtQuantity.Text = selectedBook.Quantity.ToString();
                cmbPublisher.Text = selectedBook.Publisher?.Name;
                cmbPubYear.Text = selectedBook.YearPublished?.ToString();
                txtDescription.Text = selectedBook.Description?.ToString();
            }
            else return;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm insert this book to library?", "Confirm insert?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                using (var context = new QuanLyThuVienContext())
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Book book = new();
                        book.BookId = Guid.NewGuid();
                        book.Title = txtTitle.Text;
                        book.GenreId = (cmbGenre.SelectedItem as Genre)?.GenreId;
                        book.AuthorId = (cmbAuthor.SelectedItem as Author)?.AuthorId;
                        book.Quantity = int.Parse(txtQuantity.Text);
                        book.PublisherId = (cmbPublisher.SelectedItem as Publisher)?.PublisherId;
                        book.YearPublished = int.Parse(cmbPubYear.Text);
                        book.Description = txtDescription.Text;
                        book.Isbn = GenerateUniqueIsbn(context);
                        ManageBook.Instance.InsertBook(book);
                        FillData();
                        MessageBox.Show("Insert book successfully!");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please check your data and try again.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm update this book?", "Confirm update?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                var selectedBook = (Book)BookDataGrid.SelectedItem;
                    if (selectedBook != null)
                    {
                        Book book = new();
                        book.BookId = selectedBook.BookId;
                        book.Title = txtTitle.Text;
                        book.GenreId = (cmbGenre.SelectedItem as Genre)?.GenreId;
                        book.AuthorId = (cmbAuthor.SelectedItem as Author)?.AuthorId;
                        book.Quantity = int.Parse(txtQuantity.Text);
                        book.PublisherId = (cmbPublisher.SelectedItem as Publisher)?.PublisherId;
                        book.YearPublished = int.Parse(cmbPubYear.Text);
                        book.Description = txtDescription.Text;
                        book.Isbn = null;
                        ManageBook.Instance.UpdateBook(book);
                        FillData();
                        MessageBox.Show("Update book successfully!");
                    }
                    else MessageBox.Show("Select a book to update", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please check your data and try again.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm delete this book from library?", "Confirm delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var selectedBook = (Book)BookDataGrid.SelectedItem;
                    if (selectedBook != null)
                    {
                        Book book = new();
                        book.BookId = selectedBook.BookId;
                        ManageBook.Instance.DeleteBook(book);
                        FillData();
                        MessageBox.Show("Delete book successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Please select a book to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm refresh now?", "Confirm refresh?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                txtBookId.Clear();
                txtTitle.Clear();
                txtQuantity.Clear();
                txtDescription.Clear();
                txtSearch.Clear();
                cmbGenre.SelectedIndex = -1;
                cmbAuthor.SelectedIndex = -1;
                cmbPublisher.SelectedIndex = -1;
                cmbPubYear.SelectedIndex = -1;
                FillData();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var result = ManageBook.Instance.SearchBook(txtSearch.Text);
            BookDataGrid.ItemsSource = null;
            BookDataGrid.ItemsSource = result;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manageBook = new MainWindow();
            manageBook.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?",
             "Logout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?",
             "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
