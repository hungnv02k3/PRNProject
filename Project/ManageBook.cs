using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public sealed class ManageBook
    {
        private static ManageBook? instance = null;
        private static readonly object instanceLock = new object();
        private ManageBook() { }
        public static ManageBook Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ManageBook();
                    }
                }
                return instance;
            }
        }
        public List<Book> GetAllBooks()
        {
            List<Book> books;
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                books = myLib.Books.Include(b => b.Genre).Include(b => b.Author).Include(b => b.Publisher).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return books;
        }

        public void InsertBook(Book book)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Books.Add(book);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBook(Book book)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                var bookToDelete = myLib.Books.SingleOrDefault(b => b.BookId == book.BookId);
                myLib.Books.Remove(bookToDelete);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Book> SearchBook(string key)
        {
            List<Book> result = GetAllBooks();
            if (key.IsNullOrEmpty()) return result;
            else {
                result = result.Where(x => (x.Title.ToLower().Contains(key.ToLower())) ||
                                     (x.Genre.Name.ToLower().Contains(key.ToLower())) ||
                                     (x.Author.Name.ToLower().Contains(key.ToLower())) ||
                                     (x.Quantity.ToString().Contains(key.ToLower())) ||
                                     (x.Publisher.Name.ToLower().Contains(key.ToLower())) ||
                                     (x.YearPublished.ToString().Contains(key.ToLower()))
                                     ).ToList();
            }
            return result;
        }
    }
}
