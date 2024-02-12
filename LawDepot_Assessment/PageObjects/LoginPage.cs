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
    public class LoginPage
    {
        //declaring webdriver and webelements 
        private IWebDriver driver;
        private WebDriverWait wait;

        public IWebElement Username { get; private set; }
        public IWebElement Password { get; private set; }
        public IWebElement LoginBTN { get; private set; }
        public IWebElement ErrorMsg { get; private set; }
        public string Title { get; private set; }

        public LoginPage(IWebDriver driver)
        {
            //initializing WebDriverWait and passing driver object into constructor
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void InitializePageElements()
        {
            // Initialize page elements
            Username = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='user-name']")));
            Password = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='password']")));
            LoginBTN = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#login-button")));
            //ErrorMsg = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".error-button")));
            Title = driver.Title;
        }
        public void EnterUsername(string username)
        {
            Username.Clear();
            Username.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            Password.Clear();
            Password.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginBTN.Click();
        }

        public void Login()
        {
            EnterUsername("standard_user");
            EnterPassword("secret_sauce");
            ClickLoginButton();
        }

        public bool IsErrorMessageDisplayed()
        {
            if(ErrorMsg.Displayed == true) 
                return true;
            else return false;
            
        }
    }
}
