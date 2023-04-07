using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostIT_API.EF;
using PostIT_Lib.Models;

namespace PostIT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostIT2Controller : ControllerBase
    {
        PostITContext _context;
        public PostIT2Controller(PostITContext context)
        {
            _context = context;
            //var token = HttpContext.Request.Headers["Authorization"];
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var found = _context.Find<PostItNote>(id);
            return Ok(found);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<PostItNote>> GetAll()
        {
            int userid = 0;
            var found = _context.User.Where(e => e.Id == userid).First().PostItNotes;
            return Ok(found);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PostItNote postItNote)
        {
            _context.Add<PostItNote>(postItNote);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //[HttpPut]
        //public IActionResult Put()
        //{
        //    return Ok();
        //}
        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    return Ok();
        //}

    }
}
