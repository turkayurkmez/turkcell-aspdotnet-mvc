﻿using eshop.Entities;

namespace eshop.Services
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}