using System.Collections.Generic;
using System.Linq;

namespace TaxManager.API.Application.Models.Core
{
    /// <summary>
    /// Generic command response
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// Constructor to use on unsuccessful command that resulted in some errors
        /// </summary>
        /// <param name="errors"></param>
        public CommandResponse(IEnumerable<AppError> errors)
        {
            this.Errors = errors.ToList();
        }

        /// <summary>
        /// Constructor to use on unsuccessful command that resulted in an error
        /// </summary>
        /// <param name="errors"></param>
        public CommandResponse(AppError error)
        {
            this.Errors = new List<AppError>() { error };
        }

        /// <summary>
        /// Constructor to use on successful command that modifies an entity
        /// </summary>
        /// <param name="id"></param>
        public CommandResponse(long id)
        {
            this.IdentityResponse = new IdentityResponse(id);
        }

        /// <summary>
        /// Identity response of the command
        /// </summary>
        public IdentityResponse IdentityResponse { get; }

        /// <summary>
        /// Errors that occured during command execution
        /// </summary>
        public List<AppError> Errors { get; } = new List<AppError>();

        /// <summary>
        /// Successful command response, used when the command does not modify an entity
        /// </summary>
        public static CommandResponse Success => new CommandResponse(Enumerable.Empty<AppError>());
    }
}
