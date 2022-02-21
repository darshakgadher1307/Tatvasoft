using HelperLand.Models;
using System.Collections.Generic;

namespace HelperLand.ViewModels
{
    public class BookServiceViewModel
    {
        public PostalCodeViewModel PostalCodeView { get; set; }

        public SchedulePlanViewModel SchedulePlanView { get; set; }

        public List<UserAddress> Address { get; set; }

        public UserAddress userAddress { get; set; }

        public YourDetailsViewModel yourDetailsView { get; set; }
    }
}
