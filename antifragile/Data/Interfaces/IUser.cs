﻿using antifragile.Data.Models;

namespace antifragile.Data.Interfaces;

public interface IUser
{
    IEnumerable<User> AllUsers { get; }

    public void AddUser(User newUser);

}