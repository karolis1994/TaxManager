using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using TaxManager.Domain.Taxes;

namespace TaxManager.API.Application.Queries
{
    /// <summary>
    /// Query to retrieve tax value for a specified date
    /// </summary>
    public class GetMunicipalityTaxValueQuery : IRequest<decimal?>
    {
        /// <summary>
        /// Municipality name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string MunicipalityName { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }

    internal sealed class GetMunicipalityTaxValueQueryHandler : IRequestHandler<GetMunicipalityTaxValueQuery, decimal?>
    {
        private readonly IMunicipalityTaxRepository repository;

        public GetMunicipalityTaxValueQueryHandler(IMunicipalityTaxRepository repository)
        {
            this.repository = repository;
        }

        public async Task<decimal?> Handle(GetMunicipalityTaxValueQuery request, CancellationToken cancellationToken)
        {
            return await repository.FindTaxValueByDate(request.MunicipalityName, request.Date);
        }
    }
}
