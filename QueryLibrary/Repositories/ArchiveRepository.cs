using Dapper.Contrib.Extensions;
using QueryLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace QueryLibrary.Repositories
{
    public class ArchiveRepository
    {
        private static string _connectionString = "Data Source=SQL8001.site4now.net,1433;Initial Catalog=db_a8dfe9_aspdb;User Id=db_a8dfe9_aspdb_admin;Password=Bozic901;";

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

        // Delete All Notes in Archive
        public static bool DeleteAllNotes()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                foreach (Archive item in connection.GetAll<Archive>())
                {
                    return connection.DeleteAll<Archive>();
                }
                return false;
            }
        }
    }
}
