using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.PageObjects
{
    public class ItemListPage
    {
        //declaring webdriver and webelements 
        private IWebDriver driver;
        private WebDriverWait wait;
        public IWebElement InventoryList { get; private set; }
        public IWebElement Backpack { get; private set; }
        public IWebElement BackpackAddBTN { get; private set; }
        public IWebElement ShoppingCartBTN { get; private set; }

        public ItemListPage(IWebDriver driver)
        {
            //initializing WebDriverWait and passing driver object into constructor
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void InitializePageElements()
        {
            // Initialize page elements
            InventoryList = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".inventory_list")));
            Backpack = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[normalize-space()='Sauce Labs Backpack']")));
            BackpackAddBTN = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']")));
            ShoppingCartBTN = wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@class='shopping_cart_link']")));
        }


        public void AssertItemList()
        {
            Assert.That(InventoryList.Displayed);
        }

        public void AssertBackpackItem()
        {
            Assert.That(Backpack.Displayed);
        }

        public void AddBackpackToCart()
        {
            Assert.That(BackpackAddBTN.Displayed);
            BackpackAddBTN.Click();
        }

        public void GotoShoppingCart()
        {
            Assert.That(ShoppingCartBTN.Displayed);
            ShoppingCartBTN.Click();
        }
    }
}
