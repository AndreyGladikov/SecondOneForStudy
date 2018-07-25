using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Patterns.Pages;
using OpenQA.Selenium.Support.PageObjects;
using System.Drawing.Imaging;

namespace Patterns
{
    [TestClass]
    public class PatternsTests
    {
        private static IWebDriver driver;

        [TestInitialize]
        public void initialize()
        {
            driver = new ChromeDriver(@"..\..\..\Patterns\Drivers\"); 
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("AutoTest92", "Inq2020327");
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.getText().Contains(HomePage.UName), "You did not loged in ");
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void MailLogOut()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("AutoTest92", "Inq2020327");
            HomePage homePage = new HomePage(driver);
            homePage.LogOut();
            Assert.IsTrue(loginPage.Check());
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
