﻿using AventStack.ExtentReports;
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
            //ExtentReports variable to store test results
            test = extent.CreateTest("AssertTitleAndLoginTest", "Verify login functionality");

            //Creating Object of PageObject class to access WebElements 
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InitializePageElements();
            test.Log(Status.Info, "Initialized page elements.");

            //Page title assertion
            Assert.That(loginPage.Title, Is.EqualTo("Swag Labs"));
            test.Log(Status.Pass, "Page title assertion");

            //passing username and password as a arguments
            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");
            test.Log(Status.Info, "Entered username and password.");

            //loginPage.EnterUsername(config.Username);
            //loginPage.EnterPassword(config.Password);
            Thread.Sleep(3000);
            loginPage.ClickLoginButton();
            test.Log(Status.Pass, "Logged In successfully");
            Thread.Sleep(3000);

        }

    }
}
