using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    public class Driver
    {
        public IWebDriver WebDriver;

        public Driver(string browser)
        {
            DriverInitialization(browser);
        }

        private void DriverInitialization(string browserName)
        {
            Console.WriteLine("WebDriver initizalization. Browser choosen: " + browserName);
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
            Console.WriteLine("WebDriver termination.");
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }
        }
    }
}
