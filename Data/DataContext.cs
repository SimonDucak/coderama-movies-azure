using coderama_movies_server.Models;
using Microsoft.EntityFrameworkCore;

namespace coderama_movies_server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<FavouriteMovie> FavouriteMovies { get; set; }
    }
}

