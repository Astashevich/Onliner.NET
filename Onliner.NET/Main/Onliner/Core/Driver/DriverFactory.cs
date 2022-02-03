using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace Onliner.NET.Main.Onliner.Core.Driver
{
    public class DriverFactory
    {

        /***
        * Chooses a webdriver of a defined type
        * @param browser type
        */
        public static IWebDriver GetDriver(BrowserType browser)
        {
            return browser switch
            {
                BrowserType.FIREFOX => GetFirefoxDriver(),
                BrowserType.EDGE => GetEdgeDriver(),
                BrowserType.OPERA => GetOperaDriver(),
                _ => GetChromeDriver()
            };
        }

        /***
        * Chrome webdriver settings
        * @return chrome webdriver
        */
        public static FirefoxDriver GetFirefoxDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("disable-gpu", "--start-maximized");
            return new FirefoxDriver(firefoxOptions);
        }

        /**
        * Firefox webdriver settings
        * @return firefox webdriver
        */
        public static ChromeDriver GetChromeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("disable-gpu", "--start-maximized");
            return new ChromeDriver(chromeOptions);
        }

        /***
        * Edge webdriver settings
        * @return edge webdriver
        */
        public static EdgeDriver GetEdgeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments("disable-gpu", "--start-maximized");
            return new EdgeDriver(edgeOptions);
        }

        /***
        * Opera webdriver settings
        * @return opera webdriver
        */
        public static OperaDriver GetOperaDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new OperaConfig());
            OperaOptions operaOptions = new OperaOptions();
            operaOptions.AddArguments("disable-gpu", "--start-maximized");
            return new OperaDriver(operaOptions);
        }
    }
}
