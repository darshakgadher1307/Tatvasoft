using HelperLand.Data;
using HelperLand.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using HelperLand.Models;

namespace HelperLand.Controllers
{
    public class BookServiceController : HomeController
    {
        BookServiceViewModel address = new BookServiceViewModel();
        private readonly ILogger<HomeController> logger;
        private readonly HelperlandContext helperlandContext;

        public BookServiceController(ILogger<HomeController> logger, 
            HelperlandContext helperlandContext) : base(logger, helperlandContext)
        {
            this.logger = logger;
            this.helperlandContext = helperlandContext;
        }

        public IActionResult BookService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostalCode(PostalCodeViewModel model)
        {
            var a = HttpContext.Session.GetString("UserID");
            if (a == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (model.PostalCode == null)
                {
                    return Json(new { success = false, responsetext = "Postal code required" });
                }
                else
                {
                    var isZipCodeExists = helperlandContext.UserAddresses.Any(x => x.PostalCode == model.PostalCode);
                    if (!isZipCodeExists)
                    {
                        return Json(new { success = false, responsetext = "Postal code doesn't exists" });
                    }
                }
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SchedulePlan(SchedulePlanViewModel model)
        {
            var a = int.Parse(HttpContext.Session.GetString("UserID"));
            var x = helperlandContext.UserAddresses.Where(m => m.UserId == a);
            if (x != null)
            {
                var addressList = x.ToList();
                var count = addressList.Count();
                address.Address = new List<UserAddress>();
                foreach(var userAddress in addressList)
                {
                    if(count > 0)
                    {
                        address.Address.Add(userAddress);
                    }
                }
                return Json(new { success = true ,Addresses = address.Address});

            }
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult AddAddress(UserAddress model)
        {
            if (ModelState.IsValid)
            {
                var a = int.Parse(HttpContext.Session.GetString("UserID"));
                model.UserId = a;
                helperlandContext.UserAddresses.Add(model);
                helperlandContext.SaveChanges();
                var x = helperlandContext.UserAddresses.Where(m => m.UserId == a);
                if (x != null)
                {
                    var addressList = x.ToList();
                    var count = addressList.Count();
                    address.Address = new List<UserAddress>();
                    foreach (var userAddress in addressList)
                    {
                        if (count > 0)
                        {
                            address.Address.Add(userAddress);
                        }
                    }
                    return Json(new { success = true, Addresses = address.Address });

                }
            }
            return Json(new { success = false });
        }
    }
}
