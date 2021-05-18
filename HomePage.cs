using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SwagLabsTests
{
    [TestFixture]

    public class HomePage
    {

        private IWebDriver driver;


        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
        {
            driver.Url = "https://www.saucedemo.com/";
            System.Threading.Thread.Sleep(2000);
            LogInPage loginPage = new LogInPage(driver);
            loginPage.loginValidUser("standard_user", "secret_sauce");

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);
            Assert.That("PRODUCTS", Is.EqualTo(loginPage.displayName()));
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}



