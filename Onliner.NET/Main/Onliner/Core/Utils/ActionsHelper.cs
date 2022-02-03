using Onliner.NET.Main.Onliner.Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Onliner.NET.Main.Onliner.Core.Utils
{
    public class ActionsHelper
    {
        private static readonly Actions Action = new Actions(DriverManager.ThreadDriver);

        public static void MoveToElementAndClick(IWebElement webElement)
        {
            Action.MoveToElement(webElement).Build().Perform();
            Waiter.Sleep(0.2);
            Action.Click(webElement).Build().Perform();
        }
    }
}
