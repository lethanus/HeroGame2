using System.Collections.Generic;
using HeroGame.Accounts;

namespace ConstructionYard
{
    public class AccountMemoryRepository : IAccountRepository
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account newAccount)
        {
            accounts.Add(newAccount);
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }




}
