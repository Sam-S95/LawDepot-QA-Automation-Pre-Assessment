using AventStack.ExtentReports;
using LawDepot_Assessment.BaseClass;
using LawDepot_Assessment.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Tests
{
    public class CheckoutInfoTest : BaseTest
    {
        [Test, Order(1)]
        public void FillingCheckoutInfo()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("FillingCheckoutInfo", "Verify filling checkout Info functionality");

            //Creating Object of PageObject class to access WebElements 
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InitializePageElements();
            test.Log(Status.Info, "Initialized LoginPage elements.");
            loginPage.Login();

            //Creating Object of PageObject class to access WebElements 
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.InitializePageElements();
            test.Log(Status.Info, "Initialized ItemListPage elements.");
            itemListPage.AssertBackpackItem();
            itemListPage.AddBackpackToCart();
            itemListPage.GotoShoppingCart();
            Thread.Sleep(3000);

            //Creating Object of PageObject class to access WebElements 
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(driver);
            shoppingCartPage.InitializePageElements();
            test.Log(Status.Info, "Initialized ShoppingCartPage elements.");
            shoppingCartPage.ClickCheckoutBTN();

            //Creating Object of PageObject class to access WebElements 
            CheckoutInfoPage checkoutInfoPage = new CheckoutInfoPage(driver);
            checkoutInfoPage.InitializePageElements();
            test.Log(Status.Info, "Initialized CheckoutPage elements.");
            checkoutInfoPage.EnterFirstName("Sam");
            checkoutInfoPage.EnterLastName("Sheikh");
            checkoutInfoPage.EnterPostalCode("M2J 1A4");
            Thread.Sleep(3000);
            checkoutInfoPage.ClickContinueBTN();
            test.Log(Status.Pass, "Checkout Info filled successfully.");

        }

        [Test, Order(2)]
        public void AserrtOverviewInfo()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("AserrtOverviewInfo", "Verify overview Info functionality");

            //JavaScript executer to rolldown the page
            test.Log(Status.Info, "page scroll down");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,200)", "");
            Thread.Sleep(3000);

            //Creating Object of PageObject class to access WebElements 
            OverviewPage overviewPage = new OverviewPage(driver);
            overviewPage.InitializePageElements();
            test.Log(Status.Info, "Initialized OverviewPage elements.");
            overviewPage.ClickFinishBTN();
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Overview details visible.");

        }

        [Test, Order(3)]
        public void AserrtThankyouMessage()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("AserrtThankyouMessage", "Verify Thankyou message functionality");

            //Creating Object of PageObject class to access WebElements 
            ThankyouPage thankyouPage = new ThankyouPage(driver);
            thankyouPage.InitializePageElements();
            test.Log(Status.Info, "Initialized ThankyouPage elements.");
            thankyouPage.ClickBackToHomeBTN();
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Thankyou message visible after order.");

        }

        [Test, Order(4)]
        public void AssertIfCartIsEmptyAfterOrder()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("AssertIfCartIsEmptyAfterOrder", "Verify if cart is empty after order");

            //Creating Object of PageObject class to access WebElements 
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.InitializePageElements();
            test.Log(Status.Info, "Initialized ItemListPage elements.");
            itemListPage.GotoShoppingCart();
            Thread.Sleep(2000);

            // Assert that the shopping cart is empty (hard coded)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            bool cartEmpty = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("remove-sauce-labs-backpack")));

            Assert.That(cartEmpty, Is.True);
            test.Log(Status.Pass, "Cart is Empty after order completion.");


        }
    }
}
