using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationSolution.Utils;

namespace TestAutomationSolution.Steps
{
    [Binding]
    public class Hooks
    {
        private Driver _driver;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
                _driver = new Driver("ChromeLocal");
                _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            if (_scenarioContext.TestError != null)
                {
                    WebElementsUtils.MakeScreenshot(_driver);
                }

            _driver.DriverTermination();
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            CloseChromeDriverProcesses();
        }

        private static void CloseChromeDriverProcesses()
        {
            var chromeDriverProcesses = Process.GetProcesses().
                Where(pr => pr.ProcessName == "chromedriver");

            if (chromeDriverProcesses.Count() == 0)
            {
                return;
            }

            foreach (var process in chromeDriverProcesses)
            {
                process.Kill();
            }
        }
    }
}