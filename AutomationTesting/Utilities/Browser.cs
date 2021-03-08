using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTesting.Utilities
{
    public class Browser
    {
        public static void WaitForElement(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void RemoveAttribute(IWebDriver driver, IWebElement element, string attribute)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].removeAttribute(arguments[1])", element, attribute);
        }
    }
}
