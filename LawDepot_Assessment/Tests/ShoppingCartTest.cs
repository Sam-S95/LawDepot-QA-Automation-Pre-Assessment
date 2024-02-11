using LawDepot_Assessment.BaseClass;
using LawDepot_Assessment.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Tests
{
    
    public class ShoppingCartTest : BaseTest
    {
        [Test]
        public void CheckBackAndRemoveBTNToShoppingListFromCart()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();

            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.AssertBackpackItem();
            itemListPage.AddBackpackToCart();
            itemListPage.GotoShoppingCart();
            Thread.Sleep(5000);

            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(driver);
            Assert.That(shoppingCartPage.ContShoppingBTN.Displayed);
            shoppingCartPage.RemoveBTN.Click();

            shoppingCartPage.ContShoppingBTN.Click();
            Thread.Sleep(5000);

        }


    }
}
