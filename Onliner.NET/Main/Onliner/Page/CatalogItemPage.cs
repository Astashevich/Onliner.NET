using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.NET.Main.Onliner.Page
{
    public class CatalogItemPage : BasePage
    {
        private ShoppingCartPopup shoppingCartPopup;
        private By addToShoppingCartButtonBy = By.LinkText("В корзину");
        private By greenShoppingCartButtonBy =By.LinkText("В корзине");
        private By itemNameBy = By.CssSelector(".catalog-masthead__title");

        public CatalogItemPage()
        {
            shoppingCartPopup = new ShoppingCartPopup();
            WaitForPageOpened();
        }

        protected override void WaitForPageOpened()
        {
            Waiter.WaitForDisplayed(itemNameBy);
        }

        public void AddToCart()
        {
            WaitForPageOpened();
            driver.FindElement(addToShoppingCartButtonBy).Click();
            Waiter.WaitForDisplayed(greenShoppingCartButtonBy);
            if (shoppingCartPopup.IsShoppingCartPopupVisible())
            {
                shoppingCartPopup.CloseShoppingCartPopup();
            }
        }

        public string GetItemName()
        {
            return driver.FindElement(itemNameBy).Text.Trim();
        }
    }
}
