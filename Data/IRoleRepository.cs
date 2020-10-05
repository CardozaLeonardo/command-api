using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface IRoleRepository
    {
        bool SaveChanges();
        IEnumerable<Role> GetAllRoles();
    }
}