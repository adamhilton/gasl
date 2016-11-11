
using gasl.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace gasl.Api.Features.Links
{
    [Route("/")]
    public class LinkController
    {
        private readonly LinkRepository _linkRepo;

        public LinkController(LinkRepository linkRepo)
        {
            _linkRepo = linkRepo;
        }

        [HttpGet, Route("/{id}")]
        public IActionResult Index(string id) 
        {
            var link = _linkRepo.GetById(id);
            return new RedirectResult(link.Url);
        }

        [HttpGet, Route("/links")]
        public IActionResult Links()
        {
            var links = _linkRepo.List();
            return new JsonResult(links);
        }
    }
}