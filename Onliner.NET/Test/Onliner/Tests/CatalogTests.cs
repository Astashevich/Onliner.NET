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
            string itemName = GenericPages.MainPage.GetMenu().GetNameOfSearchedItem();

            Assert.True(EqualsUtil.EqualContains(itemName, Iphone), string.Format("Searched item name [%s] wasn't contain [%s]",
                    itemName, Iphone));
        }
    }
}
