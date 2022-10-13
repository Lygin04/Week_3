using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _dataContext.users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _dataContext.users.FindAsync(id);
            if (user == null)
                return BadRequest("Пользователь не найден");
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> Create(User user)
        {
           _dataContext.users.Add(user);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> Update(User UpdateUser)
        {
            var user = await _dataContext.users.FindAsync(UpdateUser.Id);
            if (user == null)
                return BadRequest("Пользователь не найден");

            user.Name = UpdateUser.Name;
            user.Surname = UpdateUser.Surname;
            user.Age = UpdateUser.Age;
            user.Email = UpdateUser.Email;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var user = await _dataContext.users.FindAsync(id);
            if (user == null)
                return BadRequest("Пользователь не найден");

            _dataContext.users.Remove(user);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.users.ToListAsync());
        }

    }
}
