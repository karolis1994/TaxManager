using TaxManager.API.Application.Queries;

namespace TestManager.API.IntergrationTests
{
    public static class Links
    {
        private static readonly string root = "MunicipalityTax";
        public static string Get(GetMunicipalityTaxValueQuery query) => $"{root}?{TestMethods.GetQueryString(query)}";
        public static string Create => root;
        public static string Update(long id) => $"{root}/{id}";
    }
}
