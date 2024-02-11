using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.PageObjects
{
    public class ItemListPage
    {
        public IWebDriver driver;
        public IWebElement InventoryList { get; private set; }
        public IWebElement Backpack { get; private set; }
        public IWebElement BackpackAddBTN { get; private set; }
        //public IWebElement BackpackRemoveBTN { get; private set; }
        public IWebElement ShoppingCartBTN { get; private set; }

        public ItemListPage(IWebDriver driver)
        {
            this.driver = driver;
            // Initialize page elements
            InventoryList = driver.FindElement(By.CssSelector(".inventory_list"));
            Backpack = driver.FindElement(By.XPath("//div[normalize-space()='Sauce Labs Backpack']"));
            BackpackAddBTN = driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']"));
            ShoppingCartBTN = driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
            //BackpackRemoveBTN = driver.FindElement(By.XPath("//button[@id='remove-sauce-labs-backpack']"));


        }

        /*        public void DynamicRemoveButton()
                {
                    // Wait for the remove button to appear
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    BackpackRemoveBTN = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='remove-sauce-labs-backpack']")));

                }*/


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

        /*        public void RemoveBackpackFromCart()
                {
                    Assert.That(BackpackRemoveBTN.Displayed);
                    BackpackRemoveBTN.Click();
                }*/

        public void GotoShoppingCart()
        {
            /*            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        wait.Until(ExpectedConditions.ElementToBeClickable(ShoppingCartBTN));*/
            Assert.That(ShoppingCartBTN.Displayed);
            ShoppingCartBTN.Click();
        }
    }
}
