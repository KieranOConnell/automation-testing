using AutomationTesting.Base;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;

namespace AutomationTesting.TestCases
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    public class SkipTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "TestData")]
        [Category("Skip")]
        [Description("Test to demonstrate the skip feature")]
        public void Skip(string browserName, string operatingSystem)
        {
            try
            {
                #region Setting up browser and OS for testing
                test = report.CreateTest(String.Format("SkipTest - {0}, {1}", browserName, operatingSystem));
                test.Log(Status.Skip, "SkipTest has been skipped");

                SetUp(browserName, operatingSystem);
                #endregion
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }
    }
}
