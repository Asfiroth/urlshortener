using System;
using System.Linq;
using UrlShortener.Models;
using UrlShortener.Repository.Contract;
using UrlShortener.Service.Contract;

namespace UrlShortener.Service
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository ?? throw new ArgumentNullException(nameof(urlRepository));
        }

        private string GenerateToken()
        {
            var token = string.Empty;

            var rnd = new Random();

            Enumerable.Range(48, 75)
                .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
                .OrderBy(o => rnd.Next()).ToList().ForEach(i => token += Convert.ToChar(i));

            return token.Substring(rnd.Next(0, token.Length), rnd.Next(2, 6));
        }

        public string GenerateTokenUrl(string baseUrl)
        {
            var tokenUrl = new TokenUrl();
            var token = GenerateToken();

            tokenUrl.Id = Guid.NewGuid();
            tokenUrl.Url = baseUrl;
            tokenUrl.Token = token;
            tokenUrl.ShortenedUrl = $"https://localhost:44336/Redirect/{token}";

            _urlRepository.SaveUrl(tokenUrl);

            return tokenUrl.ShortenedUrl;
        }

        public TokenUrl GeTokenUrl(string token)
        {
            return _urlRepository.GetTokenUrl(token);
        }
    }
}