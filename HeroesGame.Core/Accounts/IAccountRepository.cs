﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Accounts
{
    public interface IAccountRepository
    {

        void Add(Account newAccount);
        List<Account> GetAll();

    }
}
