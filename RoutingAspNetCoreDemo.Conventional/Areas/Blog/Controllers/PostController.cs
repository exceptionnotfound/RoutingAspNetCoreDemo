﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingAspNetCoreDemo.Conventional.Areas.Blog.Controllers
{
    [Area("blog")]
    public class PostController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult Article(string title)
        {
            return View();
        }
    }
}