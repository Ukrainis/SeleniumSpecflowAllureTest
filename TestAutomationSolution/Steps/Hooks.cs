using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Allure.Commons;
using BoDi;
using NLog;
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
        private AllureLifecycle _allureLifecycle;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _allureLifecycle = AllureLifecycle.Instance;
        }

        [OneTimeSetUp]
        public void SetupForAllure()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [BeforeScenario]
        public void Setup()
        {
            if (IsUiTest())
            {
                var browserName = _scenarioContext.ScenarioInfo.Tags[1];
                _driver = new Driver(browserName);
                _objectContainer.RegisterInstanceAs<Driver>(_driver);
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            if (IsUiTest())
            {
                if (_scenarioContext.TestError != null)
                {
                    var path = WebElementsUtils.MakeScreenshot(_driver);
                    _allureLifecycle.AddAttachment(path);
                }

                Logger.Info("WebDriver termination.");
                _driver.DriverTermination();
            }

            AllureHackForScenarioOutlineTests();
        }

        private void AllureHackForScenarioOutlineTests()
        {
            _scenarioContext.TryGetValue(out TestResult testresult);
            _allureLifecycle.UpdateTestCase(testresult.uuid, tc =>
            {
                tc.name = _scenarioContext.ScenarioInfo.Title;
                tc.historyId = Guid.NewGuid().ToString();
            });
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            CloseChromeDriverProcesses();
        }

        private bool IsUiTest()
        {
            return _scenarioContext.ScenarioInfo.Tags[0] == "UiTest";
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