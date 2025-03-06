using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musical_Instruments_ECommerce.Models
{
    public class InstrumentRating
    {
        [Key]
        public int Id { get; set; }
        [Range(1,5)]
        public int Stars { get; set; }

        [ForeignKey("Accounts")]
        public int AccountId {  get; set; }
        public Accounts Accounts { get; set; }

        [ForeignKey("Instruments")]
        public int InstrumentId { get; set; }
        public Instruments Instruments { get; set; }
    }
}
