﻿using antifragile.Data.Models;

namespace antifragile.ViewModels;

public class LoginViewModel
{ 
    public string Email { get; set; }
    public string Password { get; set; }

    public bool KeepLoggedIn;
}