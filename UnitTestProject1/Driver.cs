using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using NLog;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    public class Driver
    {
        public IWebDriver WebDriver;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Driver(string browser)
        {
            DriverInitialization(browser);
        }

        private void DriverInitialization(string browserName)
        {
            Logger.Info("WebDriver initizalization. Browser choosen: " + browserName);
            switch (browserName)
            {
                case "ChromeLocal":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
                default:
                    throw new KeyNotFoundException("Wrong Browser name. Please choose correct.");
            }
        }

        public WebDriverWait MakeWebDriverWait()
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromMinutes(2));
        }

        public void DriverTermination()
        {
            Logger.Info("WebDriver termination.");
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }
        }
    }
}
