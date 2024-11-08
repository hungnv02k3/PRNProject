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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for ManageCatalogWindow.xaml
    /// </summary>
    public partial class ManageCatalogWindow : Window
    {
        public ManageCatalogWindow()
        {
            InitializeComponent();
            FillGenreData();
            FillAuthorData();
            FillPublisherData();
        }
        // Bảng Genre
        public void FillGenreData()
        {
            GenreDataGrid.ItemsSource = null;
            GenreDataGrid.ItemsSource = ManageGenre.Instance.GetAllGenres();
        }

        private void GenreDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGenre = GenreDataGrid.SelectedItem as Genre;
            if (selectedGenre != null)
            {
                txtGenreID.Text = selectedGenre.GenreId.ToString();
                txtGenreName.Text = selectedGenre.Name;
            }
            else return;
        }

        private void btnInsertGenre_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm insert genre to library?", "Confirm insert?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                using (var context = new QuanLyThuVienContext())
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Genre genre = new();
                        genre.GenreId = Guid.NewGuid();
                        genre.Name = txtGenreName.Text;
                        ManageGenre.Instance.InsertGenre(genre);
                        FillGenreData();
                        MessageBox.Show("Insert genre successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdateGenre_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to update this genre?", "Confirm update?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var selectedGenre = GenreDataGrid.SelectedItem as Genre;
                    if (selectedGenre != null)
                    {
                        Genre genre = new();
                        genre.GenreId = selectedGenre.GenreId;
                        genre.Name = txtGenreName.Text;
                        ManageGenre.Instance.UpdateGenre(genre);
                        FillGenreData();
                        MessageBox.Show("Update genre successfully!");
                    }
                    else MessageBox.Show("Select a genre to update", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to delete this genre?", "Confirm delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var selectedGenre = GenreDataGrid.SelectedItem as Genre;
                    if (selectedGenre != null)
                    {
                        if (!ManageGenre.Instance.CheckGenreToDelete(selectedGenre))
                        {
                            Genre genre = new();
                            genre.GenreId = selectedGenre.GenreId;
                            ManageGenre.Instance.DeleteGenre(genre);
                            FillGenreData();
                            MessageBox.Show("Delete genre successfully!");
                        }
                        else MessageBox.Show("Can't delete this genre because it is in use!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else MessageBox.Show("Select a genre to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ex) {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefreshGenre_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to refresh genre table now?", "Confirm refresh?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) { 
                txtGenreID.Clear();
                txtGenreName.Clear();
            }
        }

        private void btnSearchGenre_Click(object sender, RoutedEventArgs e)
        {
            var result = ManageGenre.Instance.SearchGenre(txtSearchGenre.Text);
            GenreDataGrid.ItemsSource = null;
            GenreDataGrid.ItemsSource = result;
        }

        // Bảng Authors
        public void FillAuthorData()
        {
            AuthorDataGrid.ItemsSource = null;
            AuthorDataGrid.ItemsSource = ManageAuthor.Instance.GetAllAuthors();
        }

        private void AuthorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAuthor = AuthorDataGrid.SelectedItem as Author;
            if (selectedAuthor != null)
            {
                txtAuthorID.Text = selectedAuthor.AuthorId.ToString();
                txtAuthorName.Text = selectedAuthor.Name;
                txtBiography.Text = selectedAuthor.Bio;
            }
            else return;
        }

        private void btnInsertAuthor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm insert author to library?", "Confirm insert?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                using (var context = new QuanLyThuVienContext())
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Author author = new();
                        author.AuthorId = Guid.NewGuid();
                        author.Name = txtAuthorName.Text;
                        author.Bio = txtBiography.Text;
                        ManageAuthor.Instance.InsertAuthor(author);
                        FillAuthorData();
                        MessageBox.Show("Insert author successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdateAuthor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to update this author?", "Confirm update?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var selectedAuthor = AuthorDataGrid.SelectedItem as Author;
                    if (selectedAuthor != null)
                    {
                        Author author = new();
                        author.AuthorId = selectedAuthor.AuthorId;
                        author.Name = txtAuthorName.Text;
                        author.Bio = txtBiography.Text;
                        ManageAuthor.Instance.UpdateAuthor(author);
                        FillAuthorData();
                        MessageBox.Show("Update author successfully!");
                    }
                    else MessageBox.Show("Select an author to update", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to delete this author?", "Confirm delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var selectedAuthor = AuthorDataGrid.SelectedItem as Author;
                    if (selectedAuthor != null)
                    {
                        if (!ManageAuthor.Instance.CheckAuthorToDelete(selectedAuthor))
                        {
                            Author author = new();
                            author.AuthorId = selectedAuthor.AuthorId;
                            ManageAuthor.Instance.DeleteAuthor(author);
                            FillAuthorData();
                            MessageBox.Show("Delete author successfully!");
                        }
                        else MessageBox.Show("Can't delete this author because it is in use!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else MessageBox.Show("Select an author to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefreshAuthor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to refresh author table now?", "Confirm refresh?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                txtAuthorID.Clear();
                txtAuthorName.Clear();
                txtBiography.Clear();
            }
        }

        private void btnSearchAuthor_Click(object sender, RoutedEventArgs e)
        {
            var result = ManageAuthor.Instance.SearchAuthor(txtSearchAuthor.Text);
            AuthorDataGrid.ItemsSource = null;
            AuthorDataGrid.ItemsSource = result;
        }

        // Bảng Authors
        public void FillPublisherData()
        {
            PublisherDataGrid.ItemsSource = null;
            PublisherDataGrid.ItemsSource = ManagePublisher.Instance.GetAllPublishers();
        }

        private void PublisherDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPublisher = PublisherDataGrid.SelectedItem as Publisher;
            if (selectedPublisher != null)
            {
                txtPublisherID.Text = selectedPublisher.PublisherId.ToString();
                txtPublisherName.Text = selectedPublisher.Name;
                txtPublisherAddress.Text = selectedPublisher.Address;
            }
            else return;
        }

        private void btnInsertPublisher_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm insert publisher to library?", "Confirm insert?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                using (var context = new QuanLyThuVienContext())
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Publisher publisher = new();
                        publisher.PublisherId = Guid.NewGuid();
                        publisher.Name = txtPublisherName.Text;
                        publisher.Address = txtPublisherAddress.Text;
                        ManagePublisher.Instance.InsertPublisher(publisher);
                        FillPublisherData();
                        MessageBox.Show("Insert publisher successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdatePublisher_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to update this publisher?", "Confirm update?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var selectedPublisher = PublisherDataGrid.SelectedItem as Publisher;
                    if (selectedPublisher != null)
                    {
                        Publisher publisher = new();
                        publisher.PublisherId = selectedPublisher.PublisherId;
                        publisher.Name = txtPublisherName.Text;
                        publisher.Address = txtPublisherAddress.Text;
                        ManagePublisher.Instance.UpdatePublisher(publisher);
                        FillPublisherData();
                        MessageBox.Show("Update publisher successfully!");
                    }
                    else MessageBox.Show("Select a publisher to update", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeletePublisher_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to delete this publisher?", "Confirm delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var selectedPublisher = PublisherDataGrid.SelectedItem as Publisher;
                    if (selectedPublisher != null)
                    {
                        if (!ManagePublisher.Instance.CheckPublisherToDelete(selectedPublisher))
                        {
                            Publisher publisher = new();
                            publisher.PublisherId = selectedPublisher.PublisherId;
                            ManagePublisher.Instance.DeletePublisher(publisher);
                            FillPublisherData();
                            MessageBox.Show("Delete publisher successfully!");
                        }
                        else MessageBox.Show("Can't delete this publisher because it is in use!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else MessageBox.Show("Select an publisher to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefreshPublisher_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm to refresh publisher table now?", "Confirm refresh?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                txtPublisherID.Clear();
                txtPublisherName.Clear();
                txtPublisherAddress.Clear();
            }
        }

        private void btnSearchPublisher_Click(object sender, RoutedEventArgs e)
        {
            var result = ManagePublisher.Instance.SearchPublisher(txtSearchPublisher.Text);
            PublisherDataGrid.ItemsSource = null;
            PublisherDataGrid.ItemsSource = result;
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
