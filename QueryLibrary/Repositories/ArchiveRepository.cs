using Dapper.Contrib.Extensions;
using QueryLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace QueryLibrary.Repositories
{
    public class ArchiveRepository
    {
        private static string _connectionString = "Server=DESKTOP-440KLQF\\SQLEXPRESS;Database=ASP_DataBase;Trusted_Connection=True;";

        // Get All Notes in Archive
        public static IEnumerable<Archive> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Archive>();
            }
        }

        // Get Note in Archive to "Owner"
        public static Archive GetNotesToOwners(string owner)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                foreach(Archive item in connection.GetAll<Archive>())
                {
                    if (item.Owner == owner)
                    {
                        return item;
                    }                    
                }
                return null;
            }
        }

        // Add note to Archive
        public static long AddNoteToArchive(Archive archive)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Insert(archive);
            }
        }

        // Delete Note in Archive to Owner
        public static void DeleteAllNotesByOwner(string owner)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                foreach (Archive item in connection.GetAll<Archive>())
                {
                    if (item.Owner == owner)
                    {
                        connection.Delete<Archive>(new Archive { Owner = owner });
                    }
                }
            }
        }
    }
}
