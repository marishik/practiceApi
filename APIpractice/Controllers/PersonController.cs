using APIpractice.Models;
using APIpractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIpractice.Controllers
{
    public class PersonResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
    }

    public class GetPersonResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Person[] Persons { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService) {
            _logger = logger;
            _personService = personService;
        }

        [HttpPost]
        [Route("PostPerson")]
        public async Task<PersonResponse> PostPerson(Person person){
            
            try {
                if (!ModelState.IsValid) {
                    return new PersonResponse {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Ошибка"
                    };
                }

                var res = await _personService.AddPerson(person);
                return new PersonResponse {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Ответ успешно получен!"
                };
            }

            catch (Exception ex) {
                return new PersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = $"Ошибка: {ex.Message}",
                    InnerException = $"{ex.InnerException}"
                };
            }
        }

        [HttpPut]
        [Route("PutPerson")]
        public async Task<PersonResponse> PutPerson(Person person) {
            if (!ModelState.IsValid) {
                return new PersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _personService.UpdatePerson(person);
            return new PersonResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }


        [HttpGet]
        [Route("GetPerson")]
        public async Task<GetPersonResponse> Get() {
            if (!ModelState.IsValid) {
                return new GetPersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _personService.GetAllPersons();
            return new GetPersonResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Persons = res.ToArray()
            };
        }

        [HttpGet]
        [Route(nameof(GetPersonByFilter))]
        public GetPersonResponse GetPersonByFilter(Func<Person, bool> filter) {
            if (!ModelState.IsValid) {
                return new GetPersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = _personService.GetPersonsByFilter(filter);
            return new GetPersonResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!",
                Persons = res
            };
        }

        [HttpDelete]
        [Route("RemovePerson")]
        public async Task<PersonResponse> RemovePerson(Person person) {
            if (!ModelState.IsValid) {
                return new PersonResponse {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Ошибка"
                };
            }

            var res = await _personService.RemovePerson(person);
            return new PersonResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Ответ успешно получен!"
            };
        }
    }
}
