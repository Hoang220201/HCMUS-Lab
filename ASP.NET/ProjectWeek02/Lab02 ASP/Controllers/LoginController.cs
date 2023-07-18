using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lab02_ASP.Controllers
{
    public class LoginController : Controller
    {
        private CoffeeDBDataContext db = new CoffeeDBDataContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            bool? isValidUser = false;

            db.CheckUserCredentials(name, password, ref isValidUser);

            if (isValidUser.HasValue && isValidUser.Value)
            {
                // Generate JWT token
                string token = GenerateJwtToken(name);

                // Store token in session or cookie
                HttpContext.Session["AuthToken"] = token;

          
                TempData["ToastrMessage"] = "Login successful";
                TempData["ToastrType"] = "success";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            bool usernameExists = db.Users.Any(u => u.Name == user.Name);

            if (usernameExists)
            {
                ModelState.AddModelError("", "Username already exists");
                return View();
            }
            else
            {
                try
                {
                    db.InsertUser(user.Name, user.Password);
                    TempData["ToastrMessage"] = "Sigup successful";
                    TempData["ToastrType"] = "success";
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occurred while registering user");
                    return View();
                }
            }
        }

        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CHAUNGUYENBAOHOANG22022001RANDOMSHIT"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
                // Add additional claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44313",
                audience: "SecureApiUser",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
