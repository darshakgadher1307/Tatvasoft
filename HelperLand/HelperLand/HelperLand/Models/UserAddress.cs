using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HelperLand.Models
{
    public partial class UserAddress
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }

        [Required, RegularExpression("[a-zA-Z0-9]{3,}")]
        public string AddressLine1 { get; set; }

        [Required, RegularExpression("^[0-9]{2,}$")]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }

        [Required, RegularExpression("^[0-9]{10}$")]
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
