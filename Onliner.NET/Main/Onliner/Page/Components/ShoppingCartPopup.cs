using Onliner.NET.Main.Onliner.Core.Utils;
using OpenQA.Selenium;
using System;

namespace Onliner.NET.Main.Onliner.Page.Components
{
    public class ShoppingCartPopup : BaseComponent
    {
        private static readonly By ShoppingCartPopupCloseButtonBy = By.ClassName("product-recommended__sidebar-close");
        protected override void WaitForComponentOpened()
        {
            Waiter.ElementToBeClickable(ShoppingCartPopupCloseButtonBy);
        }

        public bool IsShoppingCartPopupVisible()
        {
            try
            {
                Waiter.WaitForDisplayed(ShoppingCartPopupCloseButtonBy, 1);
                return driver.FindElement(ShoppingCartPopupCloseButtonBy).Displayed;
            }
            catch (NoSuchElementException) 
            {
                return false;
            }
            catch (WebDriverTimeoutException) 
            {
                return false;
            }
        }
 
        public void CloseShoppingCartPopup()
            {
                driver.FindElement(ShoppingCartPopupCloseButtonBy).Click();
            }
        }
}
