using AventStack.ExtentReports;
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
            //ExtentReports variable to store test results
            test = extent.CreateTest("CheckBackAndRemoveBTNToShoppingListFromCart", "Verify Back and Remove button functionality");

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
            shoppingCartPage.BackToShoppingBTNVisible();
            shoppingCartPage.ClickRemoveBTN();
            Thread.Sleep(3000);
            shoppingCartPage.ClickBackToShopping();
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Remove item from cart button is working.");
            test.Log(Status.Pass, "BackToShoppingCart button is working.");

        }


    }
}
