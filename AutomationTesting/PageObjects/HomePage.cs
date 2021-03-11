using AutomationTesting.Base;
using AutomationTesting.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class HomePage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Sign in')]")]
        public IWebElement btnLogin = null;
        [FindsBy(How = How.XPath, Using = "//ul[@id='homefeatured']//div/a[@title='" + Variables.Product + "']")]
        public IWebElement imgProduct = null;
        #endregion

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
