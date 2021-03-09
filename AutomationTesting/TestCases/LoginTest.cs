using AutomationTesting.Base;
using AutomationTesting.PageObjects;
using AutomationTesting.Settings;
using AutomationTesting.Utilities;
using NUnit.Framework;

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
            #region Setting up browser and OS for testing
            SetUp(browserName, operatingSystem);
            #endregion

            #region Navigate to the store homepage
            driver.Navigate().GoToUrl(Variables.Website);
            Assert.True(driver.Title.Contains("My Store"));

            var homePage = new HomePage(driver);
            #endregion

            #region Click the login button to progress to authentication
            Browser.WaitForElement(driver, homePage.btnLogin);
            Browser.Click(driver, homePage.btnLogin);

            var authenticationPage = new AuthenticationPage(driver);
            #endregion

            #region Enter login information & click sign in button
            Browser.WaitForElement(driver, authenticationPage.txtEmail);
            Browser.WaitForElement(driver, authenticationPage.txtPassword);

            authenticationPage.txtEmail.SendKeys(Variables.Email);
            authenticationPage.txtPassword.SendKeys(Variables.Password);

            Browser.WaitForElement(driver, authenticationPage.btnLogin);
            Browser.Click(driver, authenticationPage.btnLogin);

            var accountPage = new AccountPage(driver);
            #endregion

            #region Verify successful login of test user
            Browser.WaitForElement(driver, accountPage.lblUser);

            Assert.True(accountPage.lblUser.Text.Equals(Variables.User));
            #endregion
        }
    }
}
