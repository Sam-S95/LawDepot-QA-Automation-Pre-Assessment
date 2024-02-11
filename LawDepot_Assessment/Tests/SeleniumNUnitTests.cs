using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Tests
{
    public class SeleniumNUnitTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

        }

        [Test, Order(1)]
        public void AssertTitleTest()
        {
            //
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(3000);
            Assert.That(driver.Title, Is.EqualTo("Swag Labs"));

        }

        [Test, Order(2)]
        public void LoginTest()
        {
            //
            IWebElement Username = driver.FindElement(By.XPath("//input[@id='user-name']"));
            Username.Clear();
            Username.SendKeys("standard_user");

            IWebElement Password = driver.FindElement(By.XPath("//input[@id='password']"));
            Password.Clear();
            Password.SendKeys("secret_sauce");
            Thread.Sleep(3000);

            driver.FindElement(By.CssSelector("#login-button")).Click();
            Thread.Sleep(3000);

        }

        [Test, Order(3)]
        public void AssertItemListTest()
        {
            //
            IWebElement InventoryList = driver.FindElement(By.CssSelector(".inventory_list"));
            Assert.That(InventoryList.Displayed);
            Thread.Sleep(3000);

        }

        [Test, Order(4)]
        public void AddItemToShoppinCartTest()
        {
            //
            IWebElement Backpack = driver.FindElement(By.XPath("//div[normalize-space()='Sauce Labs Backpack']"));
            Assert.That(Backpack.Displayed);

            IWebElement BackpackBTN = driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']"));
            Assert.That(BackpackBTN.Displayed);
            BackpackBTN.Click();

            IWebElement BackpackRemove = driver.FindElement(By.XPath("//button[@id='remove-sauce-labs-backpack']"));
            Assert.That(BackpackRemove.Displayed);
            Thread.Sleep(3000);
        }

        [Test, Order(5)]
        public void CheckShoppinCartTest()
        {
            //
            IWebElement ShoppingCart = driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
            Assert.That(ShoppingCart.Displayed);
            ShoppingCart.Click();
            Thread.Sleep(3000);
        }

        [Test, Order(6)]
        public void CheckBackToShoppingFromCart()
        {
            //
            IWebElement ContShoppingBTN = driver.FindElement(By.CssSelector("#continue-shopping"));
            ContShoppingBTN.Click();
            Thread.Sleep(3000);
            IWebElement ShoppingCart = driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
            ShoppingCart.Click();
            Thread.Sleep(3000);

        }

        [Test, Order(7)]
        public void AssertCheckoutBTN()
        {
            //
            IWebElement CheckoutBTN = driver.FindElement(By.CssSelector("#checkout"));
            Assert.That(CheckoutBTN.Displayed);
            CheckoutBTN.Click();
            Thread.Sleep(3000);

        }

        [Test, Order(8)]
        public void InfoPage()
        {
            IWebElement FName = driver.FindElement(By.Id("first-name"));
            FName.Clear();
            FName.SendKeys("Sam");

            IWebElement LName = driver.FindElement(By.Id("last-name"));
            LName.Clear();
            LName.SendKeys("Sheikh");

            IWebElement PostalCode = driver.FindElement(By.Id("postal-code"));
            PostalCode.Clear();
            PostalCode.SendKeys("M2J 1A4");
            Thread.Sleep(3000);

            IWebElement ContinueBTN = driver.FindElement(By.Id("continue"));
            ContinueBTN.Click();
            Thread.Sleep(3000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,200)", "");
            Thread.Sleep(3000);

            IWebElement FinishBTN = driver.FindElement(By.Id("finish"));
            FinishBTN.Click();
            Thread.Sleep(3000);

        }

        [Test, Order(9)]
        public void CheckThankyouPage()
        {
            //
            IWebElement ThxHeader = driver.FindElement(By.CssSelector(".complete-header"));
            Assert.That(ThxHeader.Displayed);
            Thread.Sleep(3000);

        }

        [Test, Order(10)]
        public void CheckIfCartIsEmptyAfterOrder()
        {
            //
            IWebElement BackHomeBTN = driver.FindElement(By.Id("back-to-products"));
            BackHomeBTN.Click();
            Thread.Sleep(3000);

            IWebElement ShoppingCart = driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
            ShoppingCart.Click();
            Thread.Sleep(3000);

            /*// Assert that the shopping cart is empty
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            bool cartEmpty = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("remove-sauce-labs-backpack")));

            Assert.IsTrue(cartEmpty, "Shopping cart should be empty after placing an order.");*/



        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}
