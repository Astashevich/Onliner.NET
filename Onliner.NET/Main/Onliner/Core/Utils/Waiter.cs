using Onliner.NET.Main.Onliner.Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace Onliner.NET.Main.Onliner.Core.Utils
{
    public class Waiter
    {
        private const double Timeout = 3.00;
        private const int Polling = 200;
        private const long OneThousand = 1000L;

        private static readonly WebDriverWait wait = new WebDriverWait(DriverManager.ThreadDriver, TimeSpan.FromSeconds(Timeout))
        {
            PollingInterval = TimeSpan.FromMilliseconds(Polling)
        };

        private static WebDriverWait WaitSetUp()
        {
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException));
            return wait;
        }

        public static void ElementToBeClickable(By locator)
        {
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException));
            wait.Until(driver => driver.FindElement(locator).Displayed && driver.FindElement(locator).Enabled);
        }

        public static void WaitForDisplayed(By locator, double timeouSec = Timeout)
        {
            wait.Timeout = TimeSpan.FromSeconds(timeouSec);
            wait.PollingInterval = TimeSpan.FromMilliseconds(Polling);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException));
            wait.Until(e => DriverManager.ThreadDriver.FindElements(locator).Count > 0);
        }

        public static void Sleep(double timeoutSec)
        {
                Thread.Sleep((int)(timeoutSec * OneThousand));
        }

        public static void WaitForElementToBeChanged(IWebElement element)
        {
            string elementText = element.Text;
            WaitSetUp().Until(e => !Equals(elementText, element.Text));
        }
    }
}