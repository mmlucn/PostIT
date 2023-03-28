using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostIT_API.Interfaces;
using Tesseract;

namespace PostIT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OCRController : ControllerBase
    {
        IOCREngine engine;
        public OCRController(IOCREngine ocrEngine)
        {
          engine = ocrEngine;
        }

        //[HttpPost("Post")]
        //public IActionResult Post(byte[] bytes)
        //{
        //    using(var image = Pix.LoadFromMemory(bytes))
        //    {
        //        using(var page = tesseractEngine.Process(image))
        //        {
        //            var text = page.GetText();
        //            return Ok(text);
        //        }
        //    }
        //}

        [HttpPost("PostTest")]
        public async Task<IActionResult> PostTest(IFormFile file)
        {
            var fileStream = file.OpenReadStream();
            MemoryStream stream = new MemoryStream();
            await file.CopyToAsync(stream);

            var text = engine.GetText(stream.ToArray());

            return Ok(text);
        }

    }
}
