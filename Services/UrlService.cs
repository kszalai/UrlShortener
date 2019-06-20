using UrlShortener.Models;
using UrlShortener.Converter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlShortener.Services 
{
    public class UrlService
    {
        private readonly IMongoCollection<ShortenedUrl> _shortUrls;
        private UrlConverter _converter;

        public UrlService(IUrlDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shortUrls = database.GetCollection<ShortenedUrl>(settings.CollectionName);
            _converter = new UrlConverter();
        }

        public ShortenedUrl Get(string id) => _shortUrls.Find<ShortenedUrl>(url => url._id == id).FirstOrDefault();

        public ShortenedUrl GetByHash(string hashId) => _shortUrls.Find<ShortenedUrl>(url => url.HashedId == hashId).FirstOrDefault();

        public ShortenedUrl Create(UrlData url)
        {
            var shortUrl = new ShortenedUrl()
            {
                Id = Math.Abs(url.GetHashCode()),
                Url = url.Url,
                HashedId = _converter.toBase62(Math.Abs(url.GetHashCode())) 
            };

            _shortUrls.InsertOne(shortUrl);
            return shortUrl;
        }
    }
}