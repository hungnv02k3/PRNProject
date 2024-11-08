using Microsoft.IdentityModel.Tokens;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public sealed class ManageGenre
    {
        private static ManageGenre? instance = null;
        private static readonly object instanceLock = new object();
        private ManageGenre() { }
        public static ManageGenre Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ManageGenre();
                    }
                }
                return instance;
            }
        }

        public List<Genre> GetAllGenres() {
            List<Genre> genres;
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                genres = myLib.Genres.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return genres;
        }

        public void InsertGenre(Genre genre) {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Genres.Add(genre);
                myLib.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateGenre(Genre genre)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Entry<Genre>(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // True nếu genre đang được gán vào sách
        public bool CheckGenreToDelete(Genre genre) {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                
                return myLib.Books.Any(b => b.GenreId == genre.GenreId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteGenre(Genre genre)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                var genreToDelete = myLib.Genres.SingleOrDefault(g => g.GenreId == genre.GenreId);
                myLib.Genres.Remove(genreToDelete);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Genre> SearchGenre(string key)
        {
            List<Genre> result = GetAllGenres();
            if (key.IsNullOrEmpty()) return result;
            else
            {
                result = result.Where(x => x.Name.ToLower().Contains(key.ToLower())).ToList();
            }
            return result;
        }
    }
}
