using Ex2.Models;
using Microsoft.EntityFrameworkCore;


namespace Ex1.Models
{
    internal class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarsDbContext ()
        {
            Database.EnsureCreated ();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\galda\Desktop\Test\LAb16\Ex2\CarsDb.mdf;Integrated Security=True");
        }
    }
}
