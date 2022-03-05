using System.ComponentModel.DataAnnotations;

namespace HelperLand.ViewModels
{
    public class ServiceRescheduleViewModel
    {
        public int ServiceId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public string serviceDate { get; set; }

        [Required]
        public int serviceTime { get; set; }
    }
}
