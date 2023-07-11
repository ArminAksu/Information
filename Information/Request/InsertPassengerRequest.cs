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
        public int NationalCode { get; set; }

        [Required]
        [StringLength(100)]
        public int PassengerPoint { get; set; }
        public int Kilometr { get; set; }
        public int TotalAmount { get; set; }
    }
}
