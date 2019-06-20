using UrlShortener.Models;
using UrlShortener.Services;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController
    {
        private readonly UrlService _urlService;

        public UrlController(UrlService urlService)
        {
            _urlService = urlService;
        }

        [Route("encode")]
        [HttpPost]
        public ActionResult<UrlData> Encode(UrlData url)
        {
            var shortenedUrl = _urlService.Create(url);
            var newData = new UrlData
            {
                Url = "https://smol.url/" + shortenedUrl.HashedId
            };
            return newData;
        } 
    }
}