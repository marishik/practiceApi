using System.ComponentModel.DataAnnotations;

namespace APIpractice.Models {
    public class Payment {
        [Required]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}