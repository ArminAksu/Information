using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class UpdateFactorRequest
    {
        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string? FactorData { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر عدد وارد کنید")]
        public int AmountTrip { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر عدد وارد کنید")]
        public int Kilometr { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        public string CustomerId { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر باشد")]
        public string Travel { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر عدد وارد کنید")]
        public decimal TravelAmount { get; set; }

        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        [MinLength(10, ErrorMessage = "وضعیت پرداخت 010 کارکتر باشد")]
        public string PaymentStatus { get; set; }
    }
}
