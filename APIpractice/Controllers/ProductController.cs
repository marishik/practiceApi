using APIpractice.Models;
using APIpractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIpractice.Controllers {
    public class PostProductResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class GetProductResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Product[] Products { get; set; }
    }

    public class ProductController : ControllerBase {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService) {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        [Route("PostProduct")]
        public async Task<PostProductResponse> PostProduct(Product product) {

            try {
                if (!ModelState.IsValid) {
                    return new PostProductResponse {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Ошибка"
                    };
                }

                var res = await _productService.AddProduct(product);
                return new PostProductResponse {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Ответ успешно получен!"
                };
            } catch (Exception ex) {
                return new PostProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = $"Ошибка: {ex.Message}"
                };
            }
        }

        [HttpPost]
        [Route("GetProduct")]
        public async Task<GetProductResponse> Get() {
            if (!ModelState.IsValid) {
                return new GetProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _productService.GetAllProducts();
            return new GetProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }
    }
}
