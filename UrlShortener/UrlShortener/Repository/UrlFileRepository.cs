using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using UrlShortener.Models;
using UrlShortener.Repository.Contract;

namespace UrlShortener.Repository
{
    public class UrlFileRepository : IUrlRepository
    {
        public void SaveUrl(TokenUrl tokenUrl)
        {
            var filePath = GetFilePath();
            using (var file = new StreamWriter(filePath, append: true))
            {
                var line = $"{tokenUrl.Id},{tokenUrl.Url},{tokenUrl.ShortenedUrl},{tokenUrl.Title},{tokenUrl.Token}";
                file.WriteLine(line);
            }
        }

        public TokenUrl GetTokenUrl(string token)
        {
            var filePath = GetFilePath();

            var lines = File.ReadAllLines(filePath);

            var d = lines.Select(l =>
            {
                var splitted = l.Split(",");

                var urlToken = new TokenUrl();
                urlToken.Id = Guid.Parse(splitted[0]);
                urlToken.Token = splitted[4];
                urlToken.Url = splitted[1];

                return urlToken;
            });

            var url = d.FirstOrDefault(a => a.Token == token);

            return url;
        }

        public void UpdateTokenUrl(TokenUrl tokenUrl)
        {
            throw new System.NotImplementedException();
        }

        private string GetFilePath()
        {
            var currentFolder = Directory.GetCurrentDirectory();

            var path = Path.Combine(currentFolder, "FileDb.txt");

            return path;
        }

    }
}