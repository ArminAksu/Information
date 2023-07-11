using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class InsertFactorRequest
    {
        public int AmountTrip { get; set; }
        public int Kilometr { get; set; }

        [Required]
        [StringLength(50)]
        public string FactorData { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Travel { get; set; }

        //[Required]
        //[StringLength(100)]
        public decimal TravelAmount { get; set; }

        [Required]
        [StringLength(300)]
        public string PaymentStatus { get; set; }
    }
}
