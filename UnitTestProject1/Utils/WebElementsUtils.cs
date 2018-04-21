using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.Utils
{
    public static class WebElementsUtils
    {
        public static void WaitForElementPresent (this IWebElement element, Driver _driver)
        {
            WebDriverWait wait = _driver.MakeWebDriverWait();
            wait.Until(driver => element.Displayed);
        }
    }
}