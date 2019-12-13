using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutingAspNetCoreDemo.Conventional.Models;

namespace RoutingAspNetCoreDemo.Conventional.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(int id = 0)
        {
            UserVM model = new UserVM()
            {
                ID = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int id, UserVM model)
        {
            return RedirectToAction("Index");
        }
    }
}