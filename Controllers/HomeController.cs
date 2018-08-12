using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult RegistrationUser(RegistrationUser user)
        {
            return View("Register");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            return View("Login");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
