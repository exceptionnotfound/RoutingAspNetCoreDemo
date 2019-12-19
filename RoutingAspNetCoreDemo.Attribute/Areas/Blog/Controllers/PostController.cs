using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingAspNetCoreDemo.Conventional.Areas.Blog.Controllers
{
    [Area("blog")]
    [Route("blog/post")]
    public class PostController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("article/{id}/{**title}")]
        public IActionResult Article(int id)
        {
            return View();
        }
    }
}