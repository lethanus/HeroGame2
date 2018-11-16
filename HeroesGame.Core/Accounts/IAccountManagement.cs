namespace HeroesGame.Accounts
{
    public interface IAccountManagement
    {
        Account Login(string login, string password);
        Account GetLoggedAccount();
    }
}