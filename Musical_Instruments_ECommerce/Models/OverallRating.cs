using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musical_Instruments_ECommerce.Models
{
    public class OverallRating
    {
        [Key]
        public int Id { get; set; }
        public double Rating { get; set; }
        public int VotedCount { get; set; }

        [ForeignKey("Instruments")]
        public int InstrumentId { get; set; }
        public Instruments Instruments { get; set; } 
    }
}
