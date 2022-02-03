using Onliner.NET.Main.Onliner.Core.Driver;
using OpenQA.Selenium;

namespace Onliner.NET.Main.Onliner.Page.Components
{
    public abstract class BaseComponent
    {
        protected IWebDriver driver;

        public BaseComponent()
        {
            driver = DriverManager.ThreadDriver;
        }

        protected abstract void WaitForComponentOpened();
    }
}
