using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CommanderContext _context;

        public RoleRepository(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Role.ToList();
        }
    }
}