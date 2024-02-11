using LawDepot_Assessment.BaseClass;
using LawDepot_Assessment.Data;
using LawDepot_Assessment.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private ConfigReader config;

        [Test]
        public void AssertTitleAndLoginTest()
        {
            //
            //Assert.That(driver.Title, Is.EqualTo("Swag Labs"));           
            LoginPage loginPage = new LoginPage(driver);
            Assert.That(loginPage.Title, Is.EqualTo("Swag Labs"));
/*            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");*/
            loginPage.EnterUsername(config.Username);
            loginPage.EnterPassword(config.Password);
            Thread.Sleep(3000);
            loginPage.ClickLoginButton();
            Thread.Sleep(3000);

        }
    }
}
