using LawDepot_Assessment.BaseClass;
using LawDepot_Assessment.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace LawDepot_Assessment.Tests
{
    [TestFixture]
    public class ItemListTest : BaseTest
    {

        [Test, Order(1)]
        public void AssertItemListVisibleTest()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("AssertItemListVisibleTest", "Verify if the shopping list is visible");

            //Creating Object of PageObject class to access WebElements 
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InitializePageElements();
            test.Log(Status.Info, "Initialized LoginPage elements.");

            loginPage.Login();
            //Creating Object of PageObject class to access WebElements 
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.InitializePageElements();
            test.Log(Status.Info, "Initialized ItemListPage elements.");
            itemListPage.AssertItemList();
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Item List is visible on the shopping page.");


        }

        [Test, Order(2)]
        public void AddBackpackTest()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("AddBackpackTest", "Verify AddItem button funtionality");

            //Creating Object of PageObject class to access WebElements 
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.InitializePageElements();
            test.Log(Status.Info, "Initialized ItemListPage elements.");
            itemListPage.AssertBackpackItem();
            itemListPage.AddBackpackToCart();
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Backpack added Successfully to the shopping cart.");

        }
    }
}
