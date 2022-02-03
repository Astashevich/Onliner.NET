using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;

namespace Onliner.NET.Test.Onliner.Tests
{
    public class ShoppingCartTests: BaseTest
    {
        private const string ShoppingCartMessageAfterDelete = "Вы удалили";
        private const string EmptyShoppingCartMessage = "Ваша корзина пуста";

        [Test]
        public void AddItemToShoppingCartTest()
        {
            GenericPages.MainPage.OpenCatalogRandomItem();

            var itemNameFromCatalog = GenericPages.CatalogItemPage.GetItemName();
            GenericPages.CatalogItemPage.AddToCart();
            GenericPages.MainPage.GetMenu().OpenShoppingCartPage();

            var itemNameFromCart = GenericPages.ShoppingCartPage.GetItemNameText();
            Assert.AreEqual(itemNameFromCatalog, itemNameFromCart, string.Format("Item name [%s] don't match " +
                    "item name [%s] from shopping cart", itemNameFromCatalog, itemNameFromCart));
            Assert.True(GenericPages.ShoppingCartPage.IsCompleteOrderButtonVisible(), "[Перейти к оформлению] button isn't visible");
        }

        [Test]
        public void RemoveItemFromShoppingCartTest()
        {
            GenericPages.MainPage.OpenCatalogRandomItem();
            GenericPages.CatalogItemPage.AddToCart();
            GenericPages.MainPage.GetMenu().OpenShoppingCartPage();

            GenericPages.ShoppingCartPage.RemoveItemFromCart();
            var removedItemMessage = GenericPages.ShoppingCartPage.GetRemovedItemInformation();
            var emptyCartMassage = GenericPages.ShoppingCartPage.GetEmptyCartMassage();

            Assert.True(EqualsUtil.EqualContains(removedItemMessage, ShoppingCartMessageAfterDelete), $"The message [{removedItemMessage}]" +
                    $" wasn't contains at expected removed message [{ShoppingCartMessageAfterDelete}]");
            Assert.True(EqualsUtil.EqualContains(emptyCartMassage, EmptyShoppingCartMessage), $"The message " +
                    $"[{emptyCartMassage}] wasn't contains at expected empty cart message [{EmptyShoppingCartMessage}]");
        }

        [Test]
        public void AddOneMoreSameItemInCartByTest()
        {
            GenericPages.MainPage.OpenCatalogRandomItem();
            GenericPages.CatalogItemPage.AddToCart();
            GenericPages.MainPage.GetMenu().OpenShoppingCartPage();

            var itemPrice = GenericPages.ShoppingCartPage.GetPrice();
            GenericPages.ShoppingCartPage.ClickQuantityInputPlusButton();
            var numberFromQuantityInput = GenericPages.ShoppingCartPage.GetNumberFromQuantityInput();
            var itemPriceAfterAddingItem = GenericPages.ShoppingCartPage.GetPrice();

            Assert.AreEqual(numberFromQuantityInput, 2, $"The number [{numberFromQuantityInput}] from quantity input don't match [2]");
            Assert.AreEqual(itemPriceAfterAddingItem, itemPrice * 2, $"The price [{itemPriceAfterAddingItem}] after " +
                    $"adding the same item was match first price [{itemPrice}]");
        }
    }
}
