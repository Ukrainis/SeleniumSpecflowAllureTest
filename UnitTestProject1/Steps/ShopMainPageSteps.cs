﻿using FluentAssertions;
using NLog;
using TechTalk.SpecFlow;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Utils;
using Logger = NLog.Logger;

namespace UnitTestProject1.Steps
{
    [Binding]
    public class ShopMainPageSteps
    {
        private Driver _driver;
        private ShopMainPage shopMainPage;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ShopMainPageSteps(Driver driver)
        {
            _driver = driver;
            shopMainPage = new ShopMainPage(_driver.WebDriver);
        }

        [Given(@"I am navigated to Shop application main page")]
        public void GivenIAmNavigatedToShopApplication()
        {
            Logger.Info("Entering Shop application.");
            _driver.WebDriver.Navigate().GoToUrl(
                System.Configuration.ConfigurationManager.AppSettings["ShopBaseUrl"]);
        }

        [When(@"I click Sign in link")]
        public void WhenIClickSignInLink()
        {
            Logger.Info("Clicking Sign in link.");
            shopMainPage.SignInLink.Click();
        }

        [Then(@"I am redirected to Shop application main page")]
        public void ThenIAmRedirectedToShopApplicationMainPage()
        {
            Logger.Info("Verifying that we are redirected to main page.");
            shopMainPage.MainPageSlider.WaitForElementPresent(_driver);
        }

        [Then(@"I see that page title equals to ""(.*)""")]
        public void ThenISeeThatPageTitleEqualsTo(string pageTitleExpected)
        {
            var titleActual = _driver.WebDriver.Title;

            titleActual.Should().BeEquivalentTo(pageTitleExpected);
        }

    }
}