using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmThrowdown.Contracts.Repos;
using MvvmThrowdown.Models;

namespace MvvmThrowdown.Repos
{
    public class UserRepo : IUserRepo
    {
        private static readonly IList<User> _users = new List<User>()
        {
            new User
            {
                Id = 1,
                FirstName = "George",
                LastName = "Washington"
            },
            new User
            {
                Id = 2,
                FirstName = "Abraham",
                LastName = "LIncoln"
            },
            new User
            {
                Id = 3,
                FirstName = "Thomas",
                LastName = "Jefferson"
            }
        };

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_users as IEnumerable<User>);
        }
    }
}
