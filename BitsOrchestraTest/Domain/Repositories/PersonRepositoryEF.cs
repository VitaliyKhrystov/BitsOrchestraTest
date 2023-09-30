

using BitsOrchestraTest.Domain.Entities;
using BitsOrchestraTest.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BitsOrchestraTest.Domain.Repositories
{
    public class PersonRepositoryEF : IPersonRepository, IDisposable
    {
        private bool disposedValue;
        private readonly AppDbContext context;

        public PersonRepositoryEF(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Person person)
        {
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Person> people)
        {
            await context.AddRangeAsync(people);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Person person)
        {
            context.Remove(person);
            await context.SaveChangesAsync() ;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await context.People.AsNoTracking().ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await context.People.FirstOrDefaultAsync(p => p.Id == id, default);
        }

        public async Task Update(Person person)
        {
            context.Update(person);
            await context.SaveChangesAsync();
        }

        protected virtual async void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    await context.DisposeAsync();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
