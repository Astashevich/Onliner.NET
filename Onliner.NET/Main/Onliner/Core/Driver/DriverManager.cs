using OpenQA.Selenium;
using System;

namespace Onliner.NET.Main.Onliner.Core.Driver
{
    public class DriverManager
    {
        [ThreadStatic]
        public static IWebDriver ThreadDriver;


        public static void StartDriver(BrowserType browserType)
        {
            ThreadDriver ??=  DriverFactory.GetDriver(browserType);
        }

        /***
         *  Remove the value in a copy of the current thread by this thread-local variable
         * @param driver of the local thread
         */
        public static void QuitDriver()
        {
            if (ThreadDriver != null)
            {
                ThreadDriver.Quit();
                ThreadDriver = null;
            }
        }
    }
}
