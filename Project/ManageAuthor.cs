using Microsoft.IdentityModel.Tokens;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public sealed class ManageAuthor
    {
        private static ManageAuthor? instance = null;
        private static readonly object instanceLock = new object();
        private ManageAuthor() { }
        public static ManageAuthor Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ManageAuthor();
                    }
                }
                return instance;
            }
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors;
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                authors = myLib.Authors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return authors;
        }

        public void InsertAuthor(Author author)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Authors.Add(author);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAuthor(Author author)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Entry<Author>(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // True nếu author đang được gán vào sách
        public bool CheckAuthorToDelete(Author author)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();

                return myLib.Books.Any(b => b.AuthorId == author.AuthorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAuthor(Author author)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                var authorToDelete = myLib.Authors.SingleOrDefault(a => a.AuthorId == author.AuthorId);
                myLib.Authors.Remove(authorToDelete);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Author> SearchAuthor(string key)
        {
            List<Author> result = GetAllAuthors();
            if (key.IsNullOrEmpty()) return result;
            else
            {
                result = result.Where(x => x.Name.ToLower().Contains(key.ToLower())).ToList();
            }
            return result;
        }
    }
}
