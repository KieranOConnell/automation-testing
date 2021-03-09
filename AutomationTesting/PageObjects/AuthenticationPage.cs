using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class AuthenticationPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement txtEmail = null;
        [FindsBy(How = How.Id, Using = "email_create")]
        public IWebElement txtEmailCreate = null;
        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement txtPassword = null;
        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement btnLogin = null;
        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        public IWebElement btnCreate = null;
        #endregion

        public AuthenticationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
