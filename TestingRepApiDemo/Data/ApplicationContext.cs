using Microsoft.EntityFrameworkCore;
using TestingRepApiDemo.Models;

namespace TestingRepApiDemo.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tag> tags { get; set; }
        public DbSet<DogPicture> DogPictures { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    }
}
