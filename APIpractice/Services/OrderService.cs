using APIpractice.Models;

namespace APIpractice.Services {
    
    public interface IOrderService {
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Order[] GetOrdersByFilter(Func<Order, bool> filter);
    }

    public class OrderService: IOrderService {
        private readonly ApplicationContext _context;

        public OrderService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order) {
            var res = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Order>> GetAllOrders() 
            => _context.Orders.ToList();

        public Order[] GetOrdersByFilter(Func<Order, bool> filter) 
            => _context.Orders.Where(filter).ToArray();

        public async Task<Order> UpdateOrder(Order order) {
            var res = _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

    }
}