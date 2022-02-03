using NUnit.Framework;
using Onliner.NET.Main.Onliner.Core.Utils;
using Onliner.NET.Main.Onliner.Page;

namespace Onliner.NET.Test.Onliner.Tests
{
    public class LogInTests: BaseTest
    {
        private const string IncorectLogInWarningText = "укажите ник или e-mail";
        private const string IncorectPasswordWarningText = "укажите пароль";

        private const string Login = "vs2450439@gmail.com";
        private const string Password = "hqhTqwje872H";
        private const string LoginWithFewGaps = "  vs2450439@gmail.com   ";
        private const string Space = " ";
        private static readonly string _randomEmail = RandomSymbolUtil.GetRandomLogin();

        [TestCaseSource(nameof(TestData))]
        public void LogInWithIncorrectDataTest(string login, string password, string expectedMessage)
        {
            GenericPages.MainPage.GetMenu().OpenLogInPage();

            GenericPages.LogInPage.InputLogIn(login);
            GenericPages.LogInPage.InputPassword(password);
            GenericPages.LogInPage.ClickLogInFormButton();

            Assert.IsTrue(GenericPages.LogInPage.IsLogInPageDisplayed(), "Log-In page is not displayed after test");
            var actualLogInWarningText = GenericPages.LogInPage.GetInputFieldWarningText();
            Assert.AreEqual(actualLogInWarningText, expectedMessage, "The actual log-in " +
                    $"warning text [{actualLogInWarningText}] don't much expected warning text [{expectedMessage}]");
        }

        static object[] TestData =
        {
        new object[] { string.Empty, string.Empty, IncorectLogInWarningText },
        new object[] { Login, string.Empty, IncorectPasswordWarningText },
        new object[] { LoginWithFewGaps, Password, IncorectLogInWarningText },
        new object[] { _randomEmail, string.Empty, IncorectPasswordWarningText },
        new object[] { Space, Space, IncorectLogInWarningText }
        };
    }
}
