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
            if (res.Count == 0) { return BadRequest(new List<Post>()); }
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostPost([FromBody] Post post)
        {
            bool isOk = await _postData.Add(post);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPost(int id, [FromBody] Post post)
        {
            bool isOk = await _postData.Update(id, post);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }

        [HttpPut]
        [Route("like/{id}")]
        public async Task<ActionResult> PutLikePost(int id)
        {
            bool isOk = await _postData.UpdateLike(id);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            bool isOk = await _postData.Delete(id);
            if (!isOk) { return BadRequest(); }
            return Ok();
        }
    }
}
