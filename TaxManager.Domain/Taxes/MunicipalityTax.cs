using System;
using TaxManager.Domain.Core;

namespace TaxManager.Domain.Taxes
{
    /// <summary>
    /// Municipality tax
    /// </summary>
    public sealed class MunicipalityTax : Tax, IAggregateRoot
    {
        public MunicipalityTax(TaxType type, DateTime validFrom, DateTime validTo, decimal taxValue, string municipalityName) : base(type, validFrom, validTo, taxValue)
        {
            this.MunicipalityName = municipalityName;
        }

        /// <summary>
        /// Municipality name
        /// </summary>
        public string MunicipalityName { get; private set; }

        /// <summary>
        /// Updates municipality tax fields
        /// </summary>
        /// <param name="taxType"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <param name="taxValue"></param>
        /// <param name="municipalityName"></param>
        public void UpdateMunicipalityTaxFields(TaxType taxType, DateTime validFrom, DateTime validTo, decimal taxValue, string municipalityName)
        {
            this.UpdateTaxFields(taxType, validFrom, validTo, taxValue);
            this.MunicipalityName = municipalityName;
        }
    }
}
