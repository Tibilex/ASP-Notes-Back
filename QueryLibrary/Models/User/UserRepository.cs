namespace QueryLibrary.Models.User
{
    public class UserRepository : IUserRepository<Note>
    {
        private NoteContext _context;
        public UserRepository(NoteContext context)
        {
            this._context = context;
        }

        public Note Get(int id) => _context.Notes.Find(id);
        public IEnumerable<Note> GetAll() => _context.Notes;
    }
}
