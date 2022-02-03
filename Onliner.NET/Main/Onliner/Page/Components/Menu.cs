using Onliner.NET.Main.Onliner.Core.Utils;
using OpenQA.Selenium;

namespace Onliner.NET.Main.Onliner.Page.Components
{
    public class Menu : BaseComponent
    {
        private static readonly By ShoppingCartButtonBy = By.ClassName("auth-bar__item--cart");
        private static readonly By EntranceButtonBy = By.ClassName("auth-bar__item--text");
        private static readonly By MainSearchFieldBy = By.ClassName("fast-search__input");
        private static readonly By SearchedItemNameTextBy = By.ClassName("product__title-link");
        private static readonly By SearchFieldFrameBy = By.ClassName("modal-iframe");

        protected override void WaitForComponentOpened()
        {
            Waiter.WaitForDisplayed(ShoppingCartButtonBy);
        }

        public void OpenShoppingCartPage()
        {
            WaitForComponentOpened();
            driver.FindElement(ShoppingCartButtonBy).Click();
        }

        public void InputTextInSearchField(string text)
        {
            WaitForComponentOpened();
            driver.FindElement(MainSearchFieldBy).SendKeys(text);
        }

        public string GetNameOfSearchedItem()
        {
            driver.SwitchTo().Frame(driver.FindElement(SearchFieldFrameBy));
            Waiter.WaitForDisplayed(SearchedItemNameTextBy);
            return driver.FindElement(SearchedItemNameTextBy).Text.ToLower();
        }

        public void OpenLogInPage()
        {
            WaitForComponentOpened();
            driver.FindElement(EntranceButtonBy).Click();
        }
    }
}
