using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class AccountPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.XPath, Using = "//a[@class='account']/span")]
        public IWebElement lblUser = null;
        #endregion

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
