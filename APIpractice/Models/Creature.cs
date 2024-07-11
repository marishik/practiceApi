using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIpractice.Models
{
    public class Creature<TId, TStatus>
    {
        [Required]
        [Column("id")]
        public TId Id { get; set; }
        
        [Column("status")]
        public TStatus Status { get; set; }
    }
}