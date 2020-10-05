using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly CommanderContext _context;

        public UserRepository(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}