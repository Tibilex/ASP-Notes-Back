namespace QueryLibrary.Models.Admin
{
    public class AdminWork : IDisposable
    {
        private NoteContext _noteContext;
        private AdminRepository _adminRepository;

        public AdminRepository AdminRepository
        {
            get
            {
                if (_adminRepository == null)
                    _adminRepository = new AdminRepository(_noteContext);
                return _adminRepository;
            }
            set { _adminRepository = value; }
        }

        public AdminWork()
        {
            _noteContext = new();
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
