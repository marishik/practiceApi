using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}