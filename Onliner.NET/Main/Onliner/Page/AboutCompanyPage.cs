using Onliner.NET.Main.Onliner.Core.Utils;
using OpenQA.Selenium;

namespace Onliner.NET.Main.Onliner.Page
{
    public class AboutCompanyPage : BasePage
    {
        private static readonly By PageMessageBy = By.XPath("//div[@class='news-header__title']/h1");

        protected override void WaitForPageOpened()
        {
            Waiter.WaitForDisplayed(PageMessageBy);
        }

        public bool IsPageOpened(string link) => driver.Url.Contains(link);

        public string GetAboutCompanyPageMessage()
        {
            WaitForPageOpened();
            return driver.FindElement(PageMessageBy).Text.ToLower();
        }
    }
}
