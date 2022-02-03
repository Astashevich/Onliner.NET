using Onliner.NET.Main.Onliner.Core.Utils;
using OpenQA.Selenium;

namespace Onliner.NET.Main.Onliner.Page.Components
{
    public class Footer : BaseComponent
    {
        private static readonly By AboutCompanyLinkBy = By.XPath("//a[contains(., 'О компании')]");

        protected override void WaitForComponentOpened()
        {
            Waiter.WaitForDisplayed(AboutCompanyLinkBy);
        }

        public void ClickOnAboutCompanyLink()
        {
            WaitForComponentOpened();
            driver.FindElement(AboutCompanyLinkBy).Click();
        }
    }
}
