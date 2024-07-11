using System.ComponentModel.DataAnnotations;

namespace APIpractice.Models {
    public class Order {
        [Required]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int PersonId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}