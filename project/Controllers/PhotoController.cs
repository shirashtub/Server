using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoData _photoData;
        public PhotoController(IPhotoData photoData)
        {
            _photoData = photoData;
        }
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetPhoto()
        {
            List<Photo> res = await _photoData.GetAll();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> PostPhoto([FromBody] Photo p)
        {
            await _photoData.Add(p);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPhoto(int id, [FromBody] Photo p)
        {
            await _photoData.Update(id, p);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            await _photoData.Delete(id);
            return Ok();
        }
    }
}
