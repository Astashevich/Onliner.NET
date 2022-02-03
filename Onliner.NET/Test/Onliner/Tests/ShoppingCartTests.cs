using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;

namespace Onliner.NET.Test.Onliner.Tests
{
    public class ShoppingCartTests: BaseTest
    {
        [Test]
        public void AddItemToShoppingCartTest()
        {
            GenericPages.MainPage.OpenCatalogRandomItem();

            string itemNameFromCatalog = GenericPages.CatalogItemPage.GetItemName();
            GenericPages.CatalogItemPage.AddToCart();
            GenericPages.MainPage.GetMenu().OpenShoppingCartPage();

            string itemNameFromCart = GenericPages.ShoppingCartPage.GetItemNameText();
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
            string removedItemMessage = GenericPages.ShoppingCartPage.GetRemovedItemInformation();
            string emptyCartMassage = GenericPages.ShoppingCartPage.GetEmptyCartMassage();

            Assert.True(EqualsUtil.EqualContains(removedItemMessage, "Вы удалили"), string.Format("The message [%s]" +
                    " wasn't contains at expected removed message [%s]", removedItemMessage, "Вы удалили"));
            Assert.True(EqualsUtil.EqualContains(emptyCartMassage, "Ваша корзина пуста"), string.Format("The message " +
                    "[%s] wasn't contains at expected empty cart message [%s]", emptyCartMassage, "Ваша корзина пуста"));
        }

        [Test]
        public void AddOneMoreSameItemInCartByTest()
        {
            GenericPages.MainPage.OpenCatalogRandomItem();
            GenericPages.CatalogItemPage.AddToCart();
            GenericPages.MainPage.GetMenu().OpenShoppingCartPage();

            double itemPrice = GenericPages.ShoppingCartPage.GetPrice();
            GenericPages.ShoppingCartPage.ClickQuantityInputPlusButton();
            int numberFromQuantityInput = GenericPages.ShoppingCartPage.GetNumberFromQuantityInput();
            double itemPriceAfterAddingItem = GenericPages.ShoppingCartPage.GetPrice();

            Assert.AreEqual(numberFromQuantityInput, 2, string.Format("The number [%d] from quantity input don't" +
                    " match [2]", numberFromQuantityInput));
            Assert.AreEqual(itemPriceAfterAddingItem, itemPrice * 2, string.Format("The price [%f] after " +
                    "adding the same item was match first price [%f]", itemPriceAfterAddingItem, itemPrice));
        }
    }
}
