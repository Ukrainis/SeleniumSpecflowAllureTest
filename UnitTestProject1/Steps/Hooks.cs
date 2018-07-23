using System;
using System.IO;
using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UnitTestProject1.Steps
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
                Console.WriteLine("WebDriver termination.");
                _driver.DriverTermination();
            }
        }

        private bool IsUiTest()
        {
            return _scenarioContext.ScenarioInfo.Tags[0] == "UiTest";
        }
    }
}