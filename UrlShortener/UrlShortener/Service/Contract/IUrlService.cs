using System;
using UrlShortener.Models;

namespace UrlShortener.Service.Contract
{
    public interface IUrlService
    {
        string GenerateTokenUrl(string baseUrl);

        TokenUrl GeTokenUrl(string token);

        
    }
}