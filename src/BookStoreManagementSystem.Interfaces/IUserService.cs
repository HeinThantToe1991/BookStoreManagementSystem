using BookStoreManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagementSystem.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(User user);
    }
}
