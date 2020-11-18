using System;

namespace UrlShortener.Models
{
    public class TokenUrl
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ShortenedUrl { get; set; }
        public string Token { get; set; }
        public int TimesVisited { get; set; }
    }
}