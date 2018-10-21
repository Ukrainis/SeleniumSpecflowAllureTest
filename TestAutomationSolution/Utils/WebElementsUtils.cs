using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationSolution.Utils
{
    public static class WebElementsUtils
    {
        public static void WaitForElementPresent (this IWebElement element, Driver _driver)
        {
            WebDriverWait wait = _driver.MakeWebDriverWait();
            wait.Until(driver => element.Displayed);
        }

        public static string MakeScreenshot(Driver driver, string testName = "screen")
        {
            string projectPath = Path.GetDirectoryName(GetTestAssemblyFolder());
            Screenshot ss = ((ITakesScreenshot)driver.WebDriver).GetScreenshot();
            string fileLocation = $"{projectPath}/{testName}.png";
            ss.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            return fileLocation;
        }

        private static string GetTestAssemblyFolder()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
}