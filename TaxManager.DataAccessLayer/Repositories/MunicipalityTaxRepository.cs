using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaxManager.Domain.Core;
using TaxManager.Domain.Taxes;

namespace TaxManager.DataAccessLayer.Repositories
{
    public class MunicipalityTaxRepository : IMunicipalityTaxRepository
    {
        private readonly TaxManagerContext context;

        public MunicipalityTaxRepository(TaxManagerContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public void Delete(MunicipalityTax tax)
        {
            context.Remove(tax);
        }

        public async Task<MunicipalityTax> FindByIdAsync(long id)
        {
            return await this.context.MunicipalityTaxes
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal?> FindTaxValueByDate(string municipalityName, DateTime date)
        {
            return await this.context.MunicipalityTaxes
                .Where(e => e.MunicipalityName == municipalityName)
                .Where(e => e.ValidFrom <= date && date <= e.ValidTo)
                .OrderByDescending(e => e.Type)
                .Select(e => (decimal?)e.TaxValue)
                .FirstOrDefaultAsync();
        }

        public MunicipalityTax Insert(MunicipalityTax tax)
        {
            return this.context.Add(tax).Entity;
        }

        public async Task<bool> AnyMunicipalityTaxIntersecting(string municipalityName, TaxType type, DateTime validFrom, DateTime validTo, long? exceptId = null)
        {
            var query = this.context.MunicipalityTaxes
                .Where(e => e.MunicipalityName == municipalityName)
                .Where(e => e.Type == type)
                .Where(e => e.ValidFrom <= validTo && validFrom <= e.ValidTo);

            if (exceptId.HasValue)
                query = query.Where(e => e.Id != exceptId);

            return await query.AnyAsync();

        }

        public MunicipalityTax Update(MunicipalityTax tax)
        {
            return this.context.Update(tax).Entity;
        }
    }
}
