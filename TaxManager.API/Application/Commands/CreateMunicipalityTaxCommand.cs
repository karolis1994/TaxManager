using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaxManager.API.Application.Models;
using TaxManager.API.Application.Models.Core;
using TaxManager.Domain.Taxes;

namespace TaxManager.API.Application.Commands
{
    /// <summary>
    /// Command to create a new municipality tax
    /// </summary>
    public class CreateMunicipalityTaxCommand : IRequest<CommandResponse>
    {
        public CreateMunicipalityTaxCommand(MunicipalityTaxView model)
        {
            Model = model;
        }

        /// <summary>
        /// Municipality tax view
        /// </summary>
        public MunicipalityTaxView Model { get; }
    }

    internal sealed class CreateMunicipalityTaxCommandHandler : IRequestHandler<CreateMunicipalityTaxCommand, CommandResponse>
    {
        private readonly IMunicipalityTaxRepository repository;

        public CreateMunicipalityTaxCommandHandler(IMunicipalityTaxRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CommandResponse> Handle(CreateMunicipalityTaxCommand request, CancellationToken cancellationToken)
        {
            var v = request.Model;

            if (await repository.AnyMunicipalityTaxIntersecting(v.MunicipalityName, v.Type, v.ValidFrom, v.ValidTo))
                return new CommandResponse(new AppError(nameof(TaxResources.TaxRangeIntersecting), TaxResources.TaxRangeIntersecting));

            var municipalityTax = new MunicipalityTax(v.Type, v.ValidFrom, v.ValidTo, v.Value, v.MunicipalityName);

            repository.Insert(municipalityTax);
            await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new CommandResponse(municipalityTax.Id);
        }
    }
}
