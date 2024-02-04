using coderama_movies_server.Models;

namespace coderama_movies_server.Interfaces
{
    public interface IFavouriteMovieRepository
    {
        ICollection<FavouriteMovie> Get(int userId);

        ICollection<FavouriteMovie> Get(int userId, int pageSize, int pageNumber);

        FavouriteMovie? GetByImdbId(int userId, string imdbId);

        bool Delete(FavouriteMovie movie);

        bool Add(FavouriteMovie movie);

        bool Save();
    }
}
