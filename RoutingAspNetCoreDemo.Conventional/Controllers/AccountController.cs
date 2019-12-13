using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutingAspNetCoreDemo.Conventional.Models;

namespace RoutingAspNetCoreDemo.Conventional.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(int id = 0)
        {
            AccountVM model = new AccountVM()
            {
                ID = id
            };
            return View(model);
        }

        //This action and the below action are distinct methods in C#,
        //because they accept different parameters.  However, the Routing
        //middleware will not be able to distinguish them using a URL,
        //so whenever we try to route to one of them we will get an AmbiguousActionException.
        public IActionResult IndexAmbiguous(int id = 0)
        {
            AccountVM model = new AccountVM()
            {
                ID = id
            };
            return View("Index", model);
        }

        public IActionResult IndexAmbiguous(string id = "0")
        {
            AccountVM model = new AccountVM()
            {
                ID = int.Parse(id)
            };
            return View("Index", model);
        }
    }
}