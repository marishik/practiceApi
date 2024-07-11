using APIpractice.Models;

namespace APIpractice.Services {
    public interface IProductService {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<Product> RemoveProduct(Product product);
    }

    public class ProductService: IProductService {
        private readonly ApplicationContext _context;

        public ProductService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product) {
            var res = await _context.product.AddAsync(product);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Product>> GetAllProducts() {
            return _context.product.ToList();
        }

        public async Task<Product> GetProduct(int id) {
            return _context.product.Where(p => p.Id == id).First();
        }

        public async Task<Product> RemoveProduct(Product product) {
            _context.product.Where(p => p == product)
                .First().RecordStatus = RecordStatus.Inactive;

            await _context.SaveChangesAsync();
            return _context.product.Where(p => p == product).First();
        }

        public async Task<Product> UpdateProduct(Product product) {
            var res = _context.product.Update(product);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
    }
}