using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}