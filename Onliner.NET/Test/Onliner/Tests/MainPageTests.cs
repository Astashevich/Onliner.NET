using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;

namespace Onliner.NET.Test.Onliner.Tests
{
    public class MainPageTests: BaseTest
    {
        private const string AboutLink = "/about";
        private static readonly string AboutCompanyAssertion = "о сайте";

        [Test]
        public void OpenAboutPageFromFooterTest()
        {
            GenericPages.MainPage.GetFooter().ClickOnAboutCompanyLink();
            var actualPageMessage = GenericPages.AboutCompanyPage.GetAboutCompanyPageMessage();

            Assert.IsTrue(GenericPages.AboutCompanyPage.IsPageOpened(AboutLink), "About company page isn't opened");
            Assert.IsTrue(EqualsUtil.EqualContains(AboutCompanyAssertion, actualPageMessage), 
                $"The page message [{actualPageMessage}] don't contain [{AboutCompanyAssertion}]");
        }
    }
}
