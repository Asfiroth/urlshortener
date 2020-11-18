using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Service.Contract;

namespace UrlShortener.Pages
{
    public class RedirectModel : PageModel
    {
        private readonly IUrlService _urlService;
        public RedirectModel(IUrlService urlService)
        {
            _urlService = urlService ?? throw new ArgumentNullException(nameof(urlService));
        }

        public IActionResult OnGet(string token)
        {
            var tokenizedUrl = _urlService.GeTokenUrl(token);

            return Redirect(tokenizedUrl.Url);
        }
    }
}
