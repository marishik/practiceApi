namespace APIpractice.Models
{
    public class Creature<TId, TStatus>
    {
        public TId Id { get; set; }
        public TStatus Status { get; set; }
    }
}