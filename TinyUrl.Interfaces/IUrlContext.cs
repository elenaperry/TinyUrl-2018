namespace TinyUrl.Interfaces
{
    public interface IUrlContext
    {
        IUrl GetUrl(int id);
        IUrl GetUrl(string fullUrl);
    }
}
