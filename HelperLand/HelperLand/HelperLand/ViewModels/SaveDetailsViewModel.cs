using System;
using System.ComponentModel.DataAnnotations;

namespace HelperLand.ViewModels
{
    public class SaveDetailsViewModel
    {
        [Required, RegularExpression("[a-zA-Z]{3,}", ErrorMessage = "Enter valid Name")]
        public string FirstName { get; set; }

        [Required, RegularExpression("[a-zA-Z]{3,}", ErrorMessage = "Enter valid Name")]
        public string LastName { get; set; }

        [Required, RegularExpression("^[0-9]{10}$", ErrorMessage = "Enter valid Mobile Number")]
        public string Mobile { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int LanguageId { get; set; }
    }
}
