using AutomationTesting.Base;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;

namespace AutomationTesting.TestCases
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    public class FailureTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "TestData")]
        [Category("Failure")]
        [Description("Test that will fail on purpose")]
        public void Failure(string browserName, string operatingSystem)
        {
            try
            {
                #region Setting up browser and OS for testing
                test = report.CreateTest(String.Format("FailureTest - {0}, {1}", browserName, operatingSystem));
                test.Log(Status.Info, "Starting the FailureTest");

                SetUp(browserName, operatingSystem);

                throw new Exception("FailureTest has failed");
                #endregion
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }
    }
}
