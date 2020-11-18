using UrlShortener.Models;

namespace UrlShortener.Repository.Contract
{
    public interface IUrlRepository
    {
        void SaveUrl(TokenUrl tokenUrl);
        TokenUrl GetTokenUrl(string token);
        void UpdateTokenUrl(TokenUrl tokenUrl);
    }
}