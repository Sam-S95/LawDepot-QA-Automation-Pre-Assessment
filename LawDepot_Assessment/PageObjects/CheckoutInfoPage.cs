using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace LawDepot_Assessment.PageObjects
{
    public class CheckoutInfoPage
    {
        //declaring webdriver and webelements 
        private IWebDriver driver;
        private WebDriverWait wait;
        public IWebElement FName { get; private set; }
        public IWebElement LName { get; private set; }
        public IWebElement PostalCode { get; private set; }
        public IWebElement ContinueBTN { get; private set; }

        public CheckoutInfoPage(IWebDriver driver)
        {
            //initializing WebDriverWait and passing driver object into constructor
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void InitializePageElements()
        {
            // Initialize page elements
            FName = wait.Until(ExpectedConditions.ElementExists(By.Id("first-name")));
            LName = wait.Until(ExpectedConditions.ElementExists(By.Id("last-name")));
            PostalCode = wait.Until(ExpectedConditions.ElementExists(By.Id("postal-code")));
            ContinueBTN = wait.Until(ExpectedConditions.ElementExists(By.Id("continue")));

        }

        public void EnterFirstName(string value)
        {
            FName.Clear();
            FName.SendKeys(value);
        }
        public void EnterLastName(string value)
        {
            LName.Clear();
            LName.SendKeys(value);
        }
        public void EnterPostalCode(string value)
        {
            PostalCode.Clear();
            PostalCode.SendKeys(value);
        }

        public void ClickContinueBTN()
        {
            ContinueBTN.Click();

        }


    }
}
