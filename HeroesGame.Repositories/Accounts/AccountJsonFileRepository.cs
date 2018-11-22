using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using HeroesGame.Accounts;

namespace HeroesGame.Repositories
{
    public class AccountJsonFileRepository : JsonListRepository<Account>,  IAccountRepository
    {
        public AccountJsonFileRepository(string pathToRepoFile) : base(pathToRepoFile) { }
    }
}
