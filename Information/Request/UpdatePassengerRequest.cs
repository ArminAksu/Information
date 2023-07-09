using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class UpdatePassengerRequest
    {
        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string? FirstName { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "کد ملی 10 کارکتر عدد باشد")]
        [MinLength(10, ErrorMessage = "کد ملی 10 کارکتر عدد باشد")]
        public string NationalCode { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string PassengerPoint { get; set; }
    }
}
