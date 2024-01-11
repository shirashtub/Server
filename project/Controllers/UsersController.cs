using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersData _usersData;
        public UsersController(IUsersData usersData)
        {
            _usersData = usersData;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            List<Users> res = await _usersData.GetAll();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsers([FromBody] Users u)
        {
            await _usersData.Add(u);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Users u)
        {
            await _usersData.Update(id, u);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            await _usersData.Delete(id);
            return Ok();
        }
    }
}
