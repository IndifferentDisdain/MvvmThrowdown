using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmThrowdown.Models;

namespace MvvmThrowdown.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
