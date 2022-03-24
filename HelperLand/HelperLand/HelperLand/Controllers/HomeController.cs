using HelperLand.Data;
using HelperLand.Models;
using HelperLand.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HelperlandContext helperlandContext;

        public HomeController(ILogger<HomeController> logger,
                                HelperlandContext helperlandContext)
        {
            _logger = logger;
            this.helperlandContext = helperlandContext;
        }

        public IActionResult Index()
        {
            var a = Convert.ToInt32(TempData["login"]);
            if (a != 0)
            {
                ViewBag.loginStatus = a;
                ViewBag.loginModel = true;
            }
            else if(a == null || a == 0)
            {
                ViewBag.loginModel = false;
            }
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactU model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                helperlandContext.ContactUs.Add(model);
                helperlandContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Faqs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var a = Convert.ToInt32(TempData["register"]);
            if (a != 0)
            {
                ViewBag.registerStatus = true;
            }
            else if (a == null || a == 0)
            {
                ViewBag.registerStatus = false;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            TempData["register"] = "0";
            if (ModelState.IsValid)
            {
                var isEmailAlreadyExists = helperlandContext.Users.Any(x => x.Email == model.Email);
                if (isEmailAlreadyExists)
                {
                    ModelState.AddModelError("Email", "User with this email already exists");
                    return View();
                }
                model.UserTypeId = 1;
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.ModifiedBy = model.UserId;
                helperlandContext.Users.Add(model);
                helperlandContext.SaveChanges();
                TempData["register"] = "1";
                return RedirectToAction("Register");
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            TempData["login"] = "0";
            User user = helperlandContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                TempData["login"] = "2";
                return RedirectToAction("Index");
            }
            else
            {
                if (user.Email == email && user.Password == password && user.UserTypeId == 1)
                {
                    HttpContext.Session.SetString("UserID", user.UserId.ToString());
                    HttpContext.Session.SetString("UserName", user.FirstName);
                    TempData["login"] = "3";
                    return RedirectToAction("CustomerDashboard", "Customer");
                }
                else if (user.Email == email && user.Password == password && user.UserTypeId == 2)
                {
                    if(user.IsActive)
                    {
                        HttpContext.Session.SetString("UserID", user.UserId.ToString());
                        HttpContext.Session.SetString("UserName", user.FirstName);
                        TempData["login"] = "3";
                        return RedirectToAction("SPServiceRequest", "ServiceProvider");
                    }
                    else
                    {
                        TempData["login"] = "10";
                        return RedirectToAction("Index");
                    }
                   
                }
                else if (user.Email == email && user.Password == password && user.UserTypeId == 3)
                {
                    HttpContext.Session.SetString("UserID", user.UserId.ToString());
                    HttpContext.Session.SetString("UserName", user.FirstName);
                    TempData["login"] = "3";
                    return RedirectToAction("AdminService", "Admin");
                }
                else
                {
                    TempData["login"] = "1";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            TempData["login"] = "0";
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
                var isEmailAlreadyExists = helperlandContext.Users.Any(x => x.Email == email);
                if (isEmailAlreadyExists)
                {
                    var user = helperlandContext.Users.Where(x => x.Email == email).FirstOrDefault();
                    ViewBag.Data = user.UserId;
                    return View("ChangePassword");
                }
                else
                {
                    return RedirectToAction("Price");
                }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(RegisterViewModel model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var user = helperlandContext.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                user.Password = model.Password;
                helperlandContext.Users.Update(user);
                helperlandContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        

        public IActionResult Service_Provider_Sign_Up()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Service_Provider_Sign_Up(User model)
        {
            if (ModelState.IsValid)
            {
                var isEmailAlreadyExists = helperlandContext.Users.Any(x => x.Email == model.Email);
                if (isEmailAlreadyExists)
                {
                    ModelState.AddModelError("Email", "User with this email already exists");
                    return View();
                }
                model.UserTypeId = 2;
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.ModifiedBy = model.UserId;
                helperlandContext.Users.Add(model);
                helperlandContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Service_Provider_Sign_Up");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
