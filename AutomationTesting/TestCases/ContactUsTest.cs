using AutomationTesting.Base;
using AutomationTesting.PageObjects;
using AutomationTesting.Settings;
using AutomationTesting.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

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
            try
            {
                #region Setting up browser and OS for testing
                test = report.CreateTest(String.Format("ContactUsTest - {0}, {1}", browserName, operatingSystem));
                test.Log(Status.Info, "Starting the ContactUsTest");

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
                #endregion

                #region Go to the contact us page and send a message
                test.Log(Status.Info, "Navigating to the contact us page");
                Browser.WaitForElement(driver, accountPage.lnkContactUs);
                Browser.Click(driver, accountPage.lnkContactUs);

                var contactUsPage = new ContactUsPage(driver);

                Browser.WaitForElement(driver, contactUsPage.txaMessage);

                new SelectElement(contactUsPage.ddlSubjectHeading).SelectByText(Variables.SubjectHeading);
                Assert.AreEqual(Variables.Email, contactUsPage.txtEmail.GetAttribute("value"));
                contactUsPage.txaMessage.SendKeys(Variables.Message);

                test.Log(Status.Info, "Sending a messaage using the contact us feature");

                Browser.WaitForElement(driver, contactUsPage.btnSend);
                Browser.Click(driver, contactUsPage.btnSend);
                #endregion

                #region Verify message being sent successfully
                test.Log(Status.Info, "Verifying that the message was sent successfully");

                Browser.WaitForElement(driver, contactUsPage.lblResponse);

                Assert.True(contactUsPage.lblResponse.Text.Equals(Variables.SuccessfulMessage));

                test.Log(Status.Pass, "ContactUsTest has passed successfully");
                #endregion
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }
    }
}
