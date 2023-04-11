using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostIT_API.EF;
using PostIT_API.Helpers;
using MauiLib.Models;
using MauiLib.DTOs;

namespace PostIT_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        PostITContext _context;
        HttpContext? _httpContext;
        public NoteController(PostITContext context)
        {
            _context = context;
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
            //int userid = 0;
            //var found = _context.User.Where(e => e.Id == userid).First().PostItNotes;
            //return Ok(found);
            return Ok(null);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PostItNoteDTO postItNote)
        {
            var userHandler = new UserHandler(_context);
            var user = userHandler.GetUser(HttpContext);
            if (user != null)
            {
                //postItNote.User = user;
                //_context.Add<PostItNote>(postItNote);
                //await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
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
