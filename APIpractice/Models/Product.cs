using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIpractice.Models {

    [Table("product")]
    public class Product {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("record_status")]
        public RecordStatus RecordStatus { get; set; }
    }
}