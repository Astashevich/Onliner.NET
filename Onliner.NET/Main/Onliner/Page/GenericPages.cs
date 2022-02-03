using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.NET.Main.Onliner.Page
{
    internal static class GenericPages
    {
        public static MainPage MainPage => new();
        public static CatalogItemPage CatalogItemPage => new();
        public static ShoppingCartPage ShoppingCartPage => new();
        public static AboutCompanyPage AboutCompanyPage => new();
        public static LogInPage LogInPage => new();
    }
}
