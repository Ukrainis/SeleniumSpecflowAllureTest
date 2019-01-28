using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium.Chrome;

namespace TestAutomationSolution.Utils
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
            Console.WriteLine($"WebDriver initizalization. Browser choosen: {browserName}");
            switch (browserName)
            {
                case "ChromeLocal":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
                default:
                    throw new KeyNotFoundException($"Wrong Browser name: {browserName}. Please choose correct.");
            }
        }

        public WebDriverWait GetNewWebDriverWait()
        {
            return new WebDriverWait(WebDriver, 
                TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["explicitTimeout"])));
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
