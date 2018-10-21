using FluentAssertions;
using NLog;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationSolution.PageObjects;
using TestAutomationSolution.Utils;

namespace TestAutomationSolution.Steps
{
    [Binding]
    public class ShopAuthenticationPageSteps
    {
        private Driver _driver;
        private ShopAuthenticationPage shopAuthenticationPage;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ShopAuthenticationPageSteps(Driver driver)
        {
            _driver = driver;
            shopAuthenticationPage = new ShopAuthenticationPage(driver.WebDriver);
        }

        [When(@"I login using (.*) and (.*)")]
        public void WhenILoginUsingUkGmail_ComAndPass(string email, string password)
        {
            shopAuthenticationPage.LoginWithCustomCredentials(email, password);
        }

        [Then(@"I should see next (.*) message")]
        public void ThenIShouldSeeNextAuthenticationFailed(string message)
        {
            shopAuthenticationPage.WarningMessageLabel.WaitForElementPresent(_driver);
            string pageMessage = shopAuthenticationPage.WarningMessageLabel.Text;

            pageMessage.Should().BeEquivalentTo(message);
        }
    }
}