using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutingAspNetCoreDemo.Attribute.Controllers
{
    public class UserController : Controller
    {
        //The below method has no [Route] attributes defined.
        //Because we are only using Attribute Routing, this action
        //cannot be reached within the app, and will not be found by the 
        //Routing middleware.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}