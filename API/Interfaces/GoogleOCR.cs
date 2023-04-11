using Google.Cloud.Vision.V1;
using System.Text;

namespace PostIT_API.Interfaces
{
    public class GoogleOCR : IOCREngine
    {
        ImageAnnotatorClient client;
        public GoogleOCR()
        {
            var builder = new ImageAnnotatorClientBuilder()
            {
                CredentialsPath = @"visionkey.json",
            };

            client = builder.Build();
        }

        public string GetText(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return GetText(data);
        }

        public string GetText(byte[] data)
        {
            var image = Image.FromBytes(data);
            
            IReadOnlyList<EntityAnnotation> textAnnotation = client.DetectText(image);

            StringBuilder stringBuilder = new StringBuilder();

            //foreach (var text in textAnnotation)
            //{
            //    stringBuilder.Append(text.Description);
            //}

            return textAnnotation.First().Description ?? string.Empty;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
