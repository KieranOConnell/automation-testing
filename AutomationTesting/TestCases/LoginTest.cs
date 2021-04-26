using AutomationTesting.Base;
using AutomationTesting.PageObjects;
using AutomationTesting.Settings;
using AutomationTesting.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;

namespace AutomationTesting.TestCases
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    public class LoginTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "TestData")]
        [Category("Login")]
        [Description("Simple login test for users of the store")]
        public void Login(string browserName, string operatingSystem)
        {
            try
            {
                #region Setting up browser and OS for testing
                test = report.CreateTest(String.Format("LoginTest - {0}, {1}", browserName, operatingSystem));
                test.Log(Status.Info, "Starting the LoginTest");

                SetUp(browserName, operatingSystem);
                #endregion

                #region Navigate to the store homepage
                test.Log(Status.Info, "Navigating to the store homepage");

                driver.Navigate().GoToUrl(Variables.Website);
                Assert.True(driver.Title.Contains("My Store"));

                var homePage = new HomePage(driver);
                #endregion

                #region Click the login button to progress to authentication
                test.Log(Status.Info, "Attempting to log in to the store");

                Browser.WaitForElement(driver, homePage.btnLogin);
                Browser.Click(driver, homePage.btnLogin);

                var authenticationPage = new AuthenticationPage(driver);
                #endregion

                #region Enter login information & click sign in button
                test.Log(Status.Info, "Entering login information & signing in");

                Browser.WaitForElement(driver, authenticationPage.txtEmail);
                Browser.WaitForElement(driver, authenticationPage.txtPassword);

                authenticationPage.txtEmail.SendKeys(Variables.Email);
                authenticationPage.txtPassword.SendKeys(Variables.Password);

                Browser.WaitForElement(driver, authenticationPage.btnLogin);
                Browser.Click(driver, authenticationPage.btnLogin);

                var accountPage = new AccountPage(driver);
                #endregion

                #region Verify successful login of test user
                test.Log(Status.Info, "Verifying successful login of test user");

                Browser.WaitForElement(driver, accountPage.lnkUser);
                Assert.True(accountPage.lnkUser.Text.Equals(Variables.User));

                test.Log(Status.Pass, "LoginTest has passed successfully");
                #endregion
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }
    }
}
