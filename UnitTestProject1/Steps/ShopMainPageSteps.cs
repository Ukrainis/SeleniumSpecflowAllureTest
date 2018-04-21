using System;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Utils;

namespace UnitTestProject1.Steps
{
    [Binding]
    public class ShopMainPageSteps
    {
        private Driver _driver;
        private ShopAuthenticationPage shopAuthenticationPage;
        private ShopMainPage shopMainPage;

        public ShopMainPageSteps(Driver driver)
        {
            _driver = driver;
            shopMainPage = new ShopMainPage(_driver.WebDriver);
            shopAuthenticationPage = new ShopAuthenticationPage(_driver.WebDriver);
        }

        [Given(@"I am navigated to Shop application main page")]
        public void GivenIAmNavigatedToShopApplication()
        {
            Console.WriteLine("Entering Shop application.");
            _driver.WebDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [When(@"I click Sign in link")]
        public void WhenIClickSignInLink()
        {
            Console.WriteLine("Clicking Sign in link.");
            shopMainPage.SignInLink.Click();
        }

        [Then(@"I am redirected to Shop application main page")]
        public void ThenIAmRedirectedToShopApplicationMainPage()
        {
            Console.WriteLine("Verifying that we are redirected to main page.");
            shopMainPage.MainPageSlider.WaitForElementPresent(_driver);
        }
    }
}