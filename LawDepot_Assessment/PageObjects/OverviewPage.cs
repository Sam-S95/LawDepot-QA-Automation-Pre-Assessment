using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LawDepot_Assessment.PageObjects
{
    public class OverviewPage
    {
        //declaring webdriver and webelements 
        private IWebDriver driver;
        private WebDriverWait wait;
        
        public IWebElement FinishBTN { get; private set; }

        public OverviewPage(IWebDriver driver)
        {
            //initializing WebDriverWait and passing driver object into constructor
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void InitializePageElements()
        {
            // Initialize page elements
            FinishBTN = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#finish")));

        }

        
        public void ClickFinishBTN()
        {
            Assert.That(FinishBTN.Displayed);
            FinishBTN.Click();
        }
    }
}
