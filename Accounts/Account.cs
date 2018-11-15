﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroGame.Accounts
{
    public class Account
    {
        public string ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Account()
        { }
        public Account(string login, string password)
        {
            Login = login;
            Password = password;
            ID = $"{Guid.NewGuid().ToString()}_{login}";
        }
    }
}
