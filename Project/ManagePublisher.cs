using Microsoft.IdentityModel.Tokens;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public sealed class ManagePublisher
    {
        private static ManagePublisher? instance = null;
        private static readonly object instanceLock = new object();
        private ManagePublisher() { }
        public static ManagePublisher Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ManagePublisher();
                    }
                }
                return instance;
            }
        }
        public List<Publisher> GetAllPublishers()
        {
            List<Publisher> publishers;
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                publishers = myLib.Publishers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return publishers;
        }

        public void InsertPublisher(Publisher publisher)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Publishers.Add(publisher);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePublisher(Publisher publisher)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                myLib.Entry<Publisher>(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // True nếu publisher đang được gán vào sách
        public bool CheckPublisherToDelete(Publisher publisher)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();

                return myLib.Books.Any(b => b.PublisherId == publisher.PublisherId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeletePublisher(Publisher publisher)
        {
            try
            {
                using QuanLyThuVienContext myLib = new QuanLyThuVienContext();
                var publisherToDelete = myLib.Publishers.SingleOrDefault(a => a.PublisherId == publisher.PublisherId);
                myLib.Publishers.Remove(publisherToDelete);
                myLib.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Publisher> SearchPublisher(string key)
        {
            List<Publisher> result = GetAllPublishers();
            if (key.IsNullOrEmpty()) return result;
            else
            {
                result = result.Where(x => (x.Name.ToLower().Contains(key.ToLower())) ||
                                           (x.Address.ToLower().Contains(key.ToLower()))
                                            ).ToList();
            }
            return result;
        }
    }
}
