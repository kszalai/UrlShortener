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

        [HttpPost]
        public ActionResult<string> Encode([FromBody] UrlData url)
        {
            return string.Empty;
        } 
    }
}