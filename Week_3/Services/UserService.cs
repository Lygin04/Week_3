using Week_3.Repositories;

namespace Week_3.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly DataContext _dataContext;
        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dataContext.users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.users.FindAsync(id);
            if (user == null)
                return user = new User();
            return user;
        }


        public async Task Create(User user)
        {
            _dataContext.users.Add(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(User UpdateUser)
        {
            var user = await _dataContext.users.FindAsync(UpdateUser.Id);
            if (user != null)
            {
                user.Name = UpdateUser.Name;
                user.Surname = UpdateUser.Surname;
                user.Age = UpdateUser.Age;
                user.Email = UpdateUser.Email;
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _dataContext.users.FindAsync(id);

            if (user != null)
                _dataContext.users.Remove(user);
            await _dataContext.SaveChangesAsync();
        }
    }
}
