using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class HomePage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Sign in')]")]
        public IWebElement btnLogin = null;
        #endregion

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
