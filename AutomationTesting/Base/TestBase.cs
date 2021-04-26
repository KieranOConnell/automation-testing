using AutomationTesting.Utilities;
using AventStack.ExtentReports;
using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections;

namespace AutomationTesting.Base
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected ExtentReports report = ExtentManager.GetInstance();
        protected ExtentTest test;

        public void SetUp(string browserName, string operatingSystem)
        {
            string nodeURL = "";
            dynamic capability = GetBrowserOptions(browserName);

            if (capability is EdgeOptions)
                capability.UseChromium = true;
                
            if (operatingSystem.Equals("Windows 10"))
                nodeURL = "http://192.168.56.105:1111/wd/hub"; // Windows 10
            else if (operatingSystem.Equals("Ubuntu"))
                nodeURL = "http://192.168.178.43:2222/wd/hub"; // Ubuntu
            else
                nodeURL = "http://192.168.178.45:3333/wd/hub"; // macOS Big Sur

            driver = new RemoteWebDriver(new Uri(nodeURL), capability.ToCapabilities());

            driver.Manage().Window.Maximize();
            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDown()
        {
            report.Flush();
            driver.Quit();      
        }

        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName.Equals("Firefox"))
                return new FirefoxOptions(); // Mozilla Firefox
            else if (browserName.Equals("Edge"))
                return new EdgeOptions(); // Microsoft Edge
            else if (browserName.Equals("Safari"))
                return new SafariOptions(); // Safari
            else
                return new ChromeOptions(); // Google Chrome (Default browser)
        }

        public static IEnumerable TestData()
        {
            string[] operatingSystems = Configuration.TestSettings.operatingSystems.Split(',');
            string[] browsers = new string[] { };

            foreach (string operatingSystem in operatingSystems)
            {
                switch (operatingSystem)
                {
                    case "Windows 10":
                        browsers = new string[] { "Chrome", "Firefox", "Edge" };
                        break;

                    case "Ubuntu":
                        browsers = new string[] { "Chrome", "Firefox", "Edge" };
                        break;

                    case "macOS Big Sur":
                        browsers = new string[] { "Chrome", "Firefox", "Safari" };
                        break;
                }

                foreach (string browser in browsers)
                    yield return new TestCaseData(browser, operatingSystem);
            }
        }
    }
}
