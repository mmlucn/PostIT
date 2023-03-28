using System.IO;
using Tesseract;

namespace PostIT_API.Interfaces
{
    public class TessOCR : IOCREngine
    {
        TesseractEngine engine;
        public TessOCR()
        {
            engine = new TesseractEngine(@"./tessdata", "dan", EngineMode.TesseractAndLstm);
        }
        public void Start()
        {
            throw new NotImplementedException();
        }
        public string GetText(string base64)
        {
            throw new NotImplementedException();
        }

        public string GetText(byte[] data)
        {
            using (var image = Pix.LoadFromMemory(data))
            {
                using (var page = engine.Process(image))
                {
                    var text = page.GetText();
                    return text;
                }
            }
        }
    }
}
