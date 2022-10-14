using Microsoft.AspNetCore.Mvc;
using Week_3.Services;

namespace Week_3.Repositories
{
    public class UserRepository : IUserRepository<User> 
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
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

            user.Name = UpdateUser.Name;
            user.Surname = UpdateUser.Surname;
            user.Age = UpdateUser.Age;
            user.Email = UpdateUser.Email;
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _dataContext.users.FindAsync(id);

            _dataContext.users.Remove(user);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
