using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page.Components;
using OpenQA.Selenium;
using System;

namespace Onliner.NET.Main.Onliner.Page
{
    public class MainPage : BasePage
    {
        private const string Host = "https://www.onliner.by/";
        private const int MaxListSizeOnPAge = 7;
        private readonly Menu menu;
        private readonly Footer footer;

        private static readonly By CatalogItems = By.ClassName("catalog-offers__image");

        public MainPage()
        {
            menu = new Menu();
            footer = new Footer();
        }

        protected override void WaitForPageOpened()
        {
            Waiter.WaitForDisplayed(CatalogItems);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Host);
            WaitForPageOpened();
        }

        public Menu GetMenu()
        {
            return menu;
        }

        public Footer GetFooter()
        {
            return footer;
        }

        public void OpenCatalogRandomItem()
        {
            WaitForPageOpened();
            driver.FindElements(CatalogItems)[new Random().Next(MaxListSizeOnPAge)].Click();
        }
    }
}
