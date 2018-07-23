using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using NLog;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

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
            DesiredCapabilities driverOptions;
            Logger.Info("WebDriver initizalization. Browser choosen: " + browserName);
            switch (browserName)
            {
                case "ChromeLocal":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
                case "Chrome":
                    driverOptions = DesiredCapabilities.Chrome();
                    MakeDesiredCapabilities(driverOptions);
                    WebDriver = new RemoteWebDriver(
                        new Uri(System.Configuration.ConfigurationManager.AppSettings["BrowserStackUrl"]), 
                        driverOptions);
                    break;
                default:
                    throw new KeyNotFoundException("Wrong Browser name. Please choose correct.");
            }
        }

        private void MakeDesiredCapabilities(DesiredCapabilities desiredCap)
        {
            desiredCap.SetCapability("os", "Windows");
            desiredCap.SetCapability("os_version", "10");
            desiredCap.SetCapability("resolution", "1920x1080");
            desiredCap.SetCapability("browserstack.user", 
                System.Configuration.ConfigurationManager.AppSettings["BrowserStackUser"]);
            desiredCap.SetCapability("browserstack.key", 
                System.Configuration.ConfigurationManager.AppSettings["BrowserStackPass"]);
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
