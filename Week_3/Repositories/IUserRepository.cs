namespace Week_3.Repositories
{
    public interface IUserRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetUser(int id);
        Task Create(T user);
        Task Update(T user);
        Task Delete(int id);
    }
}
