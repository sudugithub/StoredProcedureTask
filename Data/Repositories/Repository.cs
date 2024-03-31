using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository(DbContextOptions<Repository> options) : DbContext(options)
    {

        public DbSet<Book> Books { get; set; }
    }
}