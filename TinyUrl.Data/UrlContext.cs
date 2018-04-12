using System;
using System.Linq;
using TinyUrl.Interfaces;

namespace TinyUrl.Data
{
    public class UrlContext :IUrlContext 
    {
        public IUrl GetUrl(int id)
        {
            using (var context = new TinyUrlModel())
            {
                return context.Urls.FirstOrDefault(u => u.Id == id);
            }
        }

        public IUrl GetUrl(string longUrl)
        {
            using (var context = new TinyUrlModel())
            {
                var url = context
                    .Urls
                    .FirstOrDefault(
                        u => u.LongUrl.Equals(longUrl,StringComparison.InvariantCulture)
                        );
                if (url != null) return url;
                url = new Url{LongUrl = longUrl};
                context.Urls.Add(url);
                context.SaveChanges();

                return url;
            }
        }
    }
}
