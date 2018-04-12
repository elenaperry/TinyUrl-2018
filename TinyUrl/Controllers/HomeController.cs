using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using TinyUrl.Data;
using TinyUrl.Models;

namespace TinyUrl.Controllers
{
    public class HomeController : Controller
    {   [HttpGet]
        public ActionResult Index(string tinyUrl)
        {
            var model = new UrlModel(new UrlContext());

            if (!string.IsNullOrEmpty(tinyUrl))
            {
                model.Retrieve(FromTinyUrl(tinyUrl));
                if (model.Url == null) model.Message = "Invalid Url";
                else
                return new PermanentRedirectResult(model.Url.LongUrl);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index()
        {
            var model = new UrlModel(new UrlContext());

            var longUrl = Request.Form["Url.LongUrl"];
            var tinyUrl = Request.Form["TinyUrlLookup"];

            
            if (!string.IsNullOrEmpty(tinyUrl))
            {
                model.Retrieve(FromTinyUrl(tinyUrl));
                if (model.Url != null)
                    model.TinyUrl = "";
            }
            else if (!string.IsNullOrEmpty(longUrl))
            {
                if (!IsUrlValid(longUrl))
                {
                    model.Message = "Please provide valid Url";
                    return View(model);
                }
                model.Retrieve(longUrl);
                if (model.Url != null)
                    model.TinyUrl = $"{Request.Url}{ToTinyUrl(model.Url.Id)}";
                model.Url=new Url();
            }

            return View(model);
        }

        public static int FromTinyUrl(string tinyUrl)
        {
            var i = 0;
            var result = 0;
            tinyUrl = tinyUrl.ToLower();
            var asciiBytes = Encoding.ASCII.GetBytes(tinyUrl);
            foreach (var code in asciiBytes)
            {
                var mutliplier = code < 48 ? -1
                    : code < 58 ? code - 48
                    : code < 97 ? -1
                    : code < 123 ? code - 87
                    : -1;
                if(mutliplier >= 0)
                result = result + (int) (mutliplier * Math.Pow(36, i++));
            }

            return result;
        }
        public static string ToTinyUrl(int id)
        {
            var result = string.Empty;

            while (id > 0)
            {
                var remainder = id % 36;
                id = id / 36;
                result =result + (remainder < 10 
                             ? (char)(remainder + 48)
                             : (char)(remainder + 87));
            }

            return result;
        }
        private static bool IsUrlValid(string url)
        {
            const string regular = @"(^(https?|ftp|file)://)";
            return Regex.IsMatch(url, regular,RegexOptions.Compiled);
        }
    }

}