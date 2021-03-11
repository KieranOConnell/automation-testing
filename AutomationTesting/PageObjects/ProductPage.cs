using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class ProductPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.Id, Using = "quantity_wanted")]
        public IWebElement txtQuantity = null;
        [FindsBy(How = How.Id, Using = "group_1")]
        public IWebElement ddlSize = null;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Add to cart')]")]
        public IWebElement btnAddToCart = null;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'cart_product')]/h2")]
        public IWebElement lblResponse = null;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Proceed to checkout')]")]
        public IWebElement btnProceedToCheckout = null;
        #endregion

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
