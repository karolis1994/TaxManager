using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxManager.API.Application.Commands;
using TaxManager.API.Application.Models;
using TaxManager.API.Application.Models.Core;
using TaxManager.API.Application.Queries;

namespace TaxManager.API.Controllers
{
    /// <summary>
    /// Municipality tax controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MunicipalityTaxController : BaseController
    {
        public MunicipalityTaxController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Retrieves municipality tax value
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<decimal?>> GetMunicipalityTax([FromQuery] GetMunicipalityTaxValueQuery query)
            => await this.ExecuteQuery(query);

        /// <summary>
        /// Creates a new municipality tax
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<IdentityResponse>> Create([FromBody] MunicipalityTaxView model)
            => await this.ExecuteCommand(new CreateMunicipalityTaxCommand(model));

        /// <summary>
        /// Updates an existing municipality tax
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<IdentityResponse>> Update([FromRoute] long id, [FromBody] MunicipalityTaxView model)
        {
            model.Id = id;

            return await this.ExecuteCommand(new UpdateMunicipalityTaxCommand(model));
        }
    }
}
