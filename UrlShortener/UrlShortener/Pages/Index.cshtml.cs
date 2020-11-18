using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Service.Contract;

namespace UrlShortener.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Shortened { get; set; }
        
        [BindProperty]
        public string UrlToTransform { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IUrlService _urlService;

        public IndexModel(ILogger<IndexModel> logger, IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            try
            {
                Shortened = _urlService.GenerateTokenUrl(UrlToTransform);
                ModelState.Remove("Shortened");
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
