using System.ComponentModel.DataAnnotations;

namespace HelperLand.ViewModels
{
    public class RegisterViewModel
    {
        public int UserId { get; set; }

        [Required, RegularExpression("[a-zA-Z]{3,}", ErrorMessage = "Enter valid Name")]
        public string FirstName { get; set; }

        [Required, RegularExpression("[a-zA-Z]{3,}", ErrorMessage = "Enter valid Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required, RegularExpression("^[0-9]{10}$", ErrorMessage = "Enter valid Mobile Number")]
        public string Mobile { get; set; }
    }
}
