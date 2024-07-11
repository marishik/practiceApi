using APIpractice.Models;

namespace APIpractice.Services
{
    public interface IPersonService {
        Task<List<Person>> GetAllPersons();
        Task<Person> GetPerson(int id);
        Task<Person> AddPerson(Person person);
    }

    public class PersonService : IPersonService {
        private readonly ApplicationContext _context;

        public PersonService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Person> AddPerson(Person person) {
            var res = await _context.person.AddAsync(person);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Person>> GetAllPersons() {
            return _context.person.ToList();
        }

        public async Task<Person> GetPerson(int id) {
            return _context.person.Where(h => h.id == id).First();
        }
    }
}