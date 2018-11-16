using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Accounts
{
    public class AccountManagement
    {
        private IAccountRepository _accountRepo;
        public AccountManagement(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Account Login(string login, string password)
        {
            return _accountRepo.GetAccounts().FirstOrDefault(x => x.Login == login && x.Password == password);
        }
    }
}
