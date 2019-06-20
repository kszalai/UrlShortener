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
            return new UrlData
            {
                Url = "https://smol.url/" + _urlService.Create(url).HashedId
            };
        }

        [HttpGet("{id}")]
        public ActionResult<UrlData> Decode(string id)
        {
            return new UrlData
            {
                Url = _urlService.GetByHash(id).Url
            };
        }
    }
}