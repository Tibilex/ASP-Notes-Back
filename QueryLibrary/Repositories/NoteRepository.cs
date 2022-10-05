using Dapper.Contrib.Extensions;
using QueryLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace QueryLibrary.Repositories
{
    public class NoteRepository
    {
        private static string _connectionString = "Server=DESKTOP-440KLQF\\SQLEXPRESS;Database=ASP_DataBase;Trusted_Connection=True;";

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
