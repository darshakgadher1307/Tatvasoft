using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HelperLand.Models
{
    public partial class ContactU
    {
        public int ContactUsId { get; set; }

        [Required(ErrorMessage = "Name is required"), RegularExpression("[a-zA-Z]{3,}", ErrorMessage = "Enter valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Phone number is required"), RegularExpression("^[0-9]{10}$", ErrorMessage = "Enter valid Mobile Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
        public string UploadFileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string FileName { get; set; }
    }
}
