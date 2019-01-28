using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationSolution.Utils
{
    public static class Extensions
    {
        private static TimeSpan timeout = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["explicitTimeout"]));

        public static void WaitForToBeVisible(this IWebElement element, string errorMessage)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = timeout
            };
            try
            {
                wait.Until(elem => elem.Displayed);
            }
            catch (Exception e)
            {
                Assert.Fail(errorMessage + " is not visible (displayed)!\n" + e.GetType() + "\n" + e.Message);
            }
        }

        public static void WaitForTitleToBe(this Driver driver, string title)
        {
            var wait = driver.GetNewWebDriverWait();
            try
            {
                wait.Until(ExpectedConditions.TitleIs(title));
            }
            catch (Exception e)
            {
                Assert.Fail("Title is not '" + title + "'!\n" + e.GetType() + "\n" + e.Message);
            }
        }
    }
}
