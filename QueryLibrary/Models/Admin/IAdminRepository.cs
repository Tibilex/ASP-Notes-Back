namespace QueryLibrary.Models.Admin
{
    public interface IAdminRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        int Add(Note note);
        bool Delete(int id);
    }
}
