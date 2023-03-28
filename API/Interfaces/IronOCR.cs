using IronOcr;

namespace PostIT_API.Interfaces
{
    public class IronOCR : IOCREngine
    {
        IronTesseract engine;
        public IronOCR()
        {
            engine = new IronTesseract();
        }
        public string GetText(string base64)
        {
            throw new NotImplementedException();
        }

        public string GetText(byte[] data)
        {
            using (var input = new OcrInput(data))
            {
                input.DeNoise();
                input.Deskew();
                var result = engine.Read(input);
                return result.Text;
            }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
