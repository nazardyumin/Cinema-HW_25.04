using Cinema.Model;
using Microsoft.EntityFrameworkCore;

namespace Cinema.BL
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Film>? Films { get; set; }
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
