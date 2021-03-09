using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class AccountPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.XPath, Using = "//a[@class='account']/span")]
        public IWebElement lnkUser = null;
        [FindsBy(How = How.XPath, Using = "//div[@id='contact-link']/a")]
        public IWebElement lnkContactUs = null;
        #endregion

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
