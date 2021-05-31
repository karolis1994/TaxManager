using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaxManager.API.Application.Models;
using TaxManager.API.Application.Queries;
using TaxManager.DataAccessLayer;
using Xunit;

namespace TestManager.API.IntergrationTests
{
    public class MunicipalityTaxControllerTests : IClassFixture<TestFixture>, IDisposable
    {
        private readonly HttpClient client;
        private readonly TestFixture fixture;

        public MunicipalityTaxControllerTests(TestFixture fixture)
        {
            this.client = fixture.Client;
            this.fixture = fixture;
        }

        private async Task RemoveMunicipalityTaxes()
        {
            using (var scope = this.fixture.TestServer.Host.Services.CreateScope())
            {
                using (var conntext = scope.ServiceProvider.GetRequiredService<TaxManagerContext>())
                {
                    string sql = "DELETE FROM TaxManager.MunicipalityTax WHERE MunicipalityName in ('Test', 'UpdateTest', 'RetrieveTest')";

                    await conntext.Database.ExecuteSqlCommandAsync(sql);
                }
            }
        } 

        [Fact]
        public async Task Get()
        {
            var model = new MunicipalityTaxView()
            {
                MunicipalityName = "RetrieveTest",
                Type = TaxManager.Domain.Taxes.TaxType.Yearly,
                ValidFrom = new DateTime(2020, 1, 1),
                ValidTo = new DateTime(2020, 12, 31),
                Value = 0.1M
            };
            _ = await client.CreateMunicipalityTax(model);
            var query = new GetMunicipalityTaxValueQuery()
            {
                MunicipalityName = "RetrieveTest",
                Date = new DateTime(2020, 2, 1)
            };

            var result = await client.GetMunicipalityTax(query);

            Assert.NotEqual(0, result);
            Assert.Equal(0.1M, result);
        }

        [Fact]
        public async Task Create()
        {
            var model = new MunicipalityTaxView()
            {
                MunicipalityName = "Test",
                Type = TaxManager.Domain.Taxes.TaxType.Yearly,
                ValidFrom = new DateTime(2020, 1, 1),
                ValidTo = new DateTime(2020, 12, 31),
                Value = 0.1M
            };

            var result = await client.CreateMunicipalityTax(model);

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Id);
        }

        [Fact]
        public async Task Update()
        {
            var model = new MunicipalityTaxView()
            {
                MunicipalityName = "UpdateTest",
                Type = TaxManager.Domain.Taxes.TaxType.Yearly,
                ValidFrom = new DateTime(2020, 1, 1),
                ValidTo = new DateTime(2020, 12, 31),
                Value = 0.1M
            };
            var createdResponse = await client.CreateMunicipalityTax(model);
            model.Id = createdResponse.Id;

            var result = await client.UpdateMunicipalityTax(model);

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Id);
        }

        public void Dispose()
        {
            RemoveMunicipalityTaxes().Wait();
        }
    }
}
