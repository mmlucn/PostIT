namespace PostIT_API.Interfaces
{
    public interface IOCREngine
    {
        void Start();
        string GetText(string base64);
        string GetText(byte[] data);
    }
}
