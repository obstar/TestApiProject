using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace TestApiProject.Tests.Config
{
    [Binding]
    public class SessionBindings
    {
        private readonly ScenarioContext _scenarioContext;

        public SessionBindings(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 10)]
        public void BeforeScenario()
        {
            Console.WriteLine($"-> [BeforeScenario] {_scenarioContext.ScenarioInfo.Title}");
        }

        [BeforeStep(Order = 10)]
        public void BeforeStep()
        {
            Console.WriteLine($"\t-> [BeforeStep] {_scenarioContext.StepContext.StepInfo.Text}");
        }

        [AfterScenario(Order = 10)]
        public void AfterEachScenario()
        {
            var nUnitStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var failed = nUnitStatus is not TestStatus.Passed and not TestStatus.Skipped;
            Console.WriteLine($"-> [AfterScenario] {_scenarioContext.ScenarioInfo.Title}");

            try
            {
                if (!failed) return;
                var error = _scenarioContext.TestError;
                Console.WriteLine("-> [AfterScenario] test has failed!");
                Console.WriteLine($"-> [AfterScenario] An error occurred: {(error != null ? error.Message : "unknown")}");
                Console.WriteLine($"-> [AfterScenario] It was of type: {(error != null ? error.GetType().Name : "unknown")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("-> Could not mark session as failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}