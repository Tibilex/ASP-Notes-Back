using Dapper.Contrib.Extensions;
using QueryLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace QueryLibrary.Repositories
{
    public class NoteRepository
    {
        private static string _connectionString = "Data Source=SQL8001.site4now.net,1433;Initial Catalog=db_a8dfe9_aspdb;User Id=db_a8dfe9_aspdb_admin;Password=Bozic901;";

        // Get All Notes
        public static IEnumerable<Note> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Note>();
            }
        }

        // Get Note for "Id"
        public static Note GetNoteToId(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Note>(id);
            }
        }

        // Add Note
        public static long AddNote(Note note)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Insert(note);
            }
        }

        // Delete Note
        public static bool DeleteNote(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Delete<Note>(new Note { Id = id });
            }
        }
    }
}
