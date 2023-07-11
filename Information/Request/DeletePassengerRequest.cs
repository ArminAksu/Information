using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class DeletePassengerRequest
    {
        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        [MinLength(100, ErrorMessage = "امتیاز مسافر 100 کارکتر وارد کنید")]
        public int PassengerPoint { get; set; }
    }
}
