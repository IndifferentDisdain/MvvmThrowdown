using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmThrowdown.Models;

namespace MvvmThrowdown.Contracts.Repos
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
