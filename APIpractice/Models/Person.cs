using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIpractice.Models
{
    public enum Status
    {
        Worker,
        NotWorker
    }

    public class Person : Creature<int, Status>
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Column("record_status")]
        public RecordStatus RecordStatus { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}