using System;
using System.ComponentModel.DataAnnotations;
using TaxManager.Domain.Taxes;

namespace TaxManager.API.Application.Models
{
    /// <summary>
    /// Municipality view model
    /// </summary>
    public class MunicipalityTaxView
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Name of the municipality to which the tax applies
        /// </summary>
        [Required]
        [StringLength(100)]
        public string MunicipalityName { get; set; }

        /// <summary>
        /// Valid from date
        /// </summary>
        [Required]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Valid to date
        /// </summary>
        [Required]
        public DateTime ValidTo { get; set; }

        /// <summary>
        /// Type of municipality tax
        /// </summary>
        [Required]
        [EnumDataType(typeof(TaxType))]
        public TaxType Type { get; set; }

        /// <summary>
        /// The value of tax
        /// </summary>
        [Required]
        public decimal Value { get; set; }
    }
}
