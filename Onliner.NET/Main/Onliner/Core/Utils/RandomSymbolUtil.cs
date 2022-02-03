using Bogus;

namespace Onliner.NET.Main.Onliner.Core.Utils
{
    public class RandomSymbolUtil
    {
        private static Faker faker = new();

        public static string GetRandomLogin()
        {
            return new Faker().Internet.Email();
        }
    }
}
