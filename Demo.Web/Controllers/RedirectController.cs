using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult RedirectServerSide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedirectServerSide_Post()
        {
            return Redirect("https://hackernoon.com/15-jokes-only-programmers-will-get-b42873eba509");
        }

        public IActionResult RedirectClientSide()
        {
            return View();
        }
    }
}