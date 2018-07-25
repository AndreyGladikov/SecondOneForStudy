﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Patterns.Pages
{
    class LoginPage
    {
        public const string MailLogURL = "https://www.tut.by/?trnd=47188";
        public const string MailURL = "https://www.tut.by/";
        public const string MailLog = "AutoTest92";
        public const string MailPWD = "Inq2020327";

        private IWebDriver driver;
        
        [FindsBy(How = How.XPath, Using = "//a[@data-target-popup='authorize-form']")]
        private IWebElement LoginPopUp { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='i-holder']//input[@type='text']")]
        private IWebElement LoginField { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement PasswordField { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@value='Войти']")]
        private IWebElement LoginButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(MailURL);
            LoginPopUp.Click();
            LoginField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public bool Check()
        {
            return LoginPopUp.Displayed;
        }
    }
}

