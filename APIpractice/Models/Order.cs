namespace APIpractice.Models {
    public class Order {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int PersonId { get; set; }
    }
}