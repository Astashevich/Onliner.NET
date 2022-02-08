using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Onliner.NET.Main.Onliner.Constants;
using Onliner.NET.Main.Onliner.Core.Driver;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace Onliner.NET.Test.Onliner
{
    public abstract class BaseTest
    {
        private static readonly int ProjectId = TestRailUtils.CreateTestProject();
        private static readonly int SuiteId = TestRailUtils.CreateTestSuite(ProjectId);
        private static readonly int SectionId = TestRailUtils.CreateTestSection(ProjectId, SuiteId);
        private static readonly int RunId = TestRailUtils.CreateTestRun(ProjectId, SuiteId);

        [SetUp]
        public void BeforTestSetUp()
        {
            DriverManager.StartDriver(BrowserType.CHROME);

            GenericPages.MainPage.OpenPage();
        } 

        [TearDown]
        public void TearDown()
        {
            DriverManager.QuitDriver();

            TestRailUtils.CreateTestCase(SectionId, TestContext.CurrentContext.Test.Properties.Get("Description").ToString());
            var testId = TestRailUtils.GetTest(RunId);
            var testResult = TestContext.CurrentContext.Result.Outcome.Status switch
            {
                TestStatus.Passed => TestResults.PASSED,
                _ => TestResults.FAILED
            };
            var comment = testResult.Equals(TestResults.FAILED) ? TestContext.CurrentContext.Result.Message : "Test passed";
            var resultId = TestRailUtils.AddResultForCase(testId, (int)testResult, comment);
        }
    }
}
