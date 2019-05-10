using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Temporary model for proof of concept to provide login functionality
/// </summary>

namespace Assignment_2.BL
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public User(string username, string password, bool admin)
        {
            Username = username;
            Password = password;
            Admin = admin;
        }
    }
}