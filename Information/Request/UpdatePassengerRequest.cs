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
        public int NationalCode { get; set; }

        [StringLength(100, ErrorMessage = " حداکثر 100 کارکتر وارد کنید")]
        [MinLength(100, ErrorMessage = "امتیاز مسافر 100 کارکتر باشد")]
        public int PassengerPoint { get; set; }
        public int TotalAmount { get; set; }
        public int Kilometr { get; set; }

    }
}
