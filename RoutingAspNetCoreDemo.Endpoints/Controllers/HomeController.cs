using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using RoutingAspNetCoreDemo.Endpoints.Models;

namespace RoutingAspNetCoreDemo.Endpoints.Controllers
{
    public class HomeController : Controller
    {
        private readonly LinkGenerator _linkGenerator;

        public HomeController(LinkGenerator generator)
        {
            _linkGenerator = generator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LinkGenerator()
        {
            Random random = new Random();
            var storeID = random.Next(1, 100);
            ViewData["GeneratedLink"] = _linkGenerator.GetPathByAction("ViewProducts", "Store", new { storeID });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
