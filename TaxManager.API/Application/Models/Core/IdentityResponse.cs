namespace TaxManager.API.Application.Models.Core
{
    /// <summary>
    /// Identity response model, used to store the identity of an entity
    /// </summary>
    public class IdentityResponse
    {
        public IdentityResponse(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Identifier of an entity
        /// </summary>
        public long Id { get; }
    }
}
