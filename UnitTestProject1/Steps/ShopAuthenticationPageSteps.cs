using NUnit.Framework;
using TechTalk.SpecFlow;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Utils;

namespace UnitTestProject1.Steps
{
    [Binding]
    public class ShopAuthenticationPageSteps
    {
        private Driver _driver;
        private ShopAuthenticationPage shopAuthenticationPage;

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
            Assert.AreEqual(message, pageMessage);
        }
    }
}