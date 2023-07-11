using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class UpdateTripRequest
    {
        [StringLength(10, ErrorMessage = "ساعت شروع 10 کارکتر میباشد")]
        [MinLength(10, ErrorMessage = "ساعت شروع 10 کارکتر میباشد")]
        public string StaretTime { get; set; }

        [StringLength(10, ErrorMessage = "ساعت پایان 10 کارکتر میباشد")]
        [MinLength(10, ErrorMessage = "ساعت پایان 10 کارکتر میباشد")]
        public string EndTime { get; set; }

        [StringLength(50, ErrorMessage = "شماره سفر 50 کارکتر عدد می باشد")]
        [MinLength(50, ErrorMessage = "شماره سفر 50 کارکتر عدد می باشد")]
        public string TravelNumber { get; set; }

        [Key]
        [Required]
        [StringLength(50, ErrorMessage = "حداکثر 50 کارکتر عدد می باشد")]
        [MinLength(50, ErrorMessage = "مسافت سفر 50 کارکتر عدد می باشد")]
        public string TravelDistance { get; set; }
    }
}
