namespace QueryLibrary.Models.Admin
{
    public class AdminRepository : IAdminRepository<Note>
    {
        private NoteContext _context;
        public AdminRepository(NoteContext context)
        {
            this._context = context;
        }

        public Note Get(int id) => _context.Notes.Find(id);

        public IEnumerable<Note> GetAll() => _context.Notes;

        public int Add(Note note)
        {
            NoteContext db = new();
            db.Notes.Add(note);
            db.SaveChanges();
            return note.Id;
        }
        public bool Delete(int id)
        {
            Note? note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
