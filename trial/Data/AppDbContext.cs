using Microsoft.EntityFrameworkCore;
using trial.Data.Models;

namespace trial.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

    }
}
