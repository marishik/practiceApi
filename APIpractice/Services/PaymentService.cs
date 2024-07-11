using APIpractice.Models;

namespace APIpractice.Services {
    public interface IPaymentService {
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetHuman(int id);
        Task<Payment> RemovePayment(Payment payment);
    }

    public class PaymentService: IPaymentService {
        private readonly ApplicationContext _context;

        public PaymentService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Payment> AddPayment(Payment payment) {
            var res = await _context.payment.AddAsync(payment);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Payment>> GetAllPayments() {
            return _context.payment.ToList();
        }

        public Task<Payment> GetHuman(int id) {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetPayment(int id) {
            return _context.payment.Where(h => h.Id == id).First();
        }

        public async Task<Payment> RemovePayment(Payment payment) {
            _context.payment.Where(p => p == payment)
                .First().RecordStatus = RecordStatus.Inactive;

            await _context.SaveChangesAsync();
            return _context.payment.Where(p => p == payment).First();
        }

        public async Task<Payment> UpdatePayment(Payment payment) {
            var res = _context.payment.Update(payment);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
    }
}
