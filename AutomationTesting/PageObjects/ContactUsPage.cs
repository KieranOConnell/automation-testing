using AutomationTesting.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.PageObjects
{
    public class ContactUsPage : TestBase
    {
        #region Page Elements
        [FindsBy(How = How.Id, Using = "id_contact")]
        public IWebElement ddlSubjectHeading = null;
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement txtEmail = null;
        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement txaMessage = null;
        [FindsBy(How = How.Id, Using = "submitMessage")]
        public IWebElement btnSend = null;
        [FindsBy(How = How.ClassName, Using = "alert")]
        public IWebElement lblResponse = null;
        #endregion

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
