namespace APIpractice.Models
{
    public class Creature<TId, TStatus>
    {
        public TId id { get; set; }
        public TStatus Status { get; set; }
    }
}