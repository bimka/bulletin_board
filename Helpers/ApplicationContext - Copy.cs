using BulletinBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Helpers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bulletinBoardDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Dima", Email = "dima@gmail.com", BirthDay = new DateTime(1992, 04, 27) },
                new User { Id = 2, Name = "Masha", Email = "masha@gmail.com", BirthDay = new DateTime(1967, 06, 27) },
                new User { Id = 3, Name = "Natasha", Email = "natasha@gmail.com", BirthDay = new DateTime(1989, 06, 07) }
            );
        }
    }
}
