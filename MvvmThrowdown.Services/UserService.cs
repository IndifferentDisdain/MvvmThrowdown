using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmThrowdown.Contracts.Repos;
using MvvmThrowdown.Contracts.Services;
using MvvmThrowdown.Models;

namespace MvvmThrowdown.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userRepo.GetAllAsync();
        }
    }
}
