using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesseract;

namespace PostIT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OCRController : ControllerBase
    {
        TesseractEngine tesseractEngine;
        public OCRController()
        {
          tesseractEngine = new TesseractEngine(@"./tessdata", "dan", EngineMode.Default);
        }

        [HttpPost]
        public IActionResult Post(byte[] bytes)
        {
            using(var image = Pix.LoadFromMemory(bytes))
            {
                using(var page = tesseractEngine.Process(image))
                {
                    var text = page.GetText();
                    return Ok(text);
                }
            }

        }

    }
}
