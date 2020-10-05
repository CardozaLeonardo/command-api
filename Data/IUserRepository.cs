using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
    }
}