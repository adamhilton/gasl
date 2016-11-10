using System;
using System.Collections.Generic;
using gasl.Domain.Entities;
using gasl.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gasl.Web.Features.Admin
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly LinkRepository _linkRepo;

        public AdminController(LinkRepository linkRepo) 
        {
            _linkRepo = linkRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Link> links = _linkRepo.List();
            return View(links);
        }

        [HttpPost]
        public IActionResult AddLink(String link)
        {
            _linkRepo.Add(new Link { Url = link });
            var links = _linkRepo.List();
            return PartialView("_Links", links);
        }
    }
}