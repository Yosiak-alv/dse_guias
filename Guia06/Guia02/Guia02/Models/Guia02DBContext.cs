using Microsoft.EntityFrameworkCore;

namespace Guia02.Models
{
    public class Guia02DBContext : DbContext
    {
        public Guia02DBContext(DbContextOptions<Guia02DBContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
