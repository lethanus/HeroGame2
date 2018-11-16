using System;
using TechTalk.SpecFlow;

namespace ConstructionYard
{
    [Binding]
    public class RefreshingMechanismSteps
    {
        [Given(@"that there was no refresh actions before for option '(.*)' for account ID '(.*)'")]
        public void GivenThatThereWasNoRefreshActionsBeforeForOption(string option, string accountID)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"current time is set to '(.*)'")]
        public void GivenCurrentTimeIsSetTo(DateTime currentTime)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Refresh time for option '(.*)' is set to '(.*)' seconds")]
        public void GivenRefreshTimeForOptionIsSetToSeconds(string option, int delayInSeconds)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"mechanizm will set refresh to '(.*)' for option '(.*)' for account ID '(.*)'")]
        public void WhenMechanizmWillSetRefreshToForOption(string status, string option, string accountID)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"player with account ID '(.*)' will use refresh for '(.*)' option at '(.*)'")]
        public void WhenPlayerWillUseRefreshForOptionAt(string accountID, string option, DateTime actionTime)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Refresh for option '(.*)' is '(.*)' and next refresh is available at '(.*)' for account ID '(.*)'")]
        public void ThenRefreshForOptionIsAndNextRefreshIsAvailableAt(string option, string status, DateTime nextActionTime, string accountID)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
