using APIpractice.Models;
using APIpractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIpractice.Controllers
{
    public class PostPersonResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class GetPersonResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Person[] Humans { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase {
        private readonly ILogger<PersonController> _logger;
        private readonly IHumanService _humanService;

        public PersonController(ILogger<PersonController> logger, IHumanService humanService) {
            _logger = logger;
            _humanService = humanService;
        }

        [HttpPost(Name = "PostHuman")]
        public async Task<PostPersonResponse> PostHuman(Person human) {
            
            try {
                if (!ModelState.IsValid) {
                    return new PostPersonResponse {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Ошибка"
                    };
                }

                var res = await _humanService.AddHuman(human);
                return new PostPersonResponse {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Ответ успешно получен!"
                };
            }

            catch (Exception ex) {
                return new PostPersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }
        }

        [HttpGet(Name = "GetHuman")]
        public async Task<GetPersonResponse> Get() {
            if (!ModelState.IsValid) {
                return new GetPersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _humanService.GetAllHumans();
            return new GetPersonResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }
    }
}
