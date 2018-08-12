using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;

namespace Login.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
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
            if(ModelState.IsValid)
            {
                List<Dictionary<string, object>> rows = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
                if(rows.Count > 0)
                {
                    ModelState.AddModelError("email", "Email already in use");
                }
                else
                {
                    //Hash Password
                    PasswordHasher<RegistrationUser> hasher = new PasswordHasher<RegistrationUser>();
                    string hashedPW = hasher.HashPassword(user, user.email);
                    //Store info in db
                    string insertString = 
                    $@"
                    INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) 
                    VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPW}', now(), now() )
                    ";

                    DbConnector.Execute(insertString);
                    TempData["message"] = "You may now log in";
                    return RedirectToAction("Index");
                }
            }
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
