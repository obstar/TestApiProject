using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using TechTalk.SpecFlow;

namespace TestApiProject.Tests.Config
{
    [Binding]
    public class ReportBindings
    {
        private static ExtentReports _extent;
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private readonly ScenarioContext _scenarioContext;

        public ReportBindings(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        private static void BeforeTestRun()
        {
            var htmlReporter = new ExtentHtmlReporter(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net5.0", "\\Report"));
            htmlReporter.Config.Theme = Theme.Standard;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario(Order = 20)]
        public void BeforeScenario()
        {
            _scenario = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title + $" {_scenarioContext.ScenarioInfo.Arguments[0]}");
        }

        [AfterStep(Order = 20)]
        public void AfterStepAppendReport()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case "When":
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case "And":
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                }
            else if (_scenarioContext.TestError != null)
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                                .Fail(_scenarioContext.TestError.Message);
                        break;
                    case "When":
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                                .Fail(_scenarioContext.TestError.Message);
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                                .Fail(_scenarioContext.TestError.Message);
                        break;
                    case "And":
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text)
                                .Fail(_scenarioContext.TestError.Message);
                        break;
                }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }
    }
}