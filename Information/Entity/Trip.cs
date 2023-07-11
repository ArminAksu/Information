using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Information.Entity
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EndTime { get; set; }
        public int Kilometr { get; set; }

        [Required]
        [StringLength(50)]
        public string TravelNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string TravelDistance { get; set; }

        public virtual Collection<Factor> Factor { get; set; }

    }
}
