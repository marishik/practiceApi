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
        public decimal MoneyInTheAcc { get; set; }
        public int? carid { get; set; }
        public int? headphonesid { get; set; }
    }
}