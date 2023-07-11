using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class DeleteTripRequest
    {
        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        [MinLength(100, ErrorMessage = "مسافت سفر 100 کارکتر وارد کنید")]
        public string TravelDistance { get; set; }
    }
}
