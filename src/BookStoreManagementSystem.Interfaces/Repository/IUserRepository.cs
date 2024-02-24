using System;
using System.Collections.Generic;
using System.Text;
using BookStoreManagementSystem.Domain.Model;

namespace BookStoreManagementSystem.Interfaces.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
    }
}
