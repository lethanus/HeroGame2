using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace HeroGame.Accounts
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
            AccountCollection accountCollection = new AccountCollection();
            foreach(var account in GetAccounts())
            {
                accountCollection.Accounts.Add(account);
            }
            accountCollection.Accounts.Add(newAccount);

            File.WriteAllText(_pathToRepoFile, JsonConvert.SerializeObject(accountCollection,Formatting.Indented));

        }

        public List<Account> GetAccounts()
        {
            if (!File.Exists(_pathToRepoFile))
            {
                return new List<Account>();
            }
            var json = File.ReadAllText(_pathToRepoFile);
            return JsonConvert.DeserializeObject<AccountCollection>(json).Accounts.ToList();
        }
    }

    public class AccountCollection
    {
        public IList<Account> Accounts { get; set; }
        public AccountCollection()
        {
            Accounts = new List<Account>();
        }
    }
}
