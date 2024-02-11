using LawDepot_Assessment.BaseClass;
using LawDepot_Assessment.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Tests
{
    [TestFixture]
    public class ItemListTest : BaseTest
    {

        [Test, Order(1)]
        public void AssertItemListVisibleTest()
        {
          
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.AssertItemList();
            Thread.Sleep(3000);

        }

        [Test, Order(2)]
        public void AddAndRemoveBackpackTest()
        {
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.AssertBackpackItem();
            itemListPage.AddBackpackToCart();
            Thread.Sleep(3000);
/*            itemListPage.RemoveBackpackFromCart();
            Thread.Sleep(3000);*/

        }

/*        [Test, Order(3)]
        public void AssertShoppingCart()
        {
            ItemListPage itemListPage = new ItemListPage(driver);
            itemListPage.GotoShoppingCart();
            Thread.Sleep(3000);

        }*/
    }
}
