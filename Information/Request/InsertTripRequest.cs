using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class InsertTripRequest
    {
        [Required]
        [StringLength(50)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string TravelNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string TravelDistance { get; set; }
        public int Kilometr { get; set; }
    }
}
