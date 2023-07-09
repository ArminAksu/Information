using System.ComponentModel.DataAnnotations;

namespace Information.Request
{
    public class Start_EndTimeTravel
    {
        [Required]
        public int Start { get; set; }

        [Required]
        [StringLength(10)]
        public string End { get; set; }
        public string TravelDistance { get; set; }
    }
}
