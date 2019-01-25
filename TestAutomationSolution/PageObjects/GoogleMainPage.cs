using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomationSolution.PageObjects
{
    public class GoogleMainPage
    {
        public GoogleMainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[name='q']")]
        public IWebElement SearchField { get; set; }
    }
}