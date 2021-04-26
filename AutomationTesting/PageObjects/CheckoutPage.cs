using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class CheckoutPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.XPath, Using = "//td/p[@class='product-name']/a")]
        public IWebElement lblProduct = null;
        [FindsBy(How = How.XPath, Using = "//p/a/span[contains(text(), 'Proceed to checkout')]")]
        public IWebElement btnSummaryCheckout = null;
        [FindsBy(How = How.XPath, Using = "//button/span[contains(text(), 'Proceed to checkout')]")]
        public IWebElement btnAddressCheckout = null;
        [FindsBy(How = How.XPath, Using = "//label[@for='cgv']")]
        public IWebElement chkTermsOfService = null;
        [FindsBy(How = How.XPath, Using = "//a[@title='Pay by check.']")]
        public IWebElement lnkPayByCheck = null;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'I confirm my order')]")]
        public IWebElement btnConfirmOrder = null;
        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'alert')]")]
        public IWebElement lblResponse = null;
        #endregion

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
