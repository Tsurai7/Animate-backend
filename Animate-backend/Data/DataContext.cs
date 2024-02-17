using Animate_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Animate_backend.Data
{
    public class DataContext :DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Nikita", Email = "nikita@test.com", Password = "123" },
                    new User { Id = 2, Name = "Egor", Email = "egor@test.com", Password = "123" },
                    new User { Id = 3, Name = "Nik", Email = "nikita123@test.com", Password = "1234" }
            );
        }
    }
}
