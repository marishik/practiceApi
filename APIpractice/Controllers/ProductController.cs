﻿using APIpractice.Models;
using APIpractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIpractice.Controllers {
    public class ProductResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
    }

    public class GetProductResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Product[] Products { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService) {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        [Route("PostProduct")]
        public async Task<ProductResponse> PostProduct(Product product)  {
            try {
                if (!ModelState.IsValid) {
                    return new ProductResponse {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Ошибка"
                    };
                }

                var res = await _productService.AddProduct(product);
                return new ProductResponse {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Ответ успешно получен!"
                };
            } catch (Exception ex) {
                return new ProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = $"Ошибка: {ex.Message}",
                    InnerException = $"{ex.InnerException}"
                };
            }
        }

        [HttpPut]
        [Route("PutProduct")]
        public async Task<ProductResponse> PutProduct(Product product) {
            if (!ModelState.IsValid) {
                return new ProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _productService.UpdateProduct(product);
            return new ProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }

        [HttpGet]
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
                Message = "Ответ успешно получен!",
                Products = res.ToArray()
            };
        }

        [HttpGet]
        [Route(nameof(GetProductsById))]
        public GetProductResponse GetProductsById(int id) {
            if (!ModelState.IsValid) {
                return new GetProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = _productService.GetProductsByFilter(p => p.Id == id);
            return new GetProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Products = res
            };
        }

        [HttpGet]
        [Route(nameof(GetProductsByCategory))]
        public GetProductResponse GetProductsByCategory(string category) {
            if (!ModelState.IsValid) {
                return new GetProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = _productService.GetProductsByFilter(p => p.Category == category);
            return new GetProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Products = res
            };
        }

        [HttpGet]
        [Route(nameof(GetProductsByPrice))]
        public GetProductResponse GetProductsByPrice(decimal price) {
            if (!ModelState.IsValid) {
                return new GetProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = _productService.GetProductsByFilter(p => p.Price == price);
            return new GetProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Products = res
            };
        }

        [HttpGet]
        [Route(nameof(GetProductsByStatus))]
        public GetProductResponse GetProductsByStatus(RecordStatus status) {
            if (!ModelState.IsValid) {
                return new GetProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = _productService.GetProductsByFilter(p => p.RecordStatus == status);
            return new GetProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Products = res
            };
        }

        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<ProductResponse> RemoveProduct(Product product) {
            if (!ModelState.IsValid) {
                return new ProductResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _productService.RemoveProduct(product);
            return new ProductResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }
    }
}
