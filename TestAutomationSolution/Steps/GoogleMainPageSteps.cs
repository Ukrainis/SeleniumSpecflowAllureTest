using FluentAssertions;
using TechTalk.SpecFlow;
using TestAutomationSolution.PageObjects;
using TestAutomationSolution.Utils;

namespace TestAutomationSolution.Steps
{
    [Binding]
    public class GoogleMainPageSteps
    {
        private Driver _driver;
        private GoogleMainPage shopMainPage;

        public GoogleMainPageSteps(Driver driver)
        {
            _driver = driver;
            shopMainPage = new GoogleMainPage(_driver.WebDriver);
        }

        [Given(@"I am navigated to Google page")]
        public void GivenIAmNavigatedToShopApplication()
        {
            _driver.WebDriver.Navigate().GoToUrl("https://www.google.com/");
        }

        [When(@"I am redirected to Google main page")]
        public void ThenIAmRedirectedToShopApplicationMainPage()
        {
            shopMainPage.SearchField.WaitForToBeVisible("Search Field");
        }

        [Then(@"I see that page title equals to (.*)")]
        public void ThenISeeThatPageTitleEqualsTo(string pageTitleExpected)
        {
            var titleActual = _driver.WebDriver.Title;

            titleActual.Should().BeEquivalentTo(pageTitleExpected);
        }
    }
}