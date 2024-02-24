using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;
using BookStoreManagementSystem.Interfaces;
using BookStoreManagementSystem.Interfaces.Repository;

namespace BookStoreManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            user.Id = Guid.NewGuid();
            // Perform any validation or business logic here
            _userRepository.AddUser(user);
        }

        // Other methods as needed
    }
}
