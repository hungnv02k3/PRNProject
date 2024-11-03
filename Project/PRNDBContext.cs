using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows;

namespace Project
{
    
    public record Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOnly { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

    }
    
    public record Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    internal class PRNDBContext
    {
        SqlConnection connection;
        SqlCommand command;
        string ConnectionString = "Server=(local);Database=PRNProject;uid=hung;pwd=1234;TrustServerCertificate=true;";
        public Account GetAccounts(Account acc)
        {
            Account accounts = new Account();
            connection = new SqlConnection(ConnectionString);           
            var query = "SELECT * FROM Account WHERE UserName = @UserName AND PassWord = @PassWord";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", acc.UserName);
            command.Parameters.AddWithValue("@PassWord", acc.Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        accounts.Id = reader.GetInt32("ID");
                        accounts.UserName = reader.GetString("UserName");
                        accounts.Password = reader.GetString("PassWord");
                    }
                    return accounts;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return null;
        }
        public void AddNewAccount(string UserName,string PassWord)
        {
            connection = new SqlConnection(ConnectionString);
            var query = "INSERT Account (UserName, PassWord) VALUES (@UserName, @PassWord)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.Add(new SqlParameter("@PassWord", PassWord));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
        }
        private bool IsNameExists(string Name)
        {
            string ConnectionString = "Server=(local);Database=PRNProject;uid=hung;pwd=1234;TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT COUNT(*) FROM Car WHERE CarName = @CarName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@CarName", Name));
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Có lỗi khi kết nối đến database: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        
    }
}
