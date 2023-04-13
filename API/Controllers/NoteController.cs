using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostIT_API.EF;
using PostIT_API.Helpers;
using MauiLib.Models;
using MauiLib.DTOs;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var found = _context.Find<PostItNote>(id);
            return Ok(found);
        }

        [HttpGet()]
        public ActionResult<List<PostItNoteDTO>> Get()
        {
            var user = new UserHandler(_context).GetUser(HttpContext);
            if (user != null)
            {
                var notes = _context.PostItNote.Include(c => c.Image).Where(u => user == u.User).ToList();
                var notesToReturn = new List<PostItNoteDTO>();
                foreach (var note in notes)
                {
                    var noteDTO = new PostItNoteDTO()
                    {
                        Category = note.Category,
                        Image = new ImageDTO() { Data = note.Image?.Data },
                        Text = note.Text,
                        Title = note.Title,
                    };
                    notesToReturn.Add(noteDTO);
                }
                return Ok(notesToReturn);
            }
            return BadRequest(string.Empty);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PostItNoteDTO postItNote)
        {
            var userHandler = new UserHandler(_context);
            var user = userHandler.GetUser(HttpContext);
            if (user != null)
            {
                var addedNote = _context.Add<PostItNote>(new PostItNote
                {
                    Category = postItNote.Category,
                    Image = postItNote.Image == null ? null : new Image(postItNote.Image.Data),
                    Created = DateTime.UtcNow,
                    Text = postItNote.Text,
                    Title = postItNote.Title,
                    User = user,
                });
                await _context.SaveChangesAsync();
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
