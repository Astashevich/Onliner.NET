using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;

namespace Onliner.NET.Test.Onliner.Tests
{
    public class MainPageTests: BaseTest
    {
        private const string AboutLink = "/about";

        [Test]
        public void OpenAboutPageFromFooterTest()
        {
            GenericPages.MainPage.GetFooter().ClickOnAboutCompanyLink();
            string actualPageMessage = GenericPages.AboutCompanyPage.GetAboutCompanyPageMessage();

            Assert.True(GenericPages.AboutCompanyPage.IsPageOpened(AboutLink), "About company page isn't opened");
            Assert.True(EqualsUtil.EqualContains("о сайте", actualPageMessage), 
                string.Format("The page message [%s] don't contain [%s]", actualPageMessage, "о сайте"));
        }
    }
}
