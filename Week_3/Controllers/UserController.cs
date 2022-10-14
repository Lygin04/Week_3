using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_3.Repositories;

namespace Week_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository<User> _db;

        public UserController(IUserRepository<User> userRepository)
        {
            _db = userRepository;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {

            return await _db.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            var user = _db.GetUser(id);
            return await user;
        }


        [HttpPost]
        public async Task Create(User user)
        {
            await _db.Create(user);
        }

        [HttpPut]
        public async Task Update(User user)
        {
            await _db.Update(user);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _db.Delete(id);
        }
    }
}
