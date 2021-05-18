﻿using NUnit.Framework;
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
            driver.Url = "https://www.saucedemo.com/";
            System.Threading.Thread.Sleep(2000);
            LogInPage loginPage = new LogInPage(driver);
            loginPage.loginValidUser("standard_user", "secret_sauce");
        }

        [Test]
        public void TestLogin()
        {
            LogInPage loginPage = new LogInPage(driver);
            System.Threading.Thread.Sleep(2000);
            Assert.That("PRODUCTS", Is.EqualTo(loginPage.displayName()));
        }

        [Test]
        public void TestAddToCart()
        {
 
            LogInPage loginPage = new LogInPage(driver);
            AddToCart addToCartGood = new AddToCart(driver);
            addToCartGood.addToCart();

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);
            Assert.That("1", Is.EqualTo(addToCartGood.shoppingCartBadgeDisplay()));

        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}



