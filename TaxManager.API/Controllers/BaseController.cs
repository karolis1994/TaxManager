using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxManager.API.Application.Models.Core;

namespace TaxManager.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<ActionResult> ExecuteCommand(IRequest<CommandResponse> command)
        {
            var result = await this.mediator.Send(command);
            var errors = result.Errors;
            errors.ForEach(e => this.ModelState.AddModelError(e.Key, e.Message));

            if (!this.ModelState.IsValid)
                return new BadRequestResult();

            if (result.IdentityResponse != null)
                return Ok(result.IdentityResponse);
            else
                return Ok();
        }

        protected async Task<ActionResult<T>> ExecuteQuery<T>(IRequest<T> query)
        {
            var result = await this.mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
