using BitsOrchestraTest.Domain.Entities;

namespace BitsOrchestraTest.Domain.Repositories.Abstract
{
    public interface IPersonRepository
    {
        Task Add(Person person);
        Task AddRange(IEnumerable<Person> person);
        Task Delete(Person person);
        Task Update(Person person);
        Task<Person> GetById(int id);
        Task<IEnumerable<Person>> GetAll();
    }
}
