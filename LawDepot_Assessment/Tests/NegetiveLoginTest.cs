using AventStack.ExtentReports;
using LawDepot_Assessment.BaseClass;
using LawDepot_Assessment.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Tests
{
    public class NegetiveLoginTest : BaseTest
    {
        [Test]
        public void AssertTitleAndLoginWithWrongPasswordTest()
        {
            //ExtentReports variable to store test results
            test = extent.CreateTest("AssertTitleAndLoginWithWrongPasswordTest", "Verify Negetive login functionality");

            //Creating Object of PageObject class to access WebElements       
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InitializePageElements();
            test.Log(Status.Info, "Initialized LoginPage elements.");
            Assert.That(loginPage.Title, Is.EqualTo("Swag Labs"));
            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("Wrong_Password");
            //loginPage.EnterUsername(config.Username);
            //loginPage.EnterPassword(config.Password);
            Thread.Sleep(3000);
            loginPage.ClickLoginButton();
            Thread.Sleep(3000);
            // Assert that an error message is displayed
            Assert.That(loginPage.IsErrorMessageDisplayed(), Is.True);
            test.Log(Status.Pass, "Login failed using wrong password.");


        }
    }
}
