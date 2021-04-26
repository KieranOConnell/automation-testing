using AutomationTesting.Base;
using AutomationTesting.PageObjects;
using AutomationTesting.Settings;
using AutomationTesting.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTesting.TestCases
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [Parallelizable(ParallelScope.Children)]
    public class OrderProductTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "TestData")]
        [Category("Order Product")]
        [Description("Verifies the functionality of ordering a product from the store")]
        public void OrderProduct(string browserName, string operatingSystem)
        {
            try
            {
                #region Setting up browser and OS for testing
                test = report.CreateTest(String.Format("OrderProductTest - {0}, {1}", browserName, operatingSystem));
                test.Log(Status.Info, "Starting the OrderProductTest");

                SetUp(browserName, operatingSystem);
                #endregion

                #region Navigate to the store homepage
                test.Log(Status.Info, "Navigating to the store homepage");

                driver.Navigate().GoToUrl(Variables.Website);
                Assert.True(driver.Title.Contains("My Store"));

                var homePage = new HomePage(driver);
                #endregion

                #region Click the login button to progress to authentication
                test.Log(Status.Info, "Attempting to log in to the store");

                Browser.WaitForElement(driver, homePage.btnLogin);
                Browser.Click(driver, homePage.btnLogin);

                var authenticationPage = new AuthenticationPage(driver);
                #endregion

                #region Enter login information & click sign in button
                test.Log(Status.Info, "Entering login information & signing in");

                Browser.WaitForElement(driver, authenticationPage.txtEmail);
                Browser.WaitForElement(driver, authenticationPage.txtPassword);

                authenticationPage.txtEmail.SendKeys(Variables.Email);
                authenticationPage.txtPassword.SendKeys(Variables.Password);

                Browser.WaitForElement(driver, authenticationPage.btnLogin);
                Browser.Click(driver, authenticationPage.btnLogin);

                var accountPage = new AccountPage(driver);
                #endregion

                #region Verify successful login of test user and go back to the home page
                test.Log(Status.Info, "Verifying successful login of test user");

                Browser.WaitForElement(driver, accountPage.lnkUser);

                Assert.True(accountPage.lnkUser.Text.Equals(Variables.User));

                test.Log(Status.Info, "Returning to the home page");

                Browser.WaitForElement(driver, accountPage.imgLogo);
                Browser.Click(driver, accountPage.imgLogo);

                homePage = new HomePage(driver);
                #endregion

                #region Add a product to the cart and proceed to checkout
                test.Log(Status.Info, "Adding product to the cart");

                Browser.WaitForElement(driver, homePage.imgProduct);
                Browser.Click(driver, homePage.imgProduct);

                var productPage = new ProductPage(driver);

                Browser.WaitForElement(driver, productPage.txtQuantity);
                Assert.AreEqual(Variables.Quantity, productPage.txtQuantity.GetAttribute("value"));
                new SelectElement(productPage.ddlSize).SelectByText(Variables.Size);

                Browser.WaitForElement(driver, productPage.btnAddToCart);
                Browser.Click(driver, productPage.btnAddToCart);

                Browser.WaitForElement(driver, productPage.lblResponse);
                Assert.AreEqual(Variables.SuccessfulCart, productPage.lblResponse.Text.Trim());

                test.Log(Status.Info, "Attempting to checkout and purchase product");

                Browser.WaitForElement(driver, productPage.btnProceedToCheckout);
                Browser.Click(driver, productPage.btnProceedToCheckout);

                var checkoutPage = new CheckoutPage(driver);
                #endregion

                #region Verify correct item has been added to cart and checkout
                test.Log(Status.Info, "Verify correct product is in the cart");

                Browser.WaitForElement(driver, checkoutPage.lblProduct);
                Assert.AreEqual(Variables.Product, checkoutPage.lblProduct.Text);

                Browser.WaitForElement(driver, checkoutPage.btnSummaryCheckout);
                Browser.Click(driver, checkoutPage.btnSummaryCheckout);

                Browser.WaitForElement(driver, checkoutPage.btnAddressCheckout);
                Browser.Click(driver, checkoutPage.btnAddressCheckout);

                Browser.WaitForElement(driver, checkoutPage.chkTermsOfService);
                Browser.WaitForElement(driver, checkoutPage.btnAddressCheckout);
                Browser.Click(driver, checkoutPage.chkTermsOfService);
                Browser.Click(driver, checkoutPage.btnAddressCheckout);

                Browser.WaitForElement(driver, checkoutPage.lnkPayByCheck);
                Browser.Click(driver, checkoutPage.lnkPayByCheck);

                Browser.WaitForElement(driver, checkoutPage.btnConfirmOrder);
                Browser.Click(driver, checkoutPage.btnConfirmOrder);

                Browser.WaitForElement(driver, checkoutPage.lblResponse);
                Assert.AreEqual(Variables.SuccessfulOrder, checkoutPage.lblResponse.Text);

                test.Log(Status.Info, "Verify product has been purchased successfully");

                test.Log(Status.Pass, "OrderProductTest has passed successfully");
                #endregion
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.Message);
            }
        }
    }
}
