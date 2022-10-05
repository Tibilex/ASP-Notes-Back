using Dapper.Contrib.Extensions;
using QueryLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace QueryLibrary.Repositories
{
    public class UserRepository
    {
        private static string _connectionString = "Server=DESKTOP-440KLQF\\SQLEXPRESS;Database=ASP_DataBase;Trusted_Connection=True;";

        // Get All Users
        public static IEnumerable<User> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<User>();
            }
        }

        // Get User for "Id"
        public static User GetUserById(int id) 
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Get<User>(id);
            }
        }

        // Add User
        public static long AddUser(User user)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Insert(user);
            }
        }

        // Delete User
        public static bool DeleteUser(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString)) 
            {
                return connection.Delete<User>(new User { Id = id });
            }
        }

        // Password valid check
        public static bool PasswordValidCheck(string name, string password)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                foreach (User item in connection.GetAll<User>())
                {
                    if (item.Name == name && BCrypt.Net.BCrypt.Verify(password, item.Password))
                    { 
                        return true;
                    }
                }
            }
            return false;
        }

        // User valid check
        public static bool UserValidCheck(string name, string token)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                foreach (User item in connection.GetAll<User>())
                {
                    if (item.Name == name && item.Token == token)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // User Token valid check
        public static bool UserTokenValidCheck(string token)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                foreach (var item in connection.GetAll<User>())
                {
                    if (item.Token == token) return true;
                }
            }
            return false;
        }
    }
}
