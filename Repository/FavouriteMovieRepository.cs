using coderama_movies_server.Data;
using coderama_movies_server.Interfaces;
using coderama_movies_server.Models;

namespace coderama_movies_server.Repository
{
    public class FavouriteMovieRepository : IFavouriteMovieRepository
    {
        private readonly DataContext _context;

        public FavouriteMovieRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<FavouriteMovie> Get(int userId)
        {
            return _context.FavouriteMovies.Where(u => u.User == userId).ToList();
        }

        public ICollection<FavouriteMovie> Get(int userId, int pageSize, int pageNumber)
        {
            var query = _context.FavouriteMovies
                .Where(u => u.User == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return query.ToList();
        }

        public FavouriteMovie? GetByImdbId(int userId, string imdbId)
        {
            return _context.FavouriteMovies.FirstOrDefault(m => m.User == userId && m.ImdbID == imdbId);
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Delete(FavouriteMovie movie)
        {
            _context.FavouriteMovies.Remove(movie);
            return Save();
        }

        public bool Add(FavouriteMovie movie)
        {
            _context.FavouriteMovies.Add(movie);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}