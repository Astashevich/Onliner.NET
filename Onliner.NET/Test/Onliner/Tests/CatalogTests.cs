using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;

namespace Onliner.NET.Test.Onliner.Tests
{
    public class CatalogTests: BaseTest
    {
        private const string Iphone = "iphone 13";

        [Test]
        public void FindItemBySearcherTest()
        {
            GenericPages.MainPage.GetMenu().InputTextInSearchField(Iphone);
            var itemName = GenericPages.MainPage.GetMenu().GetNameOfSearchedItem();

            Assert.IsTrue(EqualsUtil.EqualContains(itemName, Iphone), $"Searched item name [{itemName}] wasn't contain [{Iphone}]");
        }
    }
}
