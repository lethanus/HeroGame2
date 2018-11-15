using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ConstructionYard
{
    [Binding]
    public class AccountManagementSteps
    {
        private List<Account> accounts;
        private Account loggedId = null;


        [Given(@"Some accounts exists in system")]
        public void GivenSomeAccountsExistsInSystem(Table table)
        {
            accounts = table.CreateSet<Account>().ToList();
            Assert.Greater(accounts.Count, 0);
        }
        
        [When(@"I try to login for '(.*)' and password '(.*)'")]
        public void WhenITryToLoginForAndPassword(string givenLogin, string givenPassword)
        {
            AccountManagement accountManagement = new AccountManagement();
            loggedId = accountManagement.Login(givenLogin, givenPassword);
        }
        
        [Then(@"Logged account id is '(.*)'")]
        public void ThenLoggedAccountIdIs(string expectedAccountID)
        {
            if (expectedAccountID == "none") Assert.AreEqual(null, loggedId);
            else Assert.AreEqual(expectedAccountID, loggedId.ID);
        }
    }

    public class AccountManagement
    {
        public Account Login(string login, string password)
        {
            return null;
        }
    }

    public class Account
    {
        public string ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
