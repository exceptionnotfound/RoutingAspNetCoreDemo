using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutingAspNetCoreDemo.Attribute.Models;

namespace RoutingAspNetCoreDemo.Attribute.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        //The two actions in this class have the same route.

        [Route("Index/{id}")]
        public IActionResult Index(int id = 0)
        {
            AccountVM model = new AccountVM()
            {
                ID = id
            };
            return View("Index", model);
        }

        [Route("Index/{id}")]
        public IActionResult Index(string id = "0")
        {
            AccountVM model = new AccountVM()
            {
                ID = int.Parse(id)
            };
            return View("Index", model);
        }
    }
}