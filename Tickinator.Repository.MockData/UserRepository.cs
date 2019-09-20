using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
    public class UserRepository : IUserRepository
    {
        private IList<User> users;

        public UserRepository()
        {
            Seed();
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        private void Seed()
        {
            users = new List<User>();
            users.Add(new User {Id = 1, UserName = "bjones", Password = "password"});
            users.Add(new User {Id = 2, UserName = "bsmith", Password = "password"});
            users.Add(new User {Id = 3, UserName = "sroe", Password = "password"});
        }
    }
}