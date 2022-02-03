using Onliner.NET.Main.Onliner.Core.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.NET.Main.Onliner.Page
{
    public class LogInPage : BasePage
    {
        private static readonly By LogInInputBy = By.XPath("//input[@placeholder='Ник или e-mail']");
        private static readonly By PasswordInputBy = By.XPath("//input[@type='password']");
        private static readonly By LoginFormButtonBy = By.XPath("//button[contains(@class, 'auth-form__button')]");
        private static readonly By InputFieldWarningTextBy = By.XPath("//div[contains(@class, 'auth-form__description_extended-other')]");

        protected override void WaitForPageOpened()
        {
            Waiter.WaitForDisplayed(LoginFormButtonBy);
        }

        public void InputLogIn(string text)
        {
            WaitForPageOpened();
            driver.FindElement(LogInInputBy).SendKeys(text);
        }

        public void InputPassword(string text)
        {
            WaitForPageOpened();
            driver.FindElement(PasswordInputBy).SendKeys(text);
        }

        public void ClickLogInFormButton()
        {
            WaitForPageOpened();
            driver.FindElement(LoginFormButtonBy).Click();
        }

        public bool IsLogInPageDisplayed()
        {
            try
            {
                Waiter.Sleep(1);
                return driver.FindElement(LoginFormButtonBy).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TimeoutException e)
            {
                return false;
            }
        }

        public String GetInputFieldWarningText()
        {
            Waiter.WaitForDisplayed(InputFieldWarningTextBy);
            return driver.FindElement(InputFieldWarningTextBy).Text.ToLower().Trim();
        }
    }
}
