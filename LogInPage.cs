using OpenQA.Selenium;
using System;


namespace SwagLabsTests
{
    class LogInPage
    {
        protected IWebDriver driver;
        By usernameLocator = By.CssSelector("#user-name");
        By passwordLocator = By.CssSelector("#password");
        By loginButtonLocator = By.CssSelector("#login-button");
        By displayNameLocator => By.XPath("//span[text()='Products']");

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LogInPage typeUsername(String username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public LogInPage typePassword(String password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public HomePage submitLogin()
        {
            driver.FindElement(loginButtonLocator).Submit();
            return new HomePage();
        }

        public string displayName()
        {
            var productTitle=driver.FindElement(displayNameLocator).Text;
            return productTitle;
        }

        public HomePage loginAs(String username, String password)
        {
            typeUsername(username);
            typePassword(password);
            return submitLogin();
        }

        public HomePage loginValidUser(String userName, String password)
        {
            driver.FindElement(usernameLocator).SendKeys(userName);
            driver.FindElement(passwordLocator).SendKeys(password);
            driver.FindElement(loginButtonLocator).Click();
            return new HomePage();
        }
    }
}
