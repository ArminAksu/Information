using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Information.Entity
{
    public class Factor
    {

        [Key]
        public int Id { get; set; }

        public int AmountTrip { get; set; }
        public int Kilometr { get; set; }

        [Required]
        [StringLength(50)]
        public string FactorData { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerId { get; set;}

        [Required]
        [StringLength(100)]
        public string Travel { get; set;}

        //[Required]
        //[StringLength(100)]
        public decimal TravelAmount { get; set;}

        [Required]
        [StringLength(300)]
        public string PaymentStatus { get; set;}
        public int TripId { get; set;}

        [ForeignKey("Passenger")]
        public int PassengerId { get; set;}

        [ForeignKey("TripId")]
        public virtual Trip Trip { get; set;}

        public virtual Passenger Passenger { get; set;}
    }
}
