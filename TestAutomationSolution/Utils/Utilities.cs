using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace TestAutomationSolution.Utils
{
    public class Utilities
    {
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
