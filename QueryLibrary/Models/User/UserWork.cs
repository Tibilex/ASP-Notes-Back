namespace QueryLibrary.Models.User
{
    public class UserWork : IDisposable
    {
        private NoteContext _noteContext;
        private UserRepository _userRepository;

        public UserRepository UserRepo
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_noteContext);
                return _userRepository;
            }
        }

        public UserWork()
        {
            _noteContext = new();
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
