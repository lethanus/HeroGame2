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
    public class AccountJsonFileRepository : IAccountRepository
    {
        private string _pathToRepoFile;
        public AccountJsonFileRepository(string pathToRepoFile)
        {
            _pathToRepoFile = pathToRepoFile;
        }

        public void AddAccount(Account newAccount)
        {
            var accountCollection = new List<Account>();
            accountCollection.AddRange(GetAccounts());
            accountCollection.Add(newAccount);

            File.WriteAllText(_pathToRepoFile, JsonConvert.SerializeObject(accountCollection,Formatting.Indented));

        }

        public List<Account> GetAccounts()
        {
            if (!File.Exists(_pathToRepoFile))
            {
                return new List<Account>();
            }
            var json = File.ReadAllText(_pathToRepoFile);
            return JsonConvert.DeserializeObject<List<Account>>(json);
        }
    }
}
