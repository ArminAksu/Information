using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class PassengerRequest
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Key]
        [Required(ErrorMessage = "کد ملی را وارد کنید")]
        [StringLength(10)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "امتیاز مسافر را وارد کنید")]
        [StringLength(100)]
        public string PassengerPoint { get; set; }
    }
}
