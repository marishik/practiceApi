using APIpractice.Models;

namespace APIpractice.Services {
    public interface IPaymentService {
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<List<Payment>> GetAllPayments();
        Payment[] GetPaymentsByFilter(Func<Payment, bool> filter);
    }

    public class PaymentService: IPaymentService {
        private readonly ApplicationContext _context;

        public PaymentService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Payment> AddPayment(Payment payment) {
            var res = await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Payment>> GetAllPayments() 
            => _context.Payments.ToList();

        public Payment[] GetPaymentsByFilter(Func<Payment, bool> filter) 
            => _context.Payments.Where(filter).ToArray();

        public async Task<Payment> UpdatePayment(Payment payment) {
            var res = _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
    }
}
