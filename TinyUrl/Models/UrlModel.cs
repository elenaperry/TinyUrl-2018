
using TinyUrl.Interfaces;

namespace TinyUrl.Models
{
    public class UrlModel
    {
        private readonly IUrlContext _context;
        public UrlModel(IUrlContext urlContext)
        {
            _context = urlContext;
        }

        public IUrl Url { get; set; } 
        public string TinyUrl { get; set; }
        public string Message { get; set; } = "";

        public void Retrieve(int id)
        {
            Url = _context.GetUrl(id);
        }

        public void Retrieve(string longUrl)
        {
            Url = _context.GetUrl(longUrl);
        }

        
    }
}