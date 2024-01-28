using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoData _todoData;
        public TodoController(ITodoData todoData)
        {
            _todoData = todoData;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetTodo()
        {
            List<Todo> res = await _todoData.GetAll();
            if(res.Count == 0)
                return BadRequest(new List<Todo>());
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostTodo([FromBody] Todo t)
        {
            //Todo t = new(description);
            bool res = await _todoData.Add(t);
            if(!res)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodo(int id, [FromBody] Todo t)
        {
            bool res = await _todoData.Update(id, t);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            bool res = await _todoData.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}
