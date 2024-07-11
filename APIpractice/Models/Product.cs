using System.ComponentModel.DataAnnotations;

namespace APIpractice.Models {
    public class Product {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string, object> Characteristics { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}