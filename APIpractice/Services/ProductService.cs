using APIpractice.Models;
using System.Linq;

namespace APIpractice.Services {
    public interface IProductService {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Product[] GetProductsByFilter(Func<Product, bool> filter);
        Task<Product> RemoveProduct(Product product);
    }

    public class ProductService: IProductService {
        private readonly ApplicationContext _context;

        public ProductService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product) {
            var res = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Product> UpdateProduct(Product product) {
            var res = _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Product>> GetAllProducts()
            => _context.Products.ToList();

        public Product[] GetProductsByFilter(Func<Product, bool> filter)
            => _context.Products.Where(filter).ToArray();

        public async Task<Product> RemoveProduct(Product product) {
            _context.Products.Where(p => p == product)
                .First().RecordStatus = RecordStatus.Inactive;

            await _context.SaveChangesAsync();
            return _context.Products.Where(p => p == product).First();
        }
    }
}