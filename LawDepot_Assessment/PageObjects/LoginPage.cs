using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;
        public IWebElement Username { get; private set; }
        public IWebElement Password { get; private set; }
        public IWebElement LoginBTN { get; private set; }
        public string Title { get; private set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            // Initialize page elements
            Username = driver.FindElement(By.XPath("//input[@id='user-name']"));
            Password = driver.FindElement(By.XPath("//input[@id='password']"));
            LoginBTN = driver.FindElement(By.CssSelector("#login-button"));
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
            Thread.Sleep(3000);
            ClickLoginButton();
        }
    }
}
