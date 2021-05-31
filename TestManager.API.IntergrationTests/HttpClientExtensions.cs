using System.Net.Http;
using System.Threading.Tasks;
using TaxManager.API.Application.Models;
using TaxManager.API.Application.Models.Core;
using TaxManager.API.Application.Queries;

namespace TestManager.API.IntergrationTests
{
    public static class HttpClientExtensions
    {
        public static async Task<decimal> GetMunicipalityTax(this HttpClient client, GetMunicipalityTaxValueQuery query)
        {
            var response = await client.GetAsync(Links.Get(query));
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<decimal>();
        }

        public static async Task<IdentityResponse> CreateMunicipalityTax(this HttpClient client, MunicipalityTaxView model)
        {
            var response = await client.PostAsJsonAsync(Links.Create, model);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IdentityResponse>();
        }

        public static async Task<IdentityResponse> UpdateMunicipalityTax(this HttpClient client, MunicipalityTaxView model)
        {
            var response = await client.PutAsJsonAsync(Links.Update(model.Id.Value), model);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IdentityResponse>();
        }
    }
}
