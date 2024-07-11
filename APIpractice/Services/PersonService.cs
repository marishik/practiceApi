using APIpractice.Models;

namespace APIpractice.Services
{
    public interface IPersonService {
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<List<Person>> GetAllPersons();
        Task<Person> GetHuman(int id);
        Task<Person> RemovePerson(Person person);
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

        public async Task<Person> UpdatePerson(Person person) {
            var res = _context.person.Update(person);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Person>> GetAllPersons() {
            return _context.person.ToList();
        }

        public async Task<Person> GetHuman(int id) {
            return _context.person.Where(h => h.Id == id).First();
        }

        public async Task<Person> RemovePerson(Person person) {
            _context.person.Where(p => p == person)
                .First().RecordStatus = RecordStatus.Inactive;

            await _context.SaveChangesAsync();
            return _context.person.Where(p => p == person).First();
        }
    }
}