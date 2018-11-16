using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Accounts
{
    public class AccountManagement : IAccountManagement
    {
        private IAccountRepository _accountRepo;
        private Account _loogedAccount;
        public AccountManagement(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Account Login(string login, string password)
        {
            _loogedAccount = _accountRepo.GetAccounts().FirstOrDefault(x => x.Login == login && x.Password == password);
            return GetLoggedAccount();
        }

        public Account GetLoggedAccount()
        {
            return _loogedAccount;
        }
    }
}
