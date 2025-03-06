using System.ComponentModel.DataAnnotations;

namespace Musical_Instruments_ECommerce.ViewModel.InstrumentsVM
{
    public class InstrumentsCRUD
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
