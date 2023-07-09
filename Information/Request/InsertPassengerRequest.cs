using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class InsertPassengerRequest
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string PassengerPoint { get; set; }
    }
}
