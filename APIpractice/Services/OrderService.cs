using APIpractice.Models;

namespace APIpractice.Services {
    
    public interface IOrderService {
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<Order> RemoveOrder(Order order);
    }

    public class OrderService: IOrderService {
        private readonly ApplicationContext _context;

        public OrderService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order) {
            var res = await _context.order.AddAsync(order);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Order>> GetAllOrders() {
            return _context.order.ToList();
        }

        public async Task<Order> GetOrder(int id) {
            return _context.order.Where(h => h.Id == id).First();
        }

        public async Task<Order> UpdateOrder(Order order) {
            var res = _context.order.Update(order);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Order> RemoveOrder(Order order) {
            _context.order.Where(p => p == order)
                .First().RecordStatus = RecordStatus.Inactive;

            await _context.SaveChangesAsync();
            return _context.order.Where(p => p == order).First();
        }
    }
}