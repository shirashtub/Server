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
            if (res.Count == 0) { return BadRequest(new List<Users>()); }
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsers([FromBody] Users u)
        {
            bool isOk = await _usersData.Add(u);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Users u)
        {
            bool isOk = await _usersData.Update(id, u);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            bool isOk = await _usersData.Delete(id);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }
    }
}
