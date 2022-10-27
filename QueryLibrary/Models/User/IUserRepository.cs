namespace QueryLibrary.Models.User
{
    public interface IUserRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
