using Onliner.NET.Main.Onliner.Core.Driver;
using Onliner.NET.Main.Onliner.Core.Utils;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace Onliner.NET.Main.Onliner.Page
{
    public class ShoppingCartPage : BasePage
    {
        private const string PriceRegexPattern = "^[0-9]+.[0-9]+";

        private static readonly By openedShoppingCartMessageBy = By.XPath("//div[contains(@class, 'cart-form__title')]");
        private static readonly By removeFromCartButtonBy = By.ClassName("cart-form__control");
        private static readonly By removedItemInformationBy = By.XPath("//div[contains(@class, 'cart-form__description_condensed-extra')]");
        private static readonly By emptyCartMessageBy = By.XPath("//div[contains(@class, 'cart-message__title_big')]");
        private static readonly By itemNameTextBy = By.CssSelector(".cart-form__description_condensed-other .cart-form__link_base-alter");
        private static readonly By completeOrderButtonBy =By.XPath("//a[contains(@class, 'cart-form__button') and text()]");
        private static readonly By quantityInputPlusButtonBy =By.XPath("//a[contains(@class, 'cart-form__button_increment')]");
        private static readonly By quantityInputBy =By.XPath("//input[contains(@class, 'cart-form__input_nonadaptive')]");
        private static readonly By itemPriceTextBy =By.XPath("//div[contains(@class, 'helpers_hide_tablet')]/div[contains(@class, 'cart-form__description_condensed-another')]/span");

        protected override void WaitForPageOpened()
        {
            Waiter.ElementToBeClickable(openedShoppingCartMessageBy);
        }

        public void RemoveItemFromCart()
        {
            Waiter.WaitForDisplayed(removeFromCartButtonBy);
            ActionsHelper.MoveToElementAndClick(driver.FindElement(removeFromCartButtonBy));
        }

        public string GetRemovedItemInformation()
        {
            Waiter.WaitForDisplayed(removedItemInformationBy);
            return driver.FindElement(removedItemInformationBy).Text;
        }

        public string GetEmptyCartMassage()
        {
            DriverManager.ThreadDriver.Navigate().Refresh();
            Waiter.WaitForDisplayed(emptyCartMessageBy);
            return driver.FindElement(emptyCartMessageBy).Text;
        }

        public string GetItemNameText()
        {
            Waiter.WaitForDisplayed(itemNameTextBy);
            return driver.FindElement(itemNameTextBy).Text.Trim();
        }

        public bool IsCompleteOrderButtonVisible()
        {
            return driver.FindElement(completeOrderButtonBy).Displayed;
        }

        public void ClickQuantityInputPlusButton()
        {
            Waiter.WaitForDisplayed(quantityInputPlusButtonBy);
            driver.FindElement(quantityInputPlusButtonBy).Click();
            Waiter.WaitForElementToBeChanged(driver.FindElement(itemPriceTextBy));
        }

        public int GetNumberFromQuantityInput()
        {
            Waiter.WaitForDisplayed(quantityInputBy);
            string quantityInputAttribute = driver.FindElement(quantityInputBy).GetAttribute("value");
            return int.Parse(quantityInputAttribute);
        }

        public double GetPrice()
        {
            Waiter.WaitForDisplayed(itemPriceTextBy);
            Regex regex = new Regex(PriceRegexPattern);
            Match match = regex.Match(driver.FindElement(itemPriceTextBy).Text.Replace(",", "."));
            return double.Parse(match.Value);
        }
    }
}
