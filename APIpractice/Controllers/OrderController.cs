using APIpractice.Models;
using APIpractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIpractice.Controllers {
    public class OrderResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
    }

    public class GetOrderResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Order[] Orders { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService) {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        [Route("PostOrder")]
        public async Task<OrderResponse> PostOrder(Order order) {
            try {
                if (!ModelState.IsValid) {
                    return new OrderResponse {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Ошибка"
                    };
                }

                var res = await _orderService.AddOrder(order);
                return new OrderResponse {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Ответ успешно получен!"
                };
            } catch (Exception ex) {
                return new OrderResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = $"Ошибка: {ex.Message}",
                    InnerException = $"{ex.InnerException}"
                };
            }
        }

        [HttpPut]
        [Route("PutOrder")]
        public async Task<OrderResponse> PutOrder(Order order) {
            if (!ModelState.IsValid) {
                return new OrderResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _orderService.UpdateOrder(order);
            return new OrderResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<GetOrderResponse> GetAllOrders() {
            if (!ModelState.IsValid) {
                return new GetOrderResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _orderService.GetAllOrders();
            return new GetOrderResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Orders = res.ToArray()
            };
        }

        [HttpGet]
        [Route("GetOrder")]
        public async Task<GetOrderResponse> GetOrder(Order order) {
            if (!ModelState.IsValid) {
                return new GetOrderResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _orderService.GetOrder(order.Id);
            return new GetOrderResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }

        [HttpDelete]
        [Route("RemoveOrder")]
        public async Task<OrderResponse> RemoveOrder(Order order) {
            if (!ModelState.IsValid) {
                return new OrderResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _orderService.RemoveOrder(order);
            return new OrderResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }
    }
}
