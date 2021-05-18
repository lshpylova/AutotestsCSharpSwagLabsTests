using OpenQA.Selenium;
using System;

namespace SwagLabsTests
{
    class AddToCart
    {

       private IWebDriver driver;
        By addToCartLocator = By.Id("add-to-cart-sauce-labs-backpack");
        By shoppingCartBadgeLocator = By.ClassName("shopping_cart_badge");

        public AddToCart(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void addToCart()
        {
            driver.FindElement(addToCartLocator).Click();
        }

        public string shoppingCartBadgeDisplay()
        {
            var displayQuantity = driver.FindElement(shoppingCartBadgeLocator).Text;
            return displayQuantity;
        }
    }
}
