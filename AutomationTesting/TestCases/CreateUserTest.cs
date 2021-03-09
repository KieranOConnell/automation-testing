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
    public class CreateUserTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "TestData")]
        [Category("Login")]
        [Description("Creates a new user and logs in to the store")]
        public void CreateUser(string browserName, string operatingSystem)
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

            #region Enter random email address and proceeed to account creation page
            var email = Browser.GenerateRandomString(8) + "@gmail.com";
            var password = Browser.GenerateRandomString(10);

            Browser.WaitForElement(driver, authenticationPage.txtEmailCreate);   
            authenticationPage.txtEmailCreate.SendKeys(email);

            Browser.WaitForElement(driver, authenticationPage.btnCreate);
            Browser.Click(driver, authenticationPage.btnCreate);

            var createAccountPage = new CreateAccountPage(driver);
            #endregion

            #region Enter details for new user account and register
            // Personal Information
            Browser.WaitForElement(driver, createAccountPage.rbnGender);

            createAccountPage.rbnGender.Click();      
            createAccountPage.txtFirstName.SendKeys(Variables.FirstName);
            createAccountPage.txtLastName.SendKeys(Variables.LastName);
            createAccountPage.txtPassword.SendKeys(password);

            new SelectElement(createAccountPage.ddlDays).SelectByValue(Variables.BirthDay);
            new SelectElement(createAccountPage.ddlMonths).SelectByValue(Variables.BirthMonth);
            new SelectElement(createAccountPage.ddlYears).SelectByValue(Variables.BirthYear);

            // Address Information    
            createAccountPage.txtAddress.SendKeys(Variables.Address);
            createAccountPage.txtCity.SendKeys(Variables.City);
            createAccountPage.txtZip.SendKeys(Variables.Zip);
            createAccountPage.txtPhoneNumber.SendKeys(Variables.PhoneNumber);

            new SelectElement(createAccountPage.ddlState).SelectByText(Variables.State);
            new SelectElement(createAccountPage.ddlCountry).SelectByText(Variables.Country);

            Browser.WaitForElement(driver, createAccountPage.btnRegister);
            createAccountPage.btnRegister.Click();

            var accountPage = new AccountPage(driver);
            #endregion

            #region Verify successful login of newly created user
            Browser.WaitForElement(driver, accountPage.lblUser);

            Assert.True(accountPage.lblUser.Text.Equals(Variables.FirstName + " " + Variables.LastName));
            #endregion
        }
    }
}
