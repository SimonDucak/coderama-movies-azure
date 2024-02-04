using coderama_movies_server.Data;
using coderama_movies_server.Helper;
using coderama_movies_server.Interfaces;
using coderama_movies_server.Models;

namespace coderama_movies_server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> Get(int pageSize, int pageNumber)
        {
            var query = _context.Users.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return query.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}