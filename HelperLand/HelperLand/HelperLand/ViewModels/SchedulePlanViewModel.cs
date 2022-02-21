using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelperLand.ViewModels
{
    public class SchedulePlanViewModel
    {
        [DataType(DataType.Date)]
        public string ServiceStartDate { get; set; }

        public string StartTime { get; set; } 

        public string StayTime { get; set; } 

        public double TotalTime { get; set; } 

        public double TotalCost { get; set; }

        public double EffctiveCost { get; set; }

        public List<bool> Extra { get; set; }

        public string comment { get; set; }
        public bool IsPet { get; set; }

    }
}
