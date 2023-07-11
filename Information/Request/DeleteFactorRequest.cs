using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class DeleteFactorRequest
    {
        [StringLength(100, ErrorMessage = "حداکثر 100 کارکتر وارد کنید")]
        [MinLength(100, ErrorMessage = "وضعیت پرداخت 100 کارکتر وارد کنید")]
        public string PaymentStatus { get; set; }
    }
}
