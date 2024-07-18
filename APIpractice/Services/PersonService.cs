using APIpractice.Models;

namespace APIpractice.Services
{
    public interface IPersonService {
        public Task<Person> AddPerson(Person person);
        public Task<Person> UpdatePerson(Person person);
        public Task<List<Person>> GetAllPersons();
        public Person[] GetPersonsByFilter(Func<Person, bool> filter);
        public Task<Person> RemovePerson(Person person);
    }

    public class PersonService : IPersonService {
        private readonly ApplicationContext _context;

        public PersonService(ApplicationContext context) {
            _context = context;
        }

        public async Task<Person> AddPerson(Person person) {
            var res = await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Person> UpdatePerson(Person person) {
            var res = _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<List<Person>> GetAllPersons() 
            => _context.Persons.ToList();

        public Person[] GetPersonsByFilter(Func<Person, bool> filter)
            => _context.Persons.Where(filter).ToArray();

        public async Task<Person> RemovePerson(Person person) {
            _context.Persons.Where(p => p == person)
                .First().RecordStatus = RecordStatus.Inactive;

            await _context.SaveChangesAsync();
            return _context.Persons.Where(p => p == person).First();
        }
    }
}