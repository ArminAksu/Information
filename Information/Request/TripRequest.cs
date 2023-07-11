using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class TripRequest
    {
        [Required(ErrorMessage = "ساعت شروع را وارد کنید")]
        [StringLength(10)]
        public decimal StartTime { get; set; }

        [Required(ErrorMessage = "ساعت پایان را وارد کنید")]
        [StringLength(10)]
        public bool EndTime { get; set; }

        [Required(ErrorMessage = "شماره سفر را وارد کنید ")]
        public decimal TravelNumber { get; set; }

        [Required(ErrorMessage = "مسافت سفر را به ازای هر کیلوتر وارد کنید")]
        [StringLength(100)]
        public string TravelDistance { get; set; }
        public int Kilometr { get; set; }
    }
}
