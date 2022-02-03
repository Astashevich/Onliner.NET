using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Driver;
using Onliner.NET.Main.Onliner.Page;
using OpenQA.Selenium;

namespace Onliner.NET.Test.Onliner
{
    public abstract class BaseTest
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            DriverManager.StartDriver(BrowserType.CHROME);

            GenericPages.MainPage.OpenPage();
        } 

        [TearDown]
        public void OneTimeTearDown() => DriverManager.QuitDriver();
    }
}
