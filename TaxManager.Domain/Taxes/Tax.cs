using System;
using TaxManager.Domain.Core;

namespace TaxManager.Domain.Taxes
{
    /// <summary>
    /// Abstract tax class
    /// </summary>
    public abstract class Tax : Entity
    {
        protected Tax(TaxType type, DateTime validFrom, DateTime validTo, decimal taxValue)
        {
            Type = type;
            ValidFrom = validFrom;
            ValidTo = validTo;
            TaxValue = taxValue;
        }

        /// <summary>
        /// Tax type
        /// </summary>
        public TaxType Type { get; private set; }

        /// <summary>
        /// Tax is valid from
        /// </summary>
        public DateTime ValidFrom { get; private set; }

        /// <summary>
        /// Tax is valid to
        /// </summary>
        public DateTime ValidTo { get; private set; }
        
        /// <summary>
        /// Tax value
        /// </summary>
        public decimal TaxValue { get; private set; }

        /// <summary>
        /// Updates tax fields
        /// </summary>
        /// <param name="taxType"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <param name="taxValue"></param>
        protected void UpdateTaxFields(TaxType taxType, DateTime validFrom, DateTime validTo, decimal taxValue)
        {
            this.TaxValue = taxValue;
            this.Type = Type;
            this.ValidFrom = validFrom;
            this.ValidTo = validTo;
        }
    }
}
