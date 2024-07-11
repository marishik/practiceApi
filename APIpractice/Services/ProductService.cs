using APIpractice.Models;

namespace APIpractice.Services {
    public interface IProductService {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
    }

    public class ProductService: IProductService {
        public Task<Product> AddProduct(Product product) {
            
        }

        public Task<List<Product>> GetAllProducts() {
            
        }

        public Task<Product> GetProduct(int id) {
 
        }
    }
}
