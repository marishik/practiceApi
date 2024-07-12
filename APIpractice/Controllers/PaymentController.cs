using APIpractice.Models;
using APIpractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIpractice.Controllers {
    public class PaymentResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class GetPaymentResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Payment[] Payments { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class PaymentController: ControllerBase {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService) {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("PostPayment")]
        public async Task<PaymentResponse> PostPayment(Payment payment) {
            try {
                if (!ModelState.IsValid) {
                    return new PaymentResponse {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Ошибка"
                    };
                }

                var res = await _paymentService.AddPayment(payment);
                return new PaymentResponse {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Ответ успешно получен!"
                };
            } catch (Exception ex) {
                return new PaymentResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }
        }

        [HttpPut]
        [Route("PutPayment")]
        public async Task<PaymentResponse> PutPayment(Payment payment) {
            if (!ModelState.IsValid) {
                return new PaymentResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _paymentService.UpdatePayment(payment);
            return new PaymentResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }

        [HttpGet]
        [Route("GetPayment")]
        public async Task<GetPaymentResponse> Get() {
            if (!ModelState.IsValid) {
                return new GetPaymentResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _paymentService.GetAllPayments();
            return new GetPaymentResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Payments = res.ToArray()
            };
        }
        
        [HttpDelete]
        [Route("RemovePayment")]
        public async Task<PaymentResponse> RemovePayment(Payment payment) {
            if (!ModelState.IsValid) {
                return new PaymentResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _paymentService.RemovePayment(payment);
            return new PaymentResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }
    }
}
