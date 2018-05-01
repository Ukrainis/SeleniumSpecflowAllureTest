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
        private ScenarioContext _scenarioContext;

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
            var browserList = _scenarioContext.ScenarioInfo.Tags;
            foreach (var browser in browserList)
            {
                _driver = new Driver(browser);
                _objectContainer.RegisterInstanceAs<Driver>(_driver);
            }
            Console.WriteLine(Path.GetDirectoryName(GetType().Assembly.Location));
        }

        [AfterScenario]
        public void TearDown()
        {
            Console.WriteLine("WebDriver termination.");
            _driver.DriverTermination();
        }
    }
}