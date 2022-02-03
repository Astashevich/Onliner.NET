using Onliner.NET.Main.Onliner.Core.Driver;
using OpenQA.Selenium;

namespace Onliner.NET.Main.Onliner.Page
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage()
        {
            driver = DriverManager.ThreadDriver;
        }

        protected abstract void WaitForPageOpened();
    }
}
