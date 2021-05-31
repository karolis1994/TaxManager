using System;
using System.Threading.Tasks;
using TaxManager.Domain.Core;

namespace TaxManager.Domain.Taxes
{
    /// <summary>
    /// Municipality tax repository
    /// </summary>
    public interface IMunicipalityTaxRepository : IRepository<MunicipalityTax>
    {
        /// <summary>
        /// Finds municipality tax by supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MunicipalityTax> FindByIdAsync(long id);

        /// <summary>
        /// Finds the tax value by supplied date
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<decimal?> FindTaxValueByDate(string municipalityName, DateTime date);

        /// <summary>
        /// Inserts a new municipality tax
        /// </summary>
        /// <param name="tax"></param>
        MunicipalityTax Insert(MunicipalityTax tax);

        /// <summary>
        /// Updates an existing municipality tax
        /// </summary>
        /// <param name="tax"></param>
        MunicipalityTax Update(MunicipalityTax tax);

        /// <summary>
        /// Deletes an existing municipality tax
        /// </summary>
        /// <param name="tax"></param>
        void Delete(MunicipalityTax tax);

        /// <summary>
        /// Is there any municipality tax of the supplied type that intersects with the supplied validity dates
        /// if exceptId is supplied, it is excluded from the query
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <param name="type"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <param name="exceptId"></param>
        /// <returns></returns>
        Task<bool> AnyMunicipalityTaxIntersecting(string municipalityName, TaxType type, DateTime validFrom, DateTime validTo, long? exceptId = null);
    }
}
