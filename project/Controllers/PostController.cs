using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostData _postData;
        public PostController(IPostData postData)
        {
            _postData = postData;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPost()
        {
            List<Post> res = await _postData.GetAll();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostPost([FromBody] Post p)
        {
            await _postData.Add(p);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPost(int id, [FromBody] Post p)
        {
            await _postData.Update(id, p);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postData.Delete(id);
            return Ok();
        }
    }
}
