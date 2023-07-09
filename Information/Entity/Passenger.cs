using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Information.Entity
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

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

        public virtual Collection<Factor> Factor { get; set; }

    }
}
