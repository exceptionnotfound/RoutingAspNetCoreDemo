using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoutingAspNetCoreDemo.Attribute.Models;

namespace RoutingAspNetCoreDemo.Attribute.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("~/")]
        [Route("Home")]
        [Route("Home/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Home/HttpGet")]
        public IActionResult HttpGet()
        {
            return View();
        }

        [HttpPost("Home/HttpPost")]
        public IActionResult HttpPost()
        {
            return RedirectToAction("HttpGet");
        }

        [Route("Parameters/{level}/{type}/{id}")]
        public IActionResult Parameters(int level, string type, int id)
        {
            ParametersVM model = new ParametersVM()
            {
                Level = level,
                Type = type,
                ID = id
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
