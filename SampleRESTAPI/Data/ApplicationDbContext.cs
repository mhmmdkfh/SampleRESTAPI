using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;

namespace SampleRESTAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
