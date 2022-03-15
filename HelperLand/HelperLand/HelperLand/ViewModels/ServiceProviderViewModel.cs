using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelperLand.ViewModels
{
    public class ServiceProviderViewModel
    {
        public List<ServiceRequest> services { get; set; }

        public List<ServiceRequestAddress> addresses { get; set; }

        public List<DateTime> serviceEnd { get; set; }

        public List<string> custName { get; set; }

        public List<string> extras { get; set; }

        public bool IsPet { get; set; }

        public AcceptServiceViewModel acceptService { get; set; }

        public DateTime time { get; set; }

        public CancelServiceViewModel cancel { get; set; }

        public List<Rating> ratings { get; set; }

        public List<string> ratingRes { get; set; }

        public User user { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public UserAddress userAddress { get; set; }

        public ChangePasswordViewModel changePassword { get; set; }

        public List<FavoriteAndBlocked> favorites { get; set; }

        public List<int> userid { get; set; }



    }
}
