using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaxManager.API.Application.Models;
using TaxManager.API.Application.Models.Core;
using TaxManager.Domain.Taxes;

namespace TaxManager.API.Application.Commands
{
    /// <summary>
    /// Command to update municipality tax
    /// </summary>
    public class UpdateMunicipalityTaxCommand : IRequest<CommandResponse>
    {
        public UpdateMunicipalityTaxCommand(MunicipalityTaxView model)
        {
            Model = model;
        }

        /// <summary>
        /// Municipality tax view
        /// </summary>
        public MunicipalityTaxView Model { get; }
    }

    internal sealed class UpdateMunicipalityTaxCommandHandler : IRequestHandler<UpdateMunicipalityTaxCommand, CommandResponse>
    {
        private readonly IMunicipalityTaxRepository repository;

        public UpdateMunicipalityTaxCommandHandler(IMunicipalityTaxRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CommandResponse> Handle(UpdateMunicipalityTaxCommand request, CancellationToken cancellationToken)
        {
            var v = request.Model;
            MunicipalityTax municipalityTax = null;

            if (v.Id.HasValue)
                municipalityTax = await repository.FindByIdAsync(v.Id.Value);

            if (municipalityTax == null)
                return new CommandResponse(new AppError(nameof(TaxResources.TaxNotExisting), TaxResources.TaxNotExisting));
            if (await repository.AnyMunicipalityTaxIntersecting(v.MunicipalityName, v.Type, v.ValidFrom, v.ValidTo, municipalityTax.Id))
                return new CommandResponse(new AppError(nameof(TaxResources.TaxRangeIntersecting), TaxResources.TaxRangeIntersecting));

            municipalityTax.UpdateMunicipalityTaxFields(v.Type, v.ValidFrom, v.ValidTo, v.Value, v.MunicipalityName);

            repository.Update(municipalityTax);
            await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new CommandResponse(municipalityTax.Id);
        }
    }
}
