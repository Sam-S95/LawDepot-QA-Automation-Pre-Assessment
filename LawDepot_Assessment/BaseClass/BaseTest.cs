using AventStack.ExtentReports;
using LawDepot_Assessment.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;

namespace LawDepot_Assessment.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void Setup()
        {
         

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"..\..\..\ExtentReports\extent-report.html"; 
            string fullPath = Path.GetFullPath(Path.Combine(basePath, relativePath));

            extent = new ExtentReports();
            var htmlReporter = new ExtentSparkReporter(fullPath);
            extent.AttachReporter(htmlReporter);


            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            extent.Flush();

        }
    }
}
