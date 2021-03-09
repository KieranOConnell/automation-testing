using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class CreateAccountPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.Id, Using = "id_gender1")]
        public IWebElement rbnGender = null;
        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement txtFirstName = null;
        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement txtLastName = null;
        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement txtPassword = null;
        [FindsBy(How = How.Id, Using = "days")]
        public IWebElement ddlDays = null;
        [FindsBy(How = How.Id, Using = "months")]
        public IWebElement ddlMonths = null;
        [FindsBy(How = How.Id, Using = "years")]
        public IWebElement ddlYears = null;
        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement txtAddress = null;
        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement txtCity = null;
        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement ddlState = null;
        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement txtZip = null;
        [FindsBy(How = How.Id, Using = "id_country")]
        public IWebElement ddlCountry = null;
        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement txtPhoneNumber = null;
        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement btnRegister = null;
        #endregion

        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
