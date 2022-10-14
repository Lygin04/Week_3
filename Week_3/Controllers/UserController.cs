using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_3.Repositories;

namespace Week_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserRepository<User> _db;

        public UserController(UserRepository userRepository)
        {
            _db = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_db.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = _db.GetUser(id);
            if (user == null)
                return BadRequest("Пользователь не найден");
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            return Ok(_db.Create(user));
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            return Ok(_db.Update(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(_db.Delete(id));
        }
    }
}
