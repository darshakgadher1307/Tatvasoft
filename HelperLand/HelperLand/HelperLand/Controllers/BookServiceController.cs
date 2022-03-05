using HelperLand.Data;
using HelperLand.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using HelperLand.Models;
using System;

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

        [HttpPost]
        public IActionResult CompleteBooking(BookServiceViewModel model)
        {
            var a = float.Parse(model.SchedulePlanView.StayTime);
            var b = model.SchedulePlanView.TotalTime;
            var z = double.Parse(model.SchedulePlanView.StartTime);
            var x = Convert.ToDateTime(model.SchedulePlanView.ServiceStartDate);
            var y = x.AddHours(z);
            ServiceRequest model1 = new ServiceRequest();
            model1.UserId = int.Parse(HttpContext.Session.GetString("UserID"));
            model1.ServiceStartDate = y;
            model1.ZipCode = model.PostalCodeView.PostalCode;
            model1.ServiceHours = a;
            model1.ExtraHours = b - a;
            model1.Comments = model.SchedulePlanView.comment;
            model1.PaymentDue = false;
            model1.HasPets = model.SchedulePlanView.IsPet;
            model1.CreatedDate = DateTime.Now;
            model1.ModifiedDate = DateTime.Now;
            model1.SubTotal = Convert.ToDecimal(model.SchedulePlanView.TotalCost);
            model1.TotalCost = Convert.ToDecimal(model.SchedulePlanView.EffctiveCost);
            model1.Discount = model1.SubTotal - model1.TotalCost;
            var count = helperlandContext.ServiceRequests.Count();
            var ServiceId = 1000 + count;
            model1.ServiceId = ServiceId;
            helperlandContext.ServiceRequests.Add(model1);
            helperlandContext.SaveChanges();

            ServiceRequestAddress model2 = new ServiceRequestAddress();
            var c = helperlandContext.ServiceRequests.Where(m => m.ServiceId == ServiceId).FirstOrDefault();
            model2.ServiceRequestId = c.ServiceRequestId;
            model2.AddressLine1 = model.userAddress.AddressLine1;
            model2.AddressLine2 = model.userAddress.AddressLine2;
            model2.City = model.userAddress.City;
            model2.PostalCode = model.userAddress.PostalCode;
            model2.Mobile = model.userAddress.Mobile;
            helperlandContext.ServiceRequestAddresses.Add(model2);
            helperlandContext.SaveChanges();


            var i = 0;
            foreach(var e in model.SchedulePlanView.Extra)
            {
                if(e)
                {
                    ServiceRequestExtra model3 = new ServiceRequestExtra();
                    model3.ServiceRequestId = c.ServiceRequestId;
                    model3.ServiceExtraId = i + 1;
                    helperlandContext.ServiceRequestExtras.Add(model3);
                    helperlandContext.SaveChanges();

                }
                i += 1;
            }

            return Json(new { success = true , serviceId = ServiceId });
        }
    }
}
