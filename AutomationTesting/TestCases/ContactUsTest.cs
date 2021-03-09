using AutomationTesting.Base;
using AutomationTesting.PageObjects;
using AutomationTesting.Settings;
using AutomationTesting.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting.TestCases
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    public class ContactUsTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "TestData")]
        [Category("Contact Us")]
        [Description("Verifies the functionality of the contact us feature")]
        public void ContactUs(string browserName, string operatingSystem)
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
            Browser.WaitForElement(driver, accountPage.lnkUser);

            Assert.True(accountPage.lnkUser.Text.Equals(Variables.User));
            #endregion

            #region Go to the contact us page and send a message
            Browser.WaitForElement(driver, accountPage.lnkContactUs);
            Browser.Click(driver, accountPage.lnkContactUs);

            var contactUsPage = new ContactUsPage(driver);

            Browser.WaitForElement(driver, contactUsPage.txaMessage);

            new SelectElement(contactUsPage.ddlSubjectHeading).SelectByText(Variables.SubjectHeading);
            Assert.AreEqual(Variables.Email, contactUsPage.txtEmail.GetAttribute("value"));
            contactUsPage.txaMessage.SendKeys(Variables.Message);

            Browser.WaitForElement(driver, contactUsPage.btnSend);
            Browser.Click(driver, contactUsPage.btnSend);
            #endregion

            #region Verify message being sent successfully
            Browser.WaitForElement(driver, contactUsPage.lblResponse);

            Assert.True(contactUsPage.lblResponse.Text.Equals(Variables.SuccessfulMessage));
            #endregion
        }
    }
}
