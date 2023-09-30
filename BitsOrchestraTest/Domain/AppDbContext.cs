using BitsOrchestraTest.Domain.Entities;
using BitsOrchestraTest.Services;
using Microsoft.EntityFrameworkCore;

namespace BitsOrchestraTest.Domain
{
    public class AppDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                        .Property(p => p.DateofBirth)
                        .HasConversion<DateOnlyConverter>();
        }
    }
}
