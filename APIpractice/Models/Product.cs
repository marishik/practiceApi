using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIpractice.Models {
    public class Product {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("model", TypeName = "jsonb")]
        public Dictionary<string, object> Characteristics { get; set; } = new Dictionary<string, object>();

        [Column("record_status")]
        public RecordStatus RecordStatus { get; set; }
    }
}