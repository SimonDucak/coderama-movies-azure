using coderama_movies_server.Models;

namespace coderama_movies_server.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> Get(int pageSize, int pageNumber);

        User? GetById(int id);

        bool UserExists(int id);

        bool Update(User user);

        bool Save();
    }
}
