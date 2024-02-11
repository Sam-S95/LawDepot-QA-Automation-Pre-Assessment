using LawDepot_Assessment.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.PageObjects
{
    public class ShoppingCartPage
    {
        private IWebDriver driver;

        public IWebElement ShoppingCart { get; private set; }
        public IWebElement RemoveBTN { get; private set; }
        public IWebElement CheckoutBTN { get; private set; }
        public IWebElement ContShoppingBTN { get; private set; }

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
            InitializePageElements();
        }

        private void InitializePageElements()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            ShoppingCart = wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@class='shopping_cart_link']")));
            RemoveBTN = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#remove-sauce-labs-backpack")));
            CheckoutBTN = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("checkout")));
            ContShoppingBTN = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#continue-shopping")));
        }
    }

}
